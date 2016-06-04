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

        /// <summary>
        /// Register a callback delegate for starting new session
        /// </summary>
        private myActionDelegate registerStartNewSession
        {
            get; set;
        }

        /// <summary>
        /// Register a callback delegate for loading existing session
        /// </summary>
        private myActionDelegate registerLoadSession
        {
            get; set;
        }

        /// <summary>
        /// Register a callback for exiting program
        /// </summary>
        private myActionDelegate registerExit
        {
            get; set;
        }

        #endregion

        public delegate void myActionDelegate();

        /// <summary>
        /// Main menu control for a first layer of controling program.
        /// </summary>
        /// <param name="start">Delegate for starting new session</param>
        /// <param name="load">Delegate for loading existing session</param>
        /// <param name="exit">Delegate for exiting program</param>
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
