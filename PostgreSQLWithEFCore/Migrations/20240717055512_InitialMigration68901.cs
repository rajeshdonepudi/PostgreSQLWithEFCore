using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace PostgreSQLWithEFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration68901 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "AspNetUsers",
                type: "tsvector",
                nullable: false)
                .Annotation("Npgsql:TsVectorConfig", "english")
                .Annotation("Npgsql:TsVectorProperties", new[] { "Description", "Metadata" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SearchVector",
                table: "AspNetUsers",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SearchVector",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "AspNetUsers");
        }
    }
}
