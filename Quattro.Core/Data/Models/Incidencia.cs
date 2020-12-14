using System.ComponentModel.DataAnnotations;
using Quattro.Core.Common;

namespace Quattro.Core.Data.Models {

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
        [MaxLength(128)]
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
        [MaxLength(1024)]
        public string Notas {
            get => notas;
            set => SetProperty(ref notas, value);
        }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(Incidencia model) {
            if (model == null) return;
            Id = model.Id;
            codigo = model.Codigo;
            descripcion = model.Descripcion;
            notas = model.Notas;
            tipo = model.Tipo;
        }


        #endregion
        // ====================================================================================================


    }
}
