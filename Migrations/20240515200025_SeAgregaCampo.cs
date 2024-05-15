using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrinityShop.Migrations
{
    /// <inheritdoc />
    public partial class SeAgregaCampo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "Clients",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "Clients");
        }
    }
}
