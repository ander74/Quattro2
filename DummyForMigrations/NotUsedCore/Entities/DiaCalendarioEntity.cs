using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quattro.Core.Data.Entities {

    [Table("Calendario")]
    public class DiaCalendarioEntity : ServicioEntity {

        public DateTime Fecha { get; set; }

        public bool EsFranqueo { get; set; }

        public bool EsFestivo { get; set; }

        public bool HuelgaParcial { get; set; }

        public decimal HorasHuelga { get; set; }

        public decimal Trabajadas { get; set; }

        public decimal Acumuladas { get; set; }

        public decimal Nocturnas { get; set; }

        public bool Desayuno { get; set; }

        public bool Comida { get; set; }

        public bool Cena { get; set; }

        public string Bus { get; set; }

        public IncidenciaEntity Incidencia { get; set; }

        public CompañeroEntity Relevo { get; set; }

        public CompañeroEntity Susti { get; set; }

        public IEnumerable<ServicioDiaEntity> Servicios { get; set; }
    }
}
