using System.Linq.Expressions;
using FluentAssertions;
using NSubstitute;
using OnlineShop.App.CommandHandlers.Orders;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Domain.SalesOrderHeaders.Commands;
using OnlineShop.Persistence.Interfaces;
using Xunit;

namespace OnlineShop.App.Tests;

public class NS_DeleteOrderCommandHandlerTests
{
    private readonly IRepository<SalesOrderHeader> _repository;
    private readonly DeleteOrderCommandHandler _sut;

    public NS_DeleteOrderCommandHandlerTests()
    {
        _repository = Substitute.For<IRepository<SalesOrderHeader>>();
        _sut = new DeleteOrderCommandHandler(_repository);
    }

    [Fact]
    public async Task Handle_WhenItemIsNotDeleted_ShouldThrow()
    {
        // Arrange
        _repository.GetFirstAsync(default).ReturnsForAnyArgs(new SalesOrderHeader());
        
        // Act
        var func = () => _sut.Handle(new DeleteOrderCommand(), CancellationToken.None);
        
        // Assert
        await func.Should().ThrowAsync<ApplicationException>();
    }

    [Fact]
    public async Task Handle_WhenItemIsDeleted_ShouldNotThrow()
    {
        // Arrange
        _repository.GetFirstAsync(Arg.Any<Expression<Func<SalesOrderHeader, bool>>>(), Arg.Any<CancellationToken>())
            .Returns(new SalesOrderHeader(), (SalesOrderHeader)null!);
        
        // Act
        var func = () => _sut.Handle(new DeleteOrderCommand(), CancellationToken.None);
        
        // Assert
        await func.Should().NotThrowAsync();
    }
}