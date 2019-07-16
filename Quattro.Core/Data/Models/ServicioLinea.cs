using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quattro.Core.Data.Models {

    [Table("ServiciosLinea")]
    public class ServicioLinea : Servicio {

        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public ServicioLinea() { }

        public ServicioLinea(ServicioLinea model) => this.FromModel(model);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================


        private List<ServicioSecundario> servicios;
        public List<ServicioSecundario> Servicios {
            get => servicios;
            set => SetProperty(ref servicios, value);
        }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(ServicioLinea model, bool ignorarId = false) {
            if (model == null) return;
            base.FromModel(model, ignorarId);
            servicios = model.Servicios;
        }

        public new ServicioLinea ToModel() {
            ServicioLinea model = (ServicioLinea)base.ToModel();
            model.Servicios = this.Servicios;
            return model;
        }

        #endregion
        // ====================================================================================================

    }
}
