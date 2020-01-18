﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(TibiaThContext))]
    [Migration("20191011173933_AddedGuildToTibiaCharacter")]
    partial class AddedGuildToTibiaCharacter
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Models.CharacterList", b =>
                {
                    b.Property<int>("CharacterListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.HasKey("CharacterListId");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("CharacterList");
                });

            modelBuilder.Entity("Models.TibiaCharacter", b =>
                {
                    b.Property<int>("TibiaCharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharacterListId")
                        .HasColumnType("int");

                    b.Property<string>("Guild")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PVPType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("World")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TibiaCharacterId");

                    b.HasIndex("CharacterListId");

                    b.ToTable("TibiaCharacter");
                });

            modelBuilder.Entity("Models.CharacterList", b =>
                {
                    b.HasOne("Models.Account", "Account")
                        .WithOne("CharacterList")
                        .HasForeignKey("Models.CharacterList", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.TibiaCharacter", b =>
                {
                    b.HasOne("Models.CharacterList", "CharacterList")
                        .WithMany("TibiaCharacters")
                        .HasForeignKey("CharacterListId");
                });
#pragma warning restore 612, 618
        }
    }
}
