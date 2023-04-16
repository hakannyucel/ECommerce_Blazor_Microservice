using CatalogService.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.WebApi.Domain.Configurations
{
    public class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("CatalogItems");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Name);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.CreatedDate).HasColumnType("timestamp without time zone").IsRequired();
            builder.Property(x => x.UpdatedDate).HasColumnType("timestamp without time zone").IsRequired(false);
        }
    }
}
