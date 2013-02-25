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
using System.Windows.Threading;

namespace MSP_Ski_App1
{
    public partial class Quizz : PhoneApplicationPage
    {
        #region Fields

        private List<Answer> listAnswers;
        private List<String> listQuestion;
        private int counter, combo;
        private int current;
        private int timer;
        private DispatcherTimer Dtimer;

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
            this.Dtimer = new DispatcherTimer();
            this.timer = 48;
            this.counter = 0;
            this.combo = 0;
            this.listAnswers = this.InitializeListAnswer();
            this.listQuestion = this.InitializeListQuestion();
            this.Initialize();
            this.LoadTimer();
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
            _listQs.Add(new Answer("Slalom géant", "Slalom", "Slalom super géant", 1, "Ressources/11.png"));
            _listQs.Add(new Answer("Slalom géant", "Slalom", "Slalom super géant", 0, "Ressources/11.png"));
            _listQs.Add(new Answer("Slalom géant", "Slalom", "Slalom super géant", 2, "Ressources/11.png"));
            _listQs.Add(new Answer("Slalom géant", "Slalom", "Slalom super géant", 1, "Ressources/11.png"));
            _listQs.Add(new Answer("Slalom géant", "Slalom", "Slalom super géant", 1, "Ressources/11.png"));
            _listQs.Add(new Answer("Les bosses en parallèle", "Les bosses", "Le saut", 0, "Ressources/12.jpg"));
            _listQs.Add(new Answer("1992", "2004", "2010", 2, "Ressources/12.png"));
            return _listQs;
        }

        public List<String> InitializeListQuestion()
        {
            List<String> _listQs = new List<String>();
            _listQs.Add("Quel est cette discipline ?");
            _listQs.Add("Quel est cette discipline ?");
            _listQs.Add("Quel est cette discipline ?");
            _listQs.Add("Quel est cette discipline ?");
            _listQs.Add("Quel est cette discipline ?");
            _listQs.Add("Quel est cette discipline ?");
            _listQs.Add("Quel est cette discipline ?");
            _listQs.Add("Quel est cette discipline ?");
            _listQs.Add("Quel est cette discipline ?");
            _listQs.Add("Quel est cette discipline ?");
            _listQs.Add("En quelle année le ski alpin est-il entré aux Jeux Olympiques d'hiver ?");
            _listQs.Add("Dans quelle épreuve les skieurs doivent-ils contourner des poteaux disposés très près les uns des autres ?");
            _listQs.Add("Dans quelle épreuve les poteaux sont-ils moyennement rapprochés les uns des autres ?");
            _listQs.Add("Dans quelle épreuve les poteaux sont-ils très éloignés les uns des autres ?");
            _listQs.Add("Dans quelle épreuve les skieurs ont-ils la possibilité de faire basculer les poteaux ?");
            _listQs.Add("Dans quelle épreuve les portes sont-elles formées de seulement un poteau ?");
            _listQs.Add("Parmi ces disciplines du ski acrobatique, pour laquelle n'y a-t-il pas de compétitions aux Jeux olympiques d'hiver ?");
            _listQs.Add("Depuis quand le ski cross est-il présenté aux Jeux olympiques d'hiver ?");
            _listQs.Add("");
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

            this.ListQuestion.RemoveAt(this.current);
            this.ListAnswers.RemoveAt(this.current);

            if (this.listAnswers.Count == 0)
            {
                this.OnFinish();
            }
            else
            {
                this.Initialize();
            }
        }

        void OnTimerTick(Object sender, EventArgs args)
        {
            Timer.Text = Convert.ToString(this.timer);
            this.timer--;
            if (this.timer == 0)
            {
                this.OnFinish();
            }
        }

        private void LoadTimer()
        {
            Dtimer.Interval = TimeSpan.FromSeconds(1);
            Dtimer.Tick += OnTimerTick;
            Dtimer.Start();
        }

        private void OnFinish()
        {
            int length = 0;
            this.counter += this.combo * 5;
            try
            {
                length = (int)DataManager.userSettings["taille"];
                length++;
                DataManager.userSettings["taille"] = length;
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                length = 1;
                DataManager.userSettings.Add("taille", length);
            }
            DataManager.userSettings.Add("highscore" + length, this.counter);
            MessageBox.Show(Convert.ToString("counter : " + this.counter + "timer : " + this.timer));
            Dtimer.Stop();
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        #endregion Methods

    }
}