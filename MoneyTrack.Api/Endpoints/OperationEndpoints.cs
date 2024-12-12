using System.Security.Claims;
using LanguageExt;
using MoneyTrack.Api.Helpers;
using MoneyTrack.Api.Models.Operations.Requests;
using MoneyTrack.Api.Models.Operations.Responses;
using MoneyTrack.Domain.Data.Entities;
using MoneyTrack.Domain.Operations;

namespace MoneyTrack.Api.Endpoints;

public static class OperationEndpoints
{        
    #region Constants
 
    private const string Endpoint = "/api/v1/operations";
         
    #endregion Constants

    #region Methods

    public static void RegisterOperationEndpoints(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder operations = app.MapGroup(Endpoint);

        operations.MapPost(string.Empty, CreateAsync);
    }

    private static async Task<IResult> CreateAsync(
        OperationCreationRequest creationRequest,
        ClaimsPrincipal user,
        OperationManager manager,
        CancellationToken cancellationToken = default)
    {
        Fin<Operation> result = await manager.CreateAsync(user, creationRequest.ToData(), cancellationToken);

        return result.GetResult(o => Results.Created(string.Empty, o.ToCreationResponse()));
    }
    
    #endregion Methods
}