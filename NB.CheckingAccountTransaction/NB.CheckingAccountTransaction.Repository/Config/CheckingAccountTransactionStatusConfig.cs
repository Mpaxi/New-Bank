using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NB.CheckingAccountTransaction.Domain.Entities;

namespace NB.CheckingAccountTransaction.Repository.Config
{
    public class CheckingAccountTransactionStatusConfig : IEntityTypeConfiguration<CheckingAccountTransactionStatus>
    {
        public void Configure(EntityTypeBuilder<CheckingAccountTransactionStatus> builder)
        {
            // Make the Primary Key associated with the property UniqueKey
            builder.HasKey(o => o.ID);
            builder.HasAlternateKey(o => o.Code);

            builder.Property(o => o.Active).IsRequired();
            builder.Property(o => o.Created).IsRequired();
            builder.Property(o => o.Updated).IsRequired();
            builder.Property(o => o.Description);

            builder.ToTable("CheckingAccountTransactionStatus");
        }
    }
}
