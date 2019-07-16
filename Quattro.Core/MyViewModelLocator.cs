using System;
using MvvmCross.Navigation.EventArguments;
using MvvmCross.ViewModels;
using Quattro.Core.ViewModels;

namespace Quattro.Core {

    public class MyViewModelLocator : MvxDefaultViewModelLocator {

        public MyViewModelLocator() : base() {
            App.CalendarioVM = (CalendarioViewModel)Load(typeof(CalendarioViewModel), null, null, null);
        }


        public override IMvxViewModel Load(Type viewModelType, IMvxBundle parameterValues, IMvxBundle savedState, IMvxNavigateEventArgs navigationArgs) {

            // CALENDARIO
            if (viewModelType == typeof(CalendarioViewModel)) {
                if (App.CalendarioVM == null) {
                    App.CalendarioVM = (CalendarioViewModel)base.Load(viewModelType, parameterValues, savedState, navigationArgs);
                }
                return App.CalendarioVM;
            }

            // OTROS VIEW MODELS


            return base.Load(viewModelType, parameterValues, savedState, navigationArgs);
        }


    }
}
