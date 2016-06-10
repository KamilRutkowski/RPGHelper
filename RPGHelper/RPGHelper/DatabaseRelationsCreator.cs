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
        #region Callbacks

        /// <summary>
        /// Register a callback delegate for ExitButton.Click event
        /// </summary>
        private myDelegate registerExit
        {
            get; set;
        }

        /// <summary>
        /// Register a callback delegate for previous step button
        /// </summary>
        private myDelegate registerPreviousStep
        {
            get; set;
        }

        /// <summary>
        /// Register a callback delegate for end of database creation
        /// </summary>
        private myDelegateCreateDatabase registerCreateDatabase
        {
            get; set;
        }

        #endregion

        public delegate void myDelegate();
        public delegate void myDelegateCreateDatabase(List<ConnectionsInTables> connections);
        private List<ConnectionsInTables> connectionsToCreate;

        /// <summary>
        /// Creator of relations between tables. It can create an connection between two tables
        /// </summary>
        /// <param name="exit"> Delegate for exit of database creation</param>
        /// <param name="previousStep"> Delegate to go back by one step in creation</param>
        /// <param name="createDatabase"> Delegate for finishing creation of relations and send it to sql creation of database </param>
        /// <param name="players"></param>
        /// <param name="connections"> Connections between Player and Items tables to be edited</param>
        public DatabaseRelationsCreator(myDelegate exit, myDelegate previousStep, myDelegateCreateDatabase createDatabase, List<Table> playerTables,List<Table> itemTables, List<ConnectionsInTables> connections)
        {
            InitializeComponent();
            registerExit = exit;
            registerPreviousStep = previousStep;
            registerCreateDatabase = createDatabase;
            connectionsToCreate = connections;
        }

        private void buttonReturnToTablesCreation_Click(object sender, EventArgs e)
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
            registerCreateDatabase(connectionsToCreate);
        }

        private void makeRelations()
        {
            throw new NotImplementedException();
        }
    }
}
