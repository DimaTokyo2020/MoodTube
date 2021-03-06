﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MoodTube.Migrations
{
    public partial class Inittial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mood",
                columns: table => new
                {
                    MoodID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mood", x => x.MoodID);
                });

            migrationBuilder.CreateTable(
                name: "Singer",
                columns: table => new
                {
                    SingerID = table.Column<string>(nullable: false),
                    SingerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Singer", x => x.SingerID);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    SongID = table.Column<string>(nullable: false),
                    SongName = table.Column<string>(nullable: true),
                    SingerID = table.Column<string>(nullable: true),
                    MoodID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.SongID);
                    table.ForeignKey(
                        name: "FK_Song_Mood_MoodID",
                        column: x => x.MoodID,
                        principalTable: "Mood",
                        principalColumn: "MoodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Song_Singer_SingerID",
                        column: x => x.SingerID,
                        principalTable: "Singer",
                        principalColumn: "SingerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_MoodID",
                table: "Song",
                column: "MoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Song_SingerID",
                table: "Song",
                column: "SingerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Mood");

            migrationBuilder.DropTable(
                name: "Singer");
        }
    }
}
