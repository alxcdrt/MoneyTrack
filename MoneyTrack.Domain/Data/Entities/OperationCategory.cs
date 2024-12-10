namespace MoneyTrack.Domain.Data.Entities;

public class OperationCategory
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public ICollection<Operation> Operations { get; set; } = [];
}