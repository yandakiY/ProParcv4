using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProParcv4.Migrations
{
    /// <inheritdoc />
    public partial class update_type_dateFabrication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFabrication",
                table: "AppVehicules",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateFabrication",
                table: "AppVehicules",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
