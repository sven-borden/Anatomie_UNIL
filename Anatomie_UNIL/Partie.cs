using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anatomie_UNIL
{
    class Partie
    {
        private List<string> listQuestions;
        private List<string> listHisAnswer;
        private List<string> listAnswer;

        public Partie()
        {
            listQuestions = new List<string>();
            listHisAnswer = new List<string>();
            listAnswer = new List<string>();
        }

        public string addListQuestions { set { listQuestions.Add(value); } }
        public string addListHisAnswer { set { listHisAnswer.Add(value); } }
        public string addListAnswer { set { listAnswer.Add(value); } }

        public List<string> getListQuestions { get { return listQuestions; } }
        public List<string> getListHisAnswer { get { return listHisAnswer; } }
        public List<string> getListAnswer { get { return listAnswer; } }
    }
}
