﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using NB.CheckingAccount.Domain.Context;
using System;

namespace NB.CheckingAccount.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NB.CheckingAccount.Domain.Aggregates.CheckingAccount", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("Account");

                    b.Property<Guid>("AccountTypeID");

                    b.Property<bool>("Active");

                    b.Property<long>("Agency");

                    b.Property<DateTime>("Created");

                    b.Property<long>("Number");

                    b.Property<Guid>("StatusID");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("ID");

                    b.HasIndex("AccountTypeID");

                    b.HasIndex("StatusID");

                    b.ToTable("CheckingAccount");

                    b.HasData(
                        new { ID = new Guid("2ebf432e-93db-4471-9585-b02f20d8ce1e"), Account = 1L, AccountTypeID = new Guid("859c7f23-a9d5-4146-9d45-2463aaad46d1"), Active = true, Agency = 1L, Created = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc), Number = 1L, StatusID = new Guid("f226faea-4e74-4826-b757-3374c378c072"), Updated = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc) },
                        new { ID = new Guid("5919c21f-e390-44ad-841a-58789b893d0c"), Account = 1L, AccountTypeID = new Guid("1417063b-b22d-4c68-8784-db4d32d9fdb5"), Active = true, Agency = 1L, Created = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc), Number = 2L, StatusID = new Guid("f226faea-4e74-4826-b757-3374c378c072"), Updated = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc) }
                    );
                });

            modelBuilder.Entity("NB.CheckingAccount.Domain.Aggregates.CheckingAccountTransaction", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid>("CheckingAccountID");

                    b.Property<Guid>("CheckingAccountTransactionStatusID");

                    b.Property<Guid>("CheckingAccountTransactionTypeID");

                    b.Property<DateTime>("Created");

                    b.Property<Guid>("CurrencyTypeID");

                    b.Property<Guid>("TracedID");

                    b.Property<DateTime?>("Updated")
                        .IsRequired();

                    b.Property<decimal>("Value");

                    b.HasKey("ID");

                    b.HasIndex("CheckingAccountID");

                    b.HasIndex("CheckingAccountTransactionStatusID");

                    b.HasIndex("CheckingAccountTransactionTypeID");

                    b.HasIndex("CurrencyTypeID");

                    b.ToTable("CheckingAccountTransaction");

                    b.HasData(
                        new { ID = new Guid("cdea315f-54f7-4bf9-977a-70b93557bf32"), Active = true, CheckingAccountID = new Guid("2ebf432e-93db-4471-9585-b02f20d8ce1e"), CheckingAccountTransactionStatusID = new Guid("d314587d-3edb-4911-8b21-0249b0bb0005"), CheckingAccountTransactionTypeID = new Guid("30685f6d-f398-46f4-a147-2e99d7ec045a"), Created = new DateTime(2018, 8, 28, 21, 16, 24, 830, DateTimeKind.Utc), CurrencyTypeID = new Guid("6b577276-ddc9-4c8e-896a-eee8396eff82"), TracedID = new Guid("68f74513-a51f-4ac1-9a3c-3a62534cc5fa"), Updated = new DateTime(2018, 8, 28, 21, 16, 24, 830, DateTimeKind.Utc), Value = 10000m }
                    );
                });

            modelBuilder.Entity("NB.CheckingAccount.Domain.Entities.CheckingAccountStatus", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("Code");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("Updated")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasAlternateKey("Code");

                    b.ToTable("CheckingAccountStatus");

                    b.HasData(
                        new { ID = new Guid("f226faea-4e74-4826-b757-3374c378c072"), Active = true, Code = 1, Created = new DateTime(2018, 8, 28, 21, 16, 24, 828, DateTimeKind.Utc), Description = "Authorized", Updated = new DateTime(2018, 8, 28, 21, 16, 24, 828, DateTimeKind.Utc) },
                        new { ID = new Guid("72f63d9f-dc92-4507-9bc9-f27bd086b213"), Active = true, Code = 2, Created = new DateTime(2018, 8, 28, 21, 16, 24, 828, DateTimeKind.Utc), Description = "Canceled", Updated = new DateTime(2018, 8, 28, 21, 16, 24, 828, DateTimeKind.Utc) },
                        new { ID = new Guid("cae7e4dc-d43f-49cd-bf6c-a0db1707e4c1"), Active = true, Code = 3, Created = new DateTime(2018, 8, 28, 21, 16, 24, 828, DateTimeKind.Utc), Description = "Blocked", Updated = new DateTime(2018, 8, 28, 21, 16, 24, 828, DateTimeKind.Utc) },
                        new { ID = new Guid("5d6673d8-48b5-4feb-805f-769bea37ceb3"), Active = true, Code = 4, Created = new DateTime(2018, 8, 28, 21, 16, 24, 828, DateTimeKind.Utc), Description = "In Analysis", Updated = new DateTime(2018, 8, 28, 21, 16, 24, 828, DateTimeKind.Utc) }
                    );
                });

            modelBuilder.Entity("NB.CheckingAccount.Domain.Entities.CheckingAccountTransactionStatus", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("Code");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("Updated")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasAlternateKey("Code");

                    b.ToTable("CheckingAccountTransactionStatus");

                    b.HasData(
                        new { ID = new Guid("d314587d-3edb-4911-8b21-0249b0bb0005"), Active = true, Code = 1, Created = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc), Description = "Authorized", Updated = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc) },
                        new { ID = new Guid("fb45206b-1d23-42c0-8f48-fb663f56b6ea"), Active = true, Code = 2, Created = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc), Description = "Canceled", Updated = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc) },
                        new { ID = new Guid("000c0e7b-3a34-4612-803b-b6510ddfdb26"), Active = true, Code = 3, Created = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc), Description = "In Analysis", Updated = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc) }
                    );
                });

            modelBuilder.Entity("NB.CheckingAccount.Domain.Entities.CheckingAccountTransactionType", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("Code");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("Updated")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasAlternateKey("Code");

                    b.ToTable("CheckingAccountTransactionType");

                    b.HasData(
                        new { ID = new Guid("30685f6d-f398-46f4-a147-2e99d7ec045a"), Active = true, Code = 1, Created = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc), Description = "Internal Transfer", Updated = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc) },
                        new { ID = new Guid("fa5af19c-58f5-458b-b887-fd0dc37bd1e1"), Active = true, Code = 2, Created = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc), Description = "External Transfer", Updated = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc) },
                        new { ID = new Guid("0d0c7992-7689-45de-8ae7-96db73eab84f"), Active = true, Code = 3, Created = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc), Description = "Transfer Fee", Updated = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc) }
                    );
                });

            modelBuilder.Entity("NB.CheckingAccount.Domain.Entities.CheckingAccountType", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("Code");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("Updated")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasAlternateKey("Code");

                    b.ToTable("CheckingAccountType");

                    b.HasData(
                        new { ID = new Guid("1417063b-b22d-4c68-8784-db4d32d9fdb5"), Active = true, Code = 1, Created = new DateTime(2018, 8, 28, 21, 16, 24, 828, DateTimeKind.Utc), Description = "Physical Person", Updated = new DateTime(2018, 8, 28, 21, 16, 24, 828, DateTimeKind.Utc) },
                        new { ID = new Guid("859c7f23-a9d5-4146-9d45-2463aaad46d1"), Active = true, Code = 2, Created = new DateTime(2018, 8, 28, 21, 16, 24, 828, DateTimeKind.Utc), Description = "Legal Person", Updated = new DateTime(2018, 8, 28, 21, 16, 24, 828, DateTimeKind.Utc) }
                    );
                });

            modelBuilder.Entity("NB.CheckingAccount.Domain.Entities.Currency", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("Code");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("Symbol");

                    b.Property<DateTime?>("Updated")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasAlternateKey("Code");

                    b.ToTable("Currency");

                    b.HasData(
                        new { ID = new Guid("6b577276-ddc9-4c8e-896a-eee8396eff82"), Active = true, Code = 1, Created = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc), Description = "BRL", Symbol = "R$", Updated = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc) },
                        new { ID = new Guid("31007805-21e7-401c-834f-723fc441731a"), Active = true, Code = 2, Created = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc), Description = "USD", Symbol = "$", Updated = new DateTime(2018, 8, 28, 21, 16, 24, 829, DateTimeKind.Utc) }
                    );
                });

            modelBuilder.Entity("NB.CheckingAccount.Domain.Aggregates.CheckingAccount", b =>
                {
                    b.HasOne("NB.CheckingAccount.Domain.Entities.CheckingAccountType", "AccountType")
                        .WithMany("CheckingAccount")
                        .HasForeignKey("AccountTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NB.CheckingAccount.Domain.Entities.CheckingAccountStatus", "Status")
                        .WithMany("CheckingAccount")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NB.CheckingAccount.Domain.Aggregates.CheckingAccountTransaction", b =>
                {
                    b.HasOne("NB.CheckingAccount.Domain.Aggregates.CheckingAccount", "CheckingAccount")
                        .WithMany("CheckingAccountTransaction")
                        .HasForeignKey("CheckingAccountID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NB.CheckingAccount.Domain.Entities.CheckingAccountTransactionStatus", "CheckingAccountTransactionStatus")
                        .WithMany("CheckingAccountTransaction")
                        .HasForeignKey("CheckingAccountTransactionStatusID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NB.CheckingAccount.Domain.Entities.CheckingAccountTransactionType", "CheckingAccountTransactionType")
                        .WithMany("CheckingAccountTransaction")
                        .HasForeignKey("CheckingAccountTransactionTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NB.CheckingAccount.Domain.Entities.Currency", "CurrencyType")
                        .WithMany("CheckingAccountTransaction")
                        .HasForeignKey("CurrencyTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
