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
        private event myActionDelegate registerdatabaseCreated;

        #endregion

        private string databaseName;
        private List<Table> playerTablesInDatabase;
        private List<Table> itemsTablesInDatabase;
        private List<ConnectionsInTables> connectionsBetweenTables;
        private Control activeContorl;

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
        private void goBackToCreatingTables(List<ConnectionsInTables> connections)
        {
            activeContorl.Dispose();
            connectionsBetweenTables = connections;
            activeContorl = new DatabaseTablesCreator(stopCreation, goToNaming, goToRelations, playerTablesInDatabase, itemsTablesInDatabase);
            Controls.Add(activeContorl);
        }

        private void createDatabase(TreeOfConnections connections)
        {
            //Creating database
            try
            {
                DBCreator db = new DBCreator(connections, databaseName);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error while creating database", MessageBoxButtons.OK);
                return;
            }
            registerdatabaseCreated(databaseName);
        }
    }
}
