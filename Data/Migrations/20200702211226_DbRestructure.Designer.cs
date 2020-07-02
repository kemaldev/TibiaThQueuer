﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(TibiaThContext))]
    [Migration("20200702211226_DbRestructure")]
    partial class DbRestructure
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

                    b.Property<int>("CharacterListId")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.HasIndex("CharacterListId")
                        .IsUnique();

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Models.CharacterList", b =>
                {
                    b.Property<int>("CharacterListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("CharacterListId");

                    b.ToTable("CharacterList");
                });

            modelBuilder.Entity("Models.CharacterListRelation", b =>
                {
                    b.Property<int>("CharacterListId")
                        .HasColumnType("int");

                    b.Property<int>("TibiaCharacterId")
                        .HasColumnType("int");

                    b.HasKey("CharacterListId", "TibiaCharacterId");

                    b.HasIndex("TibiaCharacterId");

                    b.ToTable("CharacterListRelation");
                });

            modelBuilder.Entity("Models.TibiaCharacter", b =>
                {
                    b.Property<int>("TibiaCharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("TibiaCharacter");
                });

            modelBuilder.Entity("Models.Account", b =>
                {
                    b.HasOne("Models.CharacterList", "CharacterList")
                        .WithOne("Account")
                        .HasForeignKey("Models.Account", "CharacterListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.CharacterListRelation", b =>
                {
                    b.HasOne("Models.CharacterList", "CharacterList")
                        .WithMany("CharacterListRelations")
                        .HasForeignKey("CharacterListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.TibiaCharacter", "TibiaCharacter")
                        .WithMany("CharacterListRelations")
                        .HasForeignKey("TibiaCharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}