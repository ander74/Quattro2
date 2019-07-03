using System.ComponentModel.DataAnnotations.Schema;
using Quattro.Core.Common;

namespace Quattro.Core.Data.Entities {

    [Table("Convenios")]
    public class ConvenioEntity {

        public int Id { get; set; }

        public decimal JornadaMedia { get; set; }

        public decimal JornadaMinima { get; set; }

        public decimal JornadaAnual { get; set; }

        public Tiempo LimiteEntreServicios { get; set; }

        public Tiempo InicioNocturnas { get; set; }

        public Tiempo FinalNocturnas { get; set; }

        public Tiempo LimiteDesayuno { get; set; }

        public Tiempo LimiteComidaTurno1 { get; set; }

        public Tiempo LimiteComidaTurno2 { get; set; }

        public Tiempo LimiteCena { get; set; }


    }
}
