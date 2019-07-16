using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quattro.Core.Common;

namespace Quattro.Core.Data.Models {

    [Table("Companeros")]
    public class Compañero : BaseModel {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public Compañero() { }

        public Compañero(Compañero model) => this.FromModel(model);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int Id { get; set; }


        private int matricula;
        public int Matricula {
            get => matricula;
            set => SetProperty(ref matricula, value);
        }

        private string nombre;
        [MaxLength(64)]
        public string Nombre {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }

        private string apellidos;
        [MaxLength(128)]
        public string Apellidos {
            get => apellidos;
            set => SetProperty(ref apellidos, value);
        }

        private string telefono;
        [MaxLength(64)]
        public string Telefono {
            get => telefono;
            set => SetProperty(ref telefono, value);
        }

        private string email;
        [MaxLength(128)]
        public string Email {
            get => email;
            set => SetProperty(ref email, value);
        }

        private TipoCompañero calificacion;
        public TipoCompañero Calificacion {
            get => calificacion;
            set => SetProperty(ref calificacion, value);
        }

        private int deuda;
        public int Deuda {
            get => deuda;
            set => SetProperty(ref deuda, value);
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

        public void FromModel(Compañero model, bool ignorarId = false) {
            if (model == null) return;
            this.Id = ignorarId ? this.Id : model.Id;
            apellidos = model.Apellidos;
            calificacion = model.Calificacion;
            deuda = model.Deuda;
            email = model.Email;
            matricula = model.Matricula;
            nombre = model.Nombre;
            notas = model.Notas;
            telefono = model.Telefono;
        }

        public Compañero ToModel(bool ignorarId = false) {
            return new Compañero {
                Id = ignorarId ? 0 : this.Id,
                Apellidos = this.Apellidos,
                Calificacion = this.Calificacion,
                Deuda = this.Deuda,
                Email = this.Email,
                Matricula = this.Matricula,
                Nombre = this.Nombre,
                Notas = this.Notas,
                Telefono = this.Telefono,
            };
        }

        #endregion
        // ====================================================================================================


    }
}
