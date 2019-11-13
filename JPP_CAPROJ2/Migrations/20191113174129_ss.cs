using Microsoft.EntityFrameworkCore.Migrations;

namespace JPP_CAPROJ2.Migrations
{
    public partial class ss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceID",
                table: "Transactions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "Transactions");
        }
    }
}
