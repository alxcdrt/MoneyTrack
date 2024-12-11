using MoneyTrack.Domain.Abstractions;
using MoneyTrack.Domain.Data;
using MoneyTrack.Domain.Data.Entities;

namespace MoneyTrack.Domain.OperationCategories;

public class OperationCategoryQueryBuilder : QueryBuilder<OperationCategory>
{
    #region  Constructors

    public OperationCategoryQueryBuilder(IStore store) : base(store)
    {
    }

    #endregion Constructors

    #region Methods

    public OperationCategoryQueryBuilder ByName(string? name)
    {
        if (name is not null)
        {
            Query = Query.Where(c => c.Name == name);
        }
        
        return this;
    }

    #endregion Methods
}