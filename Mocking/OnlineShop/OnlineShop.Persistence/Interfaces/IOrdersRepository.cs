using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Domain.SalesOrderHeaders.Queries;

namespace OnlineShop.Persistence.Interfaces;

public interface IOrdersRepository : IRepository<SalesOrderHeader>
{
    Task<List<OrderListQueryResult>> GetSalesAsync(int page, int count);
    Task<OrderQueryResult> GetOrderAsync(int id);
    Task<decimal> DoSomeCalculation(decimal someNumber);
}