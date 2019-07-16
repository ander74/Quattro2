using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Quattro.Core.Common;
using Quattro.Core.Data.Models;
using Quattro.Core.Data.Repositories;
using Quattro.Core.Interfaces;
using Quattro.Core.ViewModels.Args;
using Xamarin.Essentials;

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
            navigation.Navigate<DiaCalendarioViewModel, DiaNavigationArgs>(new DiaNavigationArgs { Fecha = dia.Fecha });
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
            foreach (var dia in ListaDias.Where(d => d.IsSelected)) {
                dia.IsSelected = false;
            }
            IsInSelectMode = false;
            Vibration.Vibrate(30);
        }
        #endregion


        #region AnteriorPulsado
        private MvxAsyncCommand anteriorPulsadoAsyncCommand;
        public ICommand AnteriorPulsadoAsyncCommand {
            get {
                anteriorPulsadoAsyncCommand = anteriorPulsadoAsyncCommand ?? new MvxAsyncCommand(DoAnteriorPulsadoAsync);
                return anteriorPulsadoAsyncCommand;
            }
        }
        private async Task DoAnteriorPulsadoAsync() {
            Vibration.Vibrate(15);
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
        private MvxAsyncCommand siguientePulsadoAsyncCommand;
        public ICommand SiguientePulsadoAsyncCommand {
            get {
                siguientePulsadoAsyncCommand = siguientePulsadoAsyncCommand ?? new MvxAsyncCommand(DoSiguientePulsadoAsync);
                return siguientePulsadoAsyncCommand;
            }
        }
        private async Task DoSiguientePulsadoAsync() {
            Vibration.Vibrate(15);
            Fecha = Fecha.AddMonths(1);
            this.ListaDias = await repo.GetMes(Fecha).ToListAsync();
        }
        #endregion


        #region Franqueo
        private MvxAsyncCommand franqueoCommand;
        public ICommand FranqueoCommand {
            get {
                franqueoCommand = franqueoCommand ?? new MvxAsyncCommand(DoFranqueoAsync);
                return franqueoCommand;
            }
        }
        private async Task DoFranqueoAsync() {
            Vibration.Vibrate(15);
            foreach (var dia in ListaDias.Where(d => d.IsSelected)) {
                dia.EsFranqueo = !dia.EsFranqueo;
                if (dia.EsFranqueo && dia.Incidencia == null) {
                    dia.Incidencia = await repo.GetIncidenciaAsync(2);
                    dia.PropiedadCambiada(nameof(dia.TextoServicio));
                }
            }
            await GuardarDatos();
        }
        #endregion


        #region Festivo
        private MvxAsyncCommand festivoCommand;
        public ICommand FestivoCommand {
            get {
                festivoCommand = festivoCommand ?? new MvxAsyncCommand(DoFestivoAsync);
                return festivoCommand;
            }
        }
        private async Task DoFestivoAsync() {
            Vibration.Vibrate(15);
            foreach (var dia in ListaDias.Where(d => d.IsSelected)) {
                dia.EsFestivo = !dia.EsFestivo;
            }
            await GuardarDatos();
        }
        #endregion


        #region Copiar
        private MvxCommand copiarCommand;
        public ICommand CopiarCommand {
            get {
                copiarCommand = copiarCommand ?? new MvxCommand(DoCopiar);
                return copiarCommand;
            }
        }
        private void DoCopiar() {
            Vibration.Vibrate(15);
            var dia = ListaDias.FirstOrDefault(d => d.IsSelected);
            if (dia == null) return;
            if (DiaCopiado == null) DiaCopiado = new DiaCalendario();
            DiaCopiado.FromModel(dia, true);
            dialog.ShortToast("Dia copiado");
        }
        #endregion


        #region Pegar
        private MvxAsyncCommand pegarCommand;
        public ICommand PegarCommand {
            get {
                pegarCommand = pegarCommand ?? new MvxAsyncCommand(DoPegarAsync);
                return pegarCommand;
            }
        }
        private async Task DoPegarAsync() {
            Vibration.Vibrate(15);
            if (DiaCopiado == null) return;
            foreach (var dia in ListaDias.Where(d => d.IsSelected)) {
                var fecha = dia.Fecha;
                var esFranqueo = dia.EsFranqueo;
                var esFestivo = dia.EsFestivo;
                dia.FromModel(DiaCopiado, true);
                dia.Fecha = fecha;
                dia.EsFranqueo = esFranqueo;
                dia.EsFestivo = esFestivo;
                dia.PropiedadCambiada("");
            }
            await GuardarDatos();
        }
        #endregion


        #region Vaciar
        private MvxCommand vaciarCommand;
        public ICommand VaciarCommand {
            get {
                vaciarCommand = vaciarCommand ?? new MvxCommand(DoVaciar);
                return vaciarCommand;
            }
        }
        private void DoVaciar() {
            Vibration.Vibrate(15);
            dialog.Confirmar("Esta operación borrará el contenido los días seleccionados.\n\n¿Desea continuar?",
                             "Vaciar días",
                             "Si",
                             "Cancelar", async () => {
                                 foreach (var dia in ListaDias.Where(d => d.IsSelected)) {
                                     var fecha = dia.Fecha;
                                     var esFranqueo = dia.EsFranqueo;
                                     var esFestivo = dia.EsFestivo;
                                     dia.FromModel(new DiaCalendario(), true);
                                     dia.Fecha = fecha;
                                     dia.EsFranqueo = esFranqueo;
                                     dia.EsFestivo = esFestivo;
                                     dia.PropiedadCambiada("");
                                 }
                                 await GuardarDatos();
                             },
                             null);
        }
        #endregion


        #region GuardarServicio
        private MvxAsyncCommand guardarServicioCommand;
        public ICommand GuardarServicioCommand {
            get {
                guardarServicioCommand = guardarServicioCommand ?? new MvxAsyncCommand(DoGuardarServicioAsync);
                return guardarServicioCommand;
            }
        }
        private async Task DoGuardarServicioAsync() {
            Vibration.Vibrate(15);
            var dia = ListaDias.FirstOrDefault(d => d.IsSelected);
            if (dia == null || dia.Linea == null || string.IsNullOrWhiteSpace(dia.Servicio)) return;
            if (dia.Inicio == null || dia.Final == null) return;
            var linea = await repo.GetLineaByNumeroAsync(dia.Linea.Numero);
            if (linea == null) return;
            var servicio = linea.Servicios.FirstOrDefault(s => s.Servicio.Equals(dia.Servicio) && s.Turno == dia.Turno);
            if (servicio == null) {
                servicio = new ServicioLinea();
                servicio.FromModel(dia);
                linea.Servicios.Add(servicio);
            } else {
                servicio.FromModel(dia);
            }
            await GuardarDatos();
            dialog.ShortToast("Servicio guardado.");
        }
        #endregion


        #region RepetirDiaAnterior
        private MvxAsyncCommand repetirDiaAnteriorCommand;
        public ICommand RepetirDiaAnteriorCommand {
            get {
                repetirDiaAnteriorCommand = repetirDiaAnteriorCommand ?? new MvxAsyncCommand(DoRepetirDiaAnteriorAsync);
                return repetirDiaAnteriorCommand;
            }
        }
        private async Task DoRepetirDiaAnteriorAsync() {
            Vibration.Vibrate(15);
            var dia = ListaDias.FirstOrDefault(d => d.IsSelected);
            if (dia == null) return;
            var diaAnterior = await repo.GetDiaAsync(dia.Fecha.AddDays(-1));
            if (diaAnterior == null) return;
            var fecha = dia.Fecha;
            var esFranqueo = dia.EsFranqueo;
            var esFestivo = dia.EsFestivo;
            dia.FromModel(diaAnterior, true);
            dia.Fecha = fecha;
            dia.EsFranqueo = esFranqueo;
            dia.EsFestivo = esFestivo;
            dia.PropiedadCambiada("");
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
        #region MÉTODOS PÚBLICOS
        // ====================================================================================================

        public DiaCalendario GetDia(int id) {
            return ListaDias.FirstOrDefault(d => d.Id == id);
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
                    RaisePropertyChanged(nameof(IsMultipleSelect));
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


        public DiaCalendario DiaCopiado { get; set; }


        #endregion
        // ====================================================================================================

    }
}
