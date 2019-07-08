using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Ios.Core;
using Quattro.Core;
using Quattro.Core.Interfaces;
using Quattro.iOS.Services;

namespace Quattro.iOS {

    public class Setup : MvxIosSetup<App> {

        protected override void InitializeFirstChance() {
            base.InitializeFirstChance();
            Mvx.IoCProvider.RegisterType<IDialogService, DialogService>();
        }

        protected override IMvxIocOptions CreateIocOptions() {
            return new MvxIocOptions {
                PropertyInjectorOptions = MvxPropertyInjectorOptions.MvxInject
            };
        }

    }
}
