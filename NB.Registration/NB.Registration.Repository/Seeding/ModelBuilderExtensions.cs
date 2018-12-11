using Microsoft.EntityFrameworkCore;
using NB.Registration.Domain.Aggregates;
using NB.Registration.Domain.Entities;
using System;

namespace NB.Registration.Repository.Seeding
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InternetAddressType>().HasData(
                new InternetAddressType { ID = Guid.Parse("83E75FB2-CA4D-4106-9883-ECED908CF1F0"), Description = "Email", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new InternetAddressType { ID = Guid.Parse("20BE7B7F-A96B-4FA4-9920-5F4B2B596D94"), Description = "Push Notification", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow }
            );


            modelBuilder.Entity<DocumentType>().HasData(
                new DocumentType { ID = Guid.Parse("F19C4663-92FB-4B2D-A350-ACC4E4EFFE16"), Description = "Identity", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new DocumentType { ID = Guid.Parse("22276405-5C3A-42CB-A7BC-51D7F9CC24D1"), Description = "Fisical Person Certidicate", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new DocumentType { ID = Guid.Parse("6671066B-CBE3-470C-A776-9A83F9644A38"), Description = "Legal Person Certidicate", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow }
            );

            modelBuilder.Entity<PhysicalPerson>().HasData(
                new PhysicalPerson()
                {
                    ID = Guid.Parse("FF8A2B4D-FAFE-49F3-9D79-CC714DD4AC35"),
                    Birthdate = DateTime.Parse("1991-09-20"),
                    Name = "Murilo Henrique Silva Paxi",
                    Active = true,
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow
                }
            );

            modelBuilder.Entity<LegalPerson>().HasData(
                    new LegalPerson()
                    {
                        ID = Guid.Parse("FC542592-E12D-48A9-9161-F0F2FDDF6F77"),
                        PublicName = "Empresa do Murilo",
                        Name = "Nome Empresa do Murilo",
                        Active = true,
                        Created = DateTime.UtcNow,
                        Updated = DateTime.UtcNow
                    }
            );


            modelBuilder.Entity<PhysicalPersonDocument>().HasData(
                new PhysicalPersonDocument() { ID = Guid.NewGuid(), PhysicalPersonID = Guid.Parse("FF8A2B4D-FAFE-49F3-9D79-CC714DD4AC35"), DocumentTypeID = Guid.Parse("F19C4663-92FB-4B2D-A350-ACC4E4EFFE16"), Value = "3490527361", ValidDate = DateTime.Parse("2020-09-21"), Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow },
                new PhysicalPersonDocument() { ID = Guid.NewGuid(), PhysicalPersonID = Guid.Parse("FF8A2B4D-FAFE-49F3-9D79-CC714DD4AC35"), DocumentTypeID = Guid.Parse("22276405-5C3A-42CB-A7BC-51D7F9CC24D1"), Value = "34011746819", ValidDate = DateTime.Parse("2020-09-21"), Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow }

            );


            modelBuilder.Entity<LegalPersonDocument>().HasData(
                new LegalPersonDocument() { ID = Guid.NewGuid(), LegalPersonID = Guid.Parse("FC542592-E12D-48A9-9161-F0F2FDDF6F77"), DocumentTypeID = Guid.Parse("6671066B-CBE3-470C-A776-9A83F9644A38"), Value = "61059245000189", ValidDate = DateTime.Parse("2020-09-21"), Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow }
            );


            modelBuilder.Entity<PhysicalPersonInternetAddress>().HasData(
                new PhysicalPersonInternetAddress() { ID = Guid.NewGuid(), PhysicalPersonID = Guid.Parse("FF8A2B4D-FAFE-49F3-9D79-CC714DD4AC35"), InternetAddressTypeID = Guid.Parse("83E75FB2-CA4D-4106-9883-ECED908CF1F0"), Value = "murilo.paxi@superdigital.com.br", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow }

            );

            modelBuilder.Entity<LegalPersonInternetAddress>().HasData(
                new LegalPersonInternetAddress() { ID = Guid.NewGuid(), LegalPersonID = Guid.Parse("FC542592-E12D-48A9-9161-F0F2FDDF6F77"), InternetAddressTypeID = Guid.Parse("83E75FB2-CA4D-4106-9883-ECED908CF1F0"), Value = "murilo.paxiPJ@superdigital.com.br", Active = true, Created = DateTime.UtcNow, Updated = DateTime.UtcNow }
            );


            modelBuilder.Entity<Persons>().HasData(
                 new Persons()
                 {
                     ID = Guid.Parse("E02D78B1-685D-46B4-AA4A-816481580F43"),
                     PhysicalPersonID = Guid.Parse("FF8A2B4D-FAFE-49F3-9D79-CC714DD4AC35"),
                     LegalPersonID = Guid.Parse("FC542592-E12D-48A9-9161-F0F2FDDF6F77"),
                     Active = true,
                     Created = DateTime.UtcNow,
                     Updated = DateTime.UtcNow
                 }
            );

        }
    }
}
