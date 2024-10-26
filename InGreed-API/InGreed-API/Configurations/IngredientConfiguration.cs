using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace InGreed_API.Configurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            // Column names
            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.Property(i => i.Name)
                .HasColumnName("name");

            builder.Property(i => i.Icon)
                .HasColumnName("icon");

            // Property types
            builder.Property(i => i.Icon)
                .HasColumnType("varbinary(max)");

            // Default values
            var ingredients = new List<Ingredient>()
            {
                new Ingredient() {Id = 1, Name = "Ingredient1", Icon = [] },
                new Ingredient() {Id = 2, Name = "Ingredient2", Icon = [] },
                new Ingredient() {Id = 3, Name = "Ingredient3", Icon = [] },
                new Ingredient() {Id = 4, Name = "Ingredient4", Icon = [] },
                new Ingredient() {Id = 5, Name = "AIngredient", Icon = [] },
                new Ingredient() {Id = 6, Name = "BIngredient", Icon = [] }
            };

            builder.HasData(ingredients);
        }
    }
}
