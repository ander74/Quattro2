using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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


        private IEnumerable<ServicioSecundario> servicios;
        public IEnumerable<ServicioSecundario> Servicios {
            get => servicios;
            set => SetProperty(ref servicios, value);
        }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS ENTITIES
        // ====================================================================================================

        public void FromModel(ServicioLinea model) {
            if (model == null) return;
            base.FromModel(model);
            this.Servicios = model.Servicios.AsEnumerable();
        }

        public new ServicioLinea ToModel() {
            ServicioLinea model = (ServicioLinea)base.ToModel();
            model.Servicios = this.Servicios.AsEnumerable();
            return model;
        }

        #endregion
        // ====================================================================================================

    }
}
