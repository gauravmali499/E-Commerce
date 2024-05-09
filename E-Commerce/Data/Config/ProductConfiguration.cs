using E_Commerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(25);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Price).HasColumnType("decimal(10,2)");
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(t => t.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
        }
    }
}
