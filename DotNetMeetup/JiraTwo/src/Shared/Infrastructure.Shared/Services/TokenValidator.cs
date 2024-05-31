using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Shared.Services;

public class TokenValidator(IConfiguration configuration) : ITokenValidator
{
    public bool ValidateToken(string token, string application)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = configuration["SigningKeySecret"];

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "UserManager.Api",
            ValidAudience = application,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ClockSkew = TimeSpan.Zero  // Optional: reduce or remove clock skew tolerance
        };
        try
        {
            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

            // Token is valid, and you can use the principal object to access claims
            return true;
        }
        catch (SecurityTokenExpiredException)
        {
            return false;
        }
        catch (SecurityTokenValidationException)
        {
            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}