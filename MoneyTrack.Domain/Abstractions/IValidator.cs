using LanguageExt;
using LanguageExt.Common;

namespace MoneyTrack.Domain.Abstractions;

public interface IValidator<T> where T : class
{
    Task<Option<Error>> ValidateAsync(T entity, CancellationToken cancellation = default);
}