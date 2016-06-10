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
    public partial class SessionCreator : UserControl
    {
        #region Properties

        /// <summary>
        /// Register a callback delegate for an event when process of database creation has ended
        /// </summary>
        private myActionDelegate registerdatabaseCreated
        {
            get; set;
        }

        #endregion

        string databaseName;
        List<Table> playerTablesInDatabase;
        List<Table> itemsTablesInDatabase;
        List<ConnectionsInTables> connectionsBetweenTables;
        Control activeContorl;

        public delegate void myActionDelegate(string database);

        /// <summary>
        /// Control for a process of creating database for RPG session
        /// </summary>
        /// <param name="databaseCreated">Delegate for completion of creation process</param>
        public SessionCreator(myActionDelegate databaseCreated)
        {
            InitializeComponent();
            playerTablesInDatabase = new List<Table>();
            itemsTablesInDatabase = new List<Table>();
            connectionsBetweenTables = new List<ConnectionsInTables>();
            databaseName = "";
            registerdatabaseCreated = databaseCreated;
            activeContorl = new DatabaseNameCreator(stopCreation, gotNameCreateTables);
            Controls.Add(activeContorl);
        }

        private void SessionCreator_Load(object sender, EventArgs e)
        {

        }

        //For Database creation control
        private void stopCreation()
        {
            registerdatabaseCreated("");
        }
        //For DatabaseNameCreator
        private void gotNameCreateTables(string dataName)
        {
            databaseName = dataName;
            activeContorl.Dispose();
            activeContorl = new DatabaseTablesCreator(stopCreation, goToNaming, goToRelations, playerTablesInDatabase, itemsTablesInDatabase);
            Controls.Add(activeContorl);
        }

        //For DatabaseTablesCreator
        private void goToNaming()
        {
            activeContorl.Dispose();
            activeContorl = new DatabaseNameCreator(stopCreation, gotNameCreateTables,databaseName);
            Controls.Add(activeContorl);
        }

        private void goToRelations(List<Table> tablesOfPlayer, List<Table> tablesOfItems)
        {
            activeContorl.Dispose();
            activeContorl = new DatabaseRelationsCreator(stopCreation,goBackToCreatingTables,createDatabase,playerTablesInDatabase,itemsTablesInDatabase,connectionsBetweenTables);
            Controls.Add(activeContorl);
        }
        
        //For DatabaseRelationsCreator
        private void goBackToCreatingTables()
        {
            activeContorl.Dispose();
            activeContorl = new DatabaseTablesCreator(stopCreation, goToNaming, goToRelations, playerTablesInDatabase, itemsTablesInDatabase);
            Controls.Add(activeContorl);
        }

        private void createDatabase(List<ConnectionsInTables> connections)
        {
            //Creating database

            registerdatabaseCreated(databaseName);
        }
    }
}
