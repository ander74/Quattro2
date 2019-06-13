using SQLite.Net.Attributes;

namespace Quattro.Core.Models {

    [Table("Compañeros")]
    public class Compañero : BaseModel {


        [PrimaryKey, AutoIncrement, Column("_id"), Unique]
        public int Id { get; set; }


        private int matricula;
        [Unique]
        public int Matricula {
            get => matricula;
            set => SetValue(ref matricula, value);
        }


        private string nombre;
        [MaxLength(128)]
        public string Nombre {
            get => nombre;
            set => SetValue(ref nombre, value);
        }


        private string apellidos;
        [MaxLength(255)]
        public string Apellidos {
            get => apellidos;
            set => SetValue(ref apellidos, value);
        }


        private string telefono;
        [MaxLength(128)]
        public string Telefono {
            get => telefono;
            set => SetValue(ref telefono, value);
        }


        private string email;
        [MaxLength(128)]
        public string Email {
            get => email;
            set => SetValue(ref email, value);
        }


        private int calificacion;
        public int Calificacion {
            get => calificacion;
            set => SetValue(ref calificacion, value);
        }


        private int deuda;
        public int Deuda {
            get => deuda;
            set => SetValue(ref deuda, value);
        }


        private string notas;
        public string Notas {
            get => notas;
            set => SetValue(ref notas, value);
        }

    }
}
