using MoneyTrack.Domain.Data.Enums;
using MoneyTrack.Domain.Operations;

namespace MoneyTrack.Api.Models.Operations.Requests;

public class OperationCreationRequest
{
    public int AccountId { get; set; }
    public int OperationCategoryId { get; set; }
    public OperationType OperationType { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset Date { get; set; }

    public OperationData ToData() => new(
        AccountId,
        OperationCategoryId,
        OperationType,
        Amount,
        Description,
        Date);
}