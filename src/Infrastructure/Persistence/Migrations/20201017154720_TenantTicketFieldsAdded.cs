using Microsoft.EntityFrameworkCore.Migrations;

namespace Queuer.Infrastructure.Persistence.Migrations
{
    public partial class TenantTicketFieldsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentTicketNumber",
                table: "Tenants",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "MaxTicketNumber",
                table: "Tenants",
                nullable: false,
                defaultValue: 99);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentTicketNumber",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "MaxTicketNumber",
                table: "Tenants");
        }
    }
}
