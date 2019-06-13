using SQLite.Net.Attributes;

namespace Quattro.Core.Models {

    [Table("Incidencias")]
    public class Incidencia : BaseModel {

        [PrimaryKey, AutoIncrement, Column("_id"), Unique]
        public int Id { get; set; }


        private int codigo;
        public int Codigo {
            get => codigo;
            set => SetValue(ref codigo, value);
        }


        private int tipo;
        public int Tipo {
            get => tipo;
            set => SetValue(ref tipo, value);
        }


        private string textoIncidencia;
        [MaxLength(128)]
        public string TextoIncidencia {
            get => textoIncidencia;
            set => SetValue(ref textoIncidencia, value);
        }


        private string notas;
        public string Notas {
            get => notas;
            set => SetValue(ref notas, value);
        }


    }
}
