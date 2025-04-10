using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modules.Inventory.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Inventory");

            migrationBuilder.CreateTable(
                name: "SnackLocation",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    SnackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnackLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SnackType",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnackType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Snack",
                schema: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Label = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SnackTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SnackLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snack", x => x.Id);
                    table.CheckConstraint("CK_Snack_Cost", "Cost > 0");
                    table.CheckConstraint("CK_Snack_Price", "Price > 0");
                    table.ForeignKey(
                        name: "FK_Snack_SnackLocation_SnackLocationId",
                        column: x => x.SnackLocationId,
                        principalSchema: "Inventory",
                        principalTable: "SnackLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Snack_SnackType_SnackTypeId",
                        column: x => x.SnackTypeId,
                        principalSchema: "Inventory",
                        principalTable: "SnackType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Snack_Label",
                schema: "Inventory",
                table: "Snack",
                column: "Label",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Snack_SnackLocationId",
                schema: "Inventory",
                table: "Snack",
                column: "SnackLocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Snack_SnackTypeId",
                schema: "Inventory",
                table: "Snack",
                column: "SnackTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SnackLocation_Code",
                schema: "Inventory",
                table: "SnackLocation",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SnackType_Name",
                schema: "Inventory",
                table: "SnackType",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Snack",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "SnackLocation",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "SnackType",
                schema: "Inventory");
        }
    }
}
