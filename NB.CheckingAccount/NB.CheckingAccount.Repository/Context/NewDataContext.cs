using Microsoft.EntityFrameworkCore;
using NB.CheckingAccount.Domain.Entities;
using NB.CheckingAccount.Repository.Config;
using NB.SupportPackages.DataBase.Context;

namespace NB.CheckingAccount.Repository.Context
{
    public class NewDataContext : GenericDataContext
    {
        public NewDataContext(DbContextOptions<NewDataContext> options) : base() { }

        public virtual DbSet<CheckingAccountStatus> TransferenciasArquivos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CheckingAccountStatusConfig());

        }

    }
}
