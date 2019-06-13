using Quattro.Core.Common;
using SQLite.Net.Attributes;

namespace Quattro.Core.Models {

    public class ServicioBase : BaseModel {

        [PrimaryKey, AutoIncrement, Column("_id"), Unique]
        public int Id { get; set; }


        private string numeroLinea;
        [MaxLength(20)]
        public string NumeroLinea {
            get => numeroLinea;
            set => SetValue(ref numeroLinea, value);
        }


        private string servicio;
        [MaxLength(20)]
        public string Servicio {
            get => servicio;
            set => SetValue(ref servicio, value);
        }


        private int turno;
        public int Turno {
            get => turno;
            set => SetValue(ref turno, value);
        }


        private string textoLinea;
        [MaxLength(255)]
        public string TextoLinea {
            get => textoLinea;
            set => SetValue(ref textoLinea, value);
        }


        private Tiempo inicio;
        public Tiempo Inicio {
            get => inicio;
            set => SetValue(ref inicio, value);
        }


        private string lugarInicio;
        [MaxLength(255)]
        public string LugarInicio {
            get => lugarInicio;
            set => SetValue(ref lugarInicio, value);
        }


        private Tiempo final;
        public Tiempo Final {
            get => final;
            set => SetValue(ref final, value);
        }


        private string lugarFinal;
        [MaxLength(255)]
        public string LugarFinal {
            get => lugarFinal;
            set => SetValue(ref lugarFinal, value);
        }

    }
}
