using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.IO.IsolatedStorage;
using System.Windows.Shapes;

namespace MSP_Ski_App1
{
    public static class DataManager
    {
        public static IsolatedStorageSettings userSettings = IsolatedStorageSettings.ApplicationSettings;
    }
}
