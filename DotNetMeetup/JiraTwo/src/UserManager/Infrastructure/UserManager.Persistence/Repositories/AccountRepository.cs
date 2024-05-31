using Microsoft.EntityFrameworkCore;
using UserManager.Application.RepositoryInterfaces;
using UserManager.Application.ViewModels;
using UserManager.Domain.Models;

namespace UserManager.Persistence.Repositories;

public class AccountRepository(UserManagerContext dbContext) : IAccountRepository
{
    private const int MaxCount = 20;

    public Task AddAccountAsync(Account account, CancellationToken cancellationToken)
    {
        dbContext.Accounts.Add(account);
        return dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAccountAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Accounts.FirstAsync(x => x.Id == id, cancellationToken);
        dbContext.Accounts.Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<Account?> GetAccountAsync(string userName, AccountType accountType, CancellationToken cancellationToken)
    {
        return dbContext.Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Username == userName && x.AccountType == accountType, cancellationToken);
    }

    public Task<Account?> GetAccountAsync(int accountId, CancellationToken cancellationToken)
    {
        return dbContext.Accounts
            .AsNoTracking()
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == accountId, cancellationToken);
    }

    public Task<Account?> GetActiveAccountAsync(string userName, CancellationToken cancellationToken)
    {
        return dbContext.Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Username == userName && x.Status == AccountStatus.Active, cancellationToken);
    }

    public Task UpdateAccountAsync(Account account, CancellationToken cancellationToken)
    {
        dbContext.Accounts.Update(account);
        return dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> IsAdminAsync(int accountId, CancellationToken cancellationToken)
    {
        return dbContext.Accounts.AnyAsync(x => x.Id == accountId && x.AccountType == AccountType.Admin,
            cancellationToken);
    }

    public Task<List<UserViewModel>> GetPagedAccountsAsync(int page, CancellationToken cancellationToken)
    {
        var nextPage = page + 1;
        return dbContext.Accounts
            .AsNoTracking()
            .Skip(page * MaxCount)
            .Take(nextPage * MaxCount)
            .Select(x => new UserViewModel
            {
                Username = x.Username,
                Name = x.User!.Name,
                SurName = x.User!.SurName,
                Email = x.User!.Email,
                ValidTill = x.ValidTill,
                UserId = x.UserId,
                AccountId = x.Id,
                Status = x.Status,
                AccountType = x.AccountType
            })
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateAccount(Account account, CancellationToken cancellationToken)
    {
        dbContext.Accounts.Update(account);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<bool> CheckUsernameAsync(string username, CancellationToken cancellationToken)
    {
        return dbContext.Accounts.AnyAsync(x => x.Username == username, cancellationToken);
    }
}