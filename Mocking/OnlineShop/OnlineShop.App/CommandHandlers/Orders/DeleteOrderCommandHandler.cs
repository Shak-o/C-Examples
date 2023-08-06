using MediatR;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Domain.SalesOrderHeaders.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Orders;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IRepository<SalesOrderHeader> _repository;

    public DeleteOrderCommandHandler(IRepository<SalesOrderHeader> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var toDelete = await _repository.GetFirstAsync(x => x.Id == request.Id, cancellationToken);
        await _repository.DeleteAsync(toDelete, cancellationToken);
        
        var recheck = await _repository.GetFirstAsync(x => x.Id == request.Id, cancellationToken);
        
        if (recheck != null)
            throw new ApplicationException("I know this is dumb.");
        
        return Unit.Value;
    }
}