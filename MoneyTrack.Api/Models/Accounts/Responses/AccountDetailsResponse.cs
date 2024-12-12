using MoneyTrack.Api.Models.Operations.Responses;
using MoneyTrack.Domain.Data.Entities;

namespace MoneyTrack.Api.Models.Accounts.Responses;

public class AccountDetailsResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<OperationDetailsResponse> Operations { get; set; } = [];
}

public static partial class ModelExtensions
{
    public static IQueryable<AccountDetailsResponse> ToDetailsResponse(this IQueryable<Account> source)
    {
        return source.Select(a => new AccountDetailsResponse
        {
            Id = a.Id,
            Name = a.Name,
            Operations = a.Operations
                .Select(o => new OperationDetailsResponse
                {
                    Id = o.Id
                })
        });
    }
}