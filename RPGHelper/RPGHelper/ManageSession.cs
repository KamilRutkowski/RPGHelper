using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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

        public delegate void myActionDelegate();

        private string DBName;
<<<<<<< HEAD
        public ToolStripMenuItem menuItem;
=======
        private List<Table> playerTablesToManage;
        private List<Table> itemsTablesToManage;
        private int columnIndex = 0;
        private ToolStripMenuItem menuItem;
>>>>>>> origin/master

        MySqlConnection connection;
        MySqlDataAdapter adapter;
        DataTable dataSet;
        MySqlCommandBuilder commBuilder;
        #endregion

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

        /// <summary>
        /// Opens everything when ManageSession is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageSession_Load(object sender, EventArgs e)
        {
            textBoxSelectedDatabase.Text = DBName;
            MessageBox.Show("New session " + DBName + " loaded!", "New database", MessageBoxButtons.OK);
            newConnection(textBoxSelectedDatabase.Text);
        }

        /// <summary>
        /// Creates new MySql connection for selected database
        /// </summary>
        /// <param name="databaseName">Name of the current database</param>
        private void newConnection(string databaseName)
        {
            connection = DBReader.connectionCreator(databaseName);
            try
            {
                DBReader.connectionOpen(connection);
                entitiesToMenuStrip();
                comboBoxFill();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBReader.connectionEnd(connection);
            }
        }

        /// <summary>
        /// Refreshes values in DataGridView
        /// </summary>
        private void refreshTable()
        {
            try
            {
                adapter = new MySqlDataAdapter();
                adapter.SelectCommand = DBReader.commandForTheWholeTable(connection, textBoxSelectedItem.Text);
                dataSet = new DataTable();
                adapter.Fill(dataSet);
                BindingSource source = new BindingSource();

                source.DataSource = dataSet;
                tableEntity.DataSource = source;
                adapter.Update(dataSet);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBReader.connectionEnd(connection);
            }
        }

        /// <summary>
        /// Refreshes values in DataGridView when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                adapter = new MySqlDataAdapter();
                adapter.SelectCommand = DBReader.commandForTheWholeTable(connection, textBoxSelectedItem.Text);
                dataSet = new DataTable();
                adapter.Fill(dataSet);
                BindingSource source = new BindingSource();

                source.DataSource = dataSet;
                tableEntity.DataSource = source;
                adapter.Update(dataSet);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBReader.connectionEnd(connection);
            }
            refreshTable();
        }

        /// <summary>
        /// Loads available entities to MenuStrip
        /// </summary>
        private void entitiesToMenuStrip()
        {
            playerToolStripMenuItem.DropDownItems.Clear();
            itemsToolStripMenuItem.DropDownItems.Clear();
            connectorToolStripMenuItem.DropDownItems.Clear();

            foreach (string value in DBReader.selectAllPlayersTableNames(connection, textBoxSelectedDatabase.Text))
            {
                menuItem = new ToolStripMenuItem { Name = value, Text = value };
                playerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItem });
                menuItem.Click += new EventHandler(playerToolStripMenuItem_Click);
            }

            foreach (string value in DBReader.selectAllItemsTableNames(connection, textBoxSelectedDatabase.Text))
            {
                menuItem = new ToolStripMenuItem { Name = value, Text = value };
                itemsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItem });
                menuItem.Click += new EventHandler(playerToolStripMenuItem_Click);
            }

            foreach (string value in DBReader.selectAllConnectorTableNames(connection, textBoxSelectedDatabase.Text))
            {
                menuItem = new ToolStripMenuItem { Name = value, Text = value };
                connectorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItem });
                menuItem.Click += new EventHandler(playerToolStripMenuItem_Click);
            }
            
            //TEST 
            /*playerToolStripMenuItem.DropDownItems.Clear();
            itemsToolStripMenuItem.DropDownItems.Clear();

            foreach (string value in DBReader.selectAllTableNames(connection, textBoxSelectedDatabase.Text))
            {
                menuItem = new ToolStripMenuItem { Name = value, Text = value };
                playerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItem });
                menuItem.Click += new EventHandler(playerToolStripMenuItem_Click);
            }

            foreach (string value in DBReader.selectAllTableNames(connection, textBoxSelectedDatabase.Text))
            {
                menuItem = new ToolStripMenuItem { Name = value, Text = value };
                itemsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItem });
                menuItem.Click += new EventHandler(playerToolStripMenuItem_Click);
            }*/
        }

        /// <summary>
        /// Loads values to DataGridView and enables buttons when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            textBoxSelectedItem.Text = clickedItem.Text;
            refreshTable();
            buttonRefresh.Enabled = true;
            buttonInsUp.Enabled = true;
            buttonManageRows.Enabled = true;
            buttonDropTheBase.Enabled = true;
        }

        /// <summary>
        /// Fills ComboBox with database names
        /// </summary>
        private void comboBoxFill()
        {
            comboBoxDBSelector.Items.Clear();
            for (int i = 0; i < DBReader.selectAllDatabaseNames(connection).Count(); i++)
            {
                comboBoxDBSelector.Items.Add(DBReader.selectAllDatabaseNames(connection)[i]);
            }
        }

        /// <summary>
        /// Drops the base when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDropTheBase_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Do you want to delete " + DBName + "session" + "?", "Are you sure?", MessageBoxButtons.YesNo);
            {
                if (response == DialogResult.Yes)
                {
                    var response2 = MessageBox.Show("Are you sure?", "Are you sure?", MessageBoxButtons.YesNo);
                    {
                        if(response == DialogResult.Yes)
                        {
                            string commandText = "drop database " + textBoxSelectedDatabase.Text + ";";

                            MySqlCommand dropCommand = new MySqlCommand(commandText, connection);
                            MySqlDataReader reader;

                            try
                            {
                                DBReader.connectionOpen(connection);
                                reader = dropCommand.ExecuteReader();
                                MessageBox.Show("Session was dropped!");
                                while (reader.Read())
                                {

                                }
                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                DBReader.connectionEnd(connection);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Inserts/Updates values in DataGridView when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInsUp_Click(object sender, EventArgs e)
        {
            try
            {
                commBuilder = new MySqlCommandBuilder(adapter);
                adapter.Update(dataSet);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBReader.connectionEnd(connection);
            }
            refreshTable();
        }

        /// <summary>
        /// Opens new EntityManager when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonManageRows_Click(object sender, EventArgs e)
        {
            EntityManager entityForm = new EntityManager(textBoxSelectedDatabase.Text, textBoxSelectedItem.Text);
            entityForm.Show();
        }

        private void comboBoxDBSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxSelectedDatabase.Text = comboBoxDBSelector.SelectedItem.ToString();
            newConnection(textBoxSelectedDatabase.Text);
        }

        /// <summary>
        /// Rotates players when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLeftArrow_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Rotates players when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRightArrow_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Rotates players when clicked
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="currentKey"></param>
        protected override bool ProcessCmdKey(ref Message msg, Keys currentKey)
        {
            if (currentKey == (Keys.F4))
            {
                buttonManageRows.PerformClick();
                return true;
            }
            if (currentKey == (Keys.F5))
            {
                buttonRefresh.PerformClick();
                return true;
            }
            if (currentKey == (Keys.F6))
            {
                buttonInsUp.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, currentKey);
        }

        /// <summary>
        /// Quits ManageSession control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            registerEndSession();
        }
    }
}