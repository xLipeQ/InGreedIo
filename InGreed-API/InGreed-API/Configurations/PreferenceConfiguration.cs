using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InGreed_API.Configurations
{
    public class PreferenceConfiguration : IEntityTypeConfiguration<Preference>
    {
        public void Configure(EntityTypeBuilder<Preference> builder)
        {
            // Primary key
            builder.HasKey(o => new { o.UserId, o.IngredientId });

            // Column names
            builder.Property(p => p.UserId)
                .HasColumnName("user_id");

            builder.Property(p => p.IngredientId)
                .HasColumnName("ingredient_id");

            builder.Property(p => p.PreferenceType)
                .HasColumnName("preference_type");

            // Table relations
            builder.HasOne(p => p.Ingredient)
                .WithMany(i => i.Preferenes)
                .HasForeignKey(p => p.IngredientId);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Preferences)
                .HasForeignKey(p => p.UserId);

            // Default values
            var preferences = new List<Preference>()
            {
                new Preference { UserId = 1, IngredientId = 1, PreferenceType = Enums.PreferenceEnum.Prefered },
                new Preference { UserId = 1, IngredientId = 2, PreferenceType = Enums.PreferenceEnum.Allergen }
            };

            builder.HasData(preferences);
        }
    }
}
