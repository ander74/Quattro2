using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Quattro.Core.Interfaces;
using Xamarin.Essentials;

namespace Quattro.Core.ViewModels {

    public class LicenciaViewModel : MvxViewModel {

        // ====================================================================================================
        #region CAMPOS PRIVADOS
        // ====================================================================================================

        private readonly IDialogService dialog;

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region CONSTRUCTOR
        // ====================================================================================================

        public LicenciaViewModel(IDialogService dialog) {
            this.dialog = dialog;
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
        private void DoAceptar() {
            dialog.Alert("Licencia Aceptada", "Ok", "Aceptar");
        }


        private MvxCommand cancelarCommand;
        public ICommand CancelarCommand {
            get {
                cancelarCommand = cancelarCommand ?? new MvxCommand(DoCancelar);
                return cancelarCommand;
            }
        }
        private void DoCancelar() {
            dialog.Alert("Licencia Cancelada", "ERROR", "Aceptar");
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
