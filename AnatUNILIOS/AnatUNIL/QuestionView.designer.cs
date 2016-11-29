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
    [Register ("QuestionView")]
    partial class QuestionView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Reponse1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Reponse2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Reponse3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Reponse4 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TexteQuestion { get; set; }

        [Action ("Reponse2Click:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Reponse2Click (UIKit.UIButton sender);

        [Action ("Reponse3Click:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Reponse3Click (UIKit.UIButton sender);

        [Action ("Reponse4Click:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Reponse4Click (UIKit.UIButton sender);

        [Action ("Response1Click:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Response1Click (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Reponse1 != null) {
                Reponse1.Dispose ();
                Reponse1 = null;
            }

            if (Reponse2 != null) {
                Reponse2.Dispose ();
                Reponse2 = null;
            }

            if (Reponse3 != null) {
                Reponse3.Dispose ();
                Reponse3 = null;
            }

            if (Reponse4 != null) {
                Reponse4.Dispose ();
                Reponse4 = null;
            }

            if (TexteQuestion != null) {
                TexteQuestion.Dispose ();
                TexteQuestion = null;
            }
        }
    }
}