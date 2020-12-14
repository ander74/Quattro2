using System.Collections.Generic;

namespace Quattro.Core.Data.Models {

    public class ServicioLinea : ServicioBase {

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

        public void FromModel(ServicioLinea model) {
            if (model == null) return;
            base.FromModel(model);
            servicios = model.Servicios;
        }

        #endregion
        // ====================================================================================================

    }
}
