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
            base.FromEntity(entidad);
        }

        public void ToEntity(ServicioSecundarioEntity entidad) {
            base.ToEntity(entidad);
        }

        #endregion
        // ====================================================================================================

    }
}
