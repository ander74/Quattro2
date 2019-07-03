using System;
using System.Linq;
using System.Threading.Tasks;
using Quattro.Core.Data.Models;

namespace Quattro.Core.Data.Repositories {

    public interface ICalendarioRepository {


        IQueryable<DiaCalendario> GetMes(DateTime fecha);

        Task GuardarDatosAsync();

    }
}
