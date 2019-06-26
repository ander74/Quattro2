using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Quattro.Core.ViewModels {

    public class HomeViewModel : MvxViewModel {

        private readonly IMvxNavigationService navigation;

        // CONSTRUCTOR
        public HomeViewModel(IMvxNavigationService navigation) {
            this.navigation = navigation;
        }

        // INICIALIZACIÓN
        public override async Task Initialize() {
            await base.Initialize();

            CalendarioCommand = new MvxAsyncCommand(async () => await navigation.Navigate<CalendarioViewModel>());
            LicenciaCommand = new MvxAsyncCommand(async () => await navigation.Navigate<LicenciaViewModel>());
            MenuCommand = new MvxAsyncCommand(async () => await navigation.Navigate<MenuViewModel>());
        }

        //COMANDOS
        public IMvxAsyncCommand CalendarioCommand { get; private set; }

        public IMvxAsyncCommand LicenciaCommand { get; private set; }

        public IMvxAsyncCommand MenuCommand { get; private set; }

    }
}
