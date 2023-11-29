using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opensalus.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaPublicField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "FileDetails",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "FileDetails");
        }
    }
}
