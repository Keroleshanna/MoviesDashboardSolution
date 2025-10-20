using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesDashboard.Data.migrations
{
    /// <inheritdoc />
    public partial class AddDataToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Categories (name, status, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Animation', 1, 'seed_user', 'admin', '2025-10-15 11:37:12', '2025-10-15 11:37:12');insert into Categories (name, status, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Comedy', 1, 'admin', 'system', '2025-10-15 11:37:12', '2025-10-15 11:37:12');insert into Categories (name, status, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Horror', 1, 'admin', 'seed_user', '2025-10-15 11:37:12', '2025-10-15 11:37:12');insert into Categories (name, status, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Drama', 1, 'seed_user', 'admin', '2025-10-15 11:37:12', '2025-10-15 11:37:12');insert into Categories (name, status, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Horror', 1, 'system', 'seed_user', '2025-10-15 11:37:12', '2025-10-15 11:37:12');insert into Categories (name, status, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Drama', 0, 'seed_user', 'system', '2025-10-15 11:37:12', '2025-10-15 11:37:12');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("RRUNCATE TABLE CATEGORIES");
        }
    }
}
