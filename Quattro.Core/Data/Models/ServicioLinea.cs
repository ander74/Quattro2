using System.Collections.Generic;
using System.Linq;
using Quattro.Core.Data.Entities;

namespace Quattro.Core.Data.Models {

    public class ServicioLinea : Servicio {

        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public ServicioLinea() { }

        public ServicioLinea(ServicioLineaEntity entidad) => this.FromEntity(entidad);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================


        private IEnumerable<ServicioSecundario> servicios;
        public IEnumerable<ServicioSecundario> Servicios {
            get => servicios;
            set => SetProperty(ref servicios, value);
        }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS ENTITIES
        // ====================================================================================================

        public void FromEntity(ServicioLineaEntity entidad) {
            if (entidad == null) return;
            base.FromEntity(entidad);
            this.Servicios = entidad.Servicios.Select(s => new ServicioSecundario(s));
        }

        public void ToEntity(ServicioLineaEntity entidad) {
            if (entidad == null) return;
            base.ToEntity(entidad);
            entidad.Servicios = this.Servicios.Select(s => {
                var sl = new ServicioSecundarioEntity();
                s.ToEntity(sl);
                return sl;
            });
        }

        #endregion
        // ====================================================================================================

    }
}
