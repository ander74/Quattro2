using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Quattro.Core.ViewModels;

namespace Quattro.Core {

    public class App : MvxApplication {

        public override void Initialize() {

            // Inyecta cualquier clase que termine en 'Service' como un singleton, por medio de una interfaz.
            this.CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            // Inicia la aplicación usando el ViewModel indicado.
            // Este s encargará de inicializar la vista, etc.
            this.RegisterAppStart<LicenciaViewModel>();
        }

    }
}
