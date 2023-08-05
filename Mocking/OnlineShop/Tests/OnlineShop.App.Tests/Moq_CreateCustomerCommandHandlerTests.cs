using AutoMapper;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using OnlineShop.App.CommandHandlers.Customers;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Persistence.Interfaces;
using Xunit;

namespace OnlineShop.App.Tests
{
    // ReSharper disable once InconsistentNaming
    public class Moq_CreateCustomerCommandHandlerTests
    {
        private readonly AutoMocker _mocker;
        private readonly CreateCustomerCommandHandler _sut;

        public Moq_CreateCustomerCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _sut = _mocker.CreateInstance<CreateCustomerCommandHandler>();
        }

        [Fact]
        public async Task HandleAsync_WhenEverythingOk_ShouldCallRepositoryAdd()
        {
            // Arrange
            var customer = new Customer()
            {
                Title = "test",
                FirstName = "first",
                MiddleName = "middle",
                LastName = "last",
                CompanyName = "CompanyB"
            };
            _mocker.GetMock<ICompanyRepository>().Setup(x => x.GetRestrictedCompaniesAsync())
                .ReturnsAsync(new List<string>() { "CompanyC" });
            _mocker.GetMock<IMapper>().Setup(x => x.Map<Customer>(It.IsAny<object>())).Returns(customer);

            // Act
            await _sut.Handle(new CreateCustomerCommand
            {
                Title = "test",
                FirstName = "first",
                MiddleName = "middle",
                LastName = "last",
                CompanyName = "CompanyB",
                Password = "test"
            }, CancellationToken.None).ConfigureAwait(false);

            // Assert
            _mocker.GetMock<IRepository<Customer>>().Verify(x => x.AddAsync(customer, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenInvalidData_ShouldThrow()
        {
            // Act
            var func = () =>
                _sut.Handle(new CreateCustomerCommand() { CompanyName = "CompanyC" }, CancellationToken.None);

            // Assert
            await func
                .Should()
                .ThrowAsync<ApplicationException>()
                .WithMessage("Invalid parameters, missing required parameters");
        }

        [Fact]
        public async Task Handle_WhenRestrictedCompany_ShouldThrow()
        {
            // Arrange
            _mocker.GetMock<ICompanyRepository>().Setup(x => x.GetRestrictedCompaniesAsync())
                .ReturnsAsync(new List<string>() { "CompanyC" });
            
            // Act
            var func = () =>
                _sut.Handle(new CreateCustomerCommand()
                {
                    CompanyName = "CompanyC",
                    FirstName = "first",
                    LastName = "Last",
                    
                }, CancellationToken.None);

            // Assert
            await func
                .Should()
                .ThrowAsync<ApplicationException>()
                .WithMessage("Restricted Company");
        }
    }
}
