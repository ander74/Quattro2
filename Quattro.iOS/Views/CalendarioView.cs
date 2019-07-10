using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Views;
using Quattro.Core.ViewModels;
using UIKit;

namespace Quattro.iOS.Views {

    public partial class CalendarioView : MvxViewController<CalendarioViewModel> {

        public CalendarioView() : base("CalendarioView", null) {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var source = new MvxSimpleTableViewSource(ListaCalendario, "CalendarioCell", CalendarioCell.Key);
            ListaCalendario.RowHeight = 75;
            var set = this.CreateBindingSet<CalendarioView, CalendarioViewModel>();
            set.Bind(source).To(vm => vm.ListaDias);
            set.Bind(BtRetroceder).To(vm => vm.AnteriorPulsadoCommand);
            set.Bind(BtSiguiente).To(vm => vm.SiguientePulsadoCommand);
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

