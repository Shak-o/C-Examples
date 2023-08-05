using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public Task<List<string>> GetRestrictedCompaniesAsync()
        {
            return Task.FromResult(new List<string>() {"CompanyA", "CompanyB"});
        }
    }
}
