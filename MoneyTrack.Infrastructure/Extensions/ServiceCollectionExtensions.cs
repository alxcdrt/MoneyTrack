using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyTrack.Domain.Accounts;
using MoneyTrack.Domain.Data;
using MoneyTrack.Domain.Queries;
using MoneyTrack.Infrastructure.Data;

namespace MoneyTrack.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStore(this IServiceCollection services, string connectionString)
    {
        services
            .AddDbContext<MoneyTrackContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IStore, MoneyTrackContext>();
        
        return services;
    }

    public static IServiceCollection AddAccountManagement(this IServiceCollection services)
    {
        return services
            .AddScoped<IQueryBuilderFactory, QueryBuilderFactory>()
            .AddScoped<AccountManager>();
    }
}