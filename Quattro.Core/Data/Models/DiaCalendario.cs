using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
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
                    PropiedadCambiada(nameof(DiaSemana));
                    PropiedadCambiada(nameof(EsUltimoDia));
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
            set {
                if (SetProperty(ref incidencia, value)) {
                    PropiedadCambiada(nameof(TextoServicio));
                    PropiedadCambiada(nameof(HacemosDia));
                    PropiedadCambiada(nameof(NosHacenDia));
                    PropiedadCambiada(nameof(HayHuelga));
                    PropiedadCambiada(nameof(MostrarAcumuladas));
                }
            }
        }


        private Compañero relevo;
        public Compañero Relevo {
            get => relevo;
            set {
                if (SetProperty(ref relevo, value)) {
                    PropiedadCambiada(nameof(TextoRelevo));
                    PropiedadCambiada(nameof(EsRelevoBueno));
                    PropiedadCambiada(nameof(EsRelevoMalo));
                }
            }
        }


        private Compañero susti;
        public Compañero Susti {
            get => susti;
            set => SetProperty(ref susti, value);
        }


        private List<ServicioDia> servicios;
        public List<ServicioDia> Servicios {
            get => servicios;
            set => SetProperty(ref servicios, value);
        }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public void FromModel(DiaCalendario model, bool ignorarId = false) {
            if (model == null) return;
            base.FromModel(model, ignorarId);
            fecha = model.Fecha;
            esFranqueo = model.EsFranqueo;
            esFestivo = model.EsFestivo;
            huelgaParcial = model.HuelgaParcial;
            horasHuelga = model.HorasHuelga;
            trabajadas = model.Trabajadas;
            acumuladas = model.Acumuladas;
            nocturnas = model.Nocturnas;
            desayuno = model.Desayuno;
            comida = model.Comida;
            cena = model.Cena;
            bus = model.Bus;
            //if (model.Incidencia != null) {
            //    if (incidencia == null) incidencia = new Incidencia();
            //    incidencia.FromModel(model.Incidencia);
            //} else {
            //    incidencia = null;
            //}
            incidencia = model.Incidencia;

            //if (model.Relevo != null) {
            //    if (relevo == null) relevo = new Compañero();
            //    relevo.FromModel(model.Relevo);
            //} else {
            //    relevo = null;
            //}
            relevo = model.Relevo;

            //if (model.Susti != null) {
            //    if (susti == null) susti = new Compañero();
            //    susti.FromModel(model.Susti);
            //} else {
            //    susti = null;
            //}
            susti = model.Susti;

            servicios = model.Servicios;
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
            model.Servicios = this.Servicios;
            return model;
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS SOBRECARGADOS
        // ====================================================================================================

        public override void PropiedadCambiada([CallerMemberName] string prop = "") {
            base.PropiedadCambiada(prop);
            switch (prop) {
                case nameof(Servicio):
                case nameof(Linea):
                case nameof(Turno):
                    PropiedadCambiada(nameof(TextoServicio));
                    break;
                case nameof(Inicio):
                case nameof(Final):
                    PropiedadCambiada(nameof(TextoServicio));
                    PropiedadCambiada(nameof(TextoHorario));
                    break;
                case nameof(Notas):
                    PropiedadCambiada(nameof(HayNotas));
                    break;
            }
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

        public string TextoServicio {
            get {
                var resultado = string.Empty;
                if (Incidencia?.Tipo == TipoIncidencia.Trabajo ||
                    Incidencia?.Tipo == TipoIncidencia.FranqueoTrabajado ||
                    Incidencia?.Tipo == TipoIncidencia.TrabajoSinAcumular) {
                    // Si hay servicio y línea.
                    if (!string.IsNullOrEmpty(Servicio) && !string.IsNullOrEmpty(Linea?.Numero)) {
                        resultado = $"{Servicio}/{Turno} - {Linea.Numero}";
                        if (!string.IsNullOrEmpty(Linea.Descripcion)) resultado += $": {Linea.Descripcion}";
                    } else if (Turno > 0 && Inicio != null && Final != null) {
                        resultado = $"{Incidencia?.Descripcion} {Turno}";
                    }
                }
                if (Incidencia?.Tipo == TipoIncidencia.FiestaOtroDia ||
                    Incidencia?.Tipo == TipoIncidencia.Franqueo ||
                    Incidencia?.Tipo == TipoIncidencia.JornadaMedia) {
                    resultado = $"{Incidencia?.Descripcion}";
                }
                return resultado;
            }
        }

        public string TextoHorario {
            get {
                if (Inicio == null || Final == null) return string.Empty;
                return $"{Inicio.ToString("hm")} - {Final.ToString("hm")}";
            }
        }

        public string TextoRelevo {
            get {
                if (Relevo == null) return string.Empty;
                var resultado = Relevo.Matricula.ToString("0000");
                if (!string.IsNullOrEmpty(Relevo.Apellidos)) resultado += $": {Relevo.Apellidos}";
                return resultado;
            }
        }

        public bool HacemosDia {
            get => Incidencia?.Codigo == 12;
        }

        public bool NosHacenDia {
            get => Incidencia?.Codigo == 11;
        }

        public bool EsRelevoBueno {
            get => Relevo?.Calificacion == TipoCompañero.Bueno;
        }

        public bool EsRelevoMalo {
            get => Relevo?.Calificacion == TipoCompañero.Malo;
        }

        public bool MostrarAcumuladas {
            get {
                if (Inicio == null || Final == null) {
                    if (Acumuladas == 0m && Nocturnas == 0m) return false;
                } else if (Incidencia?.Tipo != TipoIncidencia.Trabajo &&
                        Incidencia?.Tipo != TipoIncidencia.FranqueoTrabajado &&
                        Incidencia?.Tipo != TipoIncidencia.FiestaOtroDia) {
                    return false;
                }
                return true;
            }
        }

        public bool HayHuelga {
            get => Incidencia?.Codigo == 15;
        }

        public bool HayNotas {
            get => !string.IsNullOrWhiteSpace(Notas);
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
