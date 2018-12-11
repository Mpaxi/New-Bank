using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NB.CheckingAccountTransaction.API.Migrations
{
    public partial class AddAlternativeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CheckingAccountTransactionStatus",
                keyColumn: "ID",
                keyValue: new Guid("000c0e7b-3a34-4612-803b-b6510ddfdb26"));

            migrationBuilder.DeleteData(
                table: "CheckingAccountTransactionStatus",
                keyColumn: "ID",
                keyValue: new Guid("d314587d-3edb-4911-8b21-0249b0bb0005"));

            migrationBuilder.DeleteData(
                table: "CheckingAccountTransactionStatus",
                keyColumn: "ID",
                keyValue: new Guid("fb45206b-1d23-42c0-8f48-fb663f56b6ea"));

            migrationBuilder.DeleteData(
                table: "CheckingAccountTransactionType",
                keyColumn: "ID",
                keyValue: new Guid("0d0c7992-7689-45de-8ae7-96db73eab84f"));

            migrationBuilder.DeleteData(
                table: "CheckingAccountTransactionType",
                keyColumn: "ID",
                keyValue: new Guid("30685f6d-f398-46f4-a147-2e99d7ec045a"));

            migrationBuilder.DeleteData(
                table: "CheckingAccountTransactionType",
                keyColumn: "ID",
                keyValue: new Guid("fa5af19c-58f5-458b-b887-fd0dc37bd1e1"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "ID",
                keyValue: new Guid("31007805-21e7-401c-834f-723fc441731a"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "ID",
                keyValue: new Guid("6b577276-ddc9-4c8e-896a-eee8396eff82"));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CheckingAccountTransaction_CheckingAccountID_TracedID",
                table: "CheckingAccountTransaction",
                columns: new[] { "CheckingAccountID", "TracedID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_CheckingAccountTransaction_CheckingAccountID_TracedID",
                table: "CheckingAccountTransaction");

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
        }
    }
}
