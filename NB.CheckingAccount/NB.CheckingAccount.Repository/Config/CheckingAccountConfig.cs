using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NB.CheckingAccount.Repository.Config
{
    public class CheckingAccountConfig : IEntityTypeConfiguration<Domain.Aggregates.CheckingAccount>
    {
        public void Configure(EntityTypeBuilder<Domain.Aggregates.CheckingAccount> builder)
        {
            // Make the Primary Key associated with the property UniqueKey
            builder.HasKey(o => o.ID);
            builder.HasAlternateKey(o => o.Number);

            builder.Property(o => o.Active).IsRequired();
            builder.Property(o => o.Created).IsRequired();
            builder.Property(o => o.Updated).IsRequired();
            builder.Property(o => o.Agency).IsRequired();
            builder.Property(o => o.Number).IsRequired();

            builder.HasOne(a => a.Status).WithMany(b => b.CheckingAccount).IsRequired();
            builder.HasOne(a => a.AccountType).WithMany(b => b.CheckingAccount).IsRequired();

            builder.ToTable("CheckingAccount");
        }
    }
}
