using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPIMVC.Migrations
{
    public partial class AddGenerationOfKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "StageName" },
                values: new object[,]
                {
                    { 1, "Milky Chance" },
                    { 2, "Mac Miller" },
                    { 3, "The Doors" },
                    { 4, "Tyler, The Creator" },
                    { 5, "Chet Baker" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pop" },
                    { 2, "Rap" },
                    { 3, "Rock" },
                    { 4, "R&B" },
                    { 5, "Jazz" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "RealeaseYear", "Title" },
                values: new object[,]
                {
                    { 1, 1, 2013, "Sadnecessary" },
                    { 2, 2, 2016, "The Divine Feminine" },
                    { 3, 3, 1967, "The Doors" },
                    { 4, 4, 2019, "IGOR" },
                    { 5, 5, 1956, "Chet Baker Sings" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "AlbumId", "GenreId", "Length", "Name" },
                values: new object[,]
                {
                    { 1, 2, 2, new TimeSpan(0, 0, 5, 13, 0), "Stolen Dance" },
                    { 2, 1, 1, new TimeSpan(0, 0, 8, 0, 0), "Cinderella" },
                    { 3, 3, 3, new TimeSpan(0, 0, 2, 25, 0), "Break on through (on the other side)" },
                    { 4, 4, 4, new TimeSpan(0, 0, 6, 15, 0), "GONE GONE / THANK YOU" },
                    { 5, 5, 5, new TimeSpan(0, 0, 3, 3, 0), "That Old Feeling" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
