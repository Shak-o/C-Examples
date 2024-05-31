using MediatR;
using UserManager.Application.Helpers;
using UserManager.Application.RepositoryInterfaces;
using UserManager.Domain.Models;
using ApplicationException = Presentation.Shared.Exceptions.ApplicationException;

namespace UserManager.Application.Commands.AccountCommands;

public class CreateAccountHandler(IAccountRepository accountRepository, IMediator mediator) : IRequestHandler<CreateAccountRequest, int>
{
    public async Task<int> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
    {
        // if (request.AccountType == AccountType.Admin)
        // {
        //     var isAdmin = await accountRepository.IsAdminAsync(request.RequesterUserId, cancellationToken);
        //
        //     if (!isAdmin)
        //         throw new ApplicationException("InvalidRequest", "No sufficient rights");
        // }

        var usernameIsTaken = await mediator.Send(new CheckUsernameCommand() { Username = request.UserName }, cancellationToken: cancellationToken);

        if (usernameIsTaken)
            throw new ApplicationException("UsernameNotAvailable", "Username is taken");
        
        var salt = PasswordHelper.GenerateSalt(255);
        var passwordHash = PasswordHelper.HashPassword(request.Password, salt);
        var account = new Account
        {
            Username = request.UserName,
            PasswordHash = passwordHash,
            Salt = salt,
            ValidTill = DateTime.Now.AddDays(100),
            User = new User
            {
                Name = request.Name,
                Email = request.Email,
                SurName = request.LastName
            },
            AccountType = request.AccountType
        };
        
        await accountRepository.AddAccountAsync(account, cancellationToken);
        
        return account.Id;
    }
}