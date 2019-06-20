using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using Quattro.Core;
using Quattro.Core.Interfaces;
using Quattro.Droid.Services;

namespace Quattro.Droid {
    public class Setup : MvxAndroidSetup<App> {

        protected override void InitializeFirstChance() {

            Mvx.IoCProvider.RegisterType<IDialogService, DialogService>();
            base.InitializeFirstChance();
        }

        public override IEnumerable<Assembly> GetPluginAssemblies() {
            var assemblies = base.GetPluginAssemblies().ToList();
            assemblies.Add(typeof(MvvmCross.Plugin.Visibility.Platforms.Android.Plugin).Assembly);
            return assemblies;
        }


    }
}