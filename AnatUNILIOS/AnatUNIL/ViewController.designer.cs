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

namespace AnatUNIL
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonInf { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonSup { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonTout { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonTronc { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch ToggleInnervation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch ToggleOrigine { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch ToggleTerminaison { get; set; }

        [Action ("ButtonSup_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ButtonSup_TouchUpInside (UIKit.UIButton sender);

        [Action ("ToggledInnervation:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ToggledInnervation (UIKit.UISwitch sender);

        [Action ("ToggledOrigin:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ToggledOrigin (UIKit.UISwitch sender);

        [Action ("ToggledTerminaison:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ToggledTerminaison (UIKit.UISwitch sender);

        void ReleaseDesignerOutlets ()
        {
            if (ButtonInf != null) {
                ButtonInf.Dispose ();
                ButtonInf = null;
            }

            if (ButtonSup != null) {
                ButtonSup.Dispose ();
                ButtonSup = null;
            }

            if (ButtonTout != null) {
                ButtonTout.Dispose ();
                ButtonTout = null;
            }

            if (ButtonTronc != null) {
                ButtonTronc.Dispose ();
                ButtonTronc = null;
            }

            if (ToggleInnervation != null) {
                ToggleInnervation.Dispose ();
                ToggleInnervation = null;
            }

            if (ToggleOrigine != null) {
                ToggleOrigine.Dispose ();
                ToggleOrigine = null;
            }

            if (ToggleTerminaison != null) {
                ToggleTerminaison.Dispose ();
                ToggleTerminaison = null;
            }
        }
    }
}