using Quattro.Core.Common;
using Quattro.Core.Data.Models;

namespace Quattro.Core.Data.SQLiteEntities {

    public class CompañeroEntity {


        // ====================================================================================================
        #region CONSTRUCTORES
        // ====================================================================================================

        public CompañeroEntity() { }

        public CompañeroEntity(Compañero model) => FromModel(model);


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int Id { get; set; }

        public int Matricula { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public TipoCompañero Calificacion { get; set; }

        public int Deuda { get; set; }

        public string Notas { get; set; }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(Compañero model) {
            if (model == null) return;
            Id = model.Id;
            Matricula = model.Matricula;
            Nombre = model.Nombre;
            Apellidos = model.Apellidos;
            Telefono = model.Telefono;
            Email = model.Email;
            Calificacion = model.Calificacion;
            Deuda = model.Deuda;
            Notas = model.Notas;
        }

        #endregion
        // ====================================================================================================




    }
}
