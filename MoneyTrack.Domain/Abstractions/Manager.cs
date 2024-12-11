using LanguageExt;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using MoneyTrack.Domain.Data;
using MoneyTrack.Domain.Queries;

namespace MoneyTrack.Domain.Abstractions;

public abstract class Manager<T> where T : class
{
    #region Instance variables

    private readonly IQueryBuilderFactory _queryBuilderFactory;
    private readonly IValidator<T> _validator;

    #endregion Instance variables
    
    #region Properties
    
    protected ILogger Logger { get; }
    
    protected IStore Store { get; }
    
    #endregion Properties
    
    #region Constructors

    protected Manager(
        IQueryBuilderFactory queryBuilderFactory,
        IStore store,
        IValidator<T> validator,
        ILogger logger)
    {
        _queryBuilderFactory = queryBuilderFactory;
        _validator = validator;
        
        Store = store;
        Logger = logger;
    }
    
    #endregion Constructors
    
    #region Methods
    
    public IQueryBuilderFactory Query() => _queryBuilderFactory;

    protected async Task<Fin<T>> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        Option<Error> result = await _validator.ValidateAsync(entity, cancellationToken);
        if (result.Case is Error error)
        {
            Logger.LogWarning("Validation errors occured.");
            return Fin<T>.Fail(error);
        }

        await Store.AddAsync(entity, cancellationToken);
        await Store.SaveChangesAsync(cancellationToken);
        
        return Fin<T>.Succ(entity);
    }
    
    #endregion Methods
}