using System.Collections.Generic;
using System.Linq;
using Quattro.Core.Data.Models;

namespace Quattro.Core.Data.SQLiteEntities {

    public class LineaEntity {


        // ====================================================================================================
        #region CONSTRUCTORES
        // ====================================================================================================

        public LineaEntity() { }

        public LineaEntity(Linea model) => FromModel(model);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int Id { get; set; }

        public string Numero { get; set; }

        public string Descripcion { get; set; }

        public string Notas { get; set; }

        public IEnumerable<ServicioLineaEntity> Servicios { get; set; }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(Linea model) {
            if (model == null) return;
            this.Id = model.Id;
            Numero = model.Numero;
            Descripcion = model.Descripcion;
            Notas = model.Notas;
            Servicios = model.Servicios.Select(s => new ServicioLineaEntity(s));
        }

        #endregion
        // ====================================================================================================



    }
}
