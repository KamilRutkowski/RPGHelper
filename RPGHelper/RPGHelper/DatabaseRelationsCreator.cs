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
    public partial class DatabaseRelationsCreator : UserControl
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

        public myDelegateCreateDatabase registerCreateDatabase
        {
            get; set;
        }

        #endregion

        public delegate void myDelegate();
        public delegate void myDelegateCreateDatabase(List<Table> tables);
        List<Table> tablesToCreate;

        public DatabaseRelationsCreator(myDelegate exit, myDelegate previousStep, myDelegateCreateDatabase createDatabase, List<Table> tables)
        {
            InitializeComponent();
            registerExit = exit;
            registerPreviousStep = previousStep;
            registerCreateDatabase = createDatabase;
            tablesToCreate = tables;
        }

        private void buttonReturnToNameCreation_Click(object sender, EventArgs e)
        {
            registerPreviousStep();
        }

        private void buttonStopCreation_Click(object sender, EventArgs e)
        {
            registerExit();
        }

        private void buttonCreateDatabase_Click(object sender, EventArgs e)
        {
            makeRelations();
            registerCreateDatabase(tablesToCreate);
        }

        private void makeRelations()
        {

        }
    }
}
