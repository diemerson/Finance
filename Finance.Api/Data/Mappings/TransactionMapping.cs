using Finance.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Api.Data.Mappings;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction");

        builder.HasKey(c => c.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.PaidOrReceivedAt);

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.Amount)
            .IsRequired();

        builder.Property(x => x.CategoryId)
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasMaxLength(160);
    }
}
