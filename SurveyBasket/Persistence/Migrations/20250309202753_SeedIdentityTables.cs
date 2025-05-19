using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurveyBasket.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefault", "IsDeleted", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01957b06-41ff-76b3-8816-b2d7be8b5263", "01957b08-522f-72b7-bbc6-ecb5372e7dd1", false, false, "Admin", "ADMIN" },
                    { "01957b07-0e34-7fae-83b9-544231cfee59", "01957b08-a2f6-781e-96ab-6d1fc73c0782", false, false, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "permissions", "polls:read", "01957b06-41ff-76b3-8816-b2d7be8b5263" },
                    { 2, "permissions", "polls:add", "01957b06-41ff-76b3-8816-b2d7be8b5263" },
                    { 3, "permissions", "polls:update", "01957b06-41ff-76b3-8816-b2d7be8b5263" },
                    { 4, "permissions", "polls:delete", "01957b06-41ff-76b3-8816-b2d7be8b5263" },
                    { 5, "permissions", "questions:read", "01957b06-41ff-76b3-8816-b2d7be8b5263" },
                    { 6, "permissions", "questions:add", "01957b06-41ff-76b3-8816-b2d7be8b5263" },
                    { 7, "permissions", "questions:update", "01957b06-41ff-76b3-8816-b2d7be8b5263" },
                    { 8, "permissions", "users:read", "01957b06-41ff-76b3-8816-b2d7be8b5263" },
                    { 9, "permissions", "users:add", "01957b06-41ff-76b3-8816-b2d7be8b5263" },
                    { 10, "permissions", "users:update", "01957b06-41ff-76b3-8816-b2d7be8b5263" },
                    { 11, "permissions", "roles:read", "01957b06-41ff-76b3-8816-b2d7be8b5263" },
                    { 12, "permissions", "roles:add", "01957b06-41ff-76b3-8816-b2d7be8b5263" },
                    { 13, "permissions", "roles:update", "01957b06-41ff-76b3-8816-b2d7be8b5263" },
                    { 14, "permissions", "results:read", "01957b06-41ff-76b3-8816-b2d7be8b5263" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "01957b06-41ff-76b3-8816-b2d7be8b5263", "01957ae4-e913-7f63-b8c4-09aca01b9697" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01957b07-0e34-7fae-83b9-544231cfee59");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "01957b06-41ff-76b3-8816-b2d7be8b5263", "01957ae4-e913-7f63-b8c4-09aca01b9697" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01957b06-41ff-76b3-8816-b2d7be8b5263");
        }
    }
}
