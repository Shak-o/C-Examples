using AutoMapper;
using FakeItEasy;
using Moq;
using OnlineShop.App.CommandHandlers.Customers;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Persistence.Interfaces;
using Xunit;
using Times = FakeItEasy.Times;

namespace OnlineShop.App.Tests;

// ReSharper disable once InconsistentNaming
public class FIE_CreateCustomerCommandHandlerTests
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IRepository<Customer> _customerRepository;
    private readonly IMapper _mapper;
    private readonly CreateCustomerCommandHandler _sut;

    public FIE_CreateCustomerCommandHandlerTests()
    {
        _customerRepository = A.Fake<IRepository<Customer>>();
        _mapper = A.Fake<IMapper>();
        _companyRepository = A.Fake<ICompanyRepository>();
        _sut = new CreateCustomerCommandHandler(_customerRepository, _mapper, _companyRepository);
    }

    [Fact]
    public async Task HandleAsync_WhenEverythingOk_ShouldCallRepositoryAdd()
    {
        // Arrange
        var customer = new Customer
        {
            Title = "test",
            FirstName = "first",
            MiddleName = "middle",
            LastName = "last",
            CompanyName = "CompanyB"
        };

        A.CallTo(() => _companyRepository.GetRestrictedCompaniesAsync()).Returns(Task.FromResult(new List<string>() {"CompanyC"}));
        A.CallTo(() => _mapper.Map<Customer>(A<object>.Ignored)).Returns(customer);

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
        A.CallTo(() => _customerRepository.AddAsync(customer, A<CancellationToken>.Ignored)).MustHaveHappened(1, Times.Exactly);
    }
}