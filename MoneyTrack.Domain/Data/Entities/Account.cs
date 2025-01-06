namespace MoneyTrack.Domain.Data.Entities;

public class Account
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal InitialBalance { get; set; }
    public ICollection<Operation> Operations { get; set; } = [];
}