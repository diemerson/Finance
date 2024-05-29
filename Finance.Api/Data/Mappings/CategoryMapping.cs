using Finance.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Api.Data.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Finance_Category");

        builder.HasKey(c => c.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(x => x.Description)
            .HasMaxLength(255);

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasMaxLength(160);
    }
}
