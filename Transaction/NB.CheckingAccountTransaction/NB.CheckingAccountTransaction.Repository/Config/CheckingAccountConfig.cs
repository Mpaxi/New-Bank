using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NB.CheckingAccountTransaction.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NB.CheckingAccountTransaction.Repository.Config
{
    public class CheckingAccountConfig : IEntityTypeConfiguration<CheckingAccount>
    {
        public void Configure(EntityTypeBuilder<CheckingAccount> builder)
        {
            // Make the Primary Key associated with the property UniqueKey
            builder.HasKey(o => o.ID);
            builder.Property(o => o.Active).IsRequired();
            builder.Property(o => o.Created).IsRequired();
            builder.Property(o => o.Updated).IsRequired();

            builder.HasOne(a => a.Status).WithMany(b => b.CheckingAccount).IsRequired();

            builder.ToTable("CheckingAccount");
        }
    }
}
