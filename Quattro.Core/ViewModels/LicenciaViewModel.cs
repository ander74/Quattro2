using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Quattro.Core.Interfaces;
using Xamarin.Essentials;

namespace Quattro.Core.ViewModels {

    public class LicenciaViewModel : MvxViewModel {

        // ====================================================================================================
        #region CAMPOS PRIVADOS
        // ====================================================================================================

        private readonly IDialogService dialog;
        private readonly IMvxNavigationService navigation;

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public LicenciaViewModel(IDialogService dialog, IMvxNavigationService navigation) {
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

            // Leemos el archivo de licencia de los recursos incrustrados y lo asignamos a la propiedad Licencia.
            //TODO: Intentar meter esto en un método estatico en Utils o algo así.
            var assembly = typeof(LicenciaViewModel).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("Quattro.Core.licencia.txt");
            using (var reader = new StreamReader(stream)) {
                this.Licencia = reader.ReadToEnd();
            }
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region COMANDOS
        // ====================================================================================================

        private MvxCommand aceptarCommand;
        public ICommand AceptarCommand {
            get {
                aceptarCommand = aceptarCommand ?? new MvxCommand(DoAceptar);
                return aceptarCommand;
            }
        }
        private async void DoAceptar() {
            Preferences.Set("PrimerInicio", false); // TODO: Cambiar esto por true, para volver a ver la licencia.
            await navigation.Navigate<CalendarioViewModel>();
        }


        private MvxCommand cancelarCommand;
        public ICommand CancelarCommand {
            get {
                cancelarCommand = cancelarCommand ?? new MvxCommand(DoCancelar);
                return cancelarCommand;
            }
        }
        private void DoCancelar() {
            dialog.Confirmar("Debe aceptar la licencia para usar este programa", "AVISO", "Salir", "Volver", () => { navigation.Close(this); }, null);
            
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region PROPIEDADES
        // ====================================================================================================


        private string licencia;
        public string Licencia {
            get => licencia;
            set => SetProperty(ref licencia, value);
        }

        #endregion
        // ====================================================================================================


    }
}
