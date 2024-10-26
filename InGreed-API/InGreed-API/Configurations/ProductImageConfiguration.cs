using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InGreed_API.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            // Column names
            builder.Property(pi => pi.Id)
                .HasColumnName("image_id");

            builder.Property(pi => pi.Image)
                .HasColumnName("image");

            builder.Property(pi => pi.ProductId)
                .HasColumnName("product_id");

            // Table relations
            builder.HasOne(pi => pi.Product)
                .WithOne(u => u.Image)
                .HasForeignKey<ProductImage>(pi => pi.ProductId);

            // Default values
            var products = new List<ProductImage>();

            for (int i = 1; i <= 12; i++)
                products.Add(new ProductImage() { Id = i, ProductId = i, Image = [] });

            builder.HasData(products);
        }
    }
}
