using MoneyTrack.Domain.Data.Entities;
using MoneyTrack.Domain.Data.Enums;

namespace MoneyTrack.Domain.Operations;

public record struct OperationData(
    int AccountId,
    int CategoryId,
    OperationType OperationType,
    decimal Amount,
    string? Description,
    DateTimeOffset Date)
{
    public Operation ToOperation()
    {
        return new()
        {
            AccountId = AccountId,
            OperationCategoryId = CategoryId,
            OperationType = OperationType,
            Amount = Amount,
            Description = Description,
            Date = Date
        };
    }
}