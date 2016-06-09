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

        /// <summary>
        /// Register a callback delegate for ExitButton.Click event
        /// </summary>
        private myDelegate registerExit
        {
            get; set;
        }

        /// <summary>
        /// Register a callback for previous step of session creation
        /// </summary>
        private myDelegate registerPreviousStep
        {
            get; set;
        }

        /// <summary>
        /// Register a callback delegate for next step of session creation
        /// </summary>
        private myDelegateWithTables registerNextStep
        {
            get; set;
        }
        #endregion

        public delegate void myDelegate();
        public delegate void myDelegateWithTables(List<Table> tables, List<ConnectionsInTables> takeFromItems);

        private List<Table> playerTablesToCreate;
        private List<Table> itemsTablesToCreate;
        private List<ConnectionsInTables> connectionsToCreate;

        /// <summary>
        /// Control for creatng tables in database with pre-existiong tables
        /// </summary>
        /// <param name="exit">Delegate for exiting a process of session creation</param>
        /// <param name="previousStep">Delegate for previous step of database creation</param>
        /// <param name="nextStep">Delegate for next step of database creation</param>
        /// <param name="playerTables">Pre-existing tables</param>
        /// <param name="conn">Pre-existing connections</param>
        public DatabaseTablesCreator(myDelegate exit, myDelegate previousStep, myDelegateWithTables nextStep, List<Table> playerTables, List<Table> itemsTables, List<ConnectionsInTables> conn)
        {
            InitializeComponent();
            registerExit = exit;
            registerPreviousStep = previousStep;
            registerNextStep = nextStep;
            playerTablesToCreate = playerTables;
            itemsTablesToCreate = itemsTables;
            connectionsToCreate = conn;
            showCreatedTables();
        }
        /// <summary>
        /// This method will draw the current table
        /// </summary>
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
            registerNextStep(playerTablesToCreate, connectionsToCreate);
        }
    }
}
