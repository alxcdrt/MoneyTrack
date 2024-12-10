using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyTrack.Api.Models;
using MoneyTrack.Domain.Accounts;
using MoneyTrack.Domain.Data.Entities;

namespace MoneyTrack.Api.Endpoints;

public static class AccountEndpoints
{
    public static void RegisterEndpoints(this IEndpointRouteBuilder app)
    {
        var accounts = app.MapGroup("/api/v1/accounts");

        accounts.MapPost(string.Empty, CreateAsync);
        accounts.MapGet(string.Empty, ListAsync);
    }

    private static Task<Account> CreateAsync(
        [FromBody]string name,
        ClaimsPrincipal user,
        AccountManager manager,
        CancellationToken cancellationToken)
    {
        return manager.CreateAsync(user, name, cancellationToken);
    }

    private static Task<List<AccountModel>> ListAsync(
        AccountManager manager,
        CancellationToken cancellationToken)
    {
        return manager
            .Query()
            .Accounts()
            .ToModel()
            .ToListAsync(cancellationToken);
    }
}