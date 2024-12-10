using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyTrack.Domain.Data.Entities;

namespace MoneyTrack.Infrastructure.Data.Configurations;

public class OperationConfiguration : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .HasOne(x => x.Account)
            .WithMany(x => x.Operations)
            .HasForeignKey(x => x.AccountId);

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Operations)
            .HasForeignKey(x => x.OperationCategoryId);

        builder
            .Property(x => x.Amount)
            .HasPrecision(18, 2);
    }
}