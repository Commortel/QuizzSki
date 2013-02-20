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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace MSP_Ski_App1
{
    public partial class Quizz : PhoneApplicationPage
    {
        #region Fields

        private List<Answer> listAnswers;
        private List<String> listQuestion;
        private int counter;
        private int current;

        #endregion Fields

        #region Accessors

        public List<Answer> ListAnswers
        {
            get { return listAnswers; }
            set { listAnswers = value; }
        }

        public List<String> ListQuestion
        {
            get { return listQuestion; }
            set { listQuestion = value; }
        }

        #endregion Accessors

        #region Constructors

        public Quizz()
        {
            InitializeComponent();
            this.counter = 0;
            this.listAnswers = this.InitializeListAnswer();
            this.listQuestion = this.InitializeListQuestion();
            this.Initialize();
        }

        #endregion Constructors

        #region Methods

        private void Initialize()
        {
            this.current = this.RandomValue();
            Question.Text = this.listQuestion[this.current];
            Answer1.Content = this.listAnswers[this.current].ListAnswer[0];
            Answer2.Content = this.listAnswers[this.current].ListAnswer[1];
            Answer3.Content = this.listAnswers[this.current].ListAnswer[2];
            QuestionImage.Source = new BitmapImage(new Uri(this.listAnswers[this.current].Path, UriKind.Relative));
        }

        public int RandomValue()
        {
            return new Random().Next(0, this.listQuestion.Count);
        }

        public List<Answer> InitializeListAnswer()
        {
            List<Answer> _listQs = new List<Answer>();
            _listQs.Add(new Answer("Ski Alpin", "Ski freestyle", "Snowboard", 1,"Ressources/1.jpg"));
            _listQs.Add(new Answer("Slalom géant", "Slalom", "Slalom super géant",2,"Ressources/2.jpg"));
            return _listQs;
        }

        public List<String> InitializeListQuestion()
        {
            List<String> _listQs = new List<String>();
            _listQs.Add("Quel est cette discipline");
            _listQs.Add("Dans quelle épreuve les skieurs doivent-ils contourner des poteaux disposés très près les uns des autres?");
            return _listQs;
        }

        private void Answer_Clicked(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content.Equals(this.listAnswers[this.current].ListAnswer[this.current]))
                this.counter++;
            this.ListQuestion.RemoveAt(current);
            this.ListAnswers.RemoveAt(current);
            this.Initialize();
        }

        #endregion Methods

    }
}