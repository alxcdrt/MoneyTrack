using MoneyTrack.Api.Models.Operations.Requests;
using MoneyTrack.Domain.Data.Entities;
using MoneyTrack.Domain.Data.Enums;

namespace MoneyTrack.Api.Models.Operations.Responses;

public class OperationCreationResponse
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int OperationCategoryId { get; set; }
    public OperationType OperationType { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset Date { get; set; }
}

public static partial class ModelExtensions
{
    public static OperationCreationResponse ToCreationResponse(this Operation operation)
    {
        return new()
        {
            Id = operation.Id,
            AccountId = operation.AccountId,
            OperationCategoryId = operation.OperationCategoryId,
            OperationType = operation.OperationType,
            Amount = operation.Amount,
            Description = operation.Description,
            Date = operation.Date
        };
    }
}