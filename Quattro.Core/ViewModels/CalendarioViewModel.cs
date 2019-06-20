using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Quattro.Core.Common;
using Quattro.Core.Interfaces;
using Quattro.Core.Models;
using Quattro.Core.Repositories;

namespace Quattro.Core.ViewModels {
    public class CalendarioViewModel : MvxViewModel {


        // ====================================================================================================
        #region CAMPOS PRIVADOS
        // ====================================================================================================

        private readonly ICalendarioRepository repo;
        private readonly IDialogService dialog;
        private readonly IMvxNavigationService navigation;

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public CalendarioViewModel(ICalendarioRepository repo, IDialogService dialog, IMvxNavigationService navigation) {
            this.repo = repo;
            this.dialog = dialog;
            this.navigation = navigation;
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS SOBRECARGADOS
        // ====================================================================================================

        public override async Task Initialize() {
            await base.Initialize();

            // Inicialización de variables internas
            this.IsInSelectMode = false;

            // Inicialización de propiedades.
            this.Fecha = DateTime.Now;
            this.ListaDias = repo.GetMes(Fecha);
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region COMANDOS
        // ====================================================================================================

        #region DiaPulsado
        private MvxCommand<DiaCalendario> diaPulsadoCommand;
        public ICommand DiaPulsadoCommand {
            get {
                diaPulsadoCommand = diaPulsadoCommand ?? new MvxCommand<DiaCalendario>(DoDiaPulsado);
                return diaPulsadoCommand;
            }
        }
        public void DoDiaPulsado(DiaCalendario dia) {
            if (IsInSelectMode) {
                dia.IsSelected = !dia.IsSelected;
                if (ListaDias.Count(d => d.IsSelected) == 0) IsInSelectMode = false;
                RaisePropertyChanged(nameof(Titulo));
                return;
            }
            this.dialog.Alert($"Has pulsado el día {dia.Fecha.Day}.", "AVISO", "Aceptar");
        }
        #endregion


        #region DiaPulsadoLargo
        private MvxCommand<DiaCalendario> diaPulsadoLargoCommand;
        public ICommand DiaPulsadoLargoCommand {
            get {
                diaPulsadoLargoCommand = diaPulsadoLargoCommand ?? new MvxCommand<DiaCalendario>(DoDiaPulsadoLargo);
                return diaPulsadoLargoCommand;
            }
        }
        private void DoDiaPulsadoLargo(DiaCalendario dia) {
            if (IsInSelectMode) return;
            dia.IsSelected = true;
            IsInSelectMode = true;
        }
        #endregion


        #region AnteriorPulsado
        private MvxCommand anteriorPulsadoCommand;
        public ICommand AnteriorPulsadoCommand {
            get {
                anteriorPulsadoCommand = anteriorPulsadoCommand ?? new MvxCommand(DoAnteriorPulsado);
                return anteriorPulsadoCommand;
            }
        }
        private void DoAnteriorPulsado() {
            this.dialog.Alert("ANTERIOR", "OK", "Aceptar");
        }
        #endregion


        #region SiguientePulsado
        private MvxCommand comandointernoCommand;
        public ICommand SiguientePulsadoCommand {
            get {
                comandointernoCommand = comandointernoCommand ?? new MvxCommand(DoSiguientePulsado);
                return comandointernoCommand;
            }
        }
        private void DoSiguientePulsado() {
            this.dialog.Alert("SIGUIENTE", "OK", "Aceptar");
        }
        #endregion



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
                    RaisePropertyChanged(nameof(Titulo));
                }
            }
        }

        public string FechaTexto {
            get => fecha.ToString("MMM - yyyy").ToUpper();
        }

        IEnumerable<DiaCalendario> listaDias;
        public IEnumerable<DiaCalendario> ListaDias {
            get => listaDias;
            set => SetProperty(ref listaDias, value);
        }


        private bool isInselectMode;
        public bool IsInSelectMode {
            get => isInselectMode;
            set {
                if (SetProperty(ref isInselectMode, value)) {
                    RaisePropertyChanged(nameof(Titulo));
                }
            }
        }

        public string Titulo {
            get {
                if (IsInSelectMode) {
                    return $"{ListaDias.Count(d => d.IsSelected)} selecc.";
                }
                return $"{(MesAbreviado)Fecha.Month} - {Fecha.Year}";
            }
        }

        #endregion
        // ====================================================================================================

    }
}
