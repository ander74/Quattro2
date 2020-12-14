using Quattro.Core.Data.Models;

namespace Quattro.Core.Data.SQLiteEntities {

    public class ServicioBaseEntity {


        // ====================================================================================================
        #region CONSTRUCTORES
        // ====================================================================================================

        public ServicioBaseEntity() { }

        public ServicioBaseEntity(ServicioBase model) => FromModel(model);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================

        public int Id { get; set; }

        public string Servicio { get; set; }

        public int Turno { get; set; }

        public int Inicio { get; set; } // Se debe parserar a la clase Tiempo

        public string LugarInicio { get; set; }

        public int Final { get; set; } // Se debe parserar a la clase Tiempo

        public string LugarFinal { get; set; }

        public int TomaDeje { get; set; } // Se debe parserar a la clase Tiempo

        public decimal Euros { get; set; }

        public string Notas { get; set; }

        public int LineaId { get; set; }

        public LineaEntity Linea { get; set; }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(ServicioBase model) {
            if (model == null) return;
            Id = model.Id;
            Servicio = model.Servicio;
            Turno = model.Turno;
            Inicio = model.Inicio.TotalMinutos;
            LugarInicio = model.LugarInicio;
            Final = model.Final.TotalMinutos;
            LugarFinal = model.LugarFinal;
            TomaDeje = model.TomaDeje.TotalMinutos;
            Euros = model.Euros;
            Notas = model.Notas;
            LineaId = model.Linea?.Id ?? 0;
            //Linea = model.Linea; //Puede ser usando FromModel.
        }

        #endregion
        // ====================================================================================================


    }
}
