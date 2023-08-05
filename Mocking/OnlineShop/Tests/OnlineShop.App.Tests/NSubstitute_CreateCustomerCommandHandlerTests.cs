using AutoMapper;
using NSubstitute;
using OnlineShop.App.CommandHandlers.Customers;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Persistence.Interfaces;
using Xunit;

namespace OnlineShop.App.Tests
{
    // ReSharper disable once InconsistentNaming
    public class NSubstitute_CreateCustomerCommandHandlerTests
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private CreateCustomerCommandHandler _sut;

        public NSubstitute_CreateCustomerCommandHandlerTests()
        {
            _customerRepository = Substitute.For<IRepository<Customer>>();
            _companyRepository = Substitute.For<ICompanyRepository>();
            _mapper = Substitute.For<IMapper>();

            _sut = new CreateCustomerCommandHandler(_customerRepository, _mapper, _companyRepository);
        }

        [Fact]
        public async Task Handle_WhenEverythingOk_ShouldCallRepositoryAdd()
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

            _companyRepository.GetRestrictedCompaniesAsync().Returns(Task.FromResult(new List<string>() { "CompanyC" }));
            _mapper.Map<Customer>(Arg.Any<object>()).Returns(customer);

            // Act
            await _sut.Handle(new CreateCustomerCommand()
            {
                FirstName = "First",
                LastName = "last",
                CompanyName = "CompanyB"
            }, CancellationToken.None);

            // Assert
            await _customerRepository
                .Received()
                .AddAsync(customer, Arg.Any<CancellationToken>());
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Handle_RandomTests_ShouldPass(bool validCompany)
        {

        }
    }
}
