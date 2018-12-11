using Microsoft.EntityFrameworkCore;
using NB.CheckingAccountTransaction.Domain.Entities;
using System;

namespace NB.CheckingAccountTransaction.Repository.Seeding
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency { ID = Guid.Parse("6B577276-DDC9-4C8E-896A-EEE8396EFF82"), Code = 1, Description = "BRL", Symbol = "R$", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new Currency { ID = Guid.Parse("31007805-21E7-401C-834F-723FC441731A"), Code = 2, Description = "USD", Symbol = "$", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow }
            );


            modelBuilder.Entity<CheckingAccountTransactionType>().HasData(
                new CheckingAccountTransactionType { ID = Guid.Parse("30685F6D-F398-46F4-A147-2E99D7EC045A"), Code = 1, Description = "Internal Transfer", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new CheckingAccountTransactionType { ID = Guid.Parse("FA5AF19C-58F5-458B-B887-FD0DC37BD1E1"), Code = 2, Description = "External Transfer", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new CheckingAccountTransactionType { ID = Guid.Parse("0D0C7992-7689-45DE-8AE7-96DB73EAB84F"), Code = 3, Description = "Transfer Fee", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new CheckingAccountTransactionType { ID = Guid.Parse("5FE4FB15-A944-4718-A539-2E269694773A"), Code = 3, Description = "Credit Card Transaction", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow }
            );

            modelBuilder.Entity<CheckingAccountTransactionStatus>().HasData(
                new CheckingAccountTransactionStatus { ID = Guid.Parse("D314587D-3EDB-4911-8B21-0249B0BB0005"), Code = 1, Description = "Authorized", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new CheckingAccountTransactionStatus { ID = Guid.Parse("FB45206B-1D23-42C0-8F48-FB663F56B6EA"), Code = 2, Description = "Canceled", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new CheckingAccountTransactionStatus { ID = Guid.Parse("000C0E7B-3A34-4612-803B-B6510DDFDB26"), Code = 3, Description = "In Analysis", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow }
            );

            modelBuilder.Entity<CheckingAccountStatus>().HasData(
                new CheckingAccountStatus { ID = Guid.Parse("F226FAEA-4E74-4826-B757-3374C378C072"),  Description = "Authorized", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new CheckingAccountStatus { ID = Guid.Parse("72F63D9F-DC92-4507-9BC9-F27BD086B213"),  Description = "Canceled", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new CheckingAccountStatus { ID = Guid.Parse("CAE7E4DC-D43F-49CD-BF6C-A0DB1707E4C1"),  Description = "Blocked", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new CheckingAccountStatus { ID = Guid.Parse("5D6673D8-48B5-4FEB-805F-769BEA37CEB3"),  Description = "In Analysis", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow }
            );

        }
    }
}
