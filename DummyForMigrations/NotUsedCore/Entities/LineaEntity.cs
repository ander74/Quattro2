using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quattro.Core.Data.Entities {

    [Table("Lineas")]
    public class LineaEntity {

        public int Id { get; set; }

        public string Numero { get; set; }

        public string Descripcion { get; set; }

        public string Notas { get; set; }

        public IEnumerable<ServicioLineaEntity> Servicios { get; set; }



    }
}
