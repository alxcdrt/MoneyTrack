using System.Net;
using FluentValidation;
using FluentValidation.Results;
using LanguageExt;
using LanguageExt.Common;

namespace MoneyTrack.Infrastructure.Validators;

public class FluentValidator<T> : Domain.Abstractions.IValidator<T> where T : class
{
    #region Instance variables

    private readonly IValidator<T> _validator;

    #endregion Instance variable
    
    #region Constructors

    public FluentValidator(IValidator<T> validator)
    {
        _validator = validator;
    }
    
    #endregion Constructors

    #region Methods

    public async Task<Option<Error>> ValidateAsync(T entity, CancellationToken cancellationToken = default)
    {
        ValidationResult result = await _validator.ValidateAsync(entity, cancellationToken);
        if (result.IsValid)
        {
            return Option<Error>.None;
        }
        
        string message = string.Join(", ", result.Errors.Select(x => x.ErrorMessage));
        
        return Option<Error>.Some(Error.New((int)HttpStatusCode.BadRequest, message));
    }

    #endregion Methods
}