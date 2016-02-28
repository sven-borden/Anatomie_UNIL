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
    public sealed partial class Tronc : Page
    {
        private DispatcherTimer timer;

        private Brush lightColor;
        private SolidColorBrush green = new SolidColorBrush(Windows.UI.Colors.Green);
        private SolidColorBrush red = new SolidColorBrush(Windows.UI.Colors.Red);

        private int nbJuste = 0;
        private int nbFaux = 0;
        private int nbAnswer = 0;
        private int nbQuestion = 0;

        private const int nbTry = 10;

        private string[] questionAnswer;
        private string reponse;
        string[] propositions;
        private Random random;
        private bool rightAnswer = false;
        private bool alreadyError = false;

        private WriteTo settings;
        private Partie listesPartie;
        private Question question;

        public Tronc()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += Tronc_BackRequested;            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            settings = new WriteTo();
            listesPartie = new Partie("Tronc");
            question = new Question(3);
            questionAnswer = new string[5];
            random = new Random();
            lightColor = buttonQ1.Background;

            progressbar.Maximum = settings.nbQuestionToDo;
            textProgress.Text = "0/" + progressbar.Maximum.ToString();

            timer = new DispatcherTimer();
            timer.Tick += GAMETICK;
            timer.Interval = new TimeSpan(0);
            timer.Start();
        }

        private void GAMETICK(object sender, object e)
        {
            timer.Stop();

            rightAnswer = false;
            alreadyError = false;

            buttonQ1.Background = lightColor;
            buttonQ2.Background = lightColor;
            buttonQ3.Background = lightColor;
            buttonQ4.Background = lightColor;

            questionAnswer = question.getQuestion(listesPartie.getListQuestions);
            listesPartie.addListQuestions = questionAnswer[0];
            listesPartie.addListAnswer = questionAnswer[1];
            textQuestion.Text = questionAnswer[0];
            reponse = questionAnswer[1];
            propositions = new string[4];
            for (int i = 0; i < 4; i++)
                propositions[i] = questionAnswer[i + 1];

            propositions = SetProposition(MixArray(propositions));
        }

        #region ButtonClick
        private void buttonQ1_Click(object sender, RoutedEventArgs e)
        {
            if (propositions[0] == reponse)
            {
                buttonQ1.Background = green;
                rightAnswer = true;
                GoodAnswer(1);
            }
            else
            {
                buttonQ1.Background = red;
                if (rightAnswer == false)
                    BadAnswer(1);
            }
        }

        private void buttonQ2_Click(object sender, RoutedEventArgs e)
        {
            if (propositions[1] == reponse)
            {
                buttonQ2.Background = green;
                rightAnswer = true;
                GoodAnswer(2);
            }
            else
            {
                buttonQ2.Background = red;
                if (rightAnswer == false)
                    BadAnswer(2);
            }
        }

        private void buttonQ3_Click(object sender, RoutedEventArgs e)
        {
            if (propositions[2] == reponse.ToString())
            {
                buttonQ3.Background = green;
                rightAnswer = true;
                GoodAnswer(3);
            }
            else
            {
                buttonQ3.Background = red;
                if (rightAnswer == false)
                    BadAnswer(3);
            }
        }

        private void buttonQ4_Click(object sender, RoutedEventArgs e)
        {

            if (propositions[3] == reponse.ToString())
            {
                buttonQ4.Background = green;
                rightAnswer = true;
                GoodAnswer(4);
            }
            else
            {
                buttonQ4.Background = red;
                if (rightAnswer == false)
                    BadAnswer(4);
            }
        }

        private void GoodAnswer(int buttonNb)
        {
            if (alreadyError == false)
            {
                nbJuste++;
                settings.nbQuestionDone++;
                settings.nbQuestionRight++;
                switch (buttonNb)
                {
                    case 1:
                        listesPartie.addListHisAnswer = buttonQ1.Content.ToString();
                        break;
                    case 2:
                        listesPartie.addListHisAnswer = buttonQ2.Content.ToString();
                        break;
                    case 3:
                        listesPartie.addListHisAnswer = buttonQ3.Content.ToString();
                        break;
                    case 4:
                        listesPartie.addListHisAnswer = buttonQ4.Content.ToString();
                        break;
                }
            }
            Juste.Text = "Corrects :" + nbJuste;
            AttributionNote();

            nbQuestion++;
            progressbar.Value = nbQuestion;
            textProgress.Text = nbQuestion.ToString() + "/" + progressbar.Maximum.ToString();

            if (nbQuestion == settings.nbQuestionToDo)
                Frame.Navigate(typeof(Resultats), listesPartie);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void BadAnswer(int buttonNb)
        {
            if (alreadyError == false)
            {
                nbFaux++;
                alreadyError = true;
                settings.nbQuestionDone++;
                settings.nbQuestionFalse++;
                switch (buttonNb)
                {
                    case 1:
                        listesPartie.addListHisAnswer = buttonQ1.Content.ToString();
                        break;
                    case 2:
                        listesPartie.addListHisAnswer = buttonQ2.Content.ToString();
                        break;
                    case 3:
                        listesPartie.addListHisAnswer = buttonQ3.Content.ToString();
                        break;
                    case 4:
                        listesPartie.addListHisAnswer = buttonQ4.Content.ToString();
                        break;
                }
            }
            Faux.Text = "Fautes : " + nbFaux;
        }

        private void AttributionNote()
        {
            int percent = nbJuste * 100 / (nbJuste + nbFaux);
            if (percent < 30)
            { Note.Text = "Note : 1"; }
            else
            {
                if (percent < 50)
                { Note.Text = "Note : 2"; }
                else
                {
                    if (percent < 72)
                    { Note.Text = "Note : 3"; }
                    else
                    {
                        if (percent < 85)
                        { Note.Text = "Note : 4"; }
                        else
                        {
                            if (percent < 92)
                            { Note.Text = "Note : 5"; }
                            else
                            { Note.Text = "Note : 6"; }
                        }
                    }
                }
            }
        }
        #endregion

        private string[] SetProposition(string[] input)
        {
            buttonQ1.Content = new TextBlock
            {
                Text = input[0],
                Name = "test",
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
            };
            buttonQ2.Content = new TextBlock
            {
                Text = input[1],
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
            };
            buttonQ3.Content = new TextBlock
            {
                Text = input[2],
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
            };
            buttonQ4.Content = new TextBlock
            {
                Text = input[3],
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
            };
            return input;
        }

        private string[] MixArray(string[] input)
        {
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();

            foreach (string s in input)
                list.Add(new KeyValuePair<int, string>(random.Next(), s));

            var sorted = from item in list
                         orderby item.Key
                         select item;

            string[] result = new string[input.Length];
            int index = 0;
            foreach (KeyValuePair<int, string> pair in sorted)
            {
                result[index] = pair.Value;
                index++;
            }

            return result;
        }

        private void Tronc_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
                return;

            if (rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }
    }
}
