using System.Security.Claims;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using MoneyTrack.Api.Helpers;
using MoneyTrack.Domain.Data.Entities;
using MoneyTrack.Domain.OperationCategories;

namespace MoneyTrack.Api.Endpoints;

public static class OperationCategoryEndpoints
{
    #region Constants

    private const string Endpoint = "/api/v1/operation-categories";

    #endregion Constants

    #region Methods

    public static void RegisterOperationCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder operationCategories = app.MapGroup(Endpoint);

        operationCategories.MapPost(string.Empty, CreateAsync);
    }

    private static async Task<IResult> CreateAsync(
        [FromBody]string name,
        ClaimsPrincipal user,
        OperationCategoryManager manager,
        CancellationToken cancellationToken)
    {
        Fin<OperationCategory> result = await manager.CreateAsync(user, name, cancellationToken);

        return result.GetResult(oc => Results.Created(string.Empty, oc));
    }
    
    #endregion Methods
}