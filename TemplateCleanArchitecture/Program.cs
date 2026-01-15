using Api.DependencyInjection;
using Api.Middlewares;
using LuxuzDev.PersonalLogger;

var builder = WebApplication.CreateBuilder(args);

PersonalLogger.Initialize();

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);

builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();


PersonalLogger.Log("PersonalLogger Iniciado", LogType.Success);
app.Run();