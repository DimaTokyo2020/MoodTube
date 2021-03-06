﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoodTube.Data;

namespace MoodTube.Migrations
{
    [DbContext(typeof(MusicContext))]
    [Migration("20181022205214_SingerWithoutVirtual")]
    partial class SingerWithoutVirtual
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoodTube.Models.Mood", b =>
                {
                    b.Property<string>("MoodID");

                    b.HasKey("MoodID");

                    b.ToTable("Mood");
                });

            modelBuilder.Entity("MoodTube.Models.Singer", b =>
                {
                    b.Property<string>("SingerID");

                    b.Property<string>("SingerName");

                    b.HasKey("SingerID");

                    b.ToTable("Singer");
                });

            modelBuilder.Entity("MoodTube.Models.Song", b =>
                {
                    b.Property<string>("SongID");

                    b.Property<string>("MoodID");

                    b.Property<string>("SingerID");

                    b.Property<string>("SongName");

                    b.HasKey("SongID");

                    b.HasIndex("MoodID");

                    b.HasIndex("SingerID");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("MoodTube.Models.Song", b =>
                {
                    b.HasOne("MoodTube.Models.Mood", "Mood")
                        .WithMany("Songs")
                        .HasForeignKey("MoodID");

                    b.HasOne("MoodTube.Models.Singer", "Singer")
                        .WithMany("Songs")
                        .HasForeignKey("SingerID");
                });
#pragma warning restore 612, 618
        }
    }
}
