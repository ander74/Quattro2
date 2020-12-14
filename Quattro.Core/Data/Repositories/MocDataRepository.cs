using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quattro.Core.Data.Models;

namespace Quattro.Core.Data.Repositories {

    public class MocDataRepository : IDataRepository {

        // ====================================================================================================
        #region CAMPOS PRIVADOS
        // ====================================================================================================

        List<DiaCalendario> lista = new List<DiaCalendario>();
        private readonly SQLiteContext context;

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public MocDataRepository(SQLiteContext context) {
            this.context = context;
        }

        #endregion
        // ====================================================================================================



        // ====================================================================================================
        #region MÉTODOS DE CALENDARIO
        // ====================================================================================================

        public IEnumerable<DiaCalendario> GetMes(DateTime fecha) {
            return new List<DiaCalendario>();// context.GetMes(fecha).Select(d => new DiaCalendario(d));
        }


        public async Task GuardarDatosAsync() {
            if (lista != null && lista.Count > 0) {
                //context.GuardarDiasCalendario(lista.Select(d => new DiaCalendarioEntity(d)));
            }
        }


        public DiaCalendario GetDia(DateTime fecha) {
            return new DiaCalendario();// context.GetDiaCalendario(fecha);
            //return lista.FirstOrDefault(d => d.Fecha.Year == fecha.Year && d.Fecha.Month == fecha.Month && d.Fecha.Day == fecha.Day);
        }

        public async Task<DiaCalendario> GetDiaAsync(DateTime fecha) {
            return lista.FirstOrDefault(d => d.Fecha.Year == fecha.Year && d.Fecha.Month == fecha.Month && d.Fecha.Day == fecha.Day);
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS DE INCIDENCIAS
        // ====================================================================================================

        public async Task<Incidencia> GetIncidenciaAsync(int codigo) {
            return new Incidencia { Codigo = 1, Descripcion = "Trabajo" };
        }

        public async Task<IEnumerable<Incidencia>> GetIncidenciasAsync() {
            return new List<Incidencia>();// context.GetIncidencias();
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS LÍNEAS
        // ====================================================================================================

        public async Task<IEnumerable<Linea>> GetLineasAsync(bool incuirCero = false) {
            var x = 1;
            if (incuirCero) x = 0;
            return new List<Linea> {
                new Linea{ Numero="RET", Descripcion = "Cabina Retuerto" },
                new Linea{ Numero="ROQ", Descripcion = "Oficina Portu" }
            };
        }

        public async Task<Linea> GetLineaByNumeroAsync(string numero) {
            return new Linea { Numero = numero, Descripcion = "Linea falsa" };
        }

        #endregion
        // ====================================================================================================


    }
}
