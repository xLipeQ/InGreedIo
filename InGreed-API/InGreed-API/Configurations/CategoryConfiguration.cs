using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InGreed_API.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Column names
            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.Type)
                .HasColumnName("type");

            // Default values
            var categories = new List<Category>()
            {
                new Category() {Id = 1, Type = "Category1" },
                new Category() {Id = 2, Type = "Category2" },
                new Category() {Id = 3, Type = "Category3" },
                new Category() {Id = 4, Type = "Category4" },
                new Category() {Id = 5, Type = "ACategory" },
                new Category() {Id = 6, Type = "BCategory" },
            };

            builder.HasData(categories);
        }
    }
}
