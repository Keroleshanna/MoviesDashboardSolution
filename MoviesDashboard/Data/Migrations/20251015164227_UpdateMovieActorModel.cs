using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesDashboard.Data.migrations
{
    /// <inheritdoc />
    public partial class UpdateMovieActorModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into MovieActors (ActorId, MovieId) values (725, 150);insert into MovieActors (ActorId, MovieId) values (685, 125);insert into MovieActors (ActorId, MovieId) values (785, 175);insert into MovieActors (ActorId, MovieId) values (725, 105);insert into MovieActors (ActorId, MovieId) values (900, 30);insert into MovieActors (ActorId, MovieId) values (850, 185);insert into MovieActors (ActorId, MovieId) values (520, 195);insert into MovieActors (ActorId, MovieId) values (760, 25);insert into MovieActors (ActorId, MovieId) values (650, 185);insert into MovieActors (ActorId, MovieId) values (605, 185);insert into MovieActors (ActorId, MovieId) values (900, 120);insert into MovieActors (ActorId, MovieId) values (800, 185);insert into MovieActors (ActorId, MovieId) values (605, 125);insert into MovieActors (ActorId, MovieId) values (540, 45);insert into MovieActors (ActorId, MovieId) values (825, 65);insert into MovieActors (ActorId, MovieId) values (795, 200);insert into MovieActors (ActorId, MovieId) values (680, 160);insert into MovieActors (ActorId, MovieId) values (730, 160);insert into MovieActors (ActorId, MovieId) values (615, 10);insert into MovieActors (ActorId, MovieId) values (760, 70);insert into MovieActors (ActorId, MovieId) values (850, 200);insert into MovieActors (ActorId, MovieId) values (795, 55);insert into MovieActors (ActorId, MovieId) values (855, 125);insert into MovieActors (ActorId, MovieId) values (705, 195);insert into MovieActors (ActorId, MovieId) values (590, 185);insert into MovieActors (ActorId, MovieId) values (890, 85);insert into MovieActors (ActorId, MovieId) values (595, 90);insert into MovieActors (ActorId, MovieId) values (895, 110);insert into MovieActors (ActorId, MovieId) values (550, 35);insert into MovieActors (ActorId, MovieId) values (835, 40);insert into MovieActors (ActorId, MovieId) values (745, 190);insert into MovieActors (ActorId, MovieId) values (895, 140);insert into MovieActors (ActorId, MovieId) values (635, 200);insert into MovieActors (ActorId, MovieId) values (625, 200);insert into MovieActors (ActorId, MovieId) values (660, 55);insert into MovieActors (ActorId, MovieId) values (575, 65);insert into MovieActors (ActorId, MovieId) values (580, 15);insert into MovieActors (ActorId, MovieId) values (795, 165);insert into MovieActors (ActorId, MovieId) values (860, 60);insert into MovieActors (ActorId, MovieId) values (845, 200);insert into MovieActors (ActorId, MovieId) values (615, 35);insert into MovieActors (ActorId, MovieId) values (540, 170);insert into MovieActors (ActorId, MovieId) values (655, 15);insert into MovieActors (ActorId, MovieId) values (850, 20);insert into MovieActors (ActorId, MovieId) values (880, 40);insert into MovieActors (ActorId, MovieId) values (855, 35);insert into MovieActors (ActorId, MovieId) values (900, 145);insert into MovieActors (ActorId, MovieId) values (740, 165);insert into MovieActors (ActorId, MovieId) values (595, 145);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE MOVIEACTORS");
        }
    }
}
