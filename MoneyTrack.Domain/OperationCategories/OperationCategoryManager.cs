using System.Security.Claims;
using LanguageExt;
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
        IValidator<OperationCategory> validator,
        ILogger<OperationCategory> logger) : base(queryBuilderFactory, store, validator, logger)
    {
    }

    #endregion Constructors

    #region Methods

    public Task<Fin<OperationCategory>> CreateAsync(
        ClaimsPrincipal principal,
        string name,
        CancellationToken cancellationToken = default)
    {
        OperationCategory operationCategory = new()
        {
            Name = name
        };
        
        return AddAsync(operationCategory, cancellationToken);
    }

    #endregion Methods
}