using Quattro.Core.Common;

namespace Quattro.Core.Data.Models {

    public class Servicio : ServicioBase {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public Servicio() { }

        public Servicio(Servicio model) => this.FromModel(model);

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

        public void FromModel(Servicio model) {
            if (model == null) return;
            base.FromModel(model);
            this.TomaDeje = model.TomaDeje;
            this.Euros = model.Euros;
            this.Notas = model.Notas;
        }

        public new Servicio ToModel() {
            Servicio model = (Servicio)base.ToModel();
            model.TomaDeje = this.TomaDeje;
            model.Euros = this.Euros;
            model.Notas = this.Notas;
            return model;
        }

        #endregion
        // ====================================================================================================


    }
}
