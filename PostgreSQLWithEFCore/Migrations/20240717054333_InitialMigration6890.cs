using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgreSQLWithEFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration6890 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Metadata",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Metadata",
                table: "AspNetUsers");
        }
    }
}
