using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UserManager.Application.Helpers;
using UserManager.Application.RepositoryInterfaces;
using UserManager.Domain.Models;
using ApplicationException = Presentation.Shared.Exceptions.ApplicationException;

namespace UserManager.Application.Commands.AuthCommands;

public class AuthenticateUsernamePassRequestHandler : IRequestHandler<AuthenticateUsernamePassRequest, string>
{
    private readonly IAccountRepository _accountsRepository;
    private readonly IAuthCountsRepository _authCountsRepository;
    private readonly IAuthSessionRepository _authSessionRepository;
    private readonly IConfiguration _configuration;
    
    public AuthenticateUsernamePassRequestHandler(
        IAuthCountsRepository authCountsRepository, 
        IAuthSessionRepository authSessionRepository, IAccountRepository accountRepository, IConfiguration configuration)
    {
        _authCountsRepository = authCountsRepository;
        _authSessionRepository = authSessionRepository;
        _accountsRepository = accountRepository;
        _configuration = configuration;
    }
    public async Task<string> Handle(AuthenticateUsernamePassRequest request, CancellationToken cancellationToken)
    {
        var account = await GetAccountAsync(request, cancellationToken);
        var key = _configuration["SigningKeySecret"];
        var sessionId = await _authSessionRepository.InitializeSessionAsync(account.Id);
        
        await ValidatePasswordAsync(request, account, sessionId, cancellationToken);

        return GetToken(account, key);
    }

    private static string GetToken(Account account, string key)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        // Define the signing credentials using the security key
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Prepare the claims (e.g., username, role)
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString())
        };

        var audience = account.AccountType == AccountType.Admin ? "UserManager.Admin" : "TaskManager.Client";
        // Create the JWT token
        var token = new JwtSecurityToken(
            issuer: "UserManager.Api",
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30), // Set token expiration time
            signingCredentials: credentials
        );

        // Return the token string
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task ValidatePasswordAsync(AuthenticateUsernamePassRequest request, Account account, int sessionId,
        CancellationToken cancellationToken)
    {
        var hashedPassword = PasswordHelper.HashPassword(request.Password, account.Salt);
        if (hashedPassword != account.PasswordHash)
        {
            var countStatus = await _authCountsRepository.UpsertCountAsync(account.Id, sessionId, cancellationToken);
            if (countStatus == AuthCountStatus.Failed)
            {
                account.Status = AccountStatus.TempBlocked;
                await _accountsRepository.UpdateAccountAsync(account, cancellationToken);
            } 
            throw new ApplicationException("InvalidCredentials", "User with those credentials not found");
        }
    }

    private async Task<Account> GetAccountAsync(AuthenticateUsernamePassRequest request, CancellationToken cancellationToken)
    {
        var account = await _accountsRepository.GetAccountAsync(request.UserName, request.AccountType, cancellationToken);

        if (account == null)
            throw new ApplicationException("InvalidCredentials", "User with those credentials not found");
        return account;
    }
}