namespace Infrastructure.Shared.Services;

public interface ITokenValidator
{
    bool ValidateToken(string token, string application);
}