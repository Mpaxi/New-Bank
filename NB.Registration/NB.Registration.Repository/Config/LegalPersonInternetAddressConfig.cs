using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NB.Registration.Domain.Entities;

namespace NB.Registration.Repository.Config
{
    public class LegalPersonInternetAddressConfig : IEntityTypeConfiguration<LegalPersonInternetAddress>
    {
        public void Configure(EntityTypeBuilder<LegalPersonInternetAddress> builder)
        {
            // Make the Primary Key associated with the property UniqueKey
            builder.HasKey(o => o.ID);

            builder.Property(o => o.Active).IsRequired();
            builder.Property(o => o.Created).IsRequired();
            builder.Property(o => o.Updated).IsRequired();
            builder.Property(o => o.Value);

            builder.HasOne(a => a.InternetAddressType)
                   .WithMany(b => b.LegalPersonInternetAddress)
                   .HasForeignKey(a => a.InternetAddressTypeID)
                   .IsRequired();

            builder.ToTable("LegalPersonInternetAddress");
        }
    }
}