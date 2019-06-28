using System;
using System.Linq;
using Quattro.Core.Data.Entities;

namespace Quattro.Core.Data.Repositories {

    public class CalendarioRepository : ICalendarioRepository {

        // ====================================================================================================
        #region CAMPOS PRIVADOS
        // ====================================================================================================

        private readonly QuattroContext context;

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public CalendarioRepository(QuattroContext context) {
            this.context = context;
            context.Database.EnsureCreated();
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS DE INTERFAZ
        // ====================================================================================================

        public IQueryable<DiaCalendarioEntity> GetMes(DateTime fecha) {
            if (!context.Calendario.Any(c => c.Fecha.Month == fecha.Month && c.Fecha.Year == fecha.Year)) {
                for (int dia = 1; dia <= DateTime.DaysInMonth(fecha.Year, fecha.Month); dia++) {
                    context.Calendario.Add(new DiaCalendarioEntity {
                        Fecha = new DateTime(fecha.Year, fecha.Month, dia),
                    });
                }
                context.SaveChanges();
            }
            return context.Calendario.Where(c => c.Fecha.Month == fecha.Month && c.Fecha.Year == fecha.Year);
        }

        #endregion
        // ====================================================================================================


    }
}
