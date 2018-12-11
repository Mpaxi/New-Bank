using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NB.Registration.Domain.Aggregates;

namespace NB.Registration.Repository.Config
{
    public class LegalPersonConfig : IEntityTypeConfiguration<LegalPerson>
    {
        public void Configure(EntityTypeBuilder<LegalPerson> builder)
        {
            // Make the Primary Key associated with the property UniqueKey
            builder.HasKey(o => o.ID);

            builder.Property(o => o.Active).IsRequired();
            builder.Property(o => o.Created).IsRequired();
            builder.Property(o => o.Updated).IsRequired();
            builder.Property(o => o.Name);
            builder.Property(o => o.PublicName);
            builder.Property(o => o.Birthdate);


            builder.HasMany(a => a.InternetAddresses)
                   .WithOne(b => b.LegalPerson)
                   .HasForeignKey(a => a.LegalPersonID)
                   .IsRequired();

            builder.HasMany(a => a.Documents)
                   .WithOne(b => b.LegalPerson)
                   .HasForeignKey(a => a.LegalPersonID)
                   .IsRequired();

            builder.HasMany(a => a.Persons)
                   .WithOne(b => b.LegalPersons)
                   .HasForeignKey(a => a.LegalPersonID)
                   .IsRequired();


            builder.ToTable("LegalPerson");
        }
    }
}
