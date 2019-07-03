using System;
using System.Collections.Generic;
using System.Linq;
using Quattro.Core.Common;
using Quattro.Core.Data.Entities;

namespace Quattro.Core.Data.Models {

    public class DiaCalendario : Servicio {

        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public DiaCalendario() { }

        public DiaCalendario(DiaCalendarioEntity entidad) => this.FromEntity(entidad);

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================


        private DateTime fecha;
        public DateTime Fecha {
            get => fecha;
            set {
                if (SetProperty(ref fecha, value)) {
                    PropiedadCambiada(nameof(EsDomingoOFestivo));
                }
            }
        }


        private bool esFranqueo;
        public bool EsFranqueo {
            get => esFranqueo;
            set => SetProperty(ref esFranqueo, value);
        }


        private bool esFestivo;
        public bool EsFestivo {
            get => esFestivo;
            set {
                if (SetProperty(ref esFestivo, value)) {
                    PropiedadCambiada(nameof(EsDomingoOFestivo));
                }
            }
        }


        private bool huelgaParcial;
        public bool HuelgaParcial {
            get => huelgaParcial;
            set => SetProperty(ref huelgaParcial, value);
        }


        private decimal horasHuelga;
        public decimal HorasHuelga {
            get => horasHuelga;
            set => SetProperty(ref horasHuelga, value);
        }


        private decimal trabajadas;
        public decimal Trabajadas {
            get => trabajadas;
            set => SetProperty(ref trabajadas, value);
        }


        private decimal acumuladas;
        public decimal Acumuladas {
            get => acumuladas;
            set => SetProperty(ref acumuladas, value);
        }


        private decimal nocturnas;
        public decimal Nocturnas {
            get => nocturnas;
            set => SetProperty(ref nocturnas, value);
        }


        private bool desayuno;
        public bool Desayuno {
            get => desayuno;
            set => SetProperty(ref desayuno, value);
        }


        private bool comida;
        public bool Comida {
            get => comida;
            set => SetProperty(ref comida, value);
        }


        private bool cena;
        public bool Cena {
            get => cena;
            set => SetProperty(ref cena, value);
        }


        private string bus;
        public string Bus {
            get => bus;
            set => SetProperty(ref bus, value);
        }


        private Incidencia incidencia;
        public Incidencia Incidencia {
            get => incidencia;
            set => SetProperty(ref incidencia, value);
        }


        private Compañero relevo;
        public Compañero Relevo {
            get => relevo;
            set => SetProperty(ref relevo, value);
        }


        private Compañero susti;
        public Compañero Susti {
            get => susti;
            set => SetProperty(ref susti, value);
        }


        private IEnumerable<ServicioDia> servicios;
        public IEnumerable<ServicioDia> Servicios {
            get => servicios;
            set => SetProperty(ref servicios, value);
        }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS ENTITIES
        // ====================================================================================================

        public void FromEntity(DiaCalendarioEntity entidad) {
            if (entidad == null) return;
            base.FromEntity(entidad);
            this.Fecha = entidad.Fecha;
            this.EsFranqueo = entidad.EsFranqueo;
            this.EsFestivo = entidad.EsFestivo;
            this.HuelgaParcial = entidad.HuelgaParcial;
            this.HorasHuelga = entidad.HorasHuelga;
            this.Trabajadas = entidad.Trabajadas;
            this.Acumuladas = entidad.Acumuladas;
            this.Nocturnas = entidad.Nocturnas;
            this.Desayuno = entidad.Desayuno;
            this.Comida = entidad.Comida;
            this.Cena = entidad.Cena;
            this.Bus = entidad.Bus;
            this.Incidencia = new Incidencia(entidad.Incidencia);
            this.Relevo = new Compañero(entidad.Relevo);
            this.Susti = new Compañero(entidad.Susti);
            this.Servicios = entidad.Servicios.Select(s => new ServicioDia(s));
        }

        public void ToEntity(DiaCalendarioEntity entidad) {
            if (entidad == null) return;
            base.ToEntity(entidad);
            entidad.Fecha = this.Fecha;
            entidad.EsFranqueo = this.EsFranqueo;
            entidad.EsFestivo = this.EsFestivo;
            entidad.HuelgaParcial = this.HuelgaParcial;
            entidad.HorasHuelga = this.HorasHuelga;
            entidad.Trabajadas = this.Trabajadas;
            entidad.Acumuladas = this.Acumuladas;
            entidad.Nocturnas = this.Nocturnas;
            entidad.Desayuno = this.Desayuno;
            entidad.Comida = this.Comida;
            entidad.Cena = this.Cena;
            entidad.Bus = this.Bus;
            entidad.Incidencia = new IncidenciaEntity();
            this.Incidencia.ToEntity(entidad.Incidencia);
            entidad.Relevo = new CompañeroEntity();
            this.Relevo.ToEntity(entidad.Relevo);
            entidad.Susti = new CompañeroEntity();
            this.Susti.ToEntity(entidad.Susti);
            entidad.Servicios = this.Servicios.Select(s => {
                var sl = new ServicioDiaEntity();
                s.ToEntity(sl);
                return sl;
            });
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES NO GUARDABLES
        // ====================================================================================================

        private bool isSelected;
        public bool IsSelected {
            get => isSelected;
            set {
                if (SetProperty(ref isSelected, value)) PropiedadCambiada(nameof(TipoFondo));
            }
        }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES SÓLO LECTURA
        // ====================================================================================================

        public string DiaSemana {
            get => $"{(DiaSemanaAbreviado)Fecha.DayOfWeek}".ToUpper();
        }


        public bool EsUltimoDia {
            get => Fecha.Day == DateTime.DaysInMonth(Fecha.Year, Fecha.Month);
        }

        public (DateTime, bool) EsDomingoOFestivo {
            get => (Fecha, EsFestivo);
        }

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
