using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccsessLayer.Configurations
{
    public class EmailReportRecipientConfiguration
        : IEntityTypeConfiguration<DB_EmailReportRecipient>
    {
        public void Configure(
            EntityTypeBuilder<DB_EmailReportRecipient> builder)
        {
            builder.ToTable("DB_EmailReportRecipient");

            builder.HasKey(x => x.RecId);

            builder.Property(x => x.ReportCode)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.EmailAddress)
                .HasMaxLength(320)
                .IsRequired();

            builder.HasIndex(x => new { x.ReportCode, x.EmailAddress })
            .IsUnique()
            .HasFilter("[DeleteDate] IS NULL");

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.HasIndex(x => new
            {
                x.ReportCode,
                x.EmailAddress
            }).IsUnique();
        }
    }
}