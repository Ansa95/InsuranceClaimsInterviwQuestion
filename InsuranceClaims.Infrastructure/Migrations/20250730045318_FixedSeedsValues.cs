using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceClaims.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedSeedsValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Claims",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "SubmittedOn" },
                values: new object[] { new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Claims",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "SubmittedOn" },
                values: new object[] { new DateTime(2025, 7, 30, 4, 45, 30, 7, DateTimeKind.Utc).AddTicks(3732), new DateTime(2025, 7, 30, 4, 45, 30, 7, DateTimeKind.Utc).AddTicks(3468) });

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 7, 30, 4, 45, 30, 7, DateTimeKind.Utc).AddTicks(1568), new DateTime(2025, 7, 30, 4, 45, 30, 7, DateTimeKind.Utc).AddTicks(1266) });
        }
    }
}
