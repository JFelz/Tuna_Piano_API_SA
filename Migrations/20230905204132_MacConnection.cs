using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Tuna_Piano.Migrations
{
    public partial class MacConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UID = table.Column<string>(type: "text", nullable: false),
                    displayName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserProfile",
                columns: new[] { "Id", "UID", "displayName" },
                values: new object[] { 1, "YOfJwqkulPUXzojJjdnCFXwrQkw2", "Jovanni Feliz" });

            migrationBuilder.CreateIndex(
                name: "IX_SongsGenres_GenreId",
                table: "SongsGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_SongsGenres_SongId",
                table: "SongsGenres",
                column: "SongId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongsGenres_Genres_GenreId",
                table: "SongsGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongsGenres_Songs_SongId",
                table: "SongsGenres",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongsGenres_Genres_GenreId",
                table: "SongsGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_SongsGenres_Songs_SongId",
                table: "SongsGenres");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_SongsGenres_GenreId",
                table: "SongsGenres");

            migrationBuilder.DropIndex(
                name: "IX_SongsGenres_SongId",
                table: "SongsGenres");

            migrationBuilder.DropIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs");
        }
    }
}
