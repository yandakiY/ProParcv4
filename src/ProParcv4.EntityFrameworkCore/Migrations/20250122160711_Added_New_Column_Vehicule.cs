using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProParcv4.Migrations
{
    /// <inheritdoc />
    public partial class Added_New_Column_Vehicule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateFabrication",
                table: "AppVehicules",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Marque",
                table: "AppVehicules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Matricule",
                table: "AppVehicules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFabrication",
                table: "AppVehicules");

            migrationBuilder.DropColumn(
                name: "Marque",
                table: "AppVehicules");

            migrationBuilder.DropColumn(
                name: "Matricule",
                table: "AppVehicules");
        }
    }
}
