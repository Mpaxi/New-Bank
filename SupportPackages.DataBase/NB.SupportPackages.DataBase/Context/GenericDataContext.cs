using Microsoft.EntityFrameworkCore;
using NB.SupportPackages.DataBase.Base;
using System;
using System.Linq;

namespace NB.SupportPackages.DataBase.Context
{
    public partial class GenericDataContext : DbContext
    {
        public GenericDataContext() : base() { }

        public override int SaveChanges()
        {
            TrackChanges();
            return base.SaveChanges();
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
