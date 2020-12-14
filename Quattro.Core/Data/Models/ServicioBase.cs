using System.ComponentModel.DataAnnotations;
using Quattro.Core.Common;

namespace Quattro.Core.Data.Models {

    public class ServicioBase : BaseModel {

        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public ServicioBase() { }

        public ServicioBase(ServicioBase model) => this.FromModel(model);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int Id { get; set; }


        private string servicio;
        [MaxLength(32)]
        public string Servicio {
            get => servicio;
            set => SetProperty(ref servicio, value);
        }


        private int turno;
        public int Turno {
            get => turno;
            set => SetProperty(ref turno, value);
        }


        private Tiempo inicio;
        public Tiempo Inicio {
            get => inicio;
            set => SetProperty(ref inicio, value);
        }


        private string lugarInicio;
        [MaxLength(128)]
        public string LugarInicio {
            get => lugarInicio;
            set => SetProperty(ref lugarInicio, value);
        }


        private Tiempo final;
        public Tiempo Final {
            get => final;
            set => SetProperty(ref final, value);
        }


        private string lugarFinal;
        [MaxLength(128)]
        public string LugarFinal {
            get => lugarFinal;
            set => SetProperty(ref lugarFinal, value);
        }


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
        [MaxLength(1024)]
        public string Notas {
            get => notas;
            set => SetProperty(ref notas, value);
        }



        private Linea linea;
        public Linea Linea {
            get => linea;
            set => SetProperty(ref linea, value);
        }



        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(ServicioBase model) {
            if (model == null) return;
            Id = model.Id;
            servicio = model.Servicio;
            turno = model.Turno;
            inicio = model.Inicio;
            lugarInicio = model.LugarInicio;
            final = model.Final;
            lugarFinal = model.LugarFinal;
            tomaDeje = model.TomaDeje;
            euros = model.Euros;
            notas = model.Notas;
            linea = model.Linea;
        }

        #endregion
        // ====================================================================================================


    }
}
