using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyTrack.Domain.Accounts;
using MoneyTrack.Domain.Data;
using MoneyTrack.Domain.Data.Entities;
using MoneyTrack.Domain.OperationCategories;
using MoneyTrack.Domain.Operations;
using MoneyTrack.Domain.Queries;
using MoneyTrack.Infrastructure.Data;
using MoneyTrack.Infrastructure.Validators;

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
            .AddValidation()
            .AddScoped<IQueryBuilderFactory, QueryBuilderFactory>()
            .AddScoped<AccountManager>()
            .AddScoped<OperationManager>()
            .AddScoped<OperationCategoryManager>();
    }

    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
        return services
            .AddScoped(typeof(Domain.Abstractions.IValidator<>), typeof(FluentValidator<>))
            .AddScoped<IValidator<OperationCategory>, OperationCategoryValidator>()
            .AddScoped<IValidator<Operation>, OperationValidator>()
            .AddScoped<IValidator<Account>, AccountValidator>();
    }
}