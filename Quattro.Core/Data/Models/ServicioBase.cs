﻿using System.ComponentModel.DataAnnotations;
using Quattro.Core.Common;
using Quattro.Core.Data.Entities;

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


        private string servivio;
        [MaxLength(32)]
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
        [MaxLength(64)]
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
        [MaxLength(64)]
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

        public void FromModel(ServicioBase model) {
            if (model == null) return;
            this.Id = model.Id;
            this.Final = model.Final;
            this.Inicio = model.Inicio;
            this.Linea = new Linea(model.Linea);
            this.LugarFinal = model.LugarFinal;
            this.LugarInicio = model.LugarInicio;
            this.Servicio = model.Servicio;
            this.Turno = model.Turno;
        }

        public ServicioBase ToModel() {
            return new ServicioBase() {
                Id = this.Id,
                Final = this.Final,
                Inicio = this.Inicio,
                LugarFinal = this.LugarFinal,
                LugarInicio = this.LugarInicio,
                Servicio = this.Servicio,
                Turno = this.Turno,
                Linea = new Linea(this.Linea),
            };
        }

        #endregion
        // ====================================================================================================


    }
}
