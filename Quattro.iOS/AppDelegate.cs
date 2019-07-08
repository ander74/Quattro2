using Foundation;
using MvvmCross.Platforms.Ios.Core;
using UIKit;

namespace Quattro.iOS {

    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate {


        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions) {

            var result = base.FinishedLaunching(application, launchOptions);

            CustomizarApariencia();

            return result;

        }


        private void CustomizarApariencia() {

            // Aquí podemos cambiar la apariencia de la aplicación.

        }

    }
}


