﻿using System;
using Quattro.Core.Common;
using SQLite.Net.Attributes;

namespace Quattro.Core.Models {

    [Table("Calendario")]
    public class DiaCalendario : Servicio {

        // ====================================================================================================
        #region PROPIEDADES EN BASE DE DATOS
        // ====================================================================================================

        private DateTime fecha;
        public DateTime Fecha {
            get => fecha;
            set => SetValue(ref fecha, value);
        }


        private bool esFranqueo;
        public bool EsFranqueo {
            get => esFranqueo;
            set => SetValue(ref esFranqueo, value);
        }


        private bool esFestivo;
        public bool EsFestivo {
            get => esFestivo;
            set => SetValue(ref esFestivo, value);
        }


        private int codigoIncidencia;
        public int CodigoIncidencia {
            get => codigoIncidencia;
            set => SetValue(ref codigoIncidencia, value);
        }


        private int tipoIncidencia;
        public int TipoIncidencia {
            get => tipoIncidencia;
            set => SetValue(ref tipoIncidencia, value);
        }


        private bool huelgaParcial;
        public bool HuelgaParcial {
            get => huelgaParcial;
            set => SetValue(ref huelgaParcial, value);
        }


        private decimal horasHuelga;
        public decimal HorasHuelga {
            get => horasHuelga;
            set => SetValue(ref horasHuelga, value);
        }


        private int relevo;
        public int Relevo {
            get => relevo;
            set => SetValue(ref relevo, value);
        }


        private int susti;
        public int Susti {
            get => susti;
            set => SetValue(ref susti, value);
        }


        private string bus;
        [MaxLength(20)]
        public string Bus {
            get => bus;
            set => SetValue(ref bus, value);
        }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES SÓLO LECTURA
        // ====================================================================================================

        [Ignore]
        public string DiaSemana {
            get {
                switch (Fecha.DayOfWeek) {
                    case DayOfWeek.Monday: return "LUN";
                    case DayOfWeek.Tuesday: return "MAR";
                    case DayOfWeek.Wednesday: return "MIE";
                    case DayOfWeek.Thursday: return "JUE";
                    case DayOfWeek.Friday: return "VIE";
                    case DayOfWeek.Saturday: return "SAB";
                    case DayOfWeek.Sunday: return "DOM";
                }
                return "";
            }
        }

        [Ignore]
        public bool EsUltimoDia { get => Fecha.Day == DateTime.DaysInMonth(Fecha.Year, Fecha.Month); }


        private bool isSelected;
        [Ignore]
        public bool IsSelected {
            get => isSelected;
            set {
                if (SetValue(ref isSelected, value)) PropiedadCambiada(nameof(TipoFondo));
            }
        }


        [Ignore]
        public Fondo TipoFondo {
            get {
                if (IsSelected) {
                    if (Fecha.Day % 2 == 0) {
                        return Fondo.AlternoSeleccionado;
                    } else {
                        return Fondo.NormalSeleccionado;
                    }
                }
                if (Fecha.Day % 2 == 0) {
                    return Fondo.Alterno;
                } else {
                    return Fondo.Normal;
                }
            }
        }

        #endregion
        // ====================================================================================================



    }
}
