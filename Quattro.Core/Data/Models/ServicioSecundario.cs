﻿namespace Quattro.Core.Data.Models {

    public class ServicioSecundario : ServicioBase {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public ServicioSecundario() { }

        public ServicioSecundario(ServicioSecundario model) => this.FromModel(model);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(ServicioSecundario model) {
            if (model == null) return;
            base.FromModel(model);
        }

        #endregion
        // ====================================================================================================

    }
}
