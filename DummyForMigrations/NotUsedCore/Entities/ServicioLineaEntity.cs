using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quattro.Core.Data.Entities {

    [Table("ServiciosLinea")]
    public class ServicioLineaEntity : ServicioEntity {

        public IEnumerable<ServicioSecundarioEntity> Servicios { get; set; }

    }
}
