using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TvSeriesApi.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "TVSeries",
                columns: table => new
                {
                    TVSeriesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TVSeries", x => x.TVSeriesId);
                    table.ForeignKey(
                        name: "FK_TVSeries_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorTVSeries",
                columns: table => new
                {
                    CastActorId = table.Column<int>(type: "int", nullable: false),
                    TVSeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorTVSeries", x => new { x.CastActorId, x.TVSeriesId });
                    table.ForeignKey(
                        name: "FK_ActorTVSeries_Actors_CastActorId",
                        column: x => x.CastActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorTVSeries_TVSeries_TVSeriesId",
                        column: x => x.TVSeriesId,
                        principalTable: "TVSeries",
                        principalColumn: "TVSeriesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TVSeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_Seasons_TVSeries_TVSeriesId",
                        column: x => x.TVSeriesId,
                        principalTable: "TVSeries",
                        principalColumn: "TVSeriesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    EpisodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.EpisodeId);
                    table.ForeignKey(
                        name: "FK_Episodes_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "Age", "Fullname" },
                values: new object[,]
                {
                    { 1, 25, "Anya Taylor" },
                    { 2, 15, "Thomas Brodie" },
                    { 3, 20, "Moses Ingram" },
                    { 4, 30, "Bryan Cranston" },
                    { 5, 32, "Aaron Paul" },
                    { 6, 22, "Anna Gunn" },
                    { 7, 35, "Antony Starr" },
                    { 8, 32, "Karl Urban" },
                    { 9, 21, "Jack Quaid" },
                    { 10, 14, "Millie Bobby Brown" },
                    { 11, 15, "Finn Wolfhard" },
                    { 12, 17, "Noah Schnapp" },
                    { 13, 66, "Yellow Magnetic Star" },
                    { 14, 30, "Ilona Ostrowska" },
                    { 15, 45, "Cezary Żak" },
                    { 16, 55, "Violetta Arlak" },
                    { 17, 31, "Justin Roiland" },
                    { 18, 40, "Chris Parnell" },
                    { 19, 61, "Tom Kenny" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Drama" },
                    { 2, "Trilling" },
                    { 3, "Action" },
                    { 4, "Science Fiction" },
                    { 5, "Comedy" },
                    { 6, "Crime Fiction" }
                });

            migrationBuilder.InsertData(
                table: "TVSeries",
                columns: new[] { "TVSeriesId", "GenreId", "Name", "Year" },
                values: new object[] { 1, 1, "GambitSuko", 2020 });

            migrationBuilder.InsertData(
                table: "TVSeries",
                columns: new[] { "TVSeriesId", "GenreId", "Name", "Year" },
                values: new object[] { 2, 2, "Breaking Bad", 2002 });

            migrationBuilder.InsertData(
                table: "TVSeries",
                columns: new[] { "TVSeriesId", "GenreId", "Name", "Year" },
                values: new object[] { 3, 3, "Branczo", 2022 });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "SeasonId", "Name", "TVSeriesId" },
                values: new object[,]
                {
                    { 1, "Season 1", 1 },
                    { 2, "Season 1", 2 },
                    { 3, "Season 2", 2 },
                    { 4, "Season 1", 3 }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "Name", "SeasonId" },
                values: new object[,]
                {
                    { 1, "Opening", 1 },
                    { 2, "Exchanges", 1 },
                    { 3, "Doubled Pawns", 1 },
                    { 4, "Middle Game", 1 },
                    { 5, "Fork", 1 },
                    { 6, "Adjounment", 1 },
                    { 7, "End", 1 },
                    { 8, "breakings1", 2 },
                    { 9, "breakings2", 3 },
                    { 10, "branczoAndMateusz", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorTVSeries_TVSeriesId",
                table: "ActorTVSeries",
                column: "TVSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeasonId",
                table: "Episodes",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_TVSeriesId",
                table: "Seasons",
                column: "TVSeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_TVSeries_GenreId",
                table: "TVSeries",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorTVSeries");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "TVSeries");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
