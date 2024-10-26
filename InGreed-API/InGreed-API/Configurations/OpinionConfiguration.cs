using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InGreed_API.Configurations
{
    public class OpinionConfiguration : IEntityTypeConfiguration<Opinion>
    {
        public void Configure(EntityTypeBuilder<Opinion> builder)
        {
            // Primary key
            builder.HasKey(o => new { o.ProductId, o.UserId });

            // Column names
            builder.Property(o => o.ProductId)
                .HasColumnName("product_id");

            builder.Property(o => o.UserId)
                .HasColumnName("user_id");

            builder.Property(o => o.Comment)
                .HasColumnName("comment");

            builder.Property(o => o.Rating)
                .HasColumnName("rating");

            // Table relations
            builder.HasOne(o => o.Product)
                .WithMany(p => p.Opinions)
                .HasForeignKey(o => o.ProductId);

            builder.HasOne(o => o.User)
                .WithMany(u => u.Opinions)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Default values
            var opinions = new List<Opinion>()
            {
                new Opinion() { ProductId = 2, UserId = 1, Comment = "Useful product", Rating = 5 },
                new Opinion() { ProductId = 2, UserId = 2, Comment = "Awful product", Rating = 1 },
                new Opinion() { ProductId = 3, UserId = 1, Comment = "Decent product", Rating = 4 }
            };

            builder.HasData(opinions);
        }
    }
}
