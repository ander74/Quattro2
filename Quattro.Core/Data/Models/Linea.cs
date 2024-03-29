﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Quattro.Core.Data.Models {

    public class Linea : BaseModel {


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public Linea() { }

        public Linea(Linea model) => this.FromModel(model);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int Id { get; set; }


        private string numero;
        [MaxLength(32)]
        public string Numero {
            get => numero;
            set => SetProperty(ref numero, value);
        }


        private string descripcion;
        [MaxLength(128)]
        public string Descripcion {
            get => descripcion;
            set => SetProperty(ref descripcion, value);
        }


        private string notas;
        [MaxLength(1024)]
        public string Notas {
            get => notas;
            set => SetProperty(ref notas, value);
        }


        private List<ServicioLinea> servicios;
        public List<ServicioLinea> Servicios {
            get => servicios;
            set => SetProperty(ref servicios, value);
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(Linea model) {
            if (model == null) return;
            Id = model.Id;
            numero = model.Numero;
            descripcion = model.Descripcion;
            notas = model.Notas;
            servicios = model.Servicios;
        }

        #endregion
        // ====================================================================================================

    }
}
