using System.Security.Claims;
using Microsoft.Extensions.Logging;
using MoneyTrack.Domain.Abstractions;
using MoneyTrack.Domain.Data;
using MoneyTrack.Domain.Data.Entities;
using MoneyTrack.Domain.Queries;

namespace MoneyTrack.Domain.OperationCategories;

public class OperationCategoryManager : Manager<OperationCategory>
{
    #region Constructors

    public OperationCategoryManager(
        IQueryBuilderFactory queryBuilderFactory,
        IStore store,
        ILogger<OperationCategory> logger) : base(queryBuilderFactory, store, logger)
    {
    }

    #endregion Constructors

    #region Methods

    public async Task<OperationCategory> CreateAsync(
        ClaimsPrincipal principal,
        string name,
        CancellationToken cancellationToken = default)
    {
        OperationCategory operationCategory = new()
        {
            Name = name
        };
        
        await Store.AddAsync(operationCategory, cancellationToken);
        await Store.SaveChangesAsync(cancellationToken);
        
        return operationCategory;
    }

    #endregion Methods
}