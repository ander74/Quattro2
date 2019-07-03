using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Quattro.Core.Common;
using Quattro.Core.Interfaces;
using Quattro.Core.Data.Models;
using Quattro.Core.Data.Repositories;
using Xamarin.Essentials;
using Microsoft.EntityFrameworkCore;

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
            this.Fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.ListaDias = await repo.GetMes(Fecha).ToListAsync();

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
                if (ListaDias.Count(d => d.IsSelected) == 0) {
                    IsInSelectMode = false;
                }
                Vibration.Vibrate(15);
                RaisePropertyChanged(nameof(Titulo));
                RaisePropertyChanged(nameof(IsMultipleSelect));
                return;
            }
            //TODO: Navegar al día.
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
            Vibration.Vibrate(50);
            dia.IsSelected = true;
            IsInSelectMode = true;
        }
        #endregion


        #region DesseleccionarTodo
        private MvxCommand desseleccionarTodoCommand;
        public ICommand DesseleccionarTodoCommand {
            get {
                desseleccionarTodoCommand = desseleccionarTodoCommand ?? new MvxCommand(DoDesseleccionarTodo);
                return desseleccionarTodoCommand;
            }
        }
        private void DoDesseleccionarTodo() {
            foreach(var dia in ListaDias.Where(d => d.IsSelected)) {
                dia.IsSelected = false;
            }
            IsInSelectMode = false;
            Vibration.Vibrate(30);
        }
        #endregion


        #region AnteriorPulsado
        private MvxAsyncCommand anteriorPulsadoCommand;
        public ICommand AnteriorPulsadoCommand {
            get {
                anteriorPulsadoCommand = anteriorPulsadoCommand ?? new MvxAsyncCommand(DoAnteriorPulsado);
                return anteriorPulsadoCommand;
            }
        }
        private async Task DoAnteriorPulsado() {
            //TODO: cambiar la instrucción siguiente por la opción
            var FechaLimite = new DateTime(2019, 1, 1);
            if (Fecha == FechaLimite) {
                dialog.LongToast("No se puede retroceder más.");
                return;
            }
            Fecha = Fecha.AddMonths(-1);
            this.ListaDias = await repo.GetMes(Fecha).ToListAsync();
        }
        #endregion


        #region SiguientePulsado
        private MvxAsyncCommand comandointernoCommand;
        public ICommand SiguientePulsadoCommand {
            get {
                comandointernoCommand = comandointernoCommand ?? new MvxAsyncCommand(DoSiguientePulsado);
                return comandointernoCommand;
            }
        }
        private async Task DoSiguientePulsado() {
            Fecha = Fecha.AddMonths(1);
            this.ListaDias = await repo.GetMes(Fecha).ToListAsync();
        }
        #endregion


        #region Franqueo
        private MvxAsyncCommand franqueoCommand;
        public ICommand FranqueoCommand {
            get {
                franqueoCommand = franqueoCommand ?? new MvxAsyncCommand(DoFranqueo);
                return franqueoCommand;
            }
        }
        private async Task DoFranqueo() {
            foreach(var dia in ListaDias.Where(d => d.IsSelected)) {
                dia.EsFranqueo = !dia.EsFranqueo;
            }
            await GuardarDatos();
        }
        #endregion


        #region Festivo
        private MvxAsyncCommand festivoCommand;
        public ICommand FestivoCommand {
            get {
                festivoCommand = festivoCommand ?? new MvxAsyncCommand(DoFestivo);
                return festivoCommand;
            }
        }
        private async Task DoFestivo() {
            foreach (var dia in ListaDias.Where(d => d.IsSelected)) {
                dia.EsFestivo = !dia.EsFestivo;
            }
            await GuardarDatos();
        }
        #endregion




        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODOS PRIVADOS
        // ====================================================================================================

        private async Task GuardarDatos() {
            await repo.GuardarDatosAsync();
        }

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


        private bool isInSelectMode;
        public bool IsInSelectMode {
            get => isInSelectMode;
            set {
                if (SetProperty(ref isInSelectMode, value)) {
                    RaisePropertyChanged(nameof(Titulo));
                }
            }
        }


        public bool IsMultipleSelect {
            get => ListaDias.Count(d => d.IsSelected) > 1;
        }


        public string Titulo {
            get {
                if (IsInSelectMode) {
                    return $"{ListaDias.Count(d => d.IsSelected)} selecc.";
                }
                return $"{(Mes)Fecha.Month} - {Fecha.Year}".ToUpper();
            }
        }

        #endregion
        // ====================================================================================================

    }
}
