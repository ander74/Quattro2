using System.ComponentModel.DataAnnotations.Schema;

namespace Quattro.Core.Data.Models {

    [Table("ServiciosDia")]
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

        public void FromModel(ServicioDia entidad, bool ignorarId = false) {
            if (entidad == null) return;
            base.FromModel(entidad, ignorarId);
        }

        public new ServicioDia ToModel() {
            return (ServicioDia)base.ToModel();
        }

        #endregion
        // ====================================================================================================

    }
}
