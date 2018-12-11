using Microsoft.EntityFrameworkCore;
using NB.CheckingAccountTransaction.Domain.Entities;
using NB.CheckingAccountTransaction.Repository.Config;
using NB.CheckingAccountTransaction.Repository.Seeding;
using NB.SupportPackages.DataBase.Base;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NB.CheckingAccountTransaction.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public virtual DbSet<Domain.Aggregates.CheckingAccountTransaction> CheckingAccountTransaction { get; set; }
        public virtual DbSet<CheckingAccountTransactionStatus> CheckingAccountTransactionStatus { get; set; }
        public virtual DbSet<CheckingAccountTransactionType> CheckingAccountTransactionType { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CheckingAccountTransactionConfig());
            builder.ApplyConfiguration(new CheckingAccountTransactionStatusConfig());
            builder.ApplyConfiguration(new CheckingAccountTransactionTypeConfig());
            builder.ApplyConfiguration(new CurrencyConfig());

            builder.EnableSqlServerDateDIFF();
            builder.Seed();

        }

        public override int SaveChanges()
        {
            TrackChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            TrackChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void TrackChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Entity is EntityBase)
                {
                    var auditable = entry.Entity as EntityBase;
                    if (entry.State == EntityState.Added)
                    {
                        //auditable.CreatedBy = UserProvider;//
                        auditable.Created = TimestampProvider();
                        auditable.Active = true;
                        auditable.Updated = TimestampProvider();
                    }
                    else
                    {
                        //auditable.UpdatedBy = UserProvider;
                        auditable.Updated = TimestampProvider();
                    }
                }
            }
        }

        public Func<DateTime> TimestampProvider { get; set; } = () => DateTime.UtcNow;
    }
}
