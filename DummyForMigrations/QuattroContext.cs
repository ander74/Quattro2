using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quattro.Core.Common;
using Quattro.Core.Data.Entities;

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

        public DbSet<LineaEntity> Lineas { get; set; }

        public DbSet<ServicioLineaEntity> ServiciosLinea { get; set; }

        public DbSet<ServicioSecundarioEntity> ServiciosSecundarios { get; set; }

        public DbSet<DiaCalendarioEntity> Calendario { get; set; }

        public DbSet<ServicioDiaEntity> ServiciosDia { get; set; }

        public DbSet<IncidenciaEntity> Incidencias { get; set; }

        public DbSet<HoraAjenaEntity> HorasAjenas { get; set; }

        public DbSet<CompañeroEntity> Compañeros { get; set; }

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
            modelBuilder.Entity<ServicioLineaEntity>().Property(sl => sl.Inicio).HasConversion(ConvertidorTiempo);
            modelBuilder.Entity<ServicioLineaEntity>().Property(sl => sl.Final).HasConversion(ConvertidorTiempo);
            modelBuilder.Entity<ServicioLineaEntity>().Property(sl => sl.TomaDeje).HasConversion(ConvertidorTiempo);

            // Servicios Secundarios
            modelBuilder.Entity<ServicioSecundarioEntity>().Property(ss => ss.Inicio).HasConversion(ConvertidorTiempo);
            modelBuilder.Entity<ServicioSecundarioEntity>().Property(ss => ss.Final).HasConversion(ConvertidorTiempo);

            // Dia Calendario
            modelBuilder.Entity<DiaCalendarioEntity>().Property(dc => dc.Inicio).HasConversion(ConvertidorTiempo);
            modelBuilder.Entity<DiaCalendarioEntity>().Property(dc => dc.Final).HasConversion(ConvertidorTiempo);
            modelBuilder.Entity<DiaCalendarioEntity>().Property(dc => dc.TomaDeje).HasConversion(ConvertidorTiempo);

            // Servicios Dia
            modelBuilder.Entity<ServicioDiaEntity>().Property(sd => sd.Inicio).HasConversion(ConvertidorTiempo);
            modelBuilder.Entity<ServicioDiaEntity>().Property(sd => sd.Final).HasConversion(ConvertidorTiempo);

            // Incidencias
            //TODO: Crear las incidencias fijas.

            // Horas Ajenas

            // Compañeros


            base.OnModelCreating(modelBuilder);
        }

        #endregion
        // ====================================================================================================

    }
}
