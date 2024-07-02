﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrabajoEdi3.Datos;

#nullable disable

namespace TrabajoEdi3.Datos.Migrations
{
    [DbContext(typeof(DbContex))]
    [Migration("20240509222514_AgregarGenero")]
    partial class AgregarGenero
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrabajoEdi3.Entidades.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColorId"));

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ColorId");

                    b.HasIndex("ColorName")
                        .IsUnique();

                    b.ToTable("colors");

                    b.HasData(
                        new
                        {
                            ColorId = 1,
                            ColorName = "Rojo"
                        },
                        new
                        {
                            ColorId = 2,
                            ColorName = "Azul"
                        },
                        new
                        {
                            ColorId = 3,
                            ColorName = "Amarillo"
                        });
                });

            modelBuilder.Entity("TrabajoEdi3.Entidades.Deporte", b =>
                {
                    b.Property<int>("DeporteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeporteId"));

                    b.Property<string>("NombreDeporte")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("DeporteId");

                    b.HasIndex("NombreDeporte")
                        .IsUnique();

                    b.ToTable("deportes");
                });

            modelBuilder.Entity("TrabajoEdi3.Entidades.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GeneroId"));

                    b.Property<string>("GeneroNombre")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("GeneroId");

                    b.HasIndex("GeneroNombre")
                        .IsUnique();

                    b.ToTable("generos");

                    b.HasData(
                        new
                        {
                            GeneroId = 1,
                            GeneroNombre = "Femenino"
                        },
                        new
                        {
                            GeneroId = 2,
                            GeneroNombre = "Masculino"
                        },
                        new
                        {
                            GeneroId = 3,
                            GeneroNombre = "Binario"
                        });
                });

            modelBuilder.Entity("TrabajoEdi3.Entidades.Marca", b =>
                {
                    b.Property<int>("MarcaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarcaId"));

                    b.Property<string>("MarcaNombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MarcaId");

                    b.HasIndex("MarcaNombre")
                        .IsUnique();

                    b.ToTable("marcas");

                    b.HasData(
                        new
                        {
                            MarcaId = 1,
                            MarcaNombre = "Nike"
                        },
                        new
                        {
                            MarcaId = 2,
                            MarcaNombre = "Adidas"
                        },
                        new
                        {
                            MarcaId = 3,
                            MarcaNombre = "Puma"
                        });
                });

            modelBuilder.Entity("TrabajoEdi3.Entidades.Zapatilla", b =>
                {
                    b.Property<int>("ZapatillaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ZapatillaId"));

                    b.Property<int>("ColoresId")
                        .HasColumnType("int");

                    b.Property<int>("DeporteId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ZapatillaId");

                    b.HasIndex("ColoresId");

                    b.HasIndex("DeporteId");

                    b.HasIndex("GeneroId");

                    b.HasIndex("MarcaId");

                    b.ToTable("zapatillas");
                });

            modelBuilder.Entity("TrabajoEdi3.Entidades.Zapatilla", b =>
                {
                    b.HasOne("TrabajoEdi3.Entidades.Color", "Colores")
                        .WithMany("zapatillas")
                        .HasForeignKey("ColoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrabajoEdi3.Entidades.Deporte", "Deporte")
                        .WithMany("zapatillas")
                        .HasForeignKey("DeporteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrabajoEdi3.Entidades.Genero", "Genero")
                        .WithMany("zapatillas")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrabajoEdi3.Entidades.Marca", "Marca")
                        .WithMany("zapatillas")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colores");

                    b.Navigation("Deporte");

                    b.Navigation("Genero");

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("TrabajoEdi3.Entidades.Color", b =>
                {
                    b.Navigation("zapatillas");
                });

            modelBuilder.Entity("TrabajoEdi3.Entidades.Deporte", b =>
                {
                    b.Navigation("zapatillas");
                });

            modelBuilder.Entity("TrabajoEdi3.Entidades.Genero", b =>
                {
                    b.Navigation("zapatillas");
                });

            modelBuilder.Entity("TrabajoEdi3.Entidades.Marca", b =>
                {
                    b.Navigation("zapatillas");
                });
#pragma warning restore 612, 618
        }
    }
}
