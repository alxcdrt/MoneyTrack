using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTrack.Domain.Data.Entities;

namespace MoneyTrack.Infrastructure.Data.Configurations;

public class OperationCategoryConfiguration : IEntityTypeConfiguration<OperationCategory>
{
    public void Configure(EntityTypeBuilder<OperationCategory> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Name).IsUnique();
    }
}