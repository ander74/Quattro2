using System.ComponentModel.DataAnnotations.Schema;

namespace Quattro.Core.Data.Models {

    [Table("ServiciosSecundarios")]
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
        #region MÉTODOS ENTITIES
        // ====================================================================================================

        public void FromModel(ServicioSecundario model) {
            if (model == null) return;
            base.FromModel(model);
        }

        public new ServicioSecundario ToModel() {
            return (ServicioSecundario)base.ToModel();
        }

        #endregion
        // ====================================================================================================

    }
}
