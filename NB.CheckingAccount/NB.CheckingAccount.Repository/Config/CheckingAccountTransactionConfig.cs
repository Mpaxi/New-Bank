using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NB.CheckingAccount.Domain.Aggregates;

namespace NB.CheckingAccount.Repository.Config
{
    public class CheckingAccountTransactionConfig : IEntityTypeConfiguration<CheckingAccountTransaction>
    {
        public void Configure(EntityTypeBuilder<CheckingAccountTransaction> builder)
        {
            builder.HasKey(o => o.ID);


            builder.Property(o => o.Active).IsRequired();
            builder.Property(o => o.Created).IsRequired();
            builder.Property(o => o.Updated).IsRequired();
            builder.Property(o => o.TracedID).IsRequired();
            builder.Property(o => o.Value).IsRequired();


            builder.HasOne(a => a.CheckingAccount).WithMany(b => b.CheckingAccountTransaction).IsRequired();
            builder.HasOne(a => a.CheckingAccountTransactionStatus).WithMany(b => b.CheckingAccountTransaction).IsRequired();
            builder.HasOne(a => a.CheckingAccountTransactionType).WithMany(b => b.CheckingAccountTransaction).IsRequired();
            builder.HasOne(a => a.CurrencyType).WithMany(b => b.CheckingAccountTransaction).IsRequired();

            builder.ToTable("CheckingAccountTransaction");
        }
    }
}
