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
    public partial class ManageSession : UserControl
    {
        #region Properties

        /// <summary>
        /// Register a callback delegate for exiting current session
        /// </summary>
        private myActionDelegate registerEndSession
        {
            get; set;
        }

        private string DBName;
        List<List<Table>> DBTest = new List<List<Table>>();
        DBReader reader = new DBReader();
        #endregion

        public delegate void myActionDelegate();

        /// <summary>
        /// Manager of existing session
        /// </summary>
        /// <param name="endSession">Delegate of ending session</param>
        /// <param name="databaseName">Name of database to open</param>
        public ManageSession(myActionDelegate endSession, string databaseName)
        {
            InitializeComponent();
            registerEndSession = endSession;
            DBName = databaseName;
        }

        private void ManageSession_Load(object sender, EventArgs e)
        {
            textBoxSelectedDatabase.Text = DBName;
            DBTest = reader.createTestDatabase("Players", "Equipment", "Weapons", "Magic");
            reader.readDatabase(playerToolStripMenuItem, itemsToolStripMenuItem, DBTest, playerToolStripMenuItem_Click);
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            registerEndSession();
        }

        private void buttonSaveQuit_Click(object sender, EventArgs e)
        {
            registerEndSession();
        }

        private void buttonSaveSession_Click(object sender, EventArgs e)
        {

        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            textBoxSelectedEntity.Text = clickedItem.Text;
            textBoxSelectedEntity.Enabled = true;
        }
    }
}
