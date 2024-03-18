using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo_mail_marketing.Migrations
{
    public partial class DbUpdateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Sent",
                table: "MailData",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sent",
                table: "MailData");
        }
    }
}
