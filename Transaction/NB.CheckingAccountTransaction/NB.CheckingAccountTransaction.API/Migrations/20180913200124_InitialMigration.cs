using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NB.CheckingAccountTransaction.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckingAccountTransactionStatus",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingAccountTransactionStatus", x => x.ID);
                    table.UniqueConstraint("AK_CheckingAccountTransactionStatus_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CheckingAccountTransactionType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingAccountTransactionType", x => x.ID);
                    table.UniqueConstraint("AK_CheckingAccountTransactionType_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.ID);
                    table.UniqueConstraint("AK_Currency_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CheckingAccountTransaction",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    TransactionValue = table.Column<decimal>(nullable: false),
                    TracedID = table.Column<Guid>(nullable: false),
                    CheckingAccountTransactionStatusID = table.Column<Guid>(nullable: false),
                    CheckingAccountTransactionTypeID = table.Column<Guid>(nullable: false),
                    CheckingAccountID = table.Column<Guid>(nullable: false),
                    CurrencyTypeID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingAccountTransaction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckingAccountTransaction_CheckingAccountTransactionStatus_CheckingAccountTransactionStatusID",
                        column: x => x.CheckingAccountTransactionStatusID,
                        principalTable: "CheckingAccountTransactionStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckingAccountTransaction_CheckingAccountTransactionType_CheckingAccountTransactionTypeID",
                        column: x => x.CheckingAccountTransactionTypeID,
                        principalTable: "CheckingAccountTransactionType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckingAccountTransaction_Currency_CurrencyTypeID",
                        column: x => x.CurrencyTypeID,
                        principalTable: "Currency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CheckingAccountTransactionStatus",
                columns: new[] { "ID", "Active", "Code", "Created", "Description", "Updated" },
                values: new object[,]
                {
                    { new Guid("d314587d-3edb-4911-8b21-0249b0bb0005"), true, 1, new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc), "Authorized", new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc) },
                    { new Guid("fb45206b-1d23-42c0-8f48-fb663f56b6ea"), true, 2, new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc), "Canceled", new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc) },
                    { new Guid("000c0e7b-3a34-4612-803b-b6510ddfdb26"), true, 3, new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc), "In Analysis", new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "CheckingAccountTransactionType",
                columns: new[] { "ID", "Active", "Code", "Created", "Description", "Updated" },
                values: new object[,]
                {
                    { new Guid("30685f6d-f398-46f4-a147-2e99d7ec045a"), true, 1, new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc), "Internal Transfer", new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc) },
                    { new Guid("fa5af19c-58f5-458b-b887-fd0dc37bd1e1"), true, 2, new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc), "External Transfer", new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc) },
                    { new Guid("0d0c7992-7689-45de-8ae7-96db73eab84f"), true, 3, new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc), "Transfer Fee", new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "ID", "Active", "Code", "Created", "Description", "Symbol", "Updated" },
                values: new object[,]
                {
                    { new Guid("6b577276-ddc9-4c8e-896a-eee8396eff82"), true, 1, new DateTime(2018, 9, 13, 20, 1, 23, 749, DateTimeKind.Utc), "BRL", "R$", new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc) },
                    { new Guid("31007805-21e7-401c-834f-723fc441731a"), true, 2, new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc), "USD", "$", new DateTime(2018, 9, 13, 20, 1, 23, 750, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckingAccountTransaction_CheckingAccountTransactionStatusID",
                table: "CheckingAccountTransaction",
                column: "CheckingAccountTransactionStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingAccountTransaction_CheckingAccountTransactionTypeID",
                table: "CheckingAccountTransaction",
                column: "CheckingAccountTransactionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingAccountTransaction_CurrencyTypeID",
                table: "CheckingAccountTransaction",
                column: "CurrencyTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckingAccountTransaction");

            migrationBuilder.DropTable(
                name: "CheckingAccountTransactionStatus");

            migrationBuilder.DropTable(
                name: "CheckingAccountTransactionType");

            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
