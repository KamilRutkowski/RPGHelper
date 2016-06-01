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

        public myActionDelegate registerdatabaseCreated
        {
            get; set;
        }

        #endregion

        string databaseName;
        List<Table> tablesInDatabase;
        Control activeContorl;

        public delegate void myActionDelegate(string database);

        public SessionCreator(myActionDelegate databaseCreated)
        {
            InitializeComponent();
            tablesInDatabase = new List<Table>();
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
            activeContorl = new DatabaseTablesCreator(stopCreation, goToNaming, goToRelations);
            Controls.Add(activeContorl);
        }

        //For DatabaseTablesCreator
        private void goToNaming()
        {
            activeContorl.Dispose();
            activeContorl = new DatabaseNameCreator(stopCreation, gotNameCreateTables,databaseName);
            Controls.Add(activeContorl);
        }

        private void goToRelations(List<Table> tables)
        {
            activeContorl.Dispose();
            activeContorl = new DatabaseRelationsCreator(stopCreation, goBackToCreatingTables, createDatabase, tablesInDatabase);
            Controls.Add(activeContorl);
        }
        
        //For DatabaseRelationsCreator
        private void goBackToCreatingTables()
        {
            activeContorl.Dispose();
            activeContorl = new DatabaseTablesCreator(stopCreation, goToNaming, goToRelations, tablesInDatabase);
            Controls.Add(activeContorl);
        }

        private void createDatabase(List<Table> tables)
        {
            //Creating database

            registerdatabaseCreated(databaseName);
        }
    }
}
