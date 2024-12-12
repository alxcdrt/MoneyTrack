using MoneyTrack.Domain.Data.Entities;

namespace MoneyTrack.Api.Models.OperationCategories.Responses;

public class OperationCategoryCreationResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
}

public static partial class ModelExtensions
{
    public static OperationCategoryCreationResponse ToOperationCategoryCreationResponse(
        this OperationCategory operationCategory)
    {
        return new()
        {
            Id = operationCategory.Id,
            Name = operationCategory.Name
        };
    }
}