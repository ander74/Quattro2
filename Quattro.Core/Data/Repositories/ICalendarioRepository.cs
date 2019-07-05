using System;
using System.Linq;
using System.Threading.Tasks;
using Quattro.Core.Data.Models;

namespace Quattro.Core.Data.Repositories {

    public interface ICalendarioRepository {


        IQueryable<DiaCalendario> GetMes(DateTime fecha);

        Task GuardarDatosAsync();

        // ====================================================================================================
        #region MÉTODOS INCIDENCIAS
        // ====================================================================================================

        Task<Incidencia> GetIncidencia(int codigo);

        #endregion
        // ====================================================================================================

    }
}
