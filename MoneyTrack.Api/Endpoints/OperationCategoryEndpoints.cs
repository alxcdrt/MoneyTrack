using System.Security.Claims;
using LanguageExt;
using MoneyTrack.Api.Helpers;
using MoneyTrack.Api.Models.OperationCategories.Requests;
using MoneyTrack.Api.Models.OperationCategories.Responses;
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
        OperationCategoryCreationRequest request,
        ClaimsPrincipal user,
        OperationCategoryManager manager,
        CancellationToken cancellationToken)
    {
        Fin<OperationCategory> result = await manager.CreateAsync(user, request.Name, cancellationToken);

        return result.GetResult(oc => Results.Created(string.Empty, oc.ToOperationCategoryCreationResponse()));
    }
    
    #endregion Methods
}