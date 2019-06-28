using Quattro.Core.Common;
using Quattro.Core.Data.Entities;

namespace Quattro.Core.Data.Models {

    public class Incidencia : BaseModel {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public Incidencia() { }

        public Incidencia(IncidenciaEntity entidad) => this.FromEntity(entidad);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int Id { get; set; }


        private string descripcion;
        public string Descripcion {
            get => descripcion;
            set => SetProperty(ref descripcion, value);
        }


        private TipoIncidencia tipo;
        public TipoIncidencia Tipo {
            get => tipo;
            set => SetProperty(ref tipo, value);
        }


        private string notas;
        public string Notas {
            get => notas;
            set => SetProperty(ref notas, value);
        }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS ENTITIES
        // ====================================================================================================

        public void FromEntity(IncidenciaEntity entidad) {
            this.Descripcion = entidad.Descripcion;
            this.Id = entidad.Id;
            this.Notas = entidad.Notas;
            this.Tipo = entidad.Tipo;
        }

        public void ToEntity(IncidenciaEntity entidad) {
            entidad.Descripcion = this.Descripcion;
            entidad.Id = this.Id;
            entidad.Notas = this.Notas;
            entidad.Tipo = this.Tipo;
        }

        #endregion
        // ====================================================================================================


    }
}
