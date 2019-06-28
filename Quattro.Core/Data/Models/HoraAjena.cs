using System;
using Quattro.Core.Common;
using Quattro.Core.Data.Entities;

namespace Quattro.Core.Data.Models {

    public class HoraAjena : BaseModel {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public HoraAjena() { }

        public HoraAjena(HoraAjenaEntity entidad) => this.FromEntity(entidad);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int Id { get; set; }


        private DateTime fecha;
        public DateTime Fecha {
            get => fecha;
            set => SetProperty(ref fecha, value);
        }


        private decimal horas;
        public decimal Horas {
            get => horas;
            set => SetProperty(ref horas, value);
        }


        private string motivo;
        public string Motivo {
            get => motivo;
            set => SetProperty(ref motivo, value);
        }


        private TipoHoraAjena tipo;
        public TipoHoraAjena Tipo {
            get => tipo;
            set => SetProperty(ref tipo, value);
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS ENTITIES
        // ====================================================================================================

        public void FromEntity(HoraAjenaEntity entidad) {
            this.Fecha = entidad.Fecha;
            this.Horas = entidad.Horas;
            this.Id = entidad.Id;
            this.Motivo = entidad.Motivo;
            this.Tipo = entidad.Tipo;
        }

        public void ToEntity(HoraAjenaEntity entidad) {
            entidad.Fecha = this.Fecha;
            entidad.Horas = this.Horas;
            entidad.Id = this.Id;
            entidad.Motivo = this.Motivo;
            entidad.Tipo = this.Tipo;
        }

        #endregion
        // ====================================================================================================

    }
}
