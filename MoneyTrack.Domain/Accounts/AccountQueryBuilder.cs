using MoneyTrack.Domain.Abstractions;
using MoneyTrack.Domain.Data;
using MoneyTrack.Domain.Data.Entities;

namespace MoneyTrack.Domain.Accounts;

public class AccountQueryBuilder : QueryBuilder<Account>
{
    #region Constructors

    public AccountQueryBuilder(IStore store) : base(store)
    {
    }

    #endregion Constructors
}