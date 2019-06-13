using System;
using SQLite.Net.Attributes;

namespace Quattro.Core.Models {

    [Table("HorasAjenas")]
    public class HoraAjena : BaseModel {

        [PrimaryKey, AutoIncrement, Column("_id"), Unique]
        public int Id { get; set; }


        private DateTime fecha;
        public DateTime Fecha {
            get => fecha;
            set => SetValue(ref fecha, value);
        }


        private decimal horas;
        public decimal Horas {
            get => horas;
            set => SetValue(ref horas, value);
        }


        private int codigo;
        public int Codigo {
            get => codigo;
            set => SetValue(ref codigo, value);
        }


        private string motivo;
        public string Motivo {
            get => motivo;
            set => SetValue(ref motivo, value);
        }


    }
}
