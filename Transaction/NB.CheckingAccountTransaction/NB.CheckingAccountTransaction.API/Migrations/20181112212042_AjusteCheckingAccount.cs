using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NB.CheckingAccountTransaction.API.Migrations
{
    public partial class AjusteCheckingAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CheckingAccountTransactionStatus",
                keyColumn: "ID",
                keyValue: new Guid("000c0e7b-3a34-4612-803b-b6510ddfdb26"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc), new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckingAccountTransactionStatus",
                keyColumn: "ID",
                keyValue: new Guid("d314587d-3edb-4911-8b21-0249b0bb0005"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc), new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckingAccountTransactionStatus",
                keyColumn: "ID",
                keyValue: new Guid("fb45206b-1d23-42c0-8f48-fb663f56b6ea"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc), new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckingAccountTransactionType",
                keyColumn: "ID",
                keyValue: new Guid("0d0c7992-7689-45de-8ae7-96db73eab84f"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc), new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckingAccountTransactionType",
                keyColumn: "ID",
                keyValue: new Guid("30685f6d-f398-46f4-a147-2e99d7ec045a"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc), new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckingAccountTransactionType",
                keyColumn: "ID",
                keyValue: new Guid("fa5af19c-58f5-458b-b887-fd0dc37bd1e1"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc), new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "ID",
                keyValue: new Guid("31007805-21e7-401c-834f-723fc441731a"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc), new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "ID",
                keyValue: new Guid("6b577276-ddc9-4c8e-896a-eee8396eff82"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc), new DateTime(2018, 11, 12, 21, 20, 42, 666, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CheckingAccountTransactionStatus",
                keyColumn: "ID",
                keyValue: new Guid("000c0e7b-3a34-4612-803b-b6510ddfdb26"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 10, 25, 14, 28, 7, 554, DateTimeKind.Utc), new DateTime(2018, 10, 25, 14, 28, 7, 554, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckingAccountTransactionStatus",
                keyColumn: "ID",
                keyValue: new Guid("d314587d-3edb-4911-8b21-0249b0bb0005"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 10, 25, 14, 28, 7, 554, DateTimeKind.Utc), new DateTime(2018, 10, 25, 14, 28, 7, 554, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckingAccountTransactionStatus",
                keyColumn: "ID",
                keyValue: new Guid("fb45206b-1d23-42c0-8f48-fb663f56b6ea"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 10, 25, 14, 28, 7, 554, DateTimeKind.Utc), new DateTime(2018, 10, 25, 14, 28, 7, 554, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckingAccountTransactionType",
                keyColumn: "ID",
                keyValue: new Guid("0d0c7992-7689-45de-8ae7-96db73eab84f"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 10, 25, 14, 28, 7, 554, DateTimeKind.Utc), new DateTime(2018, 10, 25, 14, 28, 7, 554, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckingAccountTransactionType",
                keyColumn: "ID",
                keyValue: new Guid("30685f6d-f398-46f4-a147-2e99d7ec045a"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 10, 25, 14, 28, 7, 554, DateTimeKind.Utc), new DateTime(2018, 10, 25, 14, 28, 7, 554, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CheckingAccountTransactionType",
                keyColumn: "ID",
                keyValue: new Guid("fa5af19c-58f5-458b-b887-fd0dc37bd1e1"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 10, 25, 14, 28, 7, 554, DateTimeKind.Utc), new DateTime(2018, 10, 25, 14, 28, 7, 554, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "ID",
                keyValue: new Guid("31007805-21e7-401c-834f-723fc441731a"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 10, 25, 14, 28, 7, 554, DateTimeKind.Utc), new DateTime(2018, 10, 25, 14, 28, 7, 554, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Currency",
                keyColumn: "ID",
                keyValue: new Guid("6b577276-ddc9-4c8e-896a-eee8396eff82"),
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2018, 10, 25, 14, 28, 7, 553, DateTimeKind.Utc), new DateTime(2018, 10, 25, 14, 28, 7, 553, DateTimeKind.Utc) });
        }
    }
}
