using System.ComponentModel.DataAnnotations;
using Quattro.Core.Common;

namespace Quattro.Core.Data.Models {

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
        [MaxLength(128)]
        public string Nombre {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }

        private string apellidos;
        [MaxLength(256)]
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

        public void FromModel(Compañero model) {
            if (model == null) return;
            Id = model.Id;
            apellidos = model.Apellidos;
            calificacion = model.Calificacion;
            deuda = model.Deuda;
            email = model.Email;
            matricula = model.Matricula;
            nombre = model.Nombre;
            notas = model.Notas;
            telefono = model.Telefono;
        }

        #endregion
        // ====================================================================================================


    }
}
