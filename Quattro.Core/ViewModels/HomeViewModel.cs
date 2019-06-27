using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Quattro.Core.Interfaces;

namespace Quattro.Core.ViewModels {

    public class HomeViewModel : MvxViewModel {

        private readonly IMvxNavigationService navigation;
        private readonly IDialogService dialog;

        public HomeViewModel(IMvxNavigationService navigation, IDialogService dialog) {
            this.navigation = navigation;
            this.dialog = dialog;
        }




        #region GotoCalendario
        private MvxAsyncCommand gotoCalendarioCommand;

        public ICommand GotoCalendarioCommand {
            get {
                gotoCalendarioCommand = gotoCalendarioCommand ?? new MvxAsyncCommand(DoGotoCalendario);
                return gotoCalendarioCommand;
            }
        }
        private async Task DoGotoCalendario() {
            await Task.Run(() => navigation.Navigate<CalendarioViewModel>());
        }
        #endregion



        #region GotoLicencia
        private MvxAsyncCommand gotoLicenciaCommand;
        public ICommand GotoLicenciaCommand {
            get {
                gotoLicenciaCommand = gotoLicenciaCommand ?? new MvxAsyncCommand(DoGotoLicencia);
                return gotoLicenciaCommand;
            }
        }
        private async Task DoGotoLicencia() {
            await Task.Run(() => dialog.LongToast("Has Pulsado la licencia"));
        }
        #endregion


    }
}
