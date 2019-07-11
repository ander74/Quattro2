using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quattro.Core.Data.Models;

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
        #region MÉTODOS DE CALENDARIO
        // ====================================================================================================

        public IQueryable<DiaCalendario> GetMes(DateTime fecha) {
            if (!context.Calendario.Any(c => c.Fecha.Month == fecha.Month && c.Fecha.Year == fecha.Year)) {
                for (int dia = 1; dia <= DateTime.DaysInMonth(fecha.Year, fecha.Month); dia++) {
                    context.Calendario.Add(new DiaCalendario {
                        Fecha = new DateTime(fecha.Year, fecha.Month, dia),
                    });
                }
                context.SaveChanges();
            }
            return context.Calendario.Where(c => c.Fecha.Month == fecha.Month && c.Fecha.Year == fecha.Year)
                .Include(c => c.Incidencia)
                .Include(c => c.Linea)
                .Include(c => c.Servicios).ThenInclude(s => s.Linea)
                .Include(c => c.Relevo)
                .Include(c => c.Susti)
                .OrderBy(c => c.Fecha);
        }


        public async Task GuardarDatosAsync() {
            await context.SaveChangesAsync();
        }


        public DiaCalendario GetDia(DateTime fecha) {
            return context.Calendario
                .Include(c => c.Incidencia)
                .Include(c => c.Linea)
                .Include(c => c.Servicios).ThenInclude(s => s.Linea)
                .Include(c => c.Relevo)
                .Include(c => c.Susti)
                .FirstOrDefault(d => d.Fecha.Year == fecha.Year && d.Fecha.Month == fecha.Month && d.Fecha.Day == fecha.Day);
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS DE INCIDENCIAS
        // ====================================================================================================

        public async Task<Incidencia> GetIncidencia(int codigo) {
            return await context.Incidencias.FirstOrDefaultAsync(i => i.Codigo == codigo);
        }

        public async Task<IEnumerable<Incidencia>> GetIncidencias() {
            return await context.Incidencias.Where(i => i.Codigo > 0).ToListAsync();
        }

        #endregion
        // ====================================================================================================


    }
}
