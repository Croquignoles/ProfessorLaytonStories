﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProfessorLayton.Data;

#nullable disable

namespace ProfessorLayton.Migrations
{
    [DbContext(typeof(ProfessorLaytonContext))]
    [Migration("20230108214559_creation19")]
    partial class creation19
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("CharacterGame", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GamesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CharactersId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("CharacterGame");
                });

            modelBuilder.Entity("GameMusic", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MusicsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GamesId", "MusicsId");

                    b.HasIndex("MusicsId");

                    b.ToTable("GameMusic");
                });

            modelBuilder.Entity("ProfessorLayton.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsBadGuy")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlImage1")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlImage2")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlImage3")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("ProfessorLayton.Models.Enigma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("TEXT");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MusicId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlImage")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("MusicId");

                    b.ToTable("Enigmas");
                });

            modelBuilder.Entity("ProfessorLayton.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlImage1")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlImage2")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlImage3")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("ProfessorLayton.Models.Hint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EnigmaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HintRange")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EnigmaId");

                    b.ToTable("Hints");
                });

            modelBuilder.Entity("ProfessorLayton.Models.Music", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Musics");
                });

            modelBuilder.Entity("ProfessorLayton.Models.Solution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("TEXT");

                    b.Property<int>("EnigmaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("urlImg")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EnigmaId")
                        .IsUnique();

                    b.ToTable("Solutions");
                });

            modelBuilder.Entity("CharacterGame", b =>
                {
                    b.HasOne("ProfessorLayton.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProfessorLayton.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameMusic", b =>
                {
                    b.HasOne("ProfessorLayton.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProfessorLayton.Models.Music", null)
                        .WithMany()
                        .HasForeignKey("MusicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProfessorLayton.Models.Enigma", b =>
                {
                    b.HasOne("ProfessorLayton.Models.Game", "Game")
                        .WithMany("Enigmas")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProfessorLayton.Models.Music", "Music")
                        .WithMany()
                        .HasForeignKey("MusicId");

                    b.Navigation("Game");

                    b.Navigation("Music");
                });

            modelBuilder.Entity("ProfessorLayton.Models.Hint", b =>
                {
                    b.HasOne("ProfessorLayton.Models.Enigma", "Enigma")
                        .WithMany("Hints")
                        .HasForeignKey("EnigmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enigma");
                });

            modelBuilder.Entity("ProfessorLayton.Models.Solution", b =>
                {
                    b.HasOne("ProfessorLayton.Models.Enigma", "Enigma")
                        .WithOne("Solution")
                        .HasForeignKey("ProfessorLayton.Models.Solution", "EnigmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enigma");
                });

            modelBuilder.Entity("ProfessorLayton.Models.Enigma", b =>
                {
                    b.Navigation("Hints");

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("ProfessorLayton.Models.Game", b =>
                {
                    b.Navigation("Enigmas");
                });
#pragma warning restore 612, 618
        }
    }
}