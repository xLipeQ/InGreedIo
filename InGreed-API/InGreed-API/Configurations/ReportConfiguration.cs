using InGreed_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InGreed_API.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(p => p.Id);

            // Column names
            builder.Property(b => b.Id)
                .HasColumnName("id");

            builder.Property(b => b.ProductId)
                .HasColumnName("product_id");

            builder.Property(b => b.ReporterId)
                .HasColumnName("reporter_id");

            builder.Property(b => b.OpinionCreatorId)
                .HasColumnName("opinion_creator_id");

            builder.Property(b => b.Reason)
                .HasColumnName("reason")
                .HasMaxLength(100);
        }
    }
}
