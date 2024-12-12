using System.Security.Claims;
using LanguageExt;
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
        IValidator<Account> validator,
        ILogger<AccountManager> logger) : base(queryBuilderFactory, store, validator, logger)
    {
    }
    
    #endregion Constructors
    
    #region Methods

    public Task<Fin<Account>> CreateAsync(
        ClaimsPrincipal principal,
        string name,
        CancellationToken cancellationToken = default)
    {
        Account account = new()
        {
            Name = name,
        };
        
        return AddAsync(account, cancellationToken);
    }
    
    #endregion Methods
}