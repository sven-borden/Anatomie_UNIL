using System;
using Foundation;
using UIKit;
using Logic;

namespace AnatUNIL
{
	public partial class ViewController : UIViewController
	{
		Settings settings;
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			settings = new Settings();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			var questionView = segue.DestinationViewController as QuestionView;

			if (questionView != null)
			{
				questionView.ViewTitle = (sender as UIButton).Title(UIControlState.Normal).ToString();
				questionView.settings = this.settings;
			}
		}

		partial void ToggledOrigin(UISwitch sender)
		{
			settings.isInsertion = sender.On;
		}

		partial void ToggledTerminaison(UISwitch sender)
		{
			settings.isTerminaison = sender.On;
		}

		partial void ToggledInnervation(UISwitch sender)
		{
			settings.isInnevervation = sender.On;
		}
	}
}
