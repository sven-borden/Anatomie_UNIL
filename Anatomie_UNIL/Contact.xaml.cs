using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Email;
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
    public sealed partial class Contact : Page
    {
        public Contact()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += Inferieur_BackRequested;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)//ANNULER
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//ENVOYER
        {
            EmailMessage mail = new EmailMessage();
            mail.To.Add(new EmailRecipient("glaglasven@live.com"));
            mail.Body = TextBox.Text;
            mail.Subject = "[UNIL-Anatomie] Message de : " + NameBox.Text;
            Send(mail);
        }

        private async void Send(EmailMessage mail)
        {
            await EmailManager.ShowComposeNewEmailAsync(mail);
            Frame.Navigate(typeof(MainPage));
        }

        private void Inferieur_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
