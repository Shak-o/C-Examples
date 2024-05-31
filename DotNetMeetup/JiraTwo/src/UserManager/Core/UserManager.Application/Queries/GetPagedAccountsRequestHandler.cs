using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UserManager.Application.RepositoryInterfaces;
using UserManager.Application.ViewModels;

namespace UserManager.Application.Queries;

public class GetPagedAccountsRequestHandler(IAccountRepository accountRepository) : IRequestHandler<GetPagedAccountsRequest, List<UserViewModel>>
{
    public async Task<List<UserViewModel>> Handle(GetPagedAccountsRequest request, CancellationToken cancellationToken)
    {
        var list = await accountRepository.GetPagedAccountsAsync(request.Page, cancellationToken);
        return list;
    }
}