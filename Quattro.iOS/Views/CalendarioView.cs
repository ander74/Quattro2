using System;

using UIKit;

namespace Quattro.iOS.Views {
    public partial class CalendarioView : UIViewController {
        public CalendarioView() : base("CalendarioView", null) {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning() {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

