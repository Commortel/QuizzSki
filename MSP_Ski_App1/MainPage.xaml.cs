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
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructeur
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnOrientationChanged(OrientationChangedEventArgs e)
        {
            OrientationTextBlock.Text = "On passe en mode " + e.Orientation;
            base.OnOrientationChanged(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //resultat.Text = "Bonjour " + nom.Text;
        }
    }
}