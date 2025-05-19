using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyBasket.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "01957ae4-e913-7f63-b8c4-09aca01b9697", 0, "01957ae9-a6fe-73ee-9d61-a3798be3fb1e", "admin@survey-basket@gmail.com", true, "Survey Basket", "Admin", false, null, "ADMIN@SURVEY-BASKET@GMAIL.COM", "ADMIN@SURVEY-BASKET@GMAIL.COM", "AQAAAAIAAYagAAAAEPbdXDZnRO0xsQUmzvmmuDknbzxrZFHWwJtq6MSVovGImLVIA2/n1oOqtI59b5hmAA==", null, false, "4C4FD4FBC1724FA6937EED78E0716F7D", false, "admin@survey-basket@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01957ae4-e913-7f63-b8c4-09aca01b9697");
        }
    }
}
