using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
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

    private static Task<OperationCategory> CreateAsync(
        [FromBody]string name,
        ClaimsPrincipal user,
        OperationCategoryManager manager,
        CancellationToken cancellationToken)
    {
        return manager.CreateAsync(user, name, cancellationToken);
    }
    #endregion Methods
}