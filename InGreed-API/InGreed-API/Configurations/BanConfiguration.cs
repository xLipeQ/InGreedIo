using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime;

namespace InGreed_API.Configurations
{
    public class BanConfiguration : IEntityTypeConfiguration<Ban>
    {
        public void Configure(EntityTypeBuilder<Ban> builder)
        {
            // Column names
            builder.Property(b => b.Id)
                .HasColumnName("ban_id");

            builder.Property(b => b.UserId)
                .HasColumnName("user_id");

            builder.Property(b => b.Reason)
                .HasColumnName("reason");

            // Table relations
            builder.HasOne(b => b.User)
                .WithMany(u => u.Bans)
                .HasForeignKey(b => b.UserId);

            // Default values
            var bans = new List<Ban>()
            {
                new Ban() { Id = 1, UserId = 2, Reason = "Bad behavior" }
            };

            builder.HasData(bans);
        }
    }
}

