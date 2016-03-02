using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Anatomie_UNIL
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Resultats : Page
    {
        Partie partie;
        RowDefinition rd;
        ColumnDefinition cd;
        List<string> listing;
        string[] selection;
        public Resultats()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += Resultats_BackRequested; ;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            partie = e.Parameter as Partie;
            SetAns();
        }

        private void SetAns()
        {
            note.Text = partie.getNote.ToString();

            if (partie.getMembre.ToString() == "Supérieur")
                sup(partie.getListQuestions, partie.getListAnswer, partie.getListHisAnswer);
            if (partie.getMembre.ToString() == "Inférieur")
                inf(partie.getListQuestions, partie.getListAnswer, partie.getListHisAnswer);
            if (partie.getMembre.ToString() == "Tronc")
                trc(partie.getListQuestions, partie.getListAnswer, partie.getListHisAnswer);
            if (partie.getMembre.ToString() == "Tout")
                tt(partie.getListQuestions, partie.getListAnswer, partie.getListHisAnswer);
        }

        private void sup(List<string> listQuestions, List<string> listAnswer, List<string> listHisAnswer)
        {
            listing = new List<string>();
            //gonna parse a string like this buttonUID|question|hisans|ans

            for (int i = 0; i < listQuestions.Count; i++)
            {
                rd = new RowDefinition();
                resultGrid.RowDefinitions.Add(rd);

                
                TextBlock tx0 = new TextBlock();
                tx0.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                tx0.Margin = new Thickness(10);
                tx0.Text = (i + 1).ToString();

                Grid.SetRow(tx0, i);
                Grid.SetColumn(tx0, 0);

                resultGrid.Children.Add(tx0);

                #region underGrid
                //  nouveau grid pour mettre dans le grid du grid 
                //  (je me comprend, t'as quà te remettre dedans pour comprendre bouffon)
                Grid underGrid = new Grid();
                Grid.SetRow(underGrid, i);
                Grid.SetColumn(underGrid, 1);

                rd = new RowDefinition();
                underGrid.RowDefinitions.Add(rd);//premier sous grid avec la question
                rd = new RowDefinition();
                underGrid.RowDefinitions.Add(rd);
                rd = new RowDefinition();
                underGrid.RowDefinitions.Add(rd);

                cd = new ColumnDefinition();
                cd.Width = new GridLength(5, GridUnitType.Auto);
                underGrid.ColumnDefinitions.Add(cd);
                cd = new ColumnDefinition();
                underGrid.ColumnDefinitions.Add(cd);

                TextBlock txQ = new TextBlock();
                txQ.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                txQ.HorizontalAlignment = HorizontalAlignment.Left;
                txQ.Margin = new Thickness(10);
                txQ.Text = "Question";
                Grid.SetRow(txQ, 0);
                Grid.SetColumn(txQ, 0);
                underGrid.Children.Add(txQ);

                TextBlock txAns = new TextBlock();
                txAns.TextWrapping = TextWrapping.Wrap;
                txAns.TextAlignment = TextAlignment.Left;
                txAns.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                txAns.HorizontalAlignment = HorizontalAlignment.Left;
                txAns.Margin = new Thickness(10);
                txAns.Text = listQuestions[i];
                Grid.SetRow(txAns, 0);
                Grid.SetColumn(txAns, 1);
                underGrid.Children.Add(txAns);

                TextBlock txH = new TextBlock();
                txH.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                txH.HorizontalAlignment = HorizontalAlignment.Left;
                txH.Margin = new Thickness(10);
                txH.Text = "Réponse";
                Grid.SetRow(txH, 1);
                Grid.SetColumn(txH, 0);
                underGrid.Children.Add(txH);

                TextBlock txHisAns = new TextBlock();
                txHisAns.TextWrapping = TextWrapping.Wrap;
                txHisAns.TextAlignment = TextAlignment.Left;
                txHisAns.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                txHisAns.HorizontalAlignment = HorizontalAlignment.Left;
                txHisAns.Margin = new Thickness(10);
                txHisAns.Text = listHisAnswer[i];
                Grid.SetRow(txHisAns, 1);
                Grid.SetColumn(txHisAns, 1);
                underGrid.Children.Add(txHisAns);

                if(listHisAnswer[i] != listAnswer[i])
                {
                    TextBlock txA = new TextBlock();
                    txA.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                    txA.HorizontalAlignment = HorizontalAlignment.Left;
                    txA.Margin = new Thickness(10);
                    txA.Text = "Correct";
                    Grid.SetRow(txA, 2);
                    Grid.SetColumn(txA, 0);
                    underGrid.Children.Add(txA);

                    TextBlock txAnswer = new TextBlock();
                    txAnswer.TextWrapping = TextWrapping.Wrap;
                    txAnswer.TextAlignment = TextAlignment.Left;
                    txAnswer.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                    txAnswer.HorizontalAlignment = HorizontalAlignment.Left;
                    txAnswer.Margin = new Thickness(10);
                    txAnswer.Text = listAnswer[i];
                    Grid.SetRow(txAnswer, 2);
                    Grid.SetColumn(txAnswer, 1);
                    underGrid.Children.Add(txAnswer);
                }

                #endregion

                resultGrid.Children.Add(underGrid);
                if (listHisAnswer[i] != listAnswer[i])
                {
                    FontIcon iconResult = new FontIcon();//info = &#xE946;
                    iconResult.Glyph = "\uE106";
                    iconResult.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                    Grid.SetRow(iconResult, i);
                    Grid.SetColumn(iconResult, 2);
                    resultGrid.Children.Add(iconResult);
                }
                else
                {
                    FontIcon iconResult = new FontIcon();//info = &#xE946
                    iconResult.Glyph = "\uE001";
                    iconResult.Foreground = new SolidColorBrush(Colors.WhiteSmoke);
                    Grid.SetRow(iconResult, i);
                    Grid.SetColumn(iconResult, 2);
                    resultGrid.Children.Add(iconResult);
                }

                Button infoButton = new Button();
                infoButton.Margin = new Thickness(5);
                infoButton.Click += InfoButton_Click;
                infoButton.Content = new FontIcon
                {
                    FontFamily = new FontFamily("Segoe MDL2 Assets"),
                    Glyph = "\uE946",
                    Foreground = new SolidColorBrush(Colors.WhiteSmoke)
                };

                Grid.SetRow(infoButton, i);
                Grid.SetColumn(infoButton, 3);
                resultGrid.Children.Add(infoButton);

                //adding to list
                infoButton.Tag = i;
                string tmp = infoButton.Tag.ToString() + '|';
                tmp += listQuestions[i] + '|';
                tmp += listHisAnswer[i] + '|';
                tmp += listAnswer[i] + '|';
                listing.Add(tmp);
            }
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string s = "";
            
            foreach(string tmp in listing)
                if (tmp.Contains(button.Tag.ToString()))
                    s = tmp;
            selection = s.Split('|');
            Erreur(selection[1], selection[2], selection[3]);
        }

        private async void Erreur(string question, string hisAnswer, string answer)
        {
            var messageDialog = new MessageDialog("Il y a une erreur?", "Contestation!");
            messageDialog.Content = "La réponse de la question:\n\"" + question + "\" est fausse?\n\n Réponse :\n\"" + answer + "\"\n\n Votre réponse était : \"" + hisAnswer + "\"";
            messageDialog.Commands.Add(new UICommand("Oui", new UICommandInvokedHandler(this.CommandInvokeHandler)));
            messageDialog.Commands.Add(new UICommand("Non"));
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;
            await messageDialog.ShowAsync();
        }

        private void CommandInvokeHandler(IUICommand command)
        {
            Frame.Navigate(typeof(Contact), selection);
        }

        private void inf(List<string> listQuestions, List<string> listAnswer, List<string> listHisAnswer)
        {
            sup(listQuestions, listAnswer, listHisAnswer);
        }

        private void trc(List<string> listQuestions, List<string> listAnswer, List<string> listHisAnswer)
        {
            sup(listQuestions, listAnswer, listHisAnswer);
        }

        private void tt(List<string> listQuestions, List<string> listAnswer, List<string> listHisAnswer)
        {
            sup(listQuestions, listAnswer, listHisAnswer);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e) { Frame.Navigate(typeof(MainPage)); }
        private void Resultats_BackRequested(object sender, BackRequestedEventArgs e) { Frame.Navigate(typeof(MainPage)); }
    }
}
