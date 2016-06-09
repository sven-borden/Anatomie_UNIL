using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anatomie_UNIL
{
    class WriteTo
    {
        Windows.Storage.ApplicationDataContainer localSettings;
        //Windows.Storage.StorageFolder localFolder;
        Windows.Storage.ApplicationDataCompositeValue compositeResults;
        //Windows.Storage.StorageFile sampleFile;

        private int questionToDo;
        private int totalQuestionDone;
        private int totalQuestionRight;
        private int totalQuestionFalse;
        private bool displayBoolResults;
        private bool? insertionChecked;
        private bool? terminaisonChecked;
        private bool? innervationChecked;
        private bool? mouvementChecked;

        private int viewCount;

        public WriteTo()
        {
            ReadSettings();
        }

        public int nbQuestionToDo
        {
            get { return questionToDo; }
            set { questionToDo = value; WriteSettings(); }
        }
        public int nbQuestionDone
        {
            get { return totalQuestionDone; }
            set { totalQuestionDone = value; WriteSettings(); }
        }
        public int nbQuestionRight
        {
            get { return totalQuestionRight; }
            set { totalQuestionRight = value; WriteSettings(); }
        }
        public int nbQuestionFalse
        {
            get { return totalQuestionFalse; }
            set { totalQuestionFalse = value; WriteSettings(); }
        }
        public bool displayResults
        {
            get { return displayBoolResults; }
            set { displayBoolResults = value; WriteSettings(); }
        }

        public int getViewCount()
        {
            return viewCount;
        }

        public void addViewCount()
        {
            viewCount++;
            WriteSettings();
        }

        public bool? isInsertion
        {
            get { return insertionChecked; }
            set { insertionChecked = value; WriteSettings(); }
        }
        public bool? isTerminaison
        {
            get { return terminaisonChecked; }
            set { terminaisonChecked = value; WriteSettings(); }
        }
        public bool? isInnevervation
        {
            get { return innervationChecked; }
            set { innervationChecked = value; WriteSettings(); }
        }
        public bool? isMouvement
        {
            get { return mouvementChecked; }
            set { mouvementChecked = value; WriteSettings(); }
        }

        public void ResetSettings()
        {
            localSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;
            compositeResults = new Windows.Storage.ApplicationDataCompositeValue();
            compositeResults["QuestionToDo"] = 20;
            compositeResults["totalQuestionDone"] = 0;
            compositeResults["totalQuestionRight"] = 0;
            compositeResults["totalQuestionFalse"] = 0;
            compositeResults["displayResult"] = true;
            compositeResults["isInsertion"] = true;
            compositeResults["isTerminaison"] = true;
            compositeResults["isInnervation"] = false;
            compositeResults["isMouvement"] = false;
            compositeResults["viewCount"] = 1;

            localSettings.Values["Setting"] = compositeResults;
        }

        public void ReadSettings()
        {
            localSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;

            compositeResults = (Windows.Storage.ApplicationDataCompositeValue)localSettings.Values["Setting"];

            if (compositeResults == null)
            {
                //No Data
                compositeResults = new Windows.Storage.ApplicationDataCompositeValue();
                compositeResults["QuestionToDo"] = 20;
                compositeResults["totalQuestionDone"] = 0;
                compositeResults["totalQuestionRight"] = 0;
                compositeResults["totalQuestionFalse"] = 0;
                compositeResults["displayResult"] = true;
                compositeResults["isInsertion"] = true;
                compositeResults["isTerminaison"] = true;
                compositeResults["isInnervation"] = false;
                compositeResults["isMouvement"] = false;
                compositeResults["viewCount"] = 1;

                localSettings.Values["Setting"] = compositeResults;
            }
            else
            {
                questionToDo = Convert.ToInt32(compositeResults["QuestionToDo"]);
                totalQuestionDone = Convert.ToInt32(compositeResults["totalQuestionDone"]);
                totalQuestionRight = Convert.ToInt32(compositeResults["totalQuestionRight"]);
                totalQuestionFalse = Convert.ToInt32(compositeResults["totalQuestionFalse"]);
                displayBoolResults = Convert.ToBoolean(compositeResults["displayResult"]);
                insertionChecked = Convert.ToBoolean(compositeResults["isInsertion"]);
                terminaisonChecked = Convert.ToBoolean(compositeResults["isTerminaison"]);
                innervationChecked = Convert.ToBoolean(compositeResults["isInnervation"]);
                mouvementChecked = Convert.ToBoolean(compositeResults["isMouvement"]);
                viewCount = Convert.ToInt32(compositeResults["viewCount"]);
            }
        }

        public void  WriteSettings()
        {
            localSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;

            compositeResults = (Windows.Storage.ApplicationDataCompositeValue)localSettings.Values["Setting"];
            compositeResults["QuestionToDo"] = questionToDo;
            compositeResults["totalQuestionDone"] = totalQuestionDone;
            compositeResults["totalQuestionRight"] = totalQuestionRight;
            compositeResults["totalQuestionFalse"] = totalQuestionFalse;
            compositeResults["displayResult"] = displayBoolResults;
            compositeResults["isInsertion"] = insertionChecked;
            compositeResults["isTerminaison"] = terminaisonChecked;
            compositeResults["isInnervation"] = innervationChecked;
            compositeResults["isMouvement"] = mouvementChecked;
            compositeResults["viewCount"] = viewCount;
            localSettings.Values["Results"] = compositeResults;
        }
    }
}
