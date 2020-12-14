using Quattro.Core.Data.Models;

namespace Quattro.Core.Data.SQLiteEntities {

    public class ServicioSecundarioEntity : ServicioBaseEntity {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public ServicioSecundarioEntity() { }

        public ServicioSecundarioEntity(ServicioSecundario model) => FromModel(model);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int IdServicioLinea { get; set; }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(ServicioSecundario model) {
            if (model == null) return;
            //IdServicioLinea = model.IdServicioLinea;
            base.FromModel(model);
        }

        #endregion
        // ====================================================================================================



    }
}
