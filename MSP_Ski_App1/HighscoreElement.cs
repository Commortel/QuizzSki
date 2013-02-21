﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace MSP_Ski_App1
{
    public class HighscoreElement
    {
        public int Score { get; set; }
        public BitmapImage Image { get; set; }

        public HighscoreElement(int score)
        {
            this.Score = score;
        }

        public HighscoreElement(int score, BitmapImage image)
        {
            this.Score = score;
            this.Image = image;
        }
    }
}
