using Microsoft.AspNetCore.Mvc;
using MyApplication.Domain.Models;
using MyApplication.Persistence;
using MyQueryApp.Domain.Models;
using MyQueryApp.Persistence;

namespace MyApplication.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ApplicationController : ControllerBase
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly QueryDbContext _queryDbContext;

    public ApplicationController(ApplicationDbContext applicationDbContext, QueryDbContext queryDbContext)
    {
        _applicationDbContext = applicationDbContext;
        _queryDbContext = queryDbContext;
    }

    [HttpPost("User")]
    public async Task CreateUserAndPersonAsync([FromQuery] int count)
    {
        using var appTransaction = await _applicationDbContext.Database.BeginTransactionAsync();
        using var queryTransaction = await _queryDbContext.Database.BeginTransactionAsync();
        try
        {
            var person = new Person
            {
                Name = $"Name {count}",
                SurName = $"Surname {count}",
                DateOfBirth = DateTime.Now.AddYears(-20)
            };
            _applicationDbContext.Add(person);
            await _applicationDbContext.SaveChangesAsync().ConfigureAwait(false);

            var user = new User
            {
                PersonId = person.Id,
                UserName = $"test {count}",
                Password = $"testpwd {count}",
                Salt = "salt"
            };

            _applicationDbContext.Add(user);
            await _applicationDbContext.SaveChangesAsync().ConfigureAwait(false);

            var queryModel = new PersonQueryModel
            {
                IdInMainTable = person.Id,
                Name = person.Name,
                SurName = person.SurName,
                DateOfBirth = person.DateOfBirth,
                Users = new List<UserQueryModel>()
                {
                    new UserQueryModel
                    {
                        UserName = user.UserName,
                        Password = user.Password,
                        Salt = user.Salt
                    }
                }
            };

            _queryDbContext.Add(queryModel);
            await _queryDbContext.SaveChangesAsync().ConfigureAwait(false);
            
            appTransaction.Commit();
            queryTransaction.Commit();
        }
        catch (Exception ex)
        {
            appTransaction.Rollback();
            queryTransaction.Rollback();
            throw;
        }
    }
}