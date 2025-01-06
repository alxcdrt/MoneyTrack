using MoneyTrack.Api.Endpoints;
using MoneyTrack.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception();

builder
    .Services
    .AddStore(connectionString)
    .AddAccountManagement()
    .AddCors(options => options.AddDefaultPolicy(p =>
    {
        p.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    }));

var app = builder.Build();

app.RegisterAccountEndpoints();
app.RegisterOperationEndpoints();
app.RegisterOperationCategoryEndpoints();

app.UseCors();

app.Run();