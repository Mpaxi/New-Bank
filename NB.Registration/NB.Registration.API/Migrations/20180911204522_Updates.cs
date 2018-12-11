using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NB.Registration.API.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InternetAddressType",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetAddressType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LegalPerson",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PublicName = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPerson", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPerson",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPerson", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersonDocument",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ValidDate = table.Column<DateTime>(nullable: false),
                    DocumentTypeID = table.Column<Guid>(nullable: false),
                    LegalPersonID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersonDocument", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LegalPersonDocument_DocumentType_DocumentTypeID",
                        column: x => x.DocumentTypeID,
                        principalTable: "DocumentType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegalPersonDocument_LegalPerson_LegalPersonID",
                        column: x => x.LegalPersonID,
                        principalTable: "LegalPerson",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalPersonInternetAddress",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    InternetAddressTypeID = table.Column<Guid>(nullable: false),
                    LegalPersonID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPersonInternetAddress", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LegalPersonInternetAddress_InternetAddressType_InternetAddressTypeID",
                        column: x => x.InternetAddressTypeID,
                        principalTable: "InternetAddressType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegalPersonInternetAddress_LegalPerson_LegalPersonID",
                        column: x => x.LegalPersonID,
                        principalTable: "LegalPerson",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    PhysicalPersonID = table.Column<Guid>(nullable: false),
                    LegalPersonID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Persons_LegalPerson_LegalPersonID",
                        column: x => x.LegalPersonID,
                        principalTable: "LegalPerson",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persons_PhysicalPerson_PhysicalPersonID",
                        column: x => x.PhysicalPersonID,
                        principalTable: "PhysicalPerson",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersonDocument",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ValidDate = table.Column<DateTime>(nullable: false),
                    DocumentTypeID = table.Column<Guid>(nullable: false),
                    PhysicalPersonID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersonDocument", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhysicalPersonDocument_DocumentType_DocumentTypeID",
                        column: x => x.DocumentTypeID,
                        principalTable: "DocumentType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhysicalPersonDocument_PhysicalPerson_PhysicalPersonID",
                        column: x => x.PhysicalPersonID,
                        principalTable: "PhysicalPerson",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalPersonInternetAddress",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    InternetAddressTypeID = table.Column<Guid>(nullable: false),
                    PhysicalPersonID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalPersonInternetAddress", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhysicalPersonInternetAddress_InternetAddressType_InternetAddressTypeID",
                        column: x => x.InternetAddressTypeID,
                        principalTable: "InternetAddressType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhysicalPersonInternetAddress_PhysicalPerson_PhysicalPersonID",
                        column: x => x.PhysicalPersonID,
                        principalTable: "PhysicalPerson",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DocumentType",
                columns: new[] { "ID", "Active", "Created", "Description", "Updated" },
                values: new object[,]
                {
                    { new Guid("f19c4663-92fb-4b2d-a350-acc4e4effe16"), true, new DateTime(2018, 9, 11, 20, 45, 22, 455, DateTimeKind.Utc), "Identity", new DateTime(2018, 9, 11, 20, 45, 22, 455, DateTimeKind.Utc) },
                    { new Guid("22276405-5c3a-42cb-a7bc-51d7f9cc24d1"), true, new DateTime(2018, 9, 11, 20, 45, 22, 455, DateTimeKind.Utc), "Fisical Person Certidicate", new DateTime(2018, 9, 11, 20, 45, 22, 455, DateTimeKind.Utc) },
                    { new Guid("6671066b-cbe3-470c-a776-9a83f9644a38"), true, new DateTime(2018, 9, 11, 20, 45, 22, 455, DateTimeKind.Utc), "Legal Person Certidicate", new DateTime(2018, 9, 11, 20, 45, 22, 455, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "InternetAddressType",
                columns: new[] { "ID", "Active", "Created", "Description", "Updated" },
                values: new object[,]
                {
                    { new Guid("83e75fb2-ca4d-4106-9883-eced908cf1f0"), true, new DateTime(2018, 9, 11, 20, 45, 22, 455, DateTimeKind.Utc), "Email", new DateTime(2018, 9, 11, 20, 45, 22, 455, DateTimeKind.Utc) },
                    { new Guid("20be7b7f-a96b-4fa4-9920-5f4b2b596d94"), true, new DateTime(2018, 9, 11, 20, 45, 22, 455, DateTimeKind.Utc), "Push Notification", new DateTime(2018, 9, 11, 20, 45, 22, 455, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "LegalPerson",
                columns: new[] { "ID", "Active", "Birthdate", "Created", "Name", "PublicName", "Updated" },
                values: new object[] { new Guid("fc542592-e12d-48a9-9161-f0f2fddf6f77"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 11, 20, 45, 22, 459, DateTimeKind.Utc), "Nome Empresa do Murilo", "Empresa do Murilo", new DateTime(2018, 9, 11, 20, 45, 22, 459, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "PhysicalPerson",
                columns: new[] { "ID", "Active", "Birthdate", "Created", "Name", "Updated" },
                values: new object[] { new Guid("ff8a2b4d-fafe-49f3-9d79-cc714dd4ac35"), true, new DateTime(1991, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 9, 11, 20, 45, 22, 458, DateTimeKind.Utc), "Murilo Henrique Silva Paxi", new DateTime(2018, 9, 11, 20, 45, 22, 458, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "LegalPersonDocument",
                columns: new[] { "ID", "Active", "Created", "DocumentTypeID", "LegalPersonID", "Updated", "ValidDate", "Value" },
                values: new object[] { new Guid("68ecc1c5-175c-4a4c-82e1-1ec7bf7abcfe"), true, new DateTime(2018, 9, 11, 20, 45, 22, 459, DateTimeKind.Utc), new Guid("6671066b-cbe3-470c-a776-9a83f9644a38"), new Guid("fc542592-e12d-48a9-9161-f0f2fddf6f77"), new DateTime(2018, 9, 11, 20, 45, 22, 459, DateTimeKind.Utc), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "61059245000189" });

            migrationBuilder.InsertData(
                table: "LegalPersonInternetAddress",
                columns: new[] { "ID", "Active", "Created", "InternetAddressTypeID", "LegalPersonID", "Updated", "Value" },
                values: new object[] { new Guid("7860f738-4e7a-4ecd-a939-45abf28d9e3b"), true, new DateTime(2018, 9, 11, 20, 45, 22, 460, DateTimeKind.Utc), new Guid("83e75fb2-ca4d-4106-9883-eced908cf1f0"), new Guid("fc542592-e12d-48a9-9161-f0f2fddf6f77"), new DateTime(2018, 9, 11, 20, 45, 22, 460, DateTimeKind.Utc), "murilo.paxiPJ@superdigital.com.br" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "ID", "Active", "Created", "LegalPersonID", "PhysicalPersonID", "Updated" },
                values: new object[] { new Guid("e02d78b1-685d-46b4-aa4a-816481580f43"), true, new DateTime(2018, 9, 11, 20, 45, 22, 460, DateTimeKind.Utc), new Guid("fc542592-e12d-48a9-9161-f0f2fddf6f77"), new Guid("ff8a2b4d-fafe-49f3-9d79-cc714dd4ac35"), new DateTime(2018, 9, 11, 20, 45, 22, 460, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "PhysicalPersonDocument",
                columns: new[] { "ID", "Active", "Created", "DocumentTypeID", "PhysicalPersonID", "Updated", "ValidDate", "Value" },
                values: new object[,]
                {
                    { new Guid("c29801f1-b23b-49a6-b5af-62182742bc81"), true, new DateTime(2018, 9, 11, 20, 45, 22, 459, DateTimeKind.Utc), new Guid("f19c4663-92fb-4b2d-a350-acc4e4effe16"), new Guid("ff8a2b4d-fafe-49f3-9d79-cc714dd4ac35"), new DateTime(2018, 9, 11, 20, 45, 22, 459, DateTimeKind.Utc), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "3490527361" },
                    { new Guid("537aef95-fc65-4a78-bf0b-573951843384"), true, new DateTime(2018, 9, 11, 20, 45, 22, 459, DateTimeKind.Utc), new Guid("22276405-5c3a-42cb-a7bc-51d7f9cc24d1"), new Guid("ff8a2b4d-fafe-49f3-9d79-cc714dd4ac35"), new DateTime(2018, 9, 11, 20, 45, 22, 459, DateTimeKind.Utc), new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "34011746819" }
                });

            migrationBuilder.InsertData(
                table: "PhysicalPersonInternetAddress",
                columns: new[] { "ID", "Active", "Created", "InternetAddressTypeID", "PhysicalPersonID", "Updated", "Value" },
                values: new object[] { new Guid("c703e27c-c102-412e-94a6-fe40cc6ef8b5"), true, new DateTime(2018, 9, 11, 20, 45, 22, 459, DateTimeKind.Utc), new Guid("83e75fb2-ca4d-4106-9883-eced908cf1f0"), new Guid("ff8a2b4d-fafe-49f3-9d79-cc714dd4ac35"), new DateTime(2018, 9, 11, 20, 45, 22, 459, DateTimeKind.Utc), "murilo.paxi@superdigital.com.br" });

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonDocument_DocumentTypeID",
                table: "LegalPersonDocument",
                column: "DocumentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonDocument_LegalPersonID",
                table: "LegalPersonDocument",
                column: "LegalPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonInternetAddress_InternetAddressTypeID",
                table: "LegalPersonInternetAddress",
                column: "InternetAddressTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_LegalPersonInternetAddress_LegalPersonID",
                table: "LegalPersonInternetAddress",
                column: "LegalPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_LegalPersonID",
                table: "Persons",
                column: "LegalPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PhysicalPersonID",
                table: "Persons",
                column: "PhysicalPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonDocument_DocumentTypeID",
                table: "PhysicalPersonDocument",
                column: "DocumentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonDocument_PhysicalPersonID",
                table: "PhysicalPersonDocument",
                column: "PhysicalPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonInternetAddress_InternetAddressTypeID",
                table: "PhysicalPersonInternetAddress",
                column: "InternetAddressTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalPersonInternetAddress_PhysicalPersonID",
                table: "PhysicalPersonInternetAddress",
                column: "PhysicalPersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalPersonDocument");

            migrationBuilder.DropTable(
                name: "LegalPersonInternetAddress");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PhysicalPersonDocument");

            migrationBuilder.DropTable(
                name: "PhysicalPersonInternetAddress");

            migrationBuilder.DropTable(
                name: "LegalPerson");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "InternetAddressType");

            migrationBuilder.DropTable(
                name: "PhysicalPerson");
        }
    }
}
