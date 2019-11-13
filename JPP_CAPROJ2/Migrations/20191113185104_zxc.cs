using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JPP_CAPROJ2.Migrations
{
    public partial class zxc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionCompletion",
                table: "Transactions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionCompletion",
                table: "Transactions");
        }
    }
}
