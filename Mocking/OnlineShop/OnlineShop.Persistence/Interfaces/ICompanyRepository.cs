namespace OnlineShop.Persistence.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<string>> GetRestrictedCompaniesAsync();
    }
}
