using System;
using System.Linq;
using Quattro.Core.Data.Entities;

namespace Quattro.Core.Data.Repositories {

    public interface ICalendarioRepository {


        IQueryable<DiaCalendarioEntity> GetMes(DateTime fecha);

    }
}
