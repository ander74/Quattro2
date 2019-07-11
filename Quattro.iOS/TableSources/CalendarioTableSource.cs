
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace Quattro.iOS.TableSources {

    public class CalendarioTableSource : MvxTableViewSource {

        private static readonly NSString IdentificadorCelda = new NSString("IdentificadorCelda");

        public CalendarioTableSource(UITableView tableView) : base(tableView) {
            tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            tableView.RegisterNibForCellReuse(UINib.FromName("IdentificadorCelda", NSBundle.MainBundle), IdentificadorCelda);
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item) {
            return (UITableViewCell)TableView.DequeueReusableCell(IdentificadorCelda, indexPath);
        }
    }
}