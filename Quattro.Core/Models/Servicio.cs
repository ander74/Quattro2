using Quattro.Core.Common;

namespace Quattro.Core.Models {

    public class Servicio : ServicioBase {


        private decimal trabajadas;
        public decimal Trabajadas {
            get => trabajadas;
            set => SetValue(ref trabajadas, value);
        }


        private decimal acumuladas;
        public decimal Acumuladas {
            get => acumuladas;
            set => SetValue(ref acumuladas, value);
        }


        private decimal nocturnas;
        public decimal Nocturnas {
            get => nocturnas;
            set => SetValue(ref nocturnas, value);
        }


        private bool desayuno;
        public bool Desayuno {
            get => desayuno;
            set => SetValue(ref desayuno, value);
        }


        private bool comida;
        public bool Comida {
            get => comida;
            set => SetValue(ref comida, value);
        }


        private bool cena;
        public bool Cena {
            get => cena;
            set => SetValue(ref cena, value);
        }


        private Tiempo tomaDeje;
        public Tiempo TomaDeje {
            get => tomaDeje;
            set => SetValue(ref tomaDeje, value);
        }


        private decimal euros;
        public decimal Euros {
            get => euros;
            set => SetValue(ref euros, value);
        }


        private string notas;
        public string Notas {
            get => notas;
            set => SetValue(ref notas, value);
        }

    }
}
