using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace NB.CheckingAccount.API.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckingAccountStatus",
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
                    table.PrimaryKey("PK_CheckingAccountStatus", x => x.ID);
                    table.UniqueConstraint("AK_CheckingAccountStatus_Code", x => x.Code);
                });

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
                name: "CheckingAccountType",
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
                    table.PrimaryKey("PK_CheckingAccountType", x => x.ID);
                    table.UniqueConstraint("AK_CheckingAccountType_Code", x => x.Code);
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
                name: "CheckingAccount",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Agency = table.Column<long>(nullable: false),
                    Account = table.Column<long>(nullable: false),
                    Number = table.Column<long>(nullable: false),
                    StatusID = table.Column<Guid>(nullable: false),
                    AccountTypeID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingAccount", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckingAccount_CheckingAccountType_AccountTypeID",
                        column: x => x.AccountTypeID,
                        principalTable: "CheckingAccountType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckingAccount_CheckingAccountStatus_StatusID",
                        column: x => x.StatusID,
                        principalTable: "CheckingAccountStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckingAccountTransaction",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    TracedID = table.Column<Guid>(nullable: false),
                    StatusID = table.Column<Guid>(nullable: false),
                    TypeID = table.Column<Guid>(nullable: false),
                    CheckingAccountID = table.Column<Guid>(nullable: false),
                    CurrencyTypeID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckingAccountTransaction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckingAccountTransaction_CheckingAccount_CheckingAccountID",
                        column: x => x.CheckingAccountID,
                        principalTable: "CheckingAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckingAccountTransaction_Currency_CurrencyTypeID",
                        column: x => x.CurrencyTypeID,
                        principalTable: "Currency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckingAccountTransaction_CheckingAccountTransactionStatus_StatusID",
                        column: x => x.StatusID,
                        principalTable: "CheckingAccountTransactionStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckingAccountTransaction_CheckingAccountTransactionType_TypeID",
                        column: x => x.TypeID,
                        principalTable: "CheckingAccountTransactionType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CheckingAccountStatus",
                columns: new[] { "ID", "Active", "Code", "Created", "Description", "Updated" },
                values: new object[,]
                {
                    { new Guid("f226faea-4e74-4826-b757-3374c378c072"), true, 1, new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc), "Authorized", new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc) },
                    { new Guid("72f63d9f-dc92-4507-9bc9-f27bd086b213"), true, 2, new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc), "Canceled", new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc) },
                    { new Guid("cae7e4dc-d43f-49cd-bf6c-a0db1707e4c1"), true, 3, new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc), "Blocked", new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc) },
                    { new Guid("5d6673d8-48b5-4feb-805f-769bea37ceb3"), true, 4, new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc), "In Analysis", new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "CheckingAccountTransactionStatus",
                columns: new[] { "ID", "Active", "Code", "Created", "Description", "Updated" },
                values: new object[,]
                {
                    { new Guid("d314587d-3edb-4911-8b21-0249b0bb0005"), true, 1, new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc), "Authorized", new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc) },
                    { new Guid("fb45206b-1d23-42c0-8f48-fb663f56b6ea"), true, 2, new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc), "Canceled", new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc) },
                    { new Guid("000c0e7b-3a34-4612-803b-b6510ddfdb26"), true, 3, new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc), "In Analysis", new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "CheckingAccountTransactionType",
                columns: new[] { "ID", "Active", "Code", "Created", "Description", "Updated" },
                values: new object[,]
                {
                    { new Guid("30685f6d-f398-46f4-a147-2e99d7ec045a"), true, 1, new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc), "Internal Transfer", new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc) },
                    { new Guid("fa5af19c-58f5-458b-b887-fd0dc37bd1e1"), true, 2, new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc), "External Transfer", new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc) },
                    { new Guid("0d0c7992-7689-45de-8ae7-96db73eab84f"), true, 3, new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc), "Transfer Fee", new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "CheckingAccountType",
                columns: new[] { "ID", "Active", "Code", "Created", "Description", "Updated" },
                values: new object[,]
                {
                    { new Guid("1417063b-b22d-4c68-8784-db4d32d9fdb5"), true, 1, new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc), "Physical Person", new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc) },
                    { new Guid("859c7f23-a9d5-4146-9d45-2463aaad46d1"), true, 2, new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc), "Legal Person", new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "ID", "Active", "Code", "Created", "Description", "Symbol", "Updated" },
                values: new object[,]
                {
                    { new Guid("6b577276-ddc9-4c8e-896a-eee8396eff82"), true, 1, new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc), "BRL", "R$", new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc) },
                    { new Guid("31007805-21e7-401c-834f-723fc441731a"), true, 2, new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc), "USD", "$", new DateTime(2018, 8, 28, 19, 21, 20, 941, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "CheckingAccount",
                columns: new[] { "ID", "Account", "AccountTypeID", "Active", "Agency", "Created", "Number", "StatusID", "Updated" },
                values: new object[] { new Guid("5919c21f-e390-44ad-841a-58789b893d0c"), 1L, new Guid("1417063b-b22d-4c68-8784-db4d32d9fdb5"), true, 1L, new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc), 2L, new Guid("f226faea-4e74-4826-b757-3374c378c072"), new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "CheckingAccount",
                columns: new[] { "ID", "Account", "AccountTypeID", "Active", "Agency", "Created", "Number", "StatusID", "Updated" },
                values: new object[] { new Guid("2ebf432e-93db-4471-9585-b02f20d8ce1e"), 1L, new Guid("859c7f23-a9d5-4146-9d45-2463aaad46d1"), true, 1L, new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc), 1L, new Guid("f226faea-4e74-4826-b757-3374c378c072"), new DateTime(2018, 8, 28, 19, 21, 20, 942, DateTimeKind.Utc) });

            migrationBuilder.CreateIndex(
                name: "IX_CheckingAccount_AccountTypeID",
                table: "CheckingAccount",
                column: "AccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingAccount_StatusID",
                table: "CheckingAccount",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingAccountTransaction_CheckingAccountID",
                table: "CheckingAccountTransaction",
                column: "CheckingAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingAccountTransaction_CurrencyTypeID",
                table: "CheckingAccountTransaction",
                column: "CurrencyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingAccountTransaction_StatusID",
                table: "CheckingAccountTransaction",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckingAccountTransaction_TypeID",
                table: "CheckingAccountTransaction",
                column: "TypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckingAccountTransaction");

            migrationBuilder.DropTable(
                name: "CheckingAccount");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "CheckingAccountTransactionStatus");

            migrationBuilder.DropTable(
                name: "CheckingAccountTransactionType");

            migrationBuilder.DropTable(
                name: "CheckingAccountType");

            migrationBuilder.DropTable(
                name: "CheckingAccountStatus");
        }
    }
}
