﻿namespace Quattro.Core.Data.Models {

    public class ServicioDia : ServicioBase {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public ServicioDia() { }

        public ServicioDia(ServicioDia model) => this.FromModel(model);

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

        public void FromModel(ServicioDia model) {
            if (model == null) return;
            base.FromModel(model);
        }

        #endregion
        // ====================================================================================================

    }
}
