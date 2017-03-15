using Foundation;
using System;
using UIKit;

namespace AnatUNIL
{
    public partial class ResultController : UITableViewController
    {
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			TableView.RowHeight = UITableView.AutomaticDimension;
		}

        public ResultController (IntPtr handle) : base (handle)
        {
        }
    }
}