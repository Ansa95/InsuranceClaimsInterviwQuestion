using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceClaims.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "CoverageDetails", "EndDate", "PolicyName", "PolicyNumber", "PremiumAmount", "StartDate" },
                values: new object[] { 1, "Covers hospitalization", new DateTime(2026, 7, 30, 4, 45, 30, 7, DateTimeKind.Utc).AddTicks(1568), "Health Policy A", "P123456", 1000m, new DateTime(2025, 7, 30, 4, 45, 30, 7, DateTimeKind.Utc).AddTicks(1266) });

            migrationBuilder.InsertData(
                table: "Policyholders",
                columns: new[] { "Id", "ContactInfo", "FullName" },
                values: new object[] { 1, "john@example.com", "John Doe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Username" },
                values: new object[] { 1, "hashed-password", "Hospital", "hospital1" });

            migrationBuilder.InsertData(
                table: "Claims",
                columns: new[] { "Id", "Amount", "ClaimAmount", "CreatedDate", "Description", "PolicyId", "PolicyholderId", "Status", "SubmittedByUserId", "SubmittedOn", "UpdatedOn" },
                values: new object[] { 1, 500m, 500m, new DateTime(2025, 7, 30, 4, 45, 30, 7, DateTimeKind.Utc).AddTicks(3732), "Hospitalization due to accident", 1, 1, 0, 1, new DateTime(2025, 7, 30, 4, 45, 30, 7, DateTimeKind.Utc).AddTicks(3468), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Claims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Policyholders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
