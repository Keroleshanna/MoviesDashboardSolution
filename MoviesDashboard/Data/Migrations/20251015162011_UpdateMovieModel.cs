using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesDashboard.Data.migrations
{
    /// <inheritdoc />
    public partial class UpdateMovieModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Soon",
                table: "Movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Soon",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
