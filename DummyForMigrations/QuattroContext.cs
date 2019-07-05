using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quattro.Core.Common;
using Quattro.Core.Data.Models;

namespace DummyForMigrations {

    public class QuattroContext : DbContext {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public QuattroContext() : base() {

        }

        public QuattroContext(DbContextOptions<QuattroContext> options) : base(options) {
            
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region DB SETS
        // ====================================================================================================

        public DbSet<Linea> Lineas { get; set; }

        public DbSet<ServicioLinea> ServiciosLinea { get; set; }

        public DbSet<ServicioSecundario> ServiciosSecundarios { get; set; }

        public DbSet<DiaCalendario> Calendario { get; set; }

        public DbSet<ServicioDia> ServiciosDia { get; set; }

        public DbSet<Incidencia> Incidencias { get; set; }

        public DbSet<HoraAjena> HorasAjenas { get; set; }

        public DbSet<Compañero> Compañeros { get; set; }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region ON CONFIGURING
        // ====================================================================================================

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //string dataBaseFile = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "database.qt2"); // Comentada en Dummy
            string dataBaseFile = Path.Combine("Datos", "database.qt2"); // Comentada en Core
            optionsBuilder.UseSqlite($"Filename={dataBaseFile}");
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region ON MODEL CREATING
        // ====================================================================================================

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            // Convertidor Tiempo
            var ConvertidorTiempo = new ValueConverter<Tiempo, int>(
                t => t.TotalMinutos,
                i => Tiempo.FromMinutos(i)
            );

            // Servicios Línea
            modelBuilder.Entity<ServicioLinea>().Property(sl => sl.Inicio).HasConversion(ConvertidorTiempo);
            modelBuilder.Entity<ServicioLinea>().Property(sl => sl.Final).HasConversion(ConvertidorTiempo);
            modelBuilder.Entity<ServicioLinea>().Property(sl => sl.TomaDeje).HasConversion(ConvertidorTiempo);

            // Servicios Secundarios
            modelBuilder.Entity<ServicioSecundario>().Property(ss => ss.Inicio).HasConversion(ConvertidorTiempo);
            modelBuilder.Entity<ServicioSecundario>().Property(ss => ss.Final).HasConversion(ConvertidorTiempo);

            // Dia Calendario
            modelBuilder.Entity<DiaCalendario>().Property(dc => dc.Inicio).HasConversion(ConvertidorTiempo);
            modelBuilder.Entity<DiaCalendario>().Property(dc => dc.Final).HasConversion(ConvertidorTiempo);
            modelBuilder.Entity<DiaCalendario>().Property(dc => dc.TomaDeje).HasConversion(ConvertidorTiempo);

            // Servicios Dia
            modelBuilder.Entity<ServicioDia>().Property(sd => sd.Inicio).HasConversion(ConvertidorTiempo);
            modelBuilder.Entity<ServicioDia>().Property(sd => sd.Final).HasConversion(ConvertidorTiempo);

            // Incidencias
            modelBuilder.Entity<Incidencia>()
                .HasData(
                new Incidencia { Id = 01, Codigo = 0, Descripcion = "Repite día anterior", Tipo = TipoIncidencia.Desconocido, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 02, Codigo = 1, Descripcion = "Trabajo", Tipo = TipoIncidencia.Trabajo, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 03, Codigo = 2, Descripcion = "Franqueo", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 04, Codigo = 3, Descripcion = "Vacaciones", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 05, Codigo = 4, Descripcion = "F.O.D.", Tipo = TipoIncidencia.FiestaOtroDia, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 06, Codigo = 5, Descripcion = "Franqueo a trabajar", Tipo = TipoIncidencia.FranqueoTrabajado, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 07, Codigo = 6, Descripcion = "Enferma/o", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 08, Codigo = 7, Descripcion = "Accidentada/o", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 09, Codigo = 8, Descripcion = "Permiso", Tipo = TipoIncidencia.JornadaMedia, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 10, Codigo = 9, Descripcion = "F.N.R. año actual", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 11, Codigo = 10, Descripcion = "F.N.R. año anterior", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 12, Codigo = 11, Descripcion = "Nos hacen el día", Tipo = TipoIncidencia.Trabajo, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 13, Codigo = 12, Descripcion = "Hacemos el día", Tipo = TipoIncidencia.TrabajoSinAcumular, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 14, Codigo = 13, Descripcion = "Sanción", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 15, Codigo = 14, Descripcion = "En otro destino", Tipo = TipoIncidencia.Franqueo, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 16, Codigo = 15, Descripcion = "Huelga", Tipo = TipoIncidencia.TrabajoSinAcumular, Notas = "Incidencia Protegida." },
                new Incidencia { Id = 17, Codigo = 16, Descripcion = "Día por H. Acumuladas", Tipo = TipoIncidencia.FiestaOtroDia, Notas = "Incidencia Protegida." }
                );

            // Horas Ajenas

            // Compañeros


            base.OnModelCreating(modelBuilder);
        }

        #endregion
        // ====================================================================================================

    }
}
