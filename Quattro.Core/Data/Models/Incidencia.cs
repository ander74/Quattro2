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
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(Incidencia model, bool ignorarId = false) {
            if (model == null) return;
            this.Id = ignorarId ? this.Id : model.Id;
            this.Descripcion = model.Descripcion;
            this.Notas = model.Notas;
            this.Tipo = model.Tipo;
        }

        public Incidencia ToEntity(bool ignorarId = false) {
            return new Incidencia {
                Id = ignorarId ? 0 : this.Id,
                Descripcion = this.Descripcion,
                Notas = this.Notas,
                Tipo = this.Tipo,
            };
        }

        #endregion
        // ====================================================================================================


    }
}
