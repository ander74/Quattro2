using SQLite.Net.Attributes;

namespace Quattro.Core.Models {

    [Table("Lineas")]
    public class Linea : BaseModel {

        [PrimaryKey, AutoIncrement, Column("_id"), Unique]
        public int Id { get; set; }


        private string numeroLinea;
        [MaxLength(20)]
        public string NumeroLinea {
            get => numeroLinea;
            set => SetValue(ref numeroLinea, value);
        }


        private string textoLinea;
        [MaxLength(255)]
        public string TextoLinea {
            get => textoLinea;
            set => SetValue(ref textoLinea, value);
        }


        private string notas;
        public string Notas {
            get => notas;
            set => SetValue(ref notas, value);
        }

    }
}
