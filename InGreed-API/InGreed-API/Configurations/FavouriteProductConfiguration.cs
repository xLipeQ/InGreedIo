using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InGreed_API.Configurations
{
    public class FavouriteProductConfiguration : IEntityTypeConfiguration<FavouriteProduct>
    {
        public void Configure(EntityTypeBuilder<FavouriteProduct> builder)
        {
            // Primary key
            builder.HasKey(fp => new { fp.UserId, fp.ProductId });

            // Column names
            builder.Property(fp => fp.UserId)
                .HasColumnName("user_id");

            builder.Property(fp => fp.ProductId)
                .HasColumnName("product_id");

            // Table relations
            builder.HasOne(fp => fp.User)
                .WithMany(u => u.FavouriteProducts)
                .HasForeignKey(fp => fp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(fp => fp.Product)
                .WithMany(p => p.FavouriteProducts)
                .HasForeignKey(fp => fp.ProductId);

            // Default values
            var favouriteProducts = new List<FavouriteProduct>()
            {
                new FavouriteProduct { UserId = 1, ProductId = 2 }
            };

            builder.HasData(favouriteProducts);
        }
    }
}
