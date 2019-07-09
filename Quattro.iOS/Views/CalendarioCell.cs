using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using Quattro.Core.Data.Models;
using UIKit;

namespace Quattro.iOS.Views {

    public partial class CalendarioCell : MvxTableViewCell {

        public static readonly NSString Key = new NSString("CalendarioCell");
        public static readonly UINib Nib;

        static CalendarioCell() {
            Nib = UINib.FromName("CalendarioCell", NSBundle.MainBundle);
        }

        protected CalendarioCell(IntPtr handle) : base(handle) {
            // Note: this .ctor should not contain any initialization logic.

            var set = this.CreateBindingSet<CalendarioCell, DiaCalendario>();

            set.Bind(this).For(c => c.BackgroundColor).To(vm => vm.TipoFondo).WithConversion("ColorTipoFondo");

            set.Bind(MarcadorFranqueo).For("Visibility").To(vm => vm.EsFranqueo).WithConversion("Visibility");

            set.Bind(NumeroDia).For(nd => nd.Text).To(vm => vm.Fecha.Day).WithConversion("StringFormat", "00");
            set.Bind(TextoDia).For(nd => nd.Text).To(vm => vm.DiaSemana);
            set.Bind(NumeroDia).For(t => t.TextColor).To(vm => vm.EsDomingoOFestivo).WithConversion("ColorDia");
            set.Bind(TextoDia).For(t => t.TextColor).To(vm => vm.EsDomingoOFestivo).WithConversion("ColorDia");


            set.Bind(TextoServicio).For(nd => nd.Text).To(vm => vm.TextoServicio);

            set.Bind(TextoHorario).For(nd => nd.Text).To(vm => vm.TextoHorario);

            set.Bind(TextoAcumuladas).For(nd => nd.Text).To(vm => vm.Acumuladas);
            set.Bind(TextoNocturnas).For(nd => nd.Text).To(vm => vm.Nocturnas);
            set.Bind(TextoAcumuladas).For("Visibility").To(vm => vm.MostrarAcumuladas).WithConversion("Visibility");
            set.Bind(TextoNocturnas).For("Visibility").To(vm => vm.MostrarAcumuladas).WithConversion("Visibility");
            set.Bind(GuionAcumuladas).For("Visibility").To(vm => vm.MostrarAcumuladas).WithConversion("Visibility");

            set.Bind(TextoRelevo).For(nd => nd.Text).To(vm => vm.TextoRelevo);

            set.Bind(ImgHuelga).For("Visibility").To(vm => vm.HayHuelga).WithConversion("Visibility");
            set.Bind(ImgNotas).For("Visibility").To(vm => vm.HayNotas).WithConversion("Visibility");
            set.Bind(ImgDesayuno).For("Visibility").To(vm => vm.Desayuno).WithConversion("Visibility");
            set.Bind(ImgComida).For("Visibility").To(vm => vm.Comida).WithConversion("Visibility");
            set.Bind(ImgCena).For("Visibility").To(vm => vm.Cena).WithConversion("Visibility");

            set.Bind(ImgNosHacen).For("Visibility").To(vm => vm.NosHacenDia).WithConversion("Visibility");
            set.Bind(ImgHacemos).For("Visibility").To(vm => vm.HacemosDia).WithConversion("Visibility");

            set.Bind(ImgBueno).For("Visibility").To(vm => vm.EsRelevoBueno).WithConversion("Visibility");
            set.Bind(ImgMalo).For("Visibility").To(vm => vm.EsRelevoMalo).WithConversion("Visibility");
        }
    }
}
