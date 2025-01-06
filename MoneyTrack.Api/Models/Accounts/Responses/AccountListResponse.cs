using MoneyTrack.Api.Models.Operations.Responses;
using MoneyTrack.Domain.Data.Entities;

namespace MoneyTrack.Api.Models.Accounts.Responses;

public class AccountListResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    
    public decimal Balance { get; set; }
}

public static partial class ModelExtensions
{
    public static IQueryable<AccountListResponse> ToDetailsResponse(this IQueryable<Account> source)
    {
        return source.Select(a => new AccountListResponse
        {
            Id = a.Id,
            Name = a.Name,
            Balance = a.InitialBalance + a.Operations.Sum(o => o.Amount)
        });
    }
}