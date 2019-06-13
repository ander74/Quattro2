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
            return new List<DiaCalendario>() {
                    new DiaCalendario { Fecha = new DateTime(2019,6,1), Inicio= new Tiempo(6,30), Final= new Tiempo(14,0), EsFranqueo=true,
                    Desayuno=false, Comida=false, Cena=false},
                    new DiaCalendario { Fecha = new DateTime(2019,6,2), Inicio= new Tiempo(7,30), Final= new Tiempo(14,35), EsFranqueo=false,
                    Desayuno=true, Comida=false, Cena=false},
                    new DiaCalendario { Fecha = new DateTime(2019,6,3), Inicio= new Tiempo(8,30), Final= new Tiempo(14,55), EsFranqueo=false,
                    Desayuno=false, Comida=true, Cena=false},
                    new DiaCalendario { Fecha = new DateTime(2019,6,4), Inicio= new Tiempo(10,15), Final= new Tiempo(16,20), EsFranqueo=true,
                    Desayuno=false, Comida=false, Cena=false},
                    new DiaCalendario { Fecha = new DateTime(2019,6,5), Inicio= new Tiempo(11,20), Final= new Tiempo(17,0), EsFranqueo=true,
                    Desayuno=false, Comida=false, Cena=false},
                    new DiaCalendario { Fecha = new DateTime(2019,6,6), Inicio= new Tiempo(10,25), Final= new Tiempo(15,20), EsFranqueo=false,
                    Desayuno=false, Comida=false, Cena=true},
                    new DiaCalendario { Fecha = new DateTime(2019,6,7), Inicio= new Tiempo(6,05), Final= new Tiempo(13,40), EsFranqueo=false,
                    Desayuno=true, Comida=true, Cena=false},
                    new DiaCalendario { Fecha = new DateTime(2019,6,8), Inicio= new Tiempo(5,50), Final= new Tiempo(13,10), EsFranqueo=true,
                    Desayuno=false, Comida=false, Cena=true},
                    new DiaCalendario { Fecha = new DateTime(2019,6,9), Inicio= new Tiempo(5,55), Final= new Tiempo(13,0), EsFranqueo=true,
                    Desayuno=false, Comida=false, Cena=false},
                    new DiaCalendario { Fecha = new DateTime(2019,6,10), Inicio= new Tiempo(6,45), Final= new Tiempo(14,05), EsFranqueo=false,
                    Desayuno=false, Comida=false, Cena=false},
                };

        }

    }
}
