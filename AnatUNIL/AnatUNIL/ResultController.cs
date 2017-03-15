using System;
using Foundation;
using UIKit;

namespace AnatUNIL
{
	public partial class ResultController : UIViewController
	{
		public ResultController() : base("ResultController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			string[] tableItems = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
			MyTableView.Source = new TableViewSource(tableItems);
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public ResultController(IntPtr handle) : base (handle)
        {
		}
	}

	public class TableViewSource : UITableViewSource
	{
		string[] TableItems;
		string CellIdentifier = "TableCell";

		public TableViewSource(string[] items)
		{
			TableItems = items;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems.Length;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			string item = TableItems[indexPath.Row];

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

			cell.TextLabel.Text = item;

			return cell;
		}
	}
}

