using System.ComponentModel.DataAnnotations.Schema;
using Quattro.Core.Common;

namespace Quattro.Core.Data.Entities {

    [Table("Incidencias")]
    public class IncidenciaEntity {

        public int Id { get; set; }

        public string Descripcion { get; set; }

        public TipoIncidencia Tipo { get; set; }

        public string Notas { get; set; }

    }
}
