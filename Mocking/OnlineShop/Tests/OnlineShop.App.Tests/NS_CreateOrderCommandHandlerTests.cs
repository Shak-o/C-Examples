using AutoMapper;
using FluentAssertions;
using NSubstitute;
using OnlineShop.App.CommandHandlers.Orders;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Domain.SalesOrderHeaders.Commands;
using OnlineShop.Domain.SalesOrderHeaders.Queries;
using OnlineShop.Persistence.Interfaces;
using Xunit;

namespace OnlineShop.App.Tests;

public class NS_CreateOrderCommandHandlerTests
{
    private readonly IOrdersRepository _customOrdersRepo;
    private readonly IMapper _mapper;
    private readonly IRepository<SalesOrderHeader> _repository;
    private readonly CreateOrderCommandHandler _sut;

    public NS_CreateOrderCommandHandlerTests()
    {
        _mapper = Substitute.For<IMapper>();
        _repository = Substitute.For<IRepository<SalesOrderHeader>>();
        _customOrdersRepo = Substitute.For<IOrdersRepository>();

        _sut = new CreateOrderCommandHandler(_repository, _mapper, _customOrdersRepo);
    }

    [Theory]
    [InlineData(99)]
    [InlineData(100)]
    [InlineData(101)]
    public async Task Handle_AccordingToInputData_ShouldThrowOrReturn(decimal number)
    {
        // Arrange
        _customOrdersRepo
            .When(x => x.DoSomeCalculation(Arg.Is<decimal>(y => y <= 0)))
            .Do(x => throw new ApplicationException("Invalid Argument"));

        var salesOrder = new SalesOrderHeader() {SubTotal = number};
        _mapper.Map<SalesOrderHeader>(default).ReturnsForAnyArgs(salesOrder);
        
        var order = new OrderQueryResult();
        
        // Act
        var func = () => _sut.Handle(new CreateOrderCommand
        {
            Order = order
        }, CancellationToken.None);
        
        // Assert
        if (_sut.Calculation(salesOrder.SubTotal) <= 0)
            await func.Should().ThrowAsync<ApplicationException>();
        else
            await func.Should().NotThrowAsync();
    }
}