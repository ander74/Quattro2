using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quattro.Core.Common;
using Quattro.Core.Data.Models;

namespace Quattro.Core.Data {

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
            string dataBaseFile = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "database.qt2"); // Comentada en Dummy
            //string dataBaseFile = Path.Combine("Datos", "database.qt2"); // Comentada en Core
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
            //TODO: Crear las incidencias fijas.

            // Horas Ajenas

            // Compañeros


            base.OnModelCreating(modelBuilder);
        }

        #endregion
        // ====================================================================================================

    }
}
