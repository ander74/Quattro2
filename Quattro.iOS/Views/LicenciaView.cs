using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using Quattro.Core.ViewModels;

namespace Quattro.iOS.Views {
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class LicenciaView : MvxViewController<LicenciaViewModel> {

        public override void ViewDidLoad() {

            base.ViewDidLoad();

            var set = this.CreateBindingSet<LicenciaView, LicenciaViewModel>();
            //set.Bind(this.LabelPrueba).To(vm => vm.Prueba);
            set.Apply();

        }
    }
}