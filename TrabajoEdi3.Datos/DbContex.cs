using Microsoft.EntityFrameworkCore;
using System.Drawing;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Datos
{
    public class DbContex : DbContext
    {
        public DbSet<Zapatilla> zapatillas { get; set; }
      public   DbSet<Genero> generos { get; set; }
       public  DbSet<Entidades.Color> colors { get; set; }
        public DbSet<Marca> marcas { get; set; }
        public DbSet<Deporte> deportes { get; set; }
         public DbSet<Talles> talles { get; set; }
        public DbSet<ZapatillasTalles> zapatillastalles { get; set; }
        public DbContex()
        {

        }
        public DbContex(DbContextOptions<DbContex> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
               => optionsBuilder.UseSqlServer(@"Data Source=.; 
                Initial Catalog=TrabajoPracticoEDI3; 
                Trusted_Connection=true; 
                TrustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marca>().HasIndex(c => c.MarcaNombre).IsUnique();
            modelBuilder.Entity<Deporte>().HasIndex(c => c.NombreDeporte).IsUnique();
            modelBuilder.Entity<Genero>().HasIndex(c => c.GeneroNombre).IsUnique();
            modelBuilder.Entity<Entidades.Color>().HasIndex(c => c.ColorName).IsUnique();
            modelBuilder.Entity<Talles>().HasIndex(s => s.TallesNumbero).IsUnique();
            modelBuilder.Entity<ZapatillasTalles>().HasIndex(s => s.ZapatillaTallesId).IsUnique();
            modelBuilder.Entity<ZapatillasTalles>().HasKey(s => s.ZapatillaTallesId);

            modelBuilder.Entity<Zapatilla>().Property(c => c.Precio).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Talles>().Property(s => s.TallesNumbero).HasColumnType("decimal(3, 1)");

            var MarcaList = new List<Marca>()
            {
                new Marca()
                {
                    MarcaId = 1,
                    MarcaNombre="Nike"
                },
                new Marca()
                {
                    MarcaId=2,
                    MarcaNombre="Adidas"
                },
                new Marca()
                {
                    MarcaId=3,
                    MarcaNombre="Puma"
                }

            };
            modelBuilder.Entity<Marca>().HasData(MarcaList);

            var ColoresList = new List<Entidades.Color>()
            {
                new Entidades.Color()
            {
                    ColorId=1,
                    ColorName="Rojo"
            },
                new Entidades.Color()
                {
                    ColorId=2,
                    ColorName="Azul"
                },
                new Entidades.Color()
                {
                    ColorId=3,
                    ColorName="Amarillo"
                }

            };
            modelBuilder.Entity<Entidades.Color>().HasData(ColoresList);

            var GenerosList = new List<Genero>()
            {
                new Genero()
                {
                    GeneroId=1,
                    GeneroNombre="Femenino"
                },
                new Genero()
                {
                    GeneroId=2,
                    GeneroNombre="Masculino"
                },
                new Genero()
                {
                    GeneroId =3,
                    GeneroNombre="Binario"
                }
            };
            modelBuilder.Entity<Genero>().HasData(GenerosList);

            var DeporteList = new List<Deporte>()
            {
                new Deporte()
                {
                    DeporteId=1,
                    NombreDeporte="Tenis"
                },
                new Deporte()
                {
                    DeporteId =2,
                    NombreDeporte="Futbol"
                },
                new Deporte()
                {
                    DeporteId=3,
                    NombreDeporte="Padel"
                }
            };
            modelBuilder.Entity<Deporte>().HasData(DeporteList);

            var Zapatillaslist = new List<Zapatilla>()
            {

                    new Zapatilla()

                    {
                        ZapatillaId=1,
                        MarcaId=1,
                        ColoresId=1,
                        GeneroId=1,
                        DeporteId=1,
                        Precio=100000,
                        Description="Altas",
                        Modelo="Air"


                    },
                    new Zapatilla()
                    {
                        ZapatillaId=2,
                        MarcaId=2,
                        ColoresId=2,
                        GeneroId=2,
                        DeporteId=2,
                        Precio=200000,
                        Description="Bajas",
                        Modelo="BAD BUNNY"
                    },
                    new Zapatilla ()
                    {
                        ZapatillaId=3,
                        MarcaId=3,
                        ColoresId=3,
                        GeneroId=1,
                        DeporteId=1,
                        Precio=100000,
                        Description="Medianas",
                        Modelo="Roma"
                    }
            };
            modelBuilder.Entity<Zapatilla>().HasData(Zapatillaslist);

            modelBuilder.Entity<Talles>(entity =>
            {
                
                List<Talles> talles = new List<Talles>();
                int keyId = 0;
                for (double i = 28; i <= 50; i += .5)
                {
                    keyId++;
                    var talle = new Talles()
                    {
                        TallesId = keyId,
                        TallesNumbero = Convert.ToDecimal(i),
                    };
                    talles.Add(talle);
                }
                entity.HasData(talles);
            });
        }
    }
}
