using MoneyTrack.Domain.Accounts;

namespace MoneyTrack.Domain.Queries;

public interface IQueryBuilderFactory
{
    AccountQueryBuilder Accounts();
}