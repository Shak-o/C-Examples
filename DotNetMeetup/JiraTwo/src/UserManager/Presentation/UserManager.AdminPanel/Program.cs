using JiraTwo.ServiceDefaults;
using Microsoft.AspNetCore.DataProtection;
using UserManager.AdminPanel.Middlewares;
using UserManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.AddInfrastructure();
builder.AddServiceDefaults();
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("./DataProtectionKeys"))
    .SetApplicationName("UserManager.Admin");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapDefaultEndpoints();

app.UseMiddleware<CustomAuthMiddleware>();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserManager}/{action=Index}/{id?}");

app.Run();