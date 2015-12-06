using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
            statRepondue.Text = "Total de questions répondues : " + setting.nbQuestionDone.ToString();
            statCorrect.Text = "Total de questions correctes : " + setting.nbQuestionRight.ToString();
            statFaux.Text = "Total de questions fausses : " + setting.nbQuestionFalse.ToString();
            pourcentage.Text = "Pourcentage : ";
            if (setting.nbQuestionDone == 0)
                pourcentage.Text += "*Répond d'abord à une question";
            else
            {
                if (setting.nbQuestionFalse == 0)
                {
                    pourcentage.Text += "100%";
                }
                else
                {
                    if (setting.nbQuestionRight == 0)
                        pourcentage.Text += "0%";
                    else pourcentage.Text += setting.nbQuestionRight /setting.nbQuestionDone + "%";
                }
            }

        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            setting.nbQuestionToDo = Convert.ToInt32(Slider.Value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
