using System.Collections.Generic;
using System.Linq;
using Quattro.Core.Data.Models;

namespace Quattro.Core.Data.SQLiteEntities {

    public class ServicioLineaEntity : ServicioBaseEntity {

        // ====================================================================================================
        #region CONSTRUCTORES
        // ====================================================================================================

        public ServicioLineaEntity() { }

        public ServicioLineaEntity(ServicioLinea model) => FromModel(model);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int IdLinea { get; set; }

        public IEnumerable<ServicioSecundarioEntity> Servicios { get; set; }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(ServicioLinea model) {
            base.FromModel(model);
            //IdLinea = model.IdLinea;
            Servicios = model.Servicios.Select(s => new ServicioSecundarioEntity(s));
        }

        #endregion
        // ====================================================================================================


    }
}
