using UserManager.Application.ViewModels;
using UserManager.Domain.Models;

namespace UserManager.Application.RepositoryInterfaces;

public interface IAccountRepository
{
    Task AddAccountAsync(Account account, CancellationToken cancellationToken);
    Task DeleteAccountAsync(int id, CancellationToken cancellationToken);
    Task<Account?> GetAccountAsync(string userName, AccountType accountType, CancellationToken cancellationToken);
    Task<Account?> GetAccountAsync(int accountId, CancellationToken cancellationToken);
    Task<Account?> GetActiveAccountAsync(string userName, CancellationToken cancellationToken);
    Task UpdateAccountAsync(Account account, CancellationToken cancellationToken);
    Task<bool> IsAdminAsync(int accountId, CancellationToken cancellationToken);
    Task<List<UserViewModel>> GetPagedAccountsAsync(int page, CancellationToken cancellationToken);
    Task UpdateAccount(Account account, CancellationToken cancellationToken);
    Task<bool> CheckUsernameAsync(string username, CancellationToken cancellationToken);
}