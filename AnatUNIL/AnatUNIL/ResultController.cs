using System;

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
}

