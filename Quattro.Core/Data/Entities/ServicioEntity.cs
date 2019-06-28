using Quattro.Core.Common;

namespace Quattro.Core.Data.Entities {

    public abstract class ServicioEntity : ServicioBaseEntity {

        public Tiempo TomaDeje { get; set; }

        public decimal Euros { get; set; }

        public string Notas { get; set; }

    }
}
