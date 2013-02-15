using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace MSP_Ski_App1
{
    public class Answer
    {
        #region Fields

        private List<String> listAnswer;

        #endregion Fields

        #region Accessors

        public List<String> ListAnswer
        {
            get { return listAnswer; }
            set { listAnswer = value; }
        }

        #endregion Accessors

        #region Constructors

        public Answer() { this.listAnswer = new List<string>(); }

        public Answer(String ans1, String ans2, String ans3)
        {
            this.listAnswer = new List<string>();
            this.listAnswer.Add(ans1);
            this.listAnswer.Add(ans2);
            this.listAnswer.Add(ans3);
        }

        #endregion Constructors

        #region Methods
        #endregion Methods
    }
}
