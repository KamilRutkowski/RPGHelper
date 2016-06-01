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
    public partial class DatabaseTablesCreator : UserControl
    {
        #region Properties

        public myDelegate registerExit
        {
            get; set;
        }

        public myDelegate registerPreviousStep
        {
            get; set;
        }

        public myDelegateWithTables registerNextStep
        {
            get; set;
        }
        #endregion

        public delegate void myDelegate();
        public delegate void myDelegateWithTables(List<Table> tables);

        private List<Table> tablesToCreate;

        public DatabaseTablesCreator(myDelegate exit, myDelegate previousStep, myDelegateWithTables nextStep)
        {
            InitializeComponent();
            registerExit = exit;
            registerPreviousStep = previousStep;
            registerNextStep = nextStep;
        }

        public DatabaseTablesCreator(myDelegate exit, myDelegate previousStep, myDelegateWithTables nextStep, List<Table> tables)
        {
            InitializeComponent();
            registerExit = exit;
            registerPreviousStep = previousStep;
            registerNextStep = nextStep;
            tablesToCreate = tables;
            showCreatedTables();
        }

        //This method will draw the current table
        private void showCreatedTables()
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void buttonReturnToNameCreation_Click(object sender, EventArgs e)
        {
            registerPreviousStep();
        }

        private void buttonStopCreation_Click(object sender, EventArgs e)
        {
            registerExit();
        }

        private void buttonNextStep_Click(object sender, EventArgs e)
        {
            registerNextStep(tablesToCreate);
        }
    }
}
