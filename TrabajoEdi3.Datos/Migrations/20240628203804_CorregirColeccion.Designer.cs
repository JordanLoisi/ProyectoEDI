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
    [Migration("20240628203804_CorregirColeccion")]
    partial class CorregirColeccion
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

                    b.HasData(
                        new
                        {
                            DeporteId = 1,
                            NombreDeporte = "Tenis"
                        },
                        new
                        {
                            DeporteId = 2,
                            NombreDeporte = "Futbol"
                        },
                        new
                        {
                            DeporteId = 3,
                            NombreDeporte = "Padel"
                        });
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

            modelBuilder.Entity("TrabajoEdi3.Entidades.Talles", b =>
                {
                    b.Property<int>("TallesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TallesId"));

                    b.Property<decimal>("TallesNumbero")
                        .HasColumnType("decimal(3, 1)");

                    b.HasKey("TallesId");

                    b.HasIndex("TallesNumbero")
                        .IsUnique();

                    b.ToTable("talles");

                    b.HasData(
                        new
                        {
                            TallesId = 1,
                            TallesNumbero = 28m
                        },
                        new
                        {
                            TallesId = 2,
                            TallesNumbero = 28.5m
                        },
                        new
                        {
                            TallesId = 3,
                            TallesNumbero = 29m
                        },
                        new
                        {
                            TallesId = 4,
                            TallesNumbero = 29.5m
                        },
                        new
                        {
                            TallesId = 5,
                            TallesNumbero = 30m
                        },
                        new
                        {
                            TallesId = 6,
                            TallesNumbero = 30.5m
                        },
                        new
                        {
                            TallesId = 7,
                            TallesNumbero = 31m
                        },
                        new
                        {
                            TallesId = 8,
                            TallesNumbero = 31.5m
                        },
                        new
                        {
                            TallesId = 9,
                            TallesNumbero = 32m
                        },
                        new
                        {
                            TallesId = 10,
                            TallesNumbero = 32.5m
                        },
                        new
                        {
                            TallesId = 11,
                            TallesNumbero = 33m
                        },
                        new
                        {
                            TallesId = 12,
                            TallesNumbero = 33.5m
                        },
                        new
                        {
                            TallesId = 13,
                            TallesNumbero = 34m
                        },
                        new
                        {
                            TallesId = 14,
                            TallesNumbero = 34.5m
                        },
                        new
                        {
                            TallesId = 15,
                            TallesNumbero = 35m
                        },
                        new
                        {
                            TallesId = 16,
                            TallesNumbero = 35.5m
                        },
                        new
                        {
                            TallesId = 17,
                            TallesNumbero = 36m
                        },
                        new
                        {
                            TallesId = 18,
                            TallesNumbero = 36.5m
                        },
                        new
                        {
                            TallesId = 19,
                            TallesNumbero = 37m
                        },
                        new
                        {
                            TallesId = 20,
                            TallesNumbero = 37.5m
                        },
                        new
                        {
                            TallesId = 21,
                            TallesNumbero = 38m
                        },
                        new
                        {
                            TallesId = 22,
                            TallesNumbero = 38.5m
                        },
                        new
                        {
                            TallesId = 23,
                            TallesNumbero = 39m
                        },
                        new
                        {
                            TallesId = 24,
                            TallesNumbero = 39.5m
                        },
                        new
                        {
                            TallesId = 25,
                            TallesNumbero = 40m
                        },
                        new
                        {
                            TallesId = 26,
                            TallesNumbero = 40.5m
                        },
                        new
                        {
                            TallesId = 27,
                            TallesNumbero = 41m
                        },
                        new
                        {
                            TallesId = 28,
                            TallesNumbero = 41.5m
                        },
                        new
                        {
                            TallesId = 29,
                            TallesNumbero = 42m
                        },
                        new
                        {
                            TallesId = 30,
                            TallesNumbero = 42.5m
                        },
                        new
                        {
                            TallesId = 31,
                            TallesNumbero = 43m
                        },
                        new
                        {
                            TallesId = 32,
                            TallesNumbero = 43.5m
                        },
                        new
                        {
                            TallesId = 33,
                            TallesNumbero = 44m
                        },
                        new
                        {
                            TallesId = 34,
                            TallesNumbero = 44.5m
                        },
                        new
                        {
                            TallesId = 35,
                            TallesNumbero = 45m
                        },
                        new
                        {
                            TallesId = 36,
                            TallesNumbero = 45.5m
                        },
                        new
                        {
                            TallesId = 37,
                            TallesNumbero = 46m
                        },
                        new
                        {
                            TallesId = 38,
                            TallesNumbero = 46.5m
                        },
                        new
                        {
                            TallesId = 39,
                            TallesNumbero = 47m
                        },
                        new
                        {
                            TallesId = 40,
                            TallesNumbero = 47.5m
                        },
                        new
                        {
                            TallesId = 41,
                            TallesNumbero = 48m
                        },
                        new
                        {
                            TallesId = 42,
                            TallesNumbero = 48.5m
                        },
                        new
                        {
                            TallesId = 43,
                            TallesNumbero = 49m
                        },
                        new
                        {
                            TallesId = 44,
                            TallesNumbero = 49.5m
                        },
                        new
                        {
                            TallesId = 45,
                            TallesNumbero = 50m
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

                    b.HasData(
                        new
                        {
                            ZapatillaId = 1,
                            ColoresId = 1,
                            DeporteId = 1,
                            Description = "Altas",
                            GeneroId = 1,
                            MarcaId = 1,
                            Modelo = "Air",
                            Precio = 100000m
                        },
                        new
                        {
                            ZapatillaId = 2,
                            ColoresId = 2,
                            DeporteId = 2,
                            Description = "Bajas",
                            GeneroId = 2,
                            MarcaId = 2,
                            Modelo = "BAD BUNNY",
                            Precio = 200000m
                        },
                        new
                        {
                            ZapatillaId = 3,
                            ColoresId = 3,
                            DeporteId = 1,
                            Description = "Medianas",
                            GeneroId = 1,
                            MarcaId = 3,
                            Modelo = "Roma",
                            Precio = 100000m
                        });
                });

            modelBuilder.Entity("TrabajoEdi3.Entidades.ZapatillasTalles", b =>
                {
                    b.Property<int>("ZapatillaTallesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ZapatillaTallesId"));

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.Property<int>("TallesId")
                        .HasColumnType("int");

                    b.Property<int>("ZapatillaId")
                        .HasColumnType("int");

                    b.HasKey("ZapatillaTallesId");

                    b.HasIndex("TallesId");

                    b.HasIndex("ZapatillaId");

                    b.HasIndex("ZapatillaTallesId")
                        .IsUnique();

                    b.ToTable("zapatillastalles");
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

            modelBuilder.Entity("TrabajoEdi3.Entidades.ZapatillasTalles", b =>
                {
                    b.HasOne("TrabajoEdi3.Entidades.Talles", "Talles")
                        .WithMany("zapatillastalles")
                        .HasForeignKey("TallesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrabajoEdi3.Entidades.Zapatilla", "Zapatilla")
                        .WithMany("zapatillastalles")
                        .HasForeignKey("ZapatillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Talles");

                    b.Navigation("Zapatilla");
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

            modelBuilder.Entity("TrabajoEdi3.Entidades.Talles", b =>
                {
                    b.Navigation("zapatillastalles");
                });

            modelBuilder.Entity("TrabajoEdi3.Entidades.Zapatilla", b =>
                {
                    b.Navigation("zapatillastalles");
                });
#pragma warning restore 612, 618
        }
    }
}
