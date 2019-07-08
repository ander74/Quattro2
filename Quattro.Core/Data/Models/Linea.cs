using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Quattro.Core.Data.Models {

    [Table("Lineas")]
    public class Linea : BaseModel {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public Linea() { }

        public Linea(Linea model) => this.FromModel(model);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int Id { get; set; }


        private string numero;
        [MaxLength(32)]
        public string Numero {
            get => numero;
            set => SetProperty(ref numero, value);
        }


        private string descripcion;
        [MaxLength(128)]
        public string Descripcion {
            get => descripcion;
            set => SetProperty(ref descripcion, value);
        }


        private string notas;
        public string Notas {
            get => notas;
            set => SetProperty(ref notas, value);
        }


        private IEnumerable<ServicioLinea> servicios;
        public IEnumerable<ServicioLinea> Servicios {
            get => servicios;
            set => SetProperty(ref servicios, value);
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(Linea model, bool ignorarId = false) {
            if (model == null) return;
            this.Id = ignorarId ? this.Id : model.Id;
            this.Descripcion = model.Descripcion;
            this.Notas = model.Notas;
            this.Numero = model.Numero;
            this.Servicios = model.Servicios.AsEnumerable();
        }

        public Linea ToModel(bool ignorarId = false) {
            return new Linea {
                Id = ignorarId ? 0 : this.Id,
                Descripcion = this.Descripcion,
                Notas = this.Notas,
                Numero = this.Numero,
                Servicios = this.Servicios.AsEnumerable(),
            };
        }

        #endregion
        // ====================================================================================================

    }
}
