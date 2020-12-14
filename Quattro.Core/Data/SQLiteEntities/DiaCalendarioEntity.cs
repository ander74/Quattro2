using System;
using System.Collections.Generic;
using System.Linq;
using Quattro.Core.Data.Models;

namespace Quattro.Core.Data.SQLiteEntities {

    public class DiaCalendarioEntity : ServicioBaseEntity {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public DiaCalendarioEntity() { }

        public DiaCalendarioEntity(DiaCalendario model) => FromModel(model);


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

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

        public int IncidenciaId { get; set; }
        public IncidenciaEntity Incidencia { get; set; }

        public int RelevoId { get; set; }
        public CompañeroEntity Relevo { get; set; }

        public int SustiId { get; set; }
        public CompañeroEntity Susti { get; set; }

        public IEnumerable<ServicioDiaEntity> Servicios { get; set; }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(DiaCalendario model) {
            if (model == null) return;
            base.FromModel(model);
            Fecha = model.Fecha;
            EsFranqueo = model.EsFranqueo;
            EsFestivo = model.EsFestivo;
            HuelgaParcial = model.HuelgaParcial;
            HorasHuelga = model.HorasHuelga;
            Trabajadas = model.Trabajadas;
            Acumuladas = model.Acumuladas;
            Nocturnas = model.Nocturnas;
            Desayuno = model.Desayuno;
            Comida = model.Comida;
            Cena = model.Cena;
            Bus = model.Bus;
            IncidenciaId = model.Incidencia?.Id ?? 0;
            Incidencia = model.Incidencia == null ? null : new IncidenciaEntity(model.Incidencia);
            RelevoId = model.Relevo?.Id ?? 0;
            Relevo = model.Relevo == null ? null : new CompañeroEntity(model.Relevo);
            SustiId = model.Susti?.Id ?? 0;
            Susti = model.Susti == null ? null : new CompañeroEntity(model.Susti);
            Servicios = model.Servicios.Select(s => new ServicioDiaEntity(s));
        }

        #endregion
        // ====================================================================================================




    }
}
