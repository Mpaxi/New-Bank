﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NB.CheckingAccountTransaction.Repository.Context;

namespace NB.CheckingAccountTransaction.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180918155828_AddAlternativeKey")]
    partial class AddAlternativeKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NB.CheckingAccountTransaction.Domain.Aggregates.CheckingAccountTransaction", b =>
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

                    b.Property<decimal>("TransactionValue")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("Updated")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasAlternateKey("CheckingAccountID", "TracedID");

                    b.HasIndex("CheckingAccountTransactionStatusID");

                    b.HasIndex("CheckingAccountTransactionTypeID");

                    b.HasIndex("CurrencyTypeID");

                    b.ToTable("CheckingAccountTransaction");
                });

            modelBuilder.Entity("NB.CheckingAccountTransaction.Domain.Entities.CheckingAccountTransactionStatus", b =>
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
                });

            modelBuilder.Entity("NB.CheckingAccountTransaction.Domain.Entities.CheckingAccountTransactionType", b =>
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
                });

            modelBuilder.Entity("NB.CheckingAccountTransaction.Domain.Entities.Currency", b =>
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
                });

            modelBuilder.Entity("NB.CheckingAccountTransaction.Domain.Aggregates.CheckingAccountTransaction", b =>
                {
                    b.HasOne("NB.CheckingAccountTransaction.Domain.Entities.CheckingAccountTransactionStatus", "CheckingAccountTransactionStatus")
                        .WithMany("CheckingAccountTransaction")
                        .HasForeignKey("CheckingAccountTransactionStatusID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NB.CheckingAccountTransaction.Domain.Entities.CheckingAccountTransactionType", "CheckingAccountTransactionType")
                        .WithMany("CheckingAccountTransaction")
                        .HasForeignKey("CheckingAccountTransactionTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NB.CheckingAccountTransaction.Domain.Entities.Currency", "CurrencyType")
                        .WithMany("CheckingAccountTransaction")
                        .HasForeignKey("CurrencyTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
