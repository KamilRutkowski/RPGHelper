using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGHelper
{
    public partial class MainMenuControl : UserControl
    {
        #region Properties

        public myActionDelegate registerStartNewSession
        {
            get; set;
        }

        public myActionDelegate registerLoadSession
        {
            get; set;
        }

        public myActionDelegate registerExit
        {
            get; set;
        }

        #endregion

        public delegate void myActionDelegate();

        public MainMenuControl(myActionDelegate start, myActionDelegate load, myActionDelegate exit)
        {
            InitializeComponent();
            registerStartNewSession = start;
            registerLoadSession = load;
            registerExit = exit;
        }

        private void MainMenuControl_Load(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            registerExit();
        }

        private void ButtonStartNewSession_Click(object sender, EventArgs e)
        {
            registerStartNewSession();
        }
    }
}
