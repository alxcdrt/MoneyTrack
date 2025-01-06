using System.Security.Claims;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using MoneyTrack.Api.Helpers;
using MoneyTrack.Api.Models.Accounts.Requests;
using MoneyTrack.Api.Models.Accounts.Responses;
using MoneyTrack.Domain.Accounts;
using MoneyTrack.Domain.Data.Entities;

namespace MoneyTrack.Api.Endpoints;

public static class AccountEndpoints
{
    #region Constants

    private const string Endpoint = "/api/v1/accounts"; 

    #endregion Constants
    
    #region Methods
    
    public static void RegisterAccountEndpoints(this IEndpointRouteBuilder app)
    {
        var accounts = app.MapGroup(Endpoint);

        accounts.MapPost(string.Empty, CreateAsync);
        accounts.MapGet(string.Empty, ListAsync);
    }

    private static async Task<IResult> CreateAsync(
        AccountCreationRequest request,
        ClaimsPrincipal user,
        AccountManager manager,
        CancellationToken cancellationToken)
    {
        Fin<Account> result = await manager.CreateAsync(user, request.Name, cancellationToken);
        return result.GetResult(a => Results.Created(string.Empty, a.ToCreationResponse()));
    }

    private static async Task<IResult> ListAsync(
        AccountManager manager,
        CancellationToken cancellationToken)
    {
        List<AccountListResponse> accounts = await manager
            .Query()
            .Accounts()
            .ToDetailsResponse()
            .ToListAsync(cancellationToken);
        
        return Results.Ok(accounts);
    }
    
    #endregion Methods
}