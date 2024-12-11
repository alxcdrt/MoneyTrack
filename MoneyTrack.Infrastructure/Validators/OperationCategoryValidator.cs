using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MoneyTrack.Domain.Data.Entities;
using MoneyTrack.Domain.Queries;

namespace MoneyTrack.Infrastructure.Validators;

public class OperationCategoryValidator : AbstractValidator<OperationCategory>
{
    private readonly IQueryBuilderFactory _queryBuilderFactory;

    public OperationCategoryValidator(IQueryBuilderFactory queryBuilderFactory)
    {
        _queryBuilderFactory = queryBuilderFactory;
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name cannot be empty")
            .MustAsync(BeUnique)
            .WithMessage("Name must be unique");
    }

    private async Task<bool> BeUnique(
        OperationCategory operationCategory,
        string name,
        CancellationToken cancellationToken = default)
    {
        return !await _queryBuilderFactory
            .OperationCategories()
            .ByName(name)
            .AnyAsync(cancellationToken);
    }
}