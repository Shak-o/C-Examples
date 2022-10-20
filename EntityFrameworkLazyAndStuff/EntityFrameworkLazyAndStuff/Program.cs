using EntityFrameworkLazyAndStuff.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<LocalDbContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["Default"]);
        //.UseLazyLoadingProxies(); <- for automatic lazy loading with virtual properties
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    throw new Exception(ex.Message);
}

