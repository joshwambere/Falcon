using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Searching.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renameForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Otp_User_UserId",
                table: "Otp");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Otp",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Otp_User_UserId",
                table: "Otp",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Otp_User_UserId",
                table: "Otp");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Otp",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Otp_User_UserId",
                table: "Otp",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
