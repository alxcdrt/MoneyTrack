using MoneyTrack.Api.Endpoints;
using MoneyTrack.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception();

builder
    .Services
    .AddStore(connectionString)
    .AddAccountManagement();

var app = builder.Build();

app.RegisterEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();