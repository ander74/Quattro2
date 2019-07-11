using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Quattro.Core.Common;
using Quattro.Core.Data.Models;
using Quattro.Core.Data.Repositories;
using Quattro.Core.Interfaces;
using Quattro.Core.ViewModels.Args;

namespace Quattro.Core.ViewModels {

    public class DiaCalendarioViewModel : MvxViewModel<DiaNavigationArgs> {


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

        public DiaCalendarioViewModel(ICalendarioRepository repo, IDialogService dialog, IMvxNavigationService navigation) {
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
            ListaIncidencias = await repo.GetIncidencias();
        }

        public override void Prepare(DiaNavigationArgs parameter) {
            Dia = repo.GetDia(parameter.Fecha);
            IncidenciaSeleccionada = dia.Incidencia;
        }


        public override void ViewDisappearing() {
            base.ViewDisappearing();
            repo.GuardarDatosAsync();
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region COMANDOS
        // ====================================================================================================


        #region IncidenciaSeleccionada
        private MvxCommand<Incidencia> incidenciaSeleccionadaCommand;
        public ICommand IncidenciaSeleccionadaCommand {
            get {
                incidenciaSeleccionadaCommand = incidenciaSeleccionadaCommand ?? new MvxCommand<Incidencia>(DoIncidenciaSeleccionada);
                return incidenciaSeleccionadaCommand;
            }
        }
        private void DoIncidenciaSeleccionada(Incidencia incidencia) {
            Dia.Incidencia = incidencia;
        }
        #endregion


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================


        private DiaCalendario dia;
        public DiaCalendario Dia {
            get => dia;
            set {
                if (SetProperty(ref dia, value)) {
                    RaisePropertyChanged(nameof(Titulo));
                }
            }
        }

        public string Titulo {
            get => $"{(DiaSemana)Dia.Fecha.DayOfWeek}, {Dia.Fecha.Day.ToString("00")} - {(Mes)Dia.Fecha.Month}";
        }

        public IEnumerable<Incidencia> ListaIncidencias { get; set; }


        private Incidencia incidenciaSeleccionada;
        public Incidencia IncidenciaSeleccionada {
            get => incidenciaSeleccionada;
            set => SetProperty(ref incidenciaSeleccionada, value);
        }


        #endregion
        // ====================================================================================================



    }
}
