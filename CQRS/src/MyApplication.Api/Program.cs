using Microsoft.EntityFrameworkCore;
using MyApplication.Persistence;
using MyQueryApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("Application")));

builder.Services.AddDbContext<QueryDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("Query")));

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