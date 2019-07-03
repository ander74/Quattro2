using Quattro.Core.Common;

namespace Quattro.Core.Data.Entities {

    public abstract class ServicioBaseEntity {

        public int Id { get; set; }

        public string Servicio { get; set; }

        public int Turno { get; set; }

        public Tiempo Inicio { get; set; }

        public string LugarInicio { get; set; }

        public Tiempo Final { get; set; }

        public string LugarFinal { get; set; }

        public LineaEntity Linea { get; set; }

    }
}
