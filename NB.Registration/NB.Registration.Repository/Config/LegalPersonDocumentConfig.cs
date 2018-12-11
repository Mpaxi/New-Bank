using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NB.Registration.Domain.Entities;

namespace NB.Registration.Repository.Config
{
    public class LegalPersonDocumentConfig : IEntityTypeConfiguration<LegalPersonDocument>
    {
        public void Configure(EntityTypeBuilder<LegalPersonDocument> builder)
        {
            // Make the Primary Key associated with the property UniqueKey
            builder.HasKey(o => o.ID);

            builder.Property(o => o.Active).IsRequired();
            builder.Property(o => o.Created).IsRequired();
            builder.Property(o => o.Updated).IsRequired();
            builder.Property(o => o.Value);
            builder.Property(o => o.ValidDate);

            builder.HasOne(a => a.DocumentType)
                   .WithMany(b => b.LegalPersonDocument)
                   .HasForeignKey(a => a.DocumentTypeID)
                   .IsRequired();

            builder.HasOne(a => a.LegalPerson)
                   .WithMany(b => b.Documents)
                   .HasForeignKey(a => a.LegalPersonID);


            builder.ToTable("LegalPersonDocument");
        }
    }
}
