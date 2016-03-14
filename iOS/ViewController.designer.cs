// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton askButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton membreSupButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton settingButton { get; set; }

		[Action ("contactButton_Click:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void contactButton_Click (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (askButton != null) {
				askButton.Dispose ();
				askButton = null;
			}
			if (membreSupButton != null) {
				membreSupButton.Dispose ();
				membreSupButton = null;
			}
			if (settingButton != null) {
				settingButton.Dispose ();
				settingButton = null;
			}
		}
	}
}
