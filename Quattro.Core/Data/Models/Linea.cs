using System.Collections.Generic;
using System.Linq;
using Quattro.Core.Data.Entities;

namespace Quattro.Core.Data.Models {

    public class Linea : BaseModel {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public Linea() { }

        public Linea(LineaEntity entidad) => this.FromEntity(entidad);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int Id { get; set; }


        private string numero;
        public string Numero {
            get => numero;
            set => SetProperty(ref numero, value);
        }


        private string descripcion;
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
        #region MÉTODOS ENTITIES
        // ====================================================================================================

        public void FromEntity(LineaEntity entidad) {
            if (entidad == null) return;
            this.Id = entidad.Id;
            this.Descripcion = entidad.Descripcion;
            this.Notas = entidad.Notas;
            this.Numero = entidad.Numero;
            this.Servicios = entidad.Servicios.Select(s => new ServicioLinea(s));
        }

        public void ToEntity(LineaEntity entidad) {
            if (entidad == null) return;
            entidad.Id = this.Id;
            entidad.Descripcion = this.Descripcion;
            entidad.Notas = this.Notas;
            entidad.Numero = this.Numero;
            entidad.Servicios = this.Servicios.Select(s => {
                var sl = new ServicioLineaEntity();
                s.ToEntity(sl);
                return sl;
            });
        }

        #endregion
        // ====================================================================================================

    }
}
