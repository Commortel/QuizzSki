using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace MSP_Ski_App1
{
    public partial class Quizz : PhoneApplicationPage
    {
        #region Fields

        private Dictionary<String, Answer> listQs;

        #endregion Fields

        #region Accessors

        public Dictionary<String, Answer> ListQs
        {
            get { return listQs; }
            set { listQs = value; }
        }

        #endregion Accessors

        #region Constructors

        public Quizz()
        {
            InitializeComponent();
            this.listQs = this.InitializeList();
            Question.Text = this.RandomQuestion();
            Answer1.Content = this.listQs[Question.Text].ListAnswer[0];
            Answer2.Content = this.listQs[Question.Text].ListAnswer[1];
            Answer3.Content = this.listQs[Question.Text].ListAnswer[2];
        }

        #endregion Constructors

        #region Methods

        public String RandomQuestion()
        {
            int i = 0;
            foreach (String Question in this.listQs.Keys)
            {
                if (new Random().Next(0,this.listQs.Count - 1) == i) return Question;
                i++;
            }
            return null;
        }

        public Dictionary<string, Answer> InitializeList()
        {
            Dictionary<string, Answer> _listQs = new Dictionary<string, Answer>();
            _listQs.Add("Quel est le sport de descente le plus pratiqué ?", new Answer("La descente sur pied", "La descente sur ski", "La descente sur roulette"));
            _listQs.Add("Loser", new Answer("Alain", "Bichon", "Jean-Paul"));
            _listQs.Add("Middle", new Answer("MyGame", "KindOF", "Hello"));
            return _listQs;
        }

        #endregion Methods

    }
}