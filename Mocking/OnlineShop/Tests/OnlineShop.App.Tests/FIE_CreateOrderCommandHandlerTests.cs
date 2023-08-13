using AutoFixture;
using AutoFixture.AutoFakeItEasy;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using OnlineShop.App.CommandHandlers.Orders;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Domain.SalesOrderHeaders.Commands;
using OnlineShop.Domain.SalesOrderHeaders.Queries;
using OnlineShop.Persistence.Interfaces;
using Xunit;

namespace OnlineShop.App.Tests;

// ReSharper disable once InconsistentNaming
public class FIE_CreateOrderCommandHandlerTests
{
    private readonly CreateOrderCommandHandler _sut;
    private readonly Fake<IMapper> _mapper;
    private readonly Fake<IRepository<SalesOrderHeader>> _repo;
    private readonly Fake<IOrdersRepository> _ordersRepo;
    private readonly IFixture _fixture;
    
    public FIE_CreateOrderCommandHandlerTests()
    {
        _fixture = new Fixture().Customize(new AutoFakeItEasyCustomization());
        _mapper = _fixture.Freeze<Fake<IMapper>>();
        _repo = _fixture.Freeze<Fake<IRepository<SalesOrderHeader>>>();
        _ordersRepo = _fixture.Freeze<Fake<IOrdersRepository>>();
        _sut = _fixture.Create<CreateOrderCommandHandler>();
    }

    [Theory]
    [InlineData(99)]
    [InlineData(100)]
    [InlineData(101)]
    public async Task Handle_AccordingToInputData_ShouldThrowOrReturn(decimal number)
    {
        // Arrange
        _ordersRepo
            .CallsTo(x => x.DoSomeCalculation(A<decimal>.That.Matches(y => y <= 0)))
            .Throws<ApplicationException>();
        
        var salesOrder = new SalesOrderHeader() {SubTotal = number};
        
        _mapper.CallsTo(x => x.Map<SalesOrderHeader>(A<object>.Ignored))
            .Returns(salesOrder);
        
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