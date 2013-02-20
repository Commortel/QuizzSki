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
        private int counter, combo;
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
            this.combo = 0;
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
            return new Random().Next(0, this.listQuestion.Count-1);
        }

        public List<Answer> InitializeListAnswer()
        {
            List<Answer> _listQs = new List<Answer>();
            _listQs.Add(new Answer("Ski Alpin", "Ski freestyle", "Snowboard", 0,"Ressources/1.jpg"));
            _listQs.Add(new Answer("Ski Alpin", "Saut à Ski", "Ski télémark", 1, "Ressources/2.jpg"));
            _listQs.Add(new Answer("Ski sur herbe", "Ski télémark", "Ski alpin", 0, "Ressources/3.jpg"));
            _listQs.Add(new Answer("Ski de fond", "Ski acrobatique", "Biathlon", 0, "Ressources/4.jpg"));
            _listQs.Add(new Answer("Ski freestyle", "Saut à Ski", "Biathlon", 0, "Ressources/5.jpg"));
            _listQs.Add(new Answer("Ski de vitesse", "Ski acrobatique", "Snowboard", 2, "Ressources/6.jpg"));
            _listQs.Add(new Answer("Ski acrobatique", "Ski freestyle", "Ski télémark", 2, "Ressources/7.jpg"));
            _listQs.Add(new Answer("Ski de fond", "Ski de vitesse", "Ski alpin", 1, "Ressources/8.jpg"));
            _listQs.Add(new Answer("Biathlon", "Ski alpin", "Ski de fond", 0, "Ressources/9.jpg"));
            _listQs.Add(new Answer("Ski freestyle", "Ski télémark", "Ski acrobatique",2,"Ressources/10.jpg"));
            _listQs.Add(new Answer("1924","1930","1936",2,"Ressources/11.jpg"));
            return _listQs;
        }

        public List<String> InitializeListQuestion()
        {
            List<String> _listQs = new List<String>();
            _listQs.Add("Quel est cette discipline");
            _listQs.Add("Quel est cette discipline");
            _listQs.Add("Quel est cette discipline");
            _listQs.Add("Quel est cette discipline");
            _listQs.Add("Quel est cette discipline");
            _listQs.Add("Quel est cette discipline");
            _listQs.Add("Quel est cette discipline");
            _listQs.Add("Quel est cette discipline");
            _listQs.Add("Quel est cette discipline");
            _listQs.Add("Quel est cette discipline");
            _listQs.Add("En quelle année le ski alpin est-il entré aux Jeux Olympiques d'hiver ?");
            return _listQs;
        }

        private void Answer_Clicked(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content.Equals(this.listAnswers[this.current].ListAnswer[this.listAnswers[this.current].NbTrue]))
            {
                this.counter+=2;
                this.combo++;
            }
            else
            {
                this.combo = 0;
            }

            this.ListQuestion.RemoveAt(current);
            this.ListAnswers.RemoveAt(current);

            if (this.listAnswers.Count == 0)
            {
                this.counter += this.combo * 5;
                MessageBox.Show(Convert.ToString(counter));
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            else
            {
                this.Initialize();
            }
        }

        #endregion Methods

    }
}