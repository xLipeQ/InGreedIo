using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InGreed_API.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            // Column names
            builder.Property(pc => pc.Id)
                .HasColumnName("id");

            builder.Property(pc => pc.ProductId)
                .HasColumnName("product_id");

            builder.Property(pc => pc.CategoryId)
                .HasColumnName("category_id");

            // Table relations
            builder.HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategory)
                .HasForeignKey(pc => pc.ProductId);

            builder.HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategory)
                .HasForeignKey(pc => pc.CategoryId);

            // Default values
            var productCategories = new List<ProductCategory>()
            {
                new ProductCategory() { Id = 1, ProductId = 1, CategoryId = 1 }
            };

            builder.HasData(productCategories);
        }
    }
}
