using System;
using Quattro.Core.Common;
using Quattro.Core.Data.Models;

namespace Quattro.Core.Data.SQLiteEntities {

    public class HoraAjenaEntity {

        // ====================================================================================================
        #region CONSTRUCTORES
        // ====================================================================================================

        public HoraAjenaEntity() { }

        public HoraAjenaEntity(HoraAjena model) => FromModel(model);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Horas { get; set; }

        public string Motivo { get; set; }

        public TipoHoraAjena Tipo { get; set; }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(HoraAjena model) {
            if (model == null) return;
            Id = model.Id;
            Fecha = model.Fecha;
            Horas = model.Horas;
            Motivo = model.Motivo;
            Tipo = model.Tipo;
        }

        #endregion
        // ====================================================================================================



    }
}
