﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetBDLivres.Data;

namespace ProjetBDLivres.Data.Migrations
{
    [DbContext(typeof(LivresContext))]
    [Migration("20210804172000_AddedDataAnnotationsToLivreModel")]
    partial class AddedDataAnnotationsToLivreModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetBDLivres.Models.Livres", b =>
                {
                    b.Property<int>("livreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("annee")
                        .HasColumnType("int");

                    b.Property<string>("auteur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("livreId");

                    b.ToTable("Livres");
                });
#pragma warning restore 612, 618
        }
    }
}
