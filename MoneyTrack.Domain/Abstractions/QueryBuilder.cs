using System.Collections;
using System.Linq.Expressions;
using MoneyTrack.Domain.Data;

namespace MoneyTrack.Domain.Abstractions;

public abstract class QueryBuilder<T> 
    : IQueryable<T>, IAsyncEnumerable<T> where T : class
{
    #region  Properties

    protected IStore Store { get; }
    
    protected IQueryable<T> Query  { get; set; }
    
    public Type ElementType => typeof(T);
    
    public Expression Expression => Query.Expression;
    
    public IQueryProvider Provider => Query.Provider;
    
    #endregion Properties
    
    #region Constructors

    protected QueryBuilder(IStore store)
    {
        Store = store;
        Query = Store.Set<T>();
    }
    
    #endregion Constructors

    #region Methods

    public IEnumerator<T> GetEnumerator() => Query.GetEnumerator();
    
    IEnumerator IEnumerable.GetEnumerator() => Query.GetEnumerator();

    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        if (Query is IAsyncEnumerable<T> asyncEnumerable)
        {
            return asyncEnumerable.GetAsyncEnumerator(cancellationToken);
        }

        throw new InvalidOperationException();
    }

    #endregion Methods
}