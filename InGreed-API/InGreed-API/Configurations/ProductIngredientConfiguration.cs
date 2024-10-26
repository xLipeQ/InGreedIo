using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InGreed_API.Configurations
{
    public class ProductIngredientConfiguration : IEntityTypeConfiguration<ProductIngredient>
    {
        public void Configure(EntityTypeBuilder<ProductIngredient> builder)
        {
            // Column names
            builder.Property(pi => pi.Id)
                .HasColumnName("id");

            builder.Property(pi => pi.ProductId)
                .HasColumnName("product_id");

            builder.Property(pi => pi.IngredientId)
                .HasColumnName("ingredient_id");

            // Table relations
            builder.HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            builder.HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);

            // Default values
            var productIngredients = new List<ProductIngredient>();

            for (int i = 1; i <= 12; i++)
                productIngredients.Add(new ProductIngredient { Id = i, IngredientId = 1, ProductId = i });

            productIngredients.Add(new ProductIngredient { Id = 13, IngredientId = 2, ProductId = 1 });

            builder.HasData(productIngredients);
        }
    }
}
