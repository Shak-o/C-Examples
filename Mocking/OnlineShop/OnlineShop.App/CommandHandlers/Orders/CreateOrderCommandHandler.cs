using AutoMapper;
using MediatR;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Domain.SalesOrderHeaders.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Orders;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IMapper _mapper;
    private readonly IRepository<SalesOrderHeader> _repository;
    private readonly IOrdersRepository _customRepository;
    
    public CreateOrderCommandHandler(IRepository<SalesOrderHeader> repository, IMapper mapper, IOrdersRepository customRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _customRepository = customRepository;
    }

    public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var convert = _mapper.Map<SalesOrderHeader>(request.Order);
            
            var result = await _customRepository
                .DoSomeCalculation(Calculation(convert.SubTotal))
                .ConfigureAwait(false);
            convert.Freight = result;
            
            await _repository.AddAsync(convert, cancellationToken);
            return Unit.Value;
        }
        catch (ApplicationException appException)
        {
            // some special logic for app exception
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public decimal Calculation(decimal total)
    {
        var result = 100 - total;
        return result;
    }
}