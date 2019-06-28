using System.ComponentModel.DataAnnotations.Schema;
using Quattro.Core.Common;

namespace Quattro.Core.Data.Entities {

    [Table("Companeros")]
    public class CompañeroEntity {

        public int Id { get; set; }

        public int Matricula { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public TipoCompañero Calificacion { get; set; }

        public int Deuda { get; set; }

        public string Notas { get; set; }


    }
}
