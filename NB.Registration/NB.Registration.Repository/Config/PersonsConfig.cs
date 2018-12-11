using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NB.Registration.Domain.Entities;

namespace NB.Registration.Repository.Config
{
    public class PersonsConfig : IEntityTypeConfiguration<Persons>
    {
        public void Configure(EntityTypeBuilder<Persons> builder)
        {
            builder.HasKey(o => o.ID);

            builder.Property(o => o.Active).IsRequired();
            builder.Property(o => o.Created).IsRequired();
            builder.Property(o => o.Updated).IsRequired();

            builder.HasOne(a => a.PhysicalPerson)
                   .WithMany(b => b.Persons);

            builder.HasOne(a => a.LegalPersons)
                   .WithMany(b => b.Persons);

            builder.ToTable("Persons");
        }
    }
}
