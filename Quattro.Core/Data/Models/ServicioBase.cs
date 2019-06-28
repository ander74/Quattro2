using Quattro.Core.Common;
using Quattro.Core.Data.Entities;

namespace Quattro.Core.Data.Models {

    public class ServicioBase : BaseModel {

        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public ServicioBase() { }

        public ServicioBase(ServicioBaseEntity entidad) => this.FromEntity(entidad);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int Id { get; set; }


        private string servivio;
        public string Servicio {
            get => servivio;
            set => SetProperty(ref servivio, value);
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
        public string LugarFinal {
            get => lugarFinal;
            set => SetProperty(ref lugarFinal, value);
        }


        private Linea linea;
        public Linea Linea {
            get => linea;
            set => SetProperty(ref linea, value);
        }



        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS ENTITIES
        // ====================================================================================================

        public void FromEntity(ServicioBaseEntity entidad) {
            this.Id = entidad.Id;
            this.Final = entidad.Final;
            this.Inicio = entidad.Inicio;
            this.Linea = new Linea(entidad.Linea);
            this.LugarFinal = entidad.LugarFinal;
            this.LugarInicio = entidad.LugarInicio;
            this.Servicio = entidad.Servicio;
            this.Turno = entidad.Turno;
        }

        public void ToEntity(ServicioBaseEntity entidad) {
            entidad.Id = this.Id;
            entidad.Final = this.Final;
            entidad.Inicio = this.Inicio;
            entidad.Linea = new LineaEntity();
            this.Linea.ToEntity(entidad.Linea);
            entidad.LugarFinal = this.LugarFinal;
            entidad.LugarInicio = this.LugarInicio;
            entidad.Servicio = this.Servicio;
            entidad.Turno = this.Turno;
        }

        #endregion
        // ====================================================================================================


    }
}
