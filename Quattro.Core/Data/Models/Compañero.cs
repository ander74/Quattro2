using Quattro.Core.Common;
using Quattro.Core.Data.Entities;

namespace Quattro.Core.Data.Models {

    public class Compañero : BaseModel {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public Compañero() { }

        public Compañero(CompañeroEntity entidad) => this.FromEntity(entidad);

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
        public string Nombre {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }

        private string apellidos;
        public string Apellidos {
            get => apellidos;
            set => SetProperty(ref apellidos, value);
        }

        private string telefono;
        public string Telefono {
            get => telefono;
            set => SetProperty(ref telefono, value);
        }

        private string email;
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
        #region MÉTODOS ENTITIES
        // ====================================================================================================

        public void FromEntity(CompañeroEntity entidad) {
            this.Apellidos = entidad.Apellidos;
            this.Calificacion = entidad.Calificacion;
            this.Deuda = entidad.Deuda;
            this.Email = entidad.Email;
            this.Id = entidad.Id;
            this.Matricula = entidad.Matricula;
            this.Nombre = entidad.Nombre;
            this.Notas = entidad.Notas;
            this.Telefono = entidad.Telefono;
        }

        public void ToEntity(CompañeroEntity entidad) {
            entidad.Apellidos = this.Apellidos;
            entidad.Calificacion = this.Calificacion;
            entidad.Deuda = this.Deuda;
            entidad.Email = this.Email;
            entidad.Id = this.Id;
            entidad.Matricula = this.Matricula;
            entidad.Nombre = this.Nombre;
            entidad.Notas = this.Notas;
            entidad.Telefono = this.Telefono;
            
        }

        #endregion
        // ====================================================================================================


    }
}
