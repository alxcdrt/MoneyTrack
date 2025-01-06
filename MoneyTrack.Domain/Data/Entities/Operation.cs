using MoneyTrack.Domain.Data.Enums;

namespace MoneyTrack.Domain.Data.Entities;

public class Operation
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public Account? Account { get; set; }
    public int OperationCategoryId { get; set; }
    public OperationCategory? Category { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset Date { get; set; }
}