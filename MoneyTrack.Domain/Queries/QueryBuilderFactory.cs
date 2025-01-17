using MoneyTrack.Domain.Accounts;
using MoneyTrack.Domain.Data;
using MoneyTrack.Domain.OperationCategories;

namespace MoneyTrack.Domain.Queries;

public class QueryBuilderFactory : IQueryBuilderFactory
{
    private readonly IStore _store;

    public QueryBuilderFactory(IStore store)
    {
        _store = store;
    }

    public AccountQueryBuilder Accounts() => new(_store);
    public OperationCategoryQueryBuilder OperationCategories() => new(_store);
}