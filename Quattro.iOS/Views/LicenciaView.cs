using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using Quattro.Core.ViewModels;

namespace Quattro.iOS.Views {
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class LicenciaView : MvxViewController<LicenciaViewModel> {

        public override void ViewDidLoad() {

            base.ViewDidLoad();

            this.NavigationController.SetNavigationBarHidden(true, true);
            var set = this.CreateBindingSet<LicenciaView, LicenciaViewModel>();
            set.Bind(this.LabelLicencia).To(vm => vm.Licencia);
            set.Bind(this.BtAceptar).To(vm => vm.AceptarCommand);
            set.Bind(this.BtCancelar).To(vm => vm.CancelarCommand);
            set.Apply();

        }
    }
}

