using System.ComponentModel;

namespace MoneyTrack.Domain.Data.Enums;

public enum OperationType
{
    [Description("Entrée")]
    Income = 0,
    
    [Description("Sortie")]
    Expense = 1
}