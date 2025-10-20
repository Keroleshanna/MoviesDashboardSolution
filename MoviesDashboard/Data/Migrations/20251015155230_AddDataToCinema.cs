using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesDashboard.Data.migrations
{
    /// <inheritdoc />
    public partial class AddDataToCinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Cinemas (name, img, status, address, phone, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Empire Cinema', 'cinema14.jpg', 0, '86866 Dryden Circle', '800-782-5751', 'admin', 'admin', '2025-10-15 11:48:58', '2025-10-15 11:48:58');insert into Cinemas (name, img, status, address, phone, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('DreamView Cinema', 'cinema4.jpg', 0, '5 Mendota Drive', '724-593-0925', 'seed_user', 'admin', '2025-10-15 11:48:58', '2025-10-15 11:48:58');insert into Cinemas (name, img, status, address, phone, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Horizon Movies', 'cinema7.jpg', 1, '2433 Arkansas Center', '844-386-6788', 'system', 'admin', '2025-10-15 11:48:58', '2025-10-15 11:48:58');insert into Cinemas (name, img, status, address, phone, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Empire Cinema', 'cinema5.jpg', 1, '39990 Mcguire Lane', '901-570-1837', 'system', 'system', '2025-10-15 11:48:58', '2025-10-15 11:48:58');insert into Cinemas (name, img, status, address, phone, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Galaxy Theaters', 'cinema9.jpg', 1, '12785 Colorado Place', '647-773-2156', 'admin', 'admin', '2025-10-15 11:48:58', '2025-10-15 11:48:58');insert into Cinemas (name, img, status, address, phone, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Majestic Theater', 'cinema6.jpg', 1, '49 Farmco Terrace', '137-328-4839', 'system', 'seed_user', '2025-10-15 11:48:58', '2025-10-15 11:48:58');insert into Cinemas (name, img, status, address, phone, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Platinum Movies', 'cinema8.jpg', 1, '3 Dottie Terrace', '363-768-1996', 'seed_user', 'system', '2025-10-15 11:48:58', '2025-10-15 11:48:58');insert into Cinemas (name, img, status, address, phone, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Grand Cinema', 'cinema2.jpg', 1, '91415 Oneill Center', '575-223-6121', 'admin', 'admin', '2025-10-15 11:48:58', '2025-10-15 11:48:58');insert into Cinemas (name, img, status, address, phone, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Grand Cinema', 'cinema2.jpg', 1, '17 Glendale Way', '159-820-9986', 'system', 'seed_user', '2025-10-15 11:48:58', '2025-10-15 11:48:58');insert into Cinemas (name, img, status, address, phone, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Royal Film House', 'cinema7.jpg', 1, '742 Spaight Parkway', '230-665-7409', 'seed_user', 'seed_user', '2025-10-15 11:48:58', '2025-10-15 11:48:58');insert into Cinemas (name, img, status, address, phone, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Galaxy Theaters', 'cinema12.jpg', 1, '31 Jackson Pass', '743-494-9259', 'admin', 'seed_user', '2025-10-15 11:48:58', '2025-10-15 11:48:58');insert into Cinemas (name, img, status, address, phone, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Cineplex Downtown', 'cinema8.jpg', 1, '2818 Chive Circle', '664-982-9391', 'system', 'seed_user', '2025-10-15 11:48:58', '2025-10-15 11:48:58');insert into Cinemas (name, img, status, address, phone, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('Silver Screen', 'cinema6.jpg', 1, '3 Monica Point', '782-516-1809', 'seed_user', 'seed_user', '2025-10-15 11:48:58', '2025-10-15 11:48:58');insert into Cinemas (name, img, status, address, phone, createdBy, lastModifiedBy, createdOn, lastModifiedOn) values ('StarLight Cinema', 'cinema4.jpg', 1, '27099 Talmadge Lane', '815-502-5599', 'admin', 'seed_user', '2025-10-15 11:48:58', '2025-10-15 11:48:58');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE CINEMAS");
        }
    }
}
