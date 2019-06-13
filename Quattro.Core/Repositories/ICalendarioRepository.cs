using System;
using System.Collections.Generic;
using System.Text;
using Quattro.Core.Models;

namespace Quattro.Core.Repositories {
    public interface ICalendarioRepository {

        IEnumerable<DiaCalendario> GetMes(DateTime fecha);
    }
}
