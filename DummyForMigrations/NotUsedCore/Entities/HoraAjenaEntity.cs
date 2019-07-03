using System;
using System.ComponentModel.DataAnnotations.Schema;
using Quattro.Core.Common;

namespace Quattro.Core.Data.Entities {

    [Table("HorasAjenas")]
    public class HoraAjenaEntity {

        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Horas { get; set; }

        public string Motivo { get; set; }

        public TipoHoraAjena Tipo { get; set; }

    }
}
