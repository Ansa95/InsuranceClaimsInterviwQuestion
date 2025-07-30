using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceClaims.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdatedOnAndCreatedDateToClaim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Claims",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Claims",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Claims");
        }
    }
}
