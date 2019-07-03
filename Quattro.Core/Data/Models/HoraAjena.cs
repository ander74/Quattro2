using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quattro.Core.Common;

namespace Quattro.Core.Data.Models {

    [Table("HorasAjenas")]
    public class HoraAjena : BaseModel {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public HoraAjena() { }

        public HoraAjena(HoraAjena model) => this.FromModel(model);

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
        [MaxLength(256)]
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

        public void FromModel(HoraAjena model) {
            if (model == null) return;
            this.Fecha = model.Fecha;
            this.Horas = model.Horas;
            this.Id = model.Id;
            this.Motivo = model.Motivo;
            this.Tipo = model.Tipo;
        }

        public HoraAjena ToModel() {
            return new HoraAjena {
                Fecha = this.Fecha,
                Horas = this.Horas,
                Id = this.Id,
                Motivo = this.Motivo,
                Tipo = this.Tipo,
            };
        }

        #endregion
        // ====================================================================================================

    }
}
