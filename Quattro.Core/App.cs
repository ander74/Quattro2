using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Quattro.Core.ViewModels;
using Xamarin.Essentials;

namespace Quattro.Core {

    public class App : MvxApplication {

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

            // Inicia la aplicación usando el ViewModel indicado.
            // Este se encargará de inicializar la vista, etc.
            if (Preferences.Get("PrimerInicio", true)) {
                this.RegisterAppStart<LicenciaViewModel>();
            } else {
                this.RegisterAppStart<HomeViewModel>();//TODO: Cambiar por el menú.
            }
        }

    }
}
