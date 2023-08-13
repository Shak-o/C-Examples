using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyQueryApp.Domain.Models;
using MyQueryApp.Persistence;

namespace MyQueryApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class QueryController : ControllerBase
{
    private readonly QueryDbContext _queryDbContext;

    public QueryController(QueryDbContext queryDbContext)
    {
        _queryDbContext = queryDbContext;
    }

    [HttpGet("Person/{id}")]
    public async Task<PersonQueryModel?> GetPerson(int id)
    {
        var person = await _queryDbContext.PersonQueryModels.FirstOrDefaultAsync(x => x.IdInMainTable == id);

        return person;
    }
}