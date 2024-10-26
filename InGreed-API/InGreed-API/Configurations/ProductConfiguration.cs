using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InGreed_API.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Column names
            builder.Property(p => p.Id)
                .HasColumnName("product_id");

            builder.Property(p => p.Name)
                .HasColumnName("product_name");

            builder.Property(p => p.ProducentId)
                .HasColumnName("producent_id");
            
            builder.Property(p => p.Description)
                .HasColumnName("description");

            // Table relations
            builder.HasOne(p => p.Producent)
                .WithMany(u => u.Products)
                .HasForeignKey(p => p.ProducentId);

            // Default values
            var products = new List<Product>();

            for (int i = 1; i <= 12; i++)
                products.Add(new Product() { Id = i, Description = "Very good shampoo", Name = $"Premium Shampoo N{i}", ProducentId = 3 });

            builder.HasData(products);
        }
    }
}
