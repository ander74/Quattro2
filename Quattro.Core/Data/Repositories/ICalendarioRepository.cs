using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quattro.Core.Data.Models;

namespace Quattro.Core.Data.Repositories {

    public interface ICalendarioRepository {


        // ====================================================================================================
        #region MÉTODOS CALENDARIO
        // ====================================================================================================

        IQueryable<DiaCalendario> GetMes(DateTime fecha);

        Task GuardarDatosAsync();


        DiaCalendario GetDia(DateTime fecha);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS INCIDENCIAS
        // ====================================================================================================

        Task<Incidencia> GetIncidencia(int codigo);

        Task<IEnumerable<Incidencia>> GetIncidencias();

        #endregion
        // ====================================================================================================

    }
}
