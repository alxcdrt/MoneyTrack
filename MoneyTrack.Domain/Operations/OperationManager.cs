using System.Security.Claims;
using LanguageExt;
using Microsoft.Extensions.Logging;
using MoneyTrack.Domain.Abstractions;
using MoneyTrack.Domain.Data;
using MoneyTrack.Domain.Data.Entities;
using MoneyTrack.Domain.Queries;

namespace MoneyTrack.Domain.Operations;

public class OperationManager : Manager<Operation>
{
    #region Constructors

    public OperationManager(
        IQueryBuilderFactory queryBuilderFactory,
        IStore store, 
        IValidator<Operation> validator,
        ILogger<OperationManager> logger) : base(queryBuilderFactory, store, validator, logger)
    {
    }

    #endregion Constructors

    #region Methods

    public Task<Fin<Operation>> CreateAsync(
        ClaimsPrincipal principal,
        OperationData data,
        CancellationToken cancellationToken = default)
    {
        Operation operation = data.ToOperation();
        
        return AddAsync(operation, cancellationToken);
    }

    #endregion Methods
}