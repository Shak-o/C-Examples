using SignalRDemo.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.AddServiceDefaults();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddRedisClient("redis");

var clientUrl = builder.Configuration["services:client:https:0"]!;
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        opt =>
        {
            opt.WithOrigins(clientUrl)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});
builder.Services.AddSignalR();

var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};

webSocketOptions.AllowedOrigins.Add(clientUrl);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowSpecificOrigin");
app.UseWebSockets(webSocketOptions);
app.MapDefaultEndpoints();
app.MapControllers();
app.MapHub<TestHub>("/test");

app.Run();