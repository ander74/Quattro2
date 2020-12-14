using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Quattro.Core.Data.Models;

namespace Quattro.Core.Data.Repositories {

    public interface IDataRepository {


        // ====================================================================================================
        #region MÉTODOS CALENDARIO
        // ====================================================================================================

        IEnumerable<DiaCalendario> GetMes(DateTime fecha);

        Task GuardarDatosAsync();

        DiaCalendario GetDia(DateTime fecha);

        Task<DiaCalendario> GetDiaAsync(DateTime fecha);


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS INCIDENCIAS
        // ====================================================================================================

        Task<Incidencia> GetIncidenciaAsync(int codigo);

        Task<IEnumerable<Incidencia>> GetIncidenciasAsync();

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS LÍNEAS
        // ====================================================================================================

        Task<IEnumerable<Linea>> GetLineasAsync(bool incluirCero = false);

        Task<Linea> GetLineaByNumeroAsync(string numero);

        #endregion
        // ====================================================================================================

    }
}
