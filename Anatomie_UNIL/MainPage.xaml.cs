using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Store;
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

namespace Anatomie_UNIL
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region variables
        public static bool insertion, terminaison, innervation, mouvement;
        public static LicenseInformation licence;
        #endregion

        public MainPage()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            WriteTo settings = new WriteTo();
            checkBoxInsertion.IsChecked = settings.isInsertion;
            checkBoxTerminaison.IsChecked = settings.isTerminaison;
            checkBoxInnervation.IsChecked = settings.isInnevervation;
            checkBoxMouvement.IsChecked = settings.isMouvement;

            ///THIS IS THE PART FOR INAPP PURCHASE
            ///CAREFUL WITH THIS SHIT
            ///
            CheckLicense();
            licence.LicenseChanged += Licence_LicenseChanged;
            
            theStoryBoard.Begin();
        }

        private void Licence_LicenseChanged()
        {
            CheckLicense();
        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
                return;

            //if (rootFrame.CanGoBack && e.Handled == false)
            //{
            //    e.Handled = true;
            //    Frame.GoBack(); //some stuff is not working here
            //}
        }

        private void buttonSetting_Click(object sender, RoutedEventArgs e) { Frame.Navigate(typeof(Settings)); }

        private void buttonAsk_Click(object sender, RoutedEventArgs e) { Frame.Navigate(typeof(Ask)); }

        //____________________________________________________________________//

        private void buttonMembSup_Click(object sender, RoutedEventArgs e) { Frame.Navigate(typeof(Superieur)); }

        private void buttonMembInf_Click(object sender, RoutedEventArgs e) { Frame.Navigate(typeof(Inferieur)); }

        private void buttonTronc_Click(object sender, RoutedEventArgs e) { Frame.Navigate(typeof(Tronc)); }

        private void buttonTout_Click(object sender, RoutedEventArgs e) { Frame.Navigate(typeof(Tout)); }

        //____________________________________________________________________//

        private void checkBoxInsertion_Checked(object sender, RoutedEventArgs e)
        {
            WriteTo setting = new WriteTo();
            setting.isInsertion = checkBoxInsertion.IsChecked;
        }

        private void checkBoxTerminaison_Checked(object sender, RoutedEventArgs e)
        {
            WriteTo setting = new WriteTo();
            setting.isTerminaison = checkBoxTerminaison.IsChecked;
        }

        private void checkBoxInnervation_Checked(object sender, RoutedEventArgs e)
        {
            WriteTo setting = new WriteTo();
            setting.isInnevervation = checkBoxInnervation.IsChecked;
        }

        private void checkBoxMouvement_Checked(object sender, RoutedEventArgs e)
        {
            WriteTo setting = new WriteTo();
            setting.isMouvement = checkBoxMouvement.IsChecked;
        }

        //____________________________________________________________________//

        private void checkBoxInsertion_Unchecked(object sender, RoutedEventArgs e)
        {
            WriteTo setting = new WriteTo();
            setting.isInsertion = checkBoxInsertion.IsChecked;
        }
      
        private void checkBoxTerminaison_Unchecked(object sender, RoutedEventArgs e)
        {
            WriteTo setting = new WriteTo();
            setting.isTerminaison = checkBoxTerminaison.IsChecked;

        }
        private void checkBoxInnervation_Unchecked(object sender, RoutedEventArgs e)
        {
            WriteTo setting = new WriteTo();
            setting.isInnevervation = checkBoxInnervation.IsChecked;
        }

        private void checkBoxMouvement_Unchecked(object sender, RoutedEventArgs e)
        {
            WriteTo setting = new WriteTo();
            setting.isMouvement = checkBoxMouvement.IsChecked;
        }

        //____________________________________________________________________//

        private void buttondebloquer_Click(object sender, RoutedEventArgs e) { CheckPurchaseLicence(); }

        private async void CheckPurchaseLicence()
        {
            if (!licence.ProductLicenses["DEBLOQUERTOUT"].IsActive)
            {
                try
                {
                    await CurrentAppSimulator.RequestProductPurchaseAsync("DEBLOQUERTOUT");
                }
                catch (Exception ex)
                {
                    ErrorLicensePurchase(ex.ToString());
                }
            }
            else
            {
                buttonMembInf.IsEnabled = true;
                buttonTout.IsEnabled = true;
                buttondebloquer.IsEnabled = false;
                buttondebloquer.Visibility = Visibility.Collapsed;
            }
        }

        private async void ErrorLicensePurchase(string ex)
        {
            var messageDialog = new MessageDialog("On dirait qu'une erreur s'est produite" + ex, "Ops");
            messageDialog.Commands.Add(new UICommand("OK"));
            await messageDialog.ShowAsync();
        }

        private void CheckLicense()
        {
            licence = CurrentAppSimulator.LicenseInformation;
            if (!licence.ProductLicenses["DEBLOQUERTOUT"].IsActive)
            {
                buttonMembInf.IsEnabled = false;
                buttonTout.IsEnabled = false;
                buttondebloquer.IsEnabled = true;
                buttondebloquer.Visibility = Visibility.Visible;
            }
            else
            {
                buttonMembInf.IsEnabled = true;
                buttonTout.IsEnabled = true;
                buttondebloquer.IsEnabled = false;
                buttondebloquer.Visibility = Visibility.Collapsed;
            }
        }

    }
}
