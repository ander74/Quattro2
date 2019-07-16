using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using Quattro.Core.ViewModels;
using Quattro.iOS.TableSources;

namespace Quattro.iOS.Views {

    public partial class CalendarioView : MvxTableViewController<CalendarioViewModel> {

        public CalendarioView() : base("CalendarioView", null) {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var source = new CalendarioTableSource(ListaCalendario);
            ListaCalendario.RowHeight = 75;
            var set = this.CreateBindingSet<CalendarioView, CalendarioViewModel>();
            set.Bind(source).To(vm => vm.ListaDias);
            set.Bind(BtRetroceder).To(vm => vm.AnteriorPulsadoAsyncCommand);
            set.Bind(BtSiguiente).To(vm => vm.SiguientePulsadoAsyncCommand);
            set.Apply();

            ListaCalendario.Source = source;
            ListaCalendario.ReloadData();

        }

        public override void DidReceiveMemoryWarning() {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

