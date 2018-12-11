using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NB.Registration.Domain.Aggregates;

namespace NB.Registration.Repository.Config
{
    public class PhysicalPersonConfig : IEntityTypeConfiguration<PhysicalPerson>
    {
        public void Configure(EntityTypeBuilder<PhysicalPerson> builder)
        {
            // Make the Primary Key associated with the property UniqueKey
            builder.HasKey(o => o.ID);

            builder.Property(o => o.Active).IsRequired();
            builder.Property(o => o.Created).IsRequired();
            builder.Property(o => o.Updated).IsRequired();
            builder.Property(o => o.Name);
            builder.Property(o => o.Birthdate);

            builder.HasMany(a => a.InternetAddresses)
                   .WithOne(b => b.PhysicalPerson)
                   .HasForeignKey(a => a.PhysicalPersonID)
                   .IsRequired();

            builder.HasMany(a => a.Documents)
                   .WithOne(b => b.PhysicalPerson)
                   .HasForeignKey(a => a.PhysicalPersonID)
                   .IsRequired();

            builder.HasMany(a => a.Persons)
                   .WithOne(b => b.PhysicalPerson)
                   .HasForeignKey(a => a.PhysicalPersonID)
                   .IsRequired();


            builder.ToTable("PhysicalPerson");
        }
    }
}
