using Quattro.Core.Common;
using Quattro.Core.Data.Models;

namespace Quattro.Core.Data.SQLiteEntities {

    public class IncidenciaEntity {

        // ====================================================================================================
        #region CONSTRUCTORES
        // ====================================================================================================

        public IncidenciaEntity() { }

        public IncidenciaEntity(Incidencia model) => FromModel(model);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int Id { get; set; }

        public int Codigo { get; set; }


        public string Descripcion { get; set; }

        public TipoIncidencia Tipo { get; set; }

        public string Notas { get; set; }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(Incidencia model) {
            if (model == null) return;
            Id = model.Id;
            Codigo = model.Codigo;
            Descripcion = model.Descripcion;
            Tipo = model.Tipo;
            Notas = model.Notas;
        }

        #endregion
        // ====================================================================================================



    }
}
