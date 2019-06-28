using Quattro.Core.Common;
using Quattro.Core.Data.Entities;

namespace Quattro.Core.Data.Models {

    public class Servicio : ServicioBase {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public Servicio() { }

        public Servicio(ServicioEntity entidad) => this.FromEntity(entidad);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================


        private Tiempo tomaDeje;
        public Tiempo TomaDeje {
            get => tomaDeje;
            set => SetProperty(ref tomaDeje, value);
        }


        private decimal euros;
        public decimal Euros {
            get => euros;
            set => SetProperty(ref euros, value);
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

        public void FromEntity(ServicioEntity entidad) {
            base.FromEntity(entidad);
            this.TomaDeje = entidad.TomaDeje;
            this.Euros = entidad.Euros;
            this.Notas = entidad.Notas;
        }

        public void ToEntity(ServicioEntity entidad) {
            base.ToEntity(entidad);
            entidad.TomaDeje = this.TomaDeje;
            entidad.Euros = this.Euros;
            entidad.Notas = this.Notas;
        }

        #endregion
        // ====================================================================================================


    }
}
