using System.Security.Claims;
using MoneyTrack.Api.Models;
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

    private static Task<Operation> CreateAsync(
        OperationModel model,
        ClaimsPrincipal user,
        OperationManager manager,
        CancellationToken cancellationToken = default)
    {
        return manager.CreateAsync(user, model.ToData(), cancellationToken);
    }
    
    #endregion Methods
}