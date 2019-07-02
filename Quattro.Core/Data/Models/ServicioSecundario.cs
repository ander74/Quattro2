using Quattro.Core.Data.Entities;

namespace Quattro.Core.Data.Models {

    public class ServicioSecundario : ServicioBase {

        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public ServicioSecundario() { }

        public ServicioSecundario(ServicioSecundarioEntity entidad) => this.FromEntity(entidad);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS ENTITIES
        // ====================================================================================================

        public void FromEntity(ServicioSecundarioEntity entidad) {
            if (entidad == null) return;
            base.FromEntity(entidad);
        }

        public void ToEntity(ServicioSecundarioEntity entidad) {
            if (entidad == null) return;
            base.ToEntity(entidad);
        }

        #endregion
        // ====================================================================================================

    }
}
