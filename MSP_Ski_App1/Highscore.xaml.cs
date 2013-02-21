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
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;

namespace MSP_Ski_App1
{
    public partial class Highscore : PhoneApplicationPage
    {
        private List<HighscoreElement> scores;
        private IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;

        public Highscore()
        {
            InitializeComponent();

            try
            {
                int length = (int)userSettings["taille"];
                this.scores = new List<HighscoreElement>();
                for(int i=0; i < length; i++)
                    this.scores.Add((HighscoreElement)userSettings["highscore" + i]);

                listeDesScores.ItemsSource = scores.OrderByDescending(e => e.Score).Select(e => new HighscoreElement { Score = e.Score, Image = ObtientImage(e.Score) });
            }
            catch (System.Collections.Generic.KeyNotFoundException)
            {
                MessageBox.Show("No Key");
            }

        }

        private BitmapImage ObtientImage(int priorite)
        {
            if (priorite >= 210)
                return new BitmapImage(new Uri("Ressources/level-7.jpg", UriKind.Relative));
            else if (priorite >= 160)
                return new BitmapImage(new Uri("Ressources/level-6.jpg", UriKind.Relative));
            else if (priorite >= 110)
                return new BitmapImage(new Uri("Ressources/level-5.jpg", UriKind.Relative));
            else if (priorite >= 70)
                return new BitmapImage(new Uri("Ressources/level-4.jpg", UriKind.Relative));
            else if (priorite >= 50)
                return new BitmapImage(new Uri("Ressources/level-3.jpg", UriKind.Relative));
            else if (priorite >= 20)
                return new BitmapImage(new Uri("Ressources/level-2.jpg", UriKind.Relative));
            return new BitmapImage(new Uri("Ressources/level-1.jpg", UriKind.Relative));
        }

        public void Save()
        {
            userSettings["taille"] = this.scores.Count;
            for(int i=0; i < this.scores.Count; i++)
                IsolatedStorageSettings.ApplicationSettings["highscore" + i] = this.scores[i];
        }
    }
}