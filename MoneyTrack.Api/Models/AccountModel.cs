using MoneyTrack.Domain.Data.Entities;

namespace MoneyTrack.Api.Models;

public class AccountModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
}

public static class AccountExtensions
{
    public static IQueryable<AccountModel> ToModel(this IQueryable<Account> source)
    {
        return source.Select(a => new AccountModel
        {
            Id = a.Id,
            Name = a.Name
        });
    }
}