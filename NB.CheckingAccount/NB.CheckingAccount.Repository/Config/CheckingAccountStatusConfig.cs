using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NB.CheckingAccount.Domain.Entities;

namespace NB.CheckingAccount.Repository.Config
{
    public class CheckingAccountStatusConfig : IEntityTypeConfiguration<CheckingAccountStatus>
    {
        public void Configure(EntityTypeBuilder<CheckingAccountStatus> builder)
        {
            // Make the Primary Key associated with the property UniqueKey
            builder.HasKey(o => o.ID);
            builder.HasAlternateKey(o => o.Code);

            builder.Property(o => o.Active).IsRequired();
            builder.Property(o => o.Created).IsRequired();
            builder.Property(o => o.Updated).IsRequired();
            builder.Property(o => o.Description);

            builder.ToTable("CheckingAccountStatus");
        }
    }
}
