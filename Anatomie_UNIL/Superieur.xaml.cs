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

namespace Anatomie_UNIL
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Superieur : Page
    {
        private DispatcherTimer timer;

        private Brush lightColor;
        private SolidColorBrush green   = new SolidColorBrush(Windows.UI.Colors.Green);
        private SolidColorBrush red     = new SolidColorBrush(Windows.UI.Colors.Red);
        
        private int nbJuste     = 0;
        private int nbFaux      = 0;
        private int nbAnswer    = 0;
        private int nbQuestion  = 0;

        private const int nbTry = 10;

        private string[] fourAnswer;
        private string reponse;
        private Random random;
        private bool rightAnswer    = false;
        private bool alreadyError   = false;

        private WriteTo settings;
        private Partie listesPartie;

        public Superieur()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += Superieur_BackRequested;
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
            rightAnswer     = false;
            alreadyError    = false;

            buttonQ1.Background = lightColor;
            buttonQ2.Background = lightColor;
            buttonQ3.Background = lightColor;
            buttonQ4.Background = lightColor;

            random = new Random();
            for(int Try = 0; Try < nbTry; Try++)
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
            //epauleAnterieur, epaulePosterieur, bras, anantvrasAnterieur, avantBrasPosterieur, main
            random = new Random(((int)DateTime.Now.Ticks & 0x0000FFFF));
            int val = GenRand(1, 6, random);

            switch(val)
            {
                case 1: GenEpauleAnt(questionType);
                    break;
                case 2: GenEpaulePost(questionType);
                    break;
                case 3: GenBras(questionType);
                    break;
                case 4: GenAvantBrasAnt(questionType);
                    break;
                case 5: GenAvantBrasPost(questionType);
                    break;
                case 6: GenMain(questionType);
                    break;
            }
        }

        #region GenHaut
        private void GenEpauleAnt(int questionType)
        {
            int length = 5;
            random = new Random(((int)DateTime.Now.Ticks & 0x0000FFFF));
            nbAnswer = GenRand(0, length - 1, random);//numéro de réponse
            SetTypeOfQuestion(questionType, MainPage.epauleAnterieur[nbAnswer, 0]);

            reponse = MainPage.epauleAnterieur[nbAnswer, questionType];
            //preparation des réponses
            fourAnswer = new string[4];
            fourAnswer[0] = reponse;
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[1] = MainPage.epauleAnterieur[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[1] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[2] = MainPage.epauleAnterieur[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[2] != fourAnswer[1] && fourAnswer[2] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[3] = MainPage.epauleAnterieur[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[3] != fourAnswer[2] && fourAnswer[3] != fourAnswer[1] && fourAnswer[3] != fourAnswer[0])
                    break;
            }
            fourAnswer = MixArray(fourAnswer);
            SetQuestion(fourAnswer[0], fourAnswer[1], fourAnswer[2], fourAnswer[3]);
        }

        private void GenEpaulePost(int questionType)
        {
            int length = 11;
            random = new Random(((int)DateTime.Now.Ticks & 0x0000FFFF));
            nbAnswer = GenRand(0, length - 1, random);//numéro de réponse
            SetTypeOfQuestion(questionType, MainPage.epaulePosterieur[nbAnswer, 0]);

            reponse = MainPage.epaulePosterieur[nbAnswer, questionType];

            //preparation des réponses
            fourAnswer = new string[4];
            fourAnswer[0] = reponse;
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[1] = MainPage.epaulePosterieur[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[1] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[2] = MainPage.epaulePosterieur[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[2] != fourAnswer[1] && fourAnswer[2] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[3] = MainPage.epaulePosterieur[GenRand(0, 4, random), questionType];
                if (fourAnswer[3] != fourAnswer[2] && fourAnswer[3] != fourAnswer[1] && fourAnswer[3] != fourAnswer[0])
                    break;
            }
            fourAnswer = MixArray(fourAnswer);
            SetQuestion(fourAnswer[0], fourAnswer[1], fourAnswer[2], fourAnswer[3]);
        }

        private void GenBras(int questionType)
        {
            int length = 8;
            random = new Random(((int)DateTime.Now.Ticks & 0x0000FFFF));
            nbAnswer = GenRand(0, length - 1, random);//numéro de réponse
            SetTypeOfQuestion(questionType, MainPage.bras[nbAnswer, 0]);

            reponse = MainPage.bras[nbAnswer, questionType];

            //preparation des réponses
            fourAnswer = new string[4];
            fourAnswer[0] = reponse;
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[1] = MainPage.bras[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[1] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[2] = MainPage.bras[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[2] != fourAnswer[1] && fourAnswer[2] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[3] = MainPage.bras[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[3] != fourAnswer[2] && fourAnswer[3] != fourAnswer[1] && fourAnswer[3] != fourAnswer[0])
                    break;
            }
            fourAnswer = MixArray(fourAnswer);
            SetQuestion(fourAnswer[0], fourAnswer[1], fourAnswer[2], fourAnswer[3]);
        }

        private void GenAvantBrasAnt(int questionType)
        {
            int length = 8;
            random = new Random(((int)DateTime.Now.Ticks & 0x0000FFFF));
            nbAnswer = GenRand(0, length - 1, random);//numéro de réponse
            SetTypeOfQuestion(questionType, MainPage.avantBrasAntérieur[nbAnswer, 0]);

            reponse = MainPage.avantBrasAntérieur[nbAnswer, questionType];

            //preparation des réponses
            fourAnswer = new string[4];
            fourAnswer[0] = reponse;
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[1] = MainPage.avantBrasAntérieur[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[1] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[2] = MainPage.avantBrasAntérieur[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[2] != fourAnswer[1] && fourAnswer[2] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[3] = MainPage.avantBrasAntérieur[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[3] != fourAnswer[2] && fourAnswer[3] != fourAnswer[1] && fourAnswer[3] != fourAnswer[0])
                    break;
            }
            fourAnswer = MixArray(fourAnswer);
            SetQuestion(fourAnswer[0], fourAnswer[1], fourAnswer[2], fourAnswer[3]);
        }

        private void GenAvantBrasPost(int questionType)
        {
            int length = 11;
            random = new Random(((int)DateTime.Now.Ticks & 0x0000FFFF));
            nbAnswer = GenRand(0, length - 1, random);//numéro de réponse
            SetTypeOfQuestion(questionType, MainPage.avantBrasPostérieur[nbAnswer, 0]);

            reponse = MainPage.avantBrasPostérieur[nbAnswer, questionType];

            //preparation des réponses
            fourAnswer = new string[4];
            fourAnswer[0] = reponse;
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[1] = MainPage.avantBrasPostérieur[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[1] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[2] = MainPage.avantBrasPostérieur[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[2] != fourAnswer[1] && fourAnswer[2] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[3] = MainPage.avantBrasPostérieur[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[3] != fourAnswer[2] && fourAnswer[3] != fourAnswer[1] && fourAnswer[3] != fourAnswer[0])
                    break;
            }
            fourAnswer = MixArray(fourAnswer);
            SetQuestion(fourAnswer[0], fourAnswer[1], fourAnswer[2], fourAnswer[3]);
        }

        private void GenMain(int questionType)
        {
            int length = 13;
            random = new Random(((int)DateTime.Now.Ticks & 0x0000FFFF));
            nbAnswer = GenRand(0, length - 1, random);//numéro de réponse
            SetTypeOfQuestion(questionType, MainPage.main[nbAnswer, 0]);

            reponse = MainPage.main[nbAnswer, questionType];

            //preparation des réponses
            fourAnswer = new string[4];
            fourAnswer[0] = reponse;
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[1] = MainPage.main[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[1] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[2] = MainPage.main[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[2] != fourAnswer[1] && fourAnswer[2] != fourAnswer[0])
                    break;
            }
            for (int i = 0; i < nbTry; i++)
            {
                fourAnswer[3] = MainPage.main[GenRand(0, length - 1, random), questionType];
                if (fourAnswer[3] != fourAnswer[2] && fourAnswer[3] != fourAnswer[1] && fourAnswer[3] != fourAnswer[0])
                    break;
            }
            fourAnswer = MixArray(fourAnswer);
            SetQuestion(fourAnswer[0], fourAnswer[1], fourAnswer[2], fourAnswer[3]);
        }
        #endregion GenHaut

        #region ButtonClick
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
            if(alreadyError == false)
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
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void BadAnswer(int buttonNb)
        {
            if(alreadyError == false)
            {
                nbFaux++;
                alreadyError = true;
                settings.nbQuestionDone++;
                settings.nbQuestionFalse++;
                switch(buttonNb)
                {
                    case 1: listesPartie.addListHisAnswer = buttonQ1.Content.ToString();
                        break;
                    case 2: listesPartie.addListHisAnswer = buttonQ2.Content.ToString();
                        break;
                    case 3: listesPartie.addListHisAnswer = buttonQ3.Content.ToString();
                        break;
                    case 4: listesPartie.addListHisAnswer = buttonQ4.Content.ToString();
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
                TextAlignment = TextAlignment.Center,
            };
            buttonQ2.Content = new TextBlock
            {
                Text = q2,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
            };
            buttonQ3.Content = new TextBlock
            {
                Text = q3,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
            };
            buttonQ4.Content = new TextBlock
            {
                Text = q4,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
            };
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

        private int GenRand(int low, int high, Random random) { return random.Next(low, high + 1); }//borne inf et sup en param

        private string[] MixArray(string[] input)
        {
            Random rand = new Random();
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            
            foreach(string s in input)
                list.Add(new KeyValuePair<int, string>(rand.Next(), s));

            var sorted = from item in list
                         orderby item.Key
                         select item;

            string[] result = new string[input.Length];
            int index = 0;
            foreach(KeyValuePair<int, string> pair in sorted)
            {
                result[index] = pair.Value;
                index++;
            }

            return result;
        }

        private void Superieur_BackRequested(object sender, BackRequestedEventArgs e)
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
