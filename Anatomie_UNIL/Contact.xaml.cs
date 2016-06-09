using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Email;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
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
        string[] input;
        public Contact()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += Inferieur_BackRequested;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string tmp;
            input = e.Parameter as string[];
            if (input != null)
            {
                tmp = "Relevé d'erreur concernant la question :\n";
                tmp += input[1] + "\n";
                tmp += "Réponse de l'application :\n";
                tmp += input[3] + "\n";
                tmp += "Réponse de l'utilisateur :\n";
                tmp += input[2] + "\n";
                TextBox.Text = tmp;
                NameBox.Focus(FocusState.Pointer);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)//ANNULER
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//ENVOYER
        {
            if (NameBox.Text != "" && TextBox.Text != "")
            {
                string name = NameBox.Text;
                if (name.Length < 5)
                { noName(); return; }
                EmailMessage mail = new EmailMessage();
                mail.To.Add(new EmailRecipient("glaglasven@live.com"));
                mail.Body = TextBox.Text;
                mail.Subject = "[UNIL-Anatomie] Message de : " + NameBox.Text;
                Send(mail);
            }
            if (NameBox.Text == "" || TextBox.Text == "")
                NoText();
        }

        private async void noName()
        {
            var message = new MessageDialog("Nom trop court");
            message.Commands.Add(new UICommand("Ok"));
            await message.ShowAsync();
        }

        private async void NoText()
        {
            var messageDialog = new MessageDialog("Veuillez remplir tous les champs", "Champs vides");
            messageDialog.Commands.Add(new UICommand("Ok"));
            await messageDialog.ShowAsync();
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
