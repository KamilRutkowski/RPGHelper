﻿using System;
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
        private event myActionDelegate registerEndSession;

        #endregion

        public delegate void myActionDelegate();

        private string DBName;
        private string entityName;
        private ToolStripMenuItem menuItem;

        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private DataTable dataSet;
        private MySqlCommandBuilder commBuilder;

        /// <summary>
        /// Manager of existing session
        /// </summary>
        /// <param name="endSession">Delegate of ending session</param>
        /// <param name="databaseName">Name of database to open</param>
        public ManageSession(myActionDelegate endSession, string databaseName)
        {
            InitializeComponent();
            registerEndSession = endSession;
            
            if(databaseName.StartsWith("rpgh"))
            {
                DBName = databaseName;
            }
            else
            {
                DBName = "rpgh" + databaseName;
            }
        }

        /// <summary>
        /// Opens everything when ManageSession is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageSession_Load(object sender, EventArgs e)
        {
            textBoxSelectedDatabase.Text = DBName.Substring(4, DBName.Length - 4);
            MessageBox.Show("New session " + textBoxSelectedDatabase.Text + " loaded!", "New database", MessageBoxButtons.OK);
            newConnection(DBName);
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
                adapter.SelectCommand = DBReader.commandForTheWholeTable(connection, entityName);
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
                adapter.SelectCommand = DBReader.commandForTheWholeTable(connection, entityName);
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

            foreach (string value in DBReader.selectAllPlayersTableNames(connection, DBName))
            {
                string newValuePlayer = "";
                if(value.StartsWith("playersmain"))
                {
                    newValuePlayer = value.Substring(11, value.Length - 11);
                }
                else if (value.StartsWith("playerssub"))
                {
                    newValuePlayer = value.Substring(10, value.Length - 10);
                }
                menuItem = new ToolStripMenuItem { Name = newValuePlayer, Text = newValuePlayer };
                playerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItem });
                menuItem.Click += new EventHandler(playerToolStripMenuItem_Click);
            }

            foreach (string value in DBReader.selectAllItemsTableNames(connection, DBName))
            {
                string newValueItems = "";
                if (value.StartsWith("items"))
                {
                    newValueItems = value.Substring(5, value.Length - 5);
                }
                menuItem = new ToolStripMenuItem { Name = newValueItems, Text = newValueItems };
                itemsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItem });
                menuItem.Click += new EventHandler(itemsToolStripMenuItem_Click);
            }

            foreach (string value in DBReader.selectAllConnectorTableNames(connection, DBName))
            {
                string newValueConnector = "";
                if (value.StartsWith("connector"))
                {
                    newValueConnector = value.Substring(9, value.Length - 9);
                }
                menuItem = new ToolStripMenuItem { Name = newValueConnector, Text = newValueConnector };
                connectorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItem });
                menuItem.Click += new EventHandler(connectorToolStripMenuItem_Click);
            }
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
            
            if(clickedItem.Text == "players")
            {
                entityName = "playersmain" + clickedItem.Text;
            }
            else
            {
                entityName = "playerssub" + clickedItem.Text;
            }
            refreshTable();
            enableButtons();
        }

        /// <summary>
        /// Loads values to DataGridView and enables buttons when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            textBoxSelectedItem.Text = clickedItem.Text;
            entityName = "items" + clickedItem.Text;
            refreshTable();
            enableButtons();
        }

        /// <summary>
        /// Loads values to DataGridView and enables buttons when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            textBoxSelectedItem.Text = clickedItem.Text;
            entityName = "connector" + clickedItem.Text;
            refreshTable();
            enableButtons();
        }

        /// <summary>
        /// Enables buttons
        /// </summary>
        private void enableButtons()
        {
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
                string newDatabaseName = ""; 
                newDatabaseName = DBReader.selectAllDatabaseNames(connection)[i];
                comboBoxDBSelector.Items.Add(newDatabaseName.Substring(4, newDatabaseName.Length - 4));
            }
        }

        /// <summary>
        /// Drops the base when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDropTheBase_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Do you want to delete " + textBoxSelectedDatabase.Text + " session?", "Are you sure?", MessageBoxButtons.YesNo);
            {
                if (response == DialogResult.Yes)
                {
                    var response2 = MessageBox.Show("Are you sure?", "Are you sure?", MessageBoxButtons.YesNo);
                    {
                        if (response == DialogResult.Yes)
                        {
                            string commandText = "drop database " + DBName + ";";

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
            EntityManager entityForm = new EntityManager(DBName, entityName);
            entityForm.Show();
        }

        private void comboBoxDBSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxSelectedDatabase.Text = comboBoxDBSelector.SelectedItem.ToString();
            DBName = "rpgh" + comboBoxDBSelector.SelectedItem.ToString();
            newConnection(DBName);
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