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
    public partial class DatabaseNameCreator : UserControl
    {
        #region Propeties
        public myActionDelegate registerExitCreation
        {
            get; set;
        }

        public myActionDelegateWithDatabaseName registerNextStepCreation
        {
            get; set;
        }
        #endregion


        //Delegates
        public delegate void myActionDelegate();
        public delegate void myActionDelegateWithDatabaseName(string databaseName);


        public DatabaseNameCreator(myActionDelegate exit, myActionDelegateWithDatabaseName nextStep, string startingName = "")
        {
            InitializeComponent();
            registerExitCreation = exit;
            registerNextStepCreation = nextStep;
            textBoxDatabaseName.Text = startingName;
        }

        private void DatabaseNameCreator_Load(object sender, EventArgs e)
        {

        }

        private void buttonStopCreation_Click(object sender, EventArgs e)
        {
            registerExitCreation();
        }

        private void buttonNextStep_Click(object sender, EventArgs e)
        {
            registerNextStepCreation(textBoxDatabaseName.Text);
        }
    }
}
