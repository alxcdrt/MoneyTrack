using MoneyTrack.Domain.Data.Entities;

namespace MoneyTrack.Api.Models.Accounts.Responses;

public class AccountCreationResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
}

public static partial class ModelExtensions
{
    public static AccountCreationResponse ToCreationResponse(this Account account)
    {
        return new()
        {
            Id = account.Id,
            Name = account.Name
        };
    }
}