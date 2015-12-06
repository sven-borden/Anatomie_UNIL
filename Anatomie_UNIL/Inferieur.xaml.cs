using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace Anatomie_UNIL
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Inferieur : Page
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

        private string[] fourAnswer;
        private string reponse;
        private Random random;
        private bool rightAnswer = false;
        private bool alreadyError = false;

        private WriteTo settings;
        private Partie listesPartie;

        public Inferieur()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += Inferieur_BackRequested;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            settings = new WriteTo();
            listesPartie = new Partie();

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
            int questionType = 0;
            rightAnswer = false;
            alreadyError = false;

            buttonQ1.Background = lightColor;
            buttonQ2.Background = lightColor;
            buttonQ3.Background = lightColor;
            buttonQ4.Background = lightColor;

            random = new Random();
            for (int Try = 0; Try < nbTry; Try++)
            {
                questionType = GenRand(1, 3, random);

                if (questionType == 1 && settings.isInsertion == true)
                    Try = nbTry;
                if (questionType == 2 && settings.isTerminaison == true)
                    Try = nbTry;
                if (questionType == 3 && settings.isInnevervation == true)
                    Try = nbTry;
                if (questionType == 4 && settings.isMouvement == true)
                    Try = nbTry;
            }

            GenQuestion(questionType);
        }

        private void GenQuestion(int questionType)
        {
            //to use epauleAnterieur, epaulePosterieur, bras, avantbrasAnterieur, avantBrasPosterieur, main
            random = new Random(((int)DateTime.Now.Ticks & 0x0000FFFF));
            int val = GenRand(1, 4, random);

            switch (val)
            {
                case 1:
                    GenHanche(questionType);
                    break;
                case 2:
                    GenCuisse(questionType);
                    break;
                case 3:
                    GenJambe(questionType);
                    break;
                case 4:
                    GenPied(questionType);
                    break;
            }
        }
        #region GenBas
        private void GenHanche(int questionType)
        {
            int length = 13;
            random = new Random(((int)DateTime.Now.Ticks & 0x0000FFFF));
            nbAnswer = GenRand(0, length - 1, random);//numéro de réponse
            SetTypeOfQuestion(questionType, MainPage.hanche[nbAnswer, 0]);

            reponse = MainPage.hanche[nbAnswer, questionType];
            //preparation des réponses
            fourAnswer = new string[4];
            fourAnswer[0] = reponse;
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[1] = MainPage.hanche[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[1] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[2] = MainPage.hanche[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[2] != fourAnswer[1] && fourAnswer[2] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[3] = MainPage.hanche[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[3] != fourAnswer[2] && fourAnswer[3] != fourAnswer[1] && fourAnswer[3] != fourAnswer[0])
                    break;
            }
            fourAnswer = MixArray(fourAnswer);
            SetQuestion(fourAnswer[0], fourAnswer[1], fourAnswer[2], fourAnswer[3]);
        }

        private void GenJambe(int questionType)
        {
            int length = 14;
            random = new Random(((int)DateTime.Now.Ticks & 0x0000FFFF));
            nbAnswer = GenRand(0, length - 1, random);//numéro de réponse
            SetTypeOfQuestion(questionType, MainPage.jambe[nbAnswer, 0]);

            reponse = MainPage.jambe[nbAnswer, questionType];
            //preparation des réponses
            fourAnswer = new string[4];
            fourAnswer[0] = reponse;
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[1] = MainPage.jambe[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[1] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[2] = MainPage.jambe[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[2] != fourAnswer[1] && fourAnswer[2] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[3] = MainPage.jambe[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[3] != fourAnswer[2] && fourAnswer[3] != fourAnswer[1] && fourAnswer[3] != fourAnswer[0])
                    break;
            }
            fourAnswer = MixArray(fourAnswer);
            SetQuestion(fourAnswer[0], fourAnswer[1], fourAnswer[2], fourAnswer[3]);
        }

        private void GenCuisse(int questionType)
        {
            int length = 16;
            random = new Random(((int)DateTime.Now.Ticks & 0x0000FFFF));
            nbAnswer = GenRand(0, length - 1, random);//numéro de réponse
            SetTypeOfQuestion(questionType, MainPage.cuisse[nbAnswer, 0]);

            reponse = MainPage.cuisse[nbAnswer, questionType];
            //preparation des réponses
            fourAnswer = new string[4];
            fourAnswer[0] = reponse;
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[1] = MainPage.cuisse[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[1] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[2] = MainPage.cuisse[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[2] != fourAnswer[1] && fourAnswer[2] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[3] = MainPage.cuisse[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[3] != fourAnswer[2] && fourAnswer[3] != fourAnswer[1] && fourAnswer[3] != fourAnswer[0])
                    break;
            }
            fourAnswer = MixArray(fourAnswer);
            SetQuestion(fourAnswer[0], fourAnswer[1], fourAnswer[2], fourAnswer[3]);
        }

        private void GenPied(int questionType)
        {
            int length = 14;
            random = new Random(((int)DateTime.Now.Ticks & 0x0000FFFF));
            nbAnswer = GenRand(0, length - 1, random);//numéro de réponse
            SetTypeOfQuestion(questionType, MainPage.pied[nbAnswer, 0]);

            reponse = MainPage.pied[nbAnswer, questionType];
            //preparation des réponses
            fourAnswer = new string[4];
            fourAnswer[0] = reponse;
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[1] = MainPage.pied[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[1] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[2] = MainPage.pied[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[2] != fourAnswer[1] && fourAnswer[2] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[3] = MainPage.pied[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[3] != fourAnswer[2] && fourAnswer[3] != fourAnswer[1] && fourAnswer[3] != fourAnswer[0])
                    break;
            }
            fourAnswer = MixArray(fourAnswer);
            SetQuestion(fourAnswer[0], fourAnswer[1], fourAnswer[2], fourAnswer[3]);
        }
        #endregion GenBas

        #region buttonClick
        private void buttonQ1_Click(object sender, RoutedEventArgs e)
        {
            if (fourAnswer[0] == reponse)
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
            if (fourAnswer[1] == reponse)
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
            if (fourAnswer[2] == reponse.ToString())
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

            if (fourAnswer[3] == reponse.ToString())
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
                Frame.Navigate(typeof(Resultats));//, listespartie));
            timer.Interval = new TimeSpan(0,0,1);
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

        private void SetQuestion(string q1, string q2, string q3, string q4)
        {
            buttonQ1.Content = new TextBlock
            {
                Text = q1,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center
            };
            buttonQ2.Content = new TextBlock
            {
                Text = q2,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center
            };
            buttonQ3.Content = new TextBlock
            {
                Text = q3,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center
            };
            buttonQ4.Content = new TextBlock
            {
                Text = q4,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center
            };
        }

        private int GenRand(int low, int high, Random random)//Borne inférieur, et borne supérieure
        {
            return random.Next(low, high + 1);
        }

        private void SetTypeOfQuestion(int type, string muscle)
        {
            if (type == 1)//origine
                listesPartie.addListQuestions = "Quelle est l'origine du " + muscle + "?";
            if (type == 2)//Insertion
                listesPartie.addListQuestions = "Quelle est la terminaison du " + muscle + "?";
            if (type == 3)//innervation
                listesPartie.addListQuestions = "Quelle est l'innervation du " + muscle + "?";

            int last = listesPartie.getListQuestions.Count;
            textQuestion.Text = listesPartie.getListQuestions[last - 1];
        }

        private string[] MixArray(string[] input)
        {
            Random random = new Random();
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            // Add all strings from array
            // Add new random int each time
            foreach (string s in input)
            {
                list.Add(new KeyValuePair<int, string>(random.Next(), s));
            }
            // Sort the list by the random number
            var sorted = from item in list
                         orderby item.Key
                         select item;
            // Allocate new string array
            string[] result = new string[input.Length];
            // Copy values to array
            int index = 0;
            foreach (KeyValuePair<int, string> pair in sorted)
            {
                result[index] = pair.Value;
                index++;
            }
            // Return copied array
            return result;

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
