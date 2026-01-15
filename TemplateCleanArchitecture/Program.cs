using Api;
using Api.DependencyInjection;
using Shared.Exception;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);

builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<CustomMiddleware>();
app.UseHttpsRedirection();


app.Run();

