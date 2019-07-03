using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Quattro.Core.Common;

namespace Quattro.Core.Data.Models {

    [Table("Calendario")]
    public class DiaCalendario : Servicio {

        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public DiaCalendario() { }

        public DiaCalendario(DiaCalendario model) => this.FromModel(model);

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
        [MaxLength(32)]
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

        public void FromModel(DiaCalendario model) {
            if (model == null) return;
            base.FromModel(model);
            this.Fecha = model.Fecha;
            this.EsFranqueo = model.EsFranqueo;
            this.EsFestivo = model.EsFestivo;
            this.HuelgaParcial = model.HuelgaParcial;
            this.HorasHuelga = model.HorasHuelga;
            this.Trabajadas = model.Trabajadas;
            this.Acumuladas = model.Acumuladas;
            this.Nocturnas = model.Nocturnas;
            this.Desayuno = model.Desayuno;
            this.Comida = model.Comida;
            this.Cena = model.Cena;
            this.Bus = model.Bus;
            this.Incidencia = new Incidencia(model.Incidencia);
            this.Relevo = new Compañero(model.Relevo);
            this.Susti = new Compañero(model.Susti);
            this.Servicios = model.Servicios.AsEnumerable();
        }

        public new DiaCalendario ToModel() {
            DiaCalendario model = (DiaCalendario)base.ToModel();
            model.Fecha = this.Fecha;
            model.EsFranqueo = this.EsFranqueo;
            model.EsFestivo = this.EsFestivo;
            model.HuelgaParcial = this.HuelgaParcial;
            model.HorasHuelga = this.HorasHuelga;
            model.Trabajadas = this.Trabajadas;
            model.Acumuladas = this.Acumuladas;
            model.Nocturnas = this.Nocturnas;
            model.Desayuno = this.Desayuno;
            model.Comida = this.Comida;
            model.Cena = this.Cena;
            model.Bus = this.Bus;
            model.Incidencia = new Incidencia(this.Incidencia);
            model.Relevo = new Compañero(this.Relevo);
            model.Susti = new Compañero(this.Susti);
            model.Servicios = this.Servicios.AsEnumerable();
            return model;
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES NO GUARDABLES
        // ====================================================================================================

        private bool isSelected;
        [NotMapped]
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
