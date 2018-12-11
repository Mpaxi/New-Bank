using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace NB.CheckingAccountTransaction.Repository.Config
{
    public class CheckingAccountTransactionConfig : IEntityTypeConfiguration<Domain.Aggregates.CheckingAccountTransaction>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregates.CheckingAccountTransaction> builder)
        {
            builder.HasKey(o => o.ID);


            builder.Property(o => o.Active).IsRequired();
            builder.Property(o => o.Created).IsRequired();
            builder.Property(o => o.Updated).IsRequired();
            builder.Property(o => o.TracedID).IsRequired();
            builder.Property(o => o.TransactionValue).HasColumnType("decimal(18, 2)").IsRequired();
            builder.HasAlternateKey(k => new { k.CheckingAccountID, k.TracedID });

            builder.HasOne(a => a.CheckingAccount).WithMany(b => b.CheckingAccountTransaction).HasForeignKey(k => k.CheckingAccountID).IsRequired();
            builder.HasOne(a => a.CheckingAccountTransactionStatus).WithMany(b => b.CheckingAccountTransaction).IsRequired();
            builder.HasOne(a => a.CheckingAccountTransactionType).WithMany(b => b.CheckingAccountTransaction).IsRequired();
            builder.HasOne(a => a.CurrencyType).WithMany(b => b.CheckingAccountTransaction).IsRequired();

            builder.ToTable("CheckingAccountTransaction");
        }
    }
}
