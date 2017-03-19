﻿using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Anatomie_UNIL
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        WriteTo setting;

        public Settings()
        {
            this.InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested += Inferieur_BackRequested;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            setting = new WriteTo();

            Slider.Value = setting.nbQuestionToDo;
            Slider.ValueChanged += Slider_ValueChanged;
            ToggleResults.IsOn = setting.displayResults;
            if (setting.nbQuestionToDo == 0)
                ToggleInfinite.IsOn = true;
            else
                ToggleInfinite.IsOn = false;

            ToggleInfinite.Toggled += ToggleInfinite_Toggled;
            ToggleResults.Toggled += ToggleResults_Toggled;
            statRepondue.Text = "Total de questions répondues : " + setting.nbQuestionDone.ToString();
            statCorrect.Text = "Total de questions correctes : " + setting.nbQuestionRight.ToString();
            statFaux.Text = "Total de questions fausses : " + setting.nbQuestionFalse.ToString();
            pourcentage.Text = "Pourcentage : ";
            if (setting.nbQuestionDone == 0)
                pourcentage.Text += "Répond d'abord à une question";
            else
            {
                double val = setting.nbQuestionRight*100 / setting.nbQuestionDone;
                pourcentage.Text += val.ToString() + "%";
            }

        }

        private void ToggleResults_Toggled(object sender, RoutedEventArgs e)
        {
            if (ToggleResults.IsOn == true)
                setting.displayResults = true;
            else
                setting.displayResults = false;
        }

        private void ToggleInfinite_Toggled(object sender, RoutedEventArgs e)
        {
            if (ToggleInfinite.IsOn == true)
                setting.nbQuestionToDo = 0;
            else
                setting.nbQuestionToDo = 20;
        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            setting.nbQuestionToDo = Convert.ToInt32(Slider.Value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //reset
            setting.nbQuestionDone = 0;
            setting.nbQuestionRight = 0;
            setting.nbQuestionFalse = 0;
            statCorrect.Text = "Total de questions correctes : 0";
            statFaux.Text = "Total de question fausses : 0";
            statRepondue.Text = "Total de questions répondues : 0";
            pourcentage.Text += "Répond d'abord à une question";
        }

        private void Inferieur_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
                return;

            // Navigate back if possible, and if the event has not 
            // already been handled .
            if (rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }
    }
}