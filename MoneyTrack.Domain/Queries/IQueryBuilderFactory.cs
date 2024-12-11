using MoneyTrack.Domain.Accounts;
using MoneyTrack.Domain.OperationCategories;

namespace MoneyTrack.Domain.Queries;

public interface IQueryBuilderFactory
{
    AccountQueryBuilder Accounts();
    OperationCategoryQueryBuilder OperationCategories();
}