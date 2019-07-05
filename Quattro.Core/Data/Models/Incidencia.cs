using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quattro.Core.Common;

namespace Quattro.Core.Data.Models {

    [Table("Incidencias")]
    public class Incidencia : BaseModel {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public Incidencia() { }

        public Incidencia(Incidencia model) => this.FromModel(model);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int Id { get; set; }


        private int codigo;
        public int Codigo {
            get => codigo;
            set => SetProperty(ref codigo, value);
        }


        private string descripcion;
        [MaxLength(64)]
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

        public void FromModel(Incidencia model) {
            if (model == null) return;
            this.Descripcion = model.Descripcion;
            this.Id = model.Id;
            this.Notas = model.Notas;
            this.Tipo = model.Tipo;
        }

        public Incidencia ToEntity() {
            return new Incidencia {
                Descripcion = this.Descripcion,
                Id = this.Id,
                Notas = this.Notas,
                Tipo = this.Tipo,
            };
        }

        #endregion
        // ====================================================================================================


    }
}
