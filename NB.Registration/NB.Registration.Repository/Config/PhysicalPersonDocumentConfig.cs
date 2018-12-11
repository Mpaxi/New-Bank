using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NB.Registration.Domain.Entities;

namespace NB.Registration.Repository.Config
{
    public class PhysicalPersonDocumentConfig : IEntityTypeConfiguration<PhysicalPersonDocument>
    {
        public void Configure(EntityTypeBuilder<PhysicalPersonDocument> builder)
        {
            // Make the Primary Key associated with the property UniqueKey
            builder.HasKey(o => o.ID);

            builder.Property(o => o.Active).IsRequired();
            builder.Property(o => o.Created).IsRequired();
            builder.Property(o => o.Updated).IsRequired();
            builder.Property(o => o.Value);
            builder.Property(o => o.ValidDate);

            builder.HasOne(a => a.DocumentType)
                   .WithMany(b => b.PhysicalPersonDocument)
                   .HasForeignKey(a => a.DocumentTypeID)
                   .IsRequired();

            builder.HasOne(a => a.PhysicalPerson)
                   .WithMany(b => b.Documents)
                   .HasForeignKey(a => a.PhysicalPersonID);


            builder.ToTable("PhysicalPersonDocument");
        }
    }
}
