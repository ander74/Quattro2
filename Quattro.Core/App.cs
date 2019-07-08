using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Quattro.Core.Data;
using Quattro.Core.ViewModels;
using Xamarin.Essentials;

namespace Quattro.Core {

    public class App : MvxApplication {


        // ====================================================================================================
        #region MÉTODO INITIALIZE
        // ====================================================================================================

        public override void Initialize() {

            // Inyecta cualquier clase que termine en 'Service' como un singleton, por medio de una interfaz.
            this.CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            // Inyecta cualquier clase que termine en 'Repository' como un singleton, por medio de una interfaz.
            this.CreatableTypes()
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            // Inyecta el QuattroContext
            Mvx.IoCProvider.RegisterSingleton(new QuattroContext());


            // Inicia la aplicación usando el ViewModel indicado.
            // Este se encargará de inicializar la vista, etc.
            Preferences.Set("PrimerInicio", true); //TODO: Quitar cuando no se quiera ver la licencia.
            if (Preferences.Get("PrimerInicio", true)) {
                this.RegisterAppStart<LicenciaViewModel>();
            } else {
                this.RegisterAppStart<HomeViewModel>();
            }
        }


        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region MÉTODO CREATE DEFAULT VIEWMODELLOCATOR
        // ====================================================================================================

        protected override IMvxViewModelLocator CreateDefaultViewModelLocator() {
            return new MyViewModelLocator();
        }

        #endregion
        // ====================================================================================================


        // ====================================================================================================
        #region VIEW MODELS
        // ====================================================================================================

        // Los ViewModels se establecen inicialmente en null y es el ViewModelLocator el que se encarga
        // de instanciarlos. La primera vez, se instancian por medio del propio framework, el resto de veces
        // se utiliza el ViewModel estático ya creado.

        public static CalendarioViewModel CalendarioVM { get; set; }

        #endregion
        // ====================================================================================================

    }
}
