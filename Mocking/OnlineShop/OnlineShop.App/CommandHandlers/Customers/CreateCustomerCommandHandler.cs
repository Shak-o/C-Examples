using AutoMapper;
using MediatR;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Customers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CreateCustomerCommandHandler(IRepository<Customer> repository, IMapper mapper, ICompanyRepository companyRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // THIS BUSINESS LOGIC IS FAKE
            if (string.IsNullOrEmpty(request.CompanyName) || string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.LastName))
            {
                throw new ApplicationException("Invalid parameters, missing required parameters");
            }
            var restrictedCompanies = await _companyRepository.GetRestrictedCompaniesAsync().ConfigureAwait(false);

            if (restrictedCompanies.Contains(request.CompanyName))
            {
                throw new ApplicationException("Restricted company");
            }

            var mapped = _mapper.Map<Customer>(request);

            mapped.Rowguid = Guid.NewGuid();

            await _repository.AddAsync(mapped, cancellationToken);

            return Unit.Value;

        }
    }
}
