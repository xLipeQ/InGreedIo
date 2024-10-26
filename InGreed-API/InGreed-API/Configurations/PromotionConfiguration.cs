using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InGreed_API.Configurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            // Column names
            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.ProductId)
                .HasColumnName("product_id");

            builder.Property(p => p.Start)
                .HasColumnName("start");

            builder.Property(p => p.End)
                .HasColumnName("end");

            // Table relations
            builder.HasOne(p => p.Product)
                .WithOne(p => p.Promotion)
                .HasForeignKey<Promotion>(p => p.ProductId);

            // Default values
            var promotions = new List<Promotion>()
            {
                new Promotion() {Id = 1, ProductId = 3, Start = DateTime.MinValue, End = DateTime.MaxValue },
                new Promotion() {Id = 2, ProductId = 4, Start = DateTime.MinValue, End = DateTime.MaxValue },
                new Promotion() {Id = 3, ProductId = 5, Start = DateTime.MinValue, End = DateTime.MaxValue }
            };

            builder.HasData(promotions);
        }
    }
}
