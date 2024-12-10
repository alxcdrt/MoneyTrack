using System.Security.Claims;
using Microsoft.Extensions.Logging;
using MoneyTrack.Domain.Abstractions;
using MoneyTrack.Domain.Data;
using MoneyTrack.Domain.Data.Entities;
using MoneyTrack.Domain.Queries;

namespace MoneyTrack.Domain.Accounts;

public class AccountManager : Manager<Account>
{
    #region Constructors
    
    public AccountManager(
        IQueryBuilderFactory queryBuilderFactory,
        IStore store,
        ILogger<AccountManager> logger) : base(queryBuilderFactory, store, logger)
    {
    }
    
    #endregion Constructors
    
    #region Methods

    public async Task<Account> CreateAsync(
        ClaimsPrincipal principal,
        string name,
        CancellationToken cancellationToken = default)
    {
        Account account = new()
        {
            Name = name,
        };

        await Store.AddAsync(account, cancellationToken);
        await Store.SaveChangesAsync(cancellationToken);
        
        return account;
    }
    
    #endregion Methods
}