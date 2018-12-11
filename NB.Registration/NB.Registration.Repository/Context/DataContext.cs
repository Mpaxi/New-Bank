using Microsoft.EntityFrameworkCore;
using NB.Registration.Domain.Aggregates;
using NB.Registration.Domain.Entities;
using NB.Registration.Repository.Config;
using NB.Registration.Repository.Seeding;
using NB.SupportPackages.DataBase.Base;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NB.Registration.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public virtual DbSet<InternetAddressType> InternetAddressType { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<PhysicalPersonInternetAddress> InternetAddress { get; set; }
        public virtual DbSet<PhysicalPersonDocument> PhysicalPersonDocument { get; set; }
        public virtual DbSet<LegalPersonDocument> LegalPersonDocument { get; set; }
        public virtual DbSet<LegalPerson> LegalPerson { get; set; }
        public virtual DbSet<PhysicalPerson> PhysicalPerson { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new InternetAddressTypeConfig());
            builder.ApplyConfiguration(new DocumentTypeConfig());
            builder.ApplyConfiguration(new PhysicalPersonInternetAddressConfig());
            builder.ApplyConfiguration(new PhysicalPersonDocumentConfig());
            builder.ApplyConfiguration(new LegalPersonInternetAddressConfig());
            builder.ApplyConfiguration(new LegalPersonDocumentConfig());
            builder.ApplyConfiguration(new LegalPersonConfig());
            builder.ApplyConfiguration(new PhysicalPersonConfig());
            builder.ApplyConfiguration(new PersonsConfig());

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
