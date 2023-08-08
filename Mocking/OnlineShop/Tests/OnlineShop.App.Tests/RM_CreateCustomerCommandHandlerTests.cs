using AutoMapper;
using OnlineShop.App.CommandHandlers.Customers;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Persistence.Interfaces;
using Rhino.Mocks;
using Xunit;

namespace OnlineShop.App.Tests;

// ReSharper disable once InconsistentNaming
public class RM_CreateCustomerCommandHandlerTests
{
    private readonly IRepository<Customer> _repository;
    private readonly ICompanyRepository _customRepository;
    private readonly IMapper _mapper;
    private readonly CreateCustomerCommandHandler _sut;

    public RM_CreateCustomerCommandHandlerTests()
    {
        _repository = MockRepository.GenerateMock<IRepository<Customer>>();
        _customRepository = MockRepository.GenerateMock<ICompanyRepository>();
        _mapper = MockRepository.GenerateMock<IMapper>();

        _sut = new CreateCustomerCommandHandler(_repository, _mapper, _customRepository);
    }
    
    // https://stackoverflow.com/questions/75919799/rhino-mock-compatibility-with-net-6
    [Fact(Skip = "Rhino Mocks is practically dead")]
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
        
        _customRepository
            .Stub(x => x.GetRestrictedCompaniesAsync())
            .Return(Task.FromResult(new List<string>() { "TEST1", "TEST2" }));

        _mapper.Stub(x => x.Map<Customer>(Arg.Is(typeof(object)))).Return(customer);
        
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
        _repository.AssertWasCalled(
            x => x.AddAsync(
                customer, Arg<CancellationToken>.Matches(c => c != default || c == default)
                )
            );
    }
}