using Microsoft.Extensions.Logging;
using MoneyTrack.Domain.Data;
using MoneyTrack.Domain.Queries;

namespace MoneyTrack.Domain.Abstractions;

public abstract class Manager<T> where T : class
{
    #region Instance variables

    private readonly IQueryBuilderFactory _queryBuilderFactory;

    #endregion Instance variables
    
    #region Properties
    
    protected ILogger Logger { get; }
    
    protected IStore Store { get; }
    
    #endregion Properties
    
    #region Constructors

    protected Manager(
        IQueryBuilderFactory queryBuilderFactory,
        IStore store,
        ILogger logger)
    {
        _queryBuilderFactory = queryBuilderFactory;
        
        Store = store;
        Logger = logger;
    }
    
    #endregion Constructors
    
    #region Methods
    
    public IQueryBuilderFactory Query() => _queryBuilderFactory;
    
    #endregion Methods
}