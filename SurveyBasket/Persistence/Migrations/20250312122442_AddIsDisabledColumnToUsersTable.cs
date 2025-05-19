using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyBasket.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDisabledColumnToUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01957ae4-e913-7f63-b8c4-09aca01b9697",
                columns: new[] { "Email", "IsDisabled", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "admin@survey-basket.com", false, "ADMIN@SURVEY-BASKET.COM", "ADMIN@SURVEY-BASKET.COM", "admin@survey-basket.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01957ae4-e913-7f63-b8c4-09aca01b9697",
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "admin@survey-basket@gmail.com", "ADMIN@SURVEY-BASKET@GMAIL.COM", "ADMIN@SURVEY-BASKET@GMAIL.COM", "admin@survey-basket@gmail.com" });
        }
    }
}
