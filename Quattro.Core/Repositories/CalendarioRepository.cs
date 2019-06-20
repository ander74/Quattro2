using System;
using System.Collections.Generic;
using System.Linq;
using Quattro.Core.Common;
using Quattro.Core.Models;

namespace Quattro.Core.Repositories {

    public class CalendarioRepository : ICalendarioRepository {

        public IEnumerable<DiaCalendario> GetMes(DateTime fecha) {
            //TODO: Cambiar por el real.
            List<DiaCalendario> lista = new List<DiaCalendario>();
            Random rnd = new Random();
            for (int i=1; i<=DateTime.DaysInMonth(fecha.Year, fecha.Month); i++) {
                lista.Add(new DiaCalendario {
                    Fecha = new DateTime(fecha.Year, fecha.Month, i),
                    Inicio = new Tiempo(6, 30),
                    Final = new Tiempo(14, 0),
                    EsFranqueo = rnd.Next(100) < 50 ? false : true,
                    Desayuno = rnd.Next(100) < 50 ? false : true,
                    Comida = rnd.Next(100) < 50 ? false : true,
                    Cena = rnd.Next(100) < 50 ? false : true
                });
            }
            lista[0].Inicio = new Tiempo(5, 30);
            lista[0].Final = new Tiempo(13, 45);
            lista[1].Inicio = new Tiempo(6, 40);
            lista[1].Final = new Tiempo(14, 10);
            lista[2].Inicio = new Tiempo(14, 25);
            lista[2].Final = new Tiempo(21, 20);
            lista[3].Inicio = new Tiempo(14, 10);
            lista[3].Final = new Tiempo(22, 55);
            return lista;

        }

    }
}
