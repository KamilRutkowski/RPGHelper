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
        private event myDelegate registerExit;

        /// <summary>
        /// Register a callback delegate for previous step button
        /// </summary>
        private event myDelegateCreateDatabase registerPreviousStep;

        /// <summary>
        /// Register a callback delegate for end of database creation
        /// </summary>
        private event myDelegateCreateDatabase registerCreateDatabase;

        #endregion

        public delegate void myDelegate();
        public delegate void myDelegateCreateDatabase(List<ConnectionsInTables> connections);
        private List<ConnectionsInTables> connectionsToCreate;
        private List<Table> playerTablesToUse;
        private List<Table> itemTablesToUse;

        /// <summary>
        /// Creator of relations between tables. It can create an connection between two tables
        /// </summary>
        /// <param name="exit"> Delegate for exit of database creation</param>
        /// <param name="previousStep"> Delegate to go back by one step in creation</param>
        /// <param name="createDatabase"> Delegate for finishing creation of relations and send it to sql creation of database </param>
        /// <param name="players"></param>
        /// <param name="connections"> Connections between Player and Items tables to be edited</param>
        public DatabaseRelationsCreator(myDelegate exit, myDelegateCreateDatabase previousStep, myDelegateCreateDatabase createDatabase, List<Table> playerTables,List<Table> itemTables, List<ConnectionsInTables> connections)
        {
            InitializeComponent();
            registerExit = exit;
            registerPreviousStep = previousStep;
            registerCreateDatabase = createDatabase;
            connectionsToCreate = connections;
            playerTablesToUse = playerTables;
            itemTablesToUse = itemTables;
            
            if(playerTables.Count > 1)
            {
                buttonAddPlayerTables.Visible = true;
            }
            else
            {
                buttonAddPlayerTables.Visible = false;
            }
            if (itemTables.Count > 0)
            {
                buttonAddConnectionToItems.Visible = true;
            }
            else
            {
                buttonAddConnectionToItems.Visible = false;
            }
            showConnections();
            rearangeControls();
        }

        private void buttonReturnToTablesCreation_Click(object sender, EventArgs e)
        {
            makeConnections();
            registerPreviousStep(connectionsToCreate);
        }

        private void buttonStopCreation_Click(object sender, EventArgs e)
        {
            registerExit();
        }

        private void buttonCreateDatabase_Click(object sender, EventArgs e)
        {
            makeConnections();
            Table tmp = new Table();
            foreach(Table plTable in playerTablesToUse)
            {
                if(plTable.tableName == "Players")
                {
                    tmp = plTable;
                    break;
                }
            }
            TreeOfConnections tree = new TreeOfConnections(tmp);
            if(!tree.setConnections(connectionsToCreate))
            {
                MessageBox.Show("Some of connections were not possible to create", "Creation error", MessageBoxButtons.OK);
                return;
            }
            foreach (Table tab in playerTablesToUse)
            {
                if(!tree.isInTree(tab))
                {
                    MessageBox.Show("Some of player tables are not connected!", "Creation error", MessageBoxButtons.OK);
                    return;
                }
            }
            foreach (Table tab in itemTablesToUse)
            {
                
            }
            registerCreateDatabase(connectionsToCreate);
        }

        private void makeConnections()
        {
            connectionsToCreate = new List<ConnectionsInTables>();
            foreach (Control item in splitContainer1.Panel1.Controls)
            {
                if(item is BasicConnectionInterface)
                {
                    connectionsToCreate.Add(((BasicConnectionInterface)item).getConnection());
                }
            }
        }

        private void deleteControlCallback(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Do you wish to remove this connection?", "Removing connection", MessageBoxButtons.YesNo))
                return;
            ((Control)sender).Dispose();
            rearangeControls();
        }

        void rearangeControls()
        {
            int startPosition = 3;
            foreach (Control con in splitContainer1.Panel1.Controls)
            {
                if(con is ConnectionBetweenPlayerTables)
                {
                    ((BasicConnectionInterface)con).setLocationY(startPosition);
                    startPosition += 100;//90 heigth of control + 10 space in-between
                    continue;
                }
                if (con is ConnectionBetweenPlayerAndItems)
                {
                    ((BasicConnectionInterface)con).setLocationY(startPosition);
                    startPosition += 40;//30 heigth of control + 10 space in-between
                    continue;
                }
            }
            buttonAddConnectionToItems.Location = new Point(buttonAddConnectionToItems.Location.X, startPosition);
            buttonAddPlayerTables.Location = new Point(buttonAddPlayerTables.Location.X, startPosition);
        }

        void showConnections()
        {
            Control tmp;
            List<ConnectionsInTables> toRemove = new List<ConnectionsInTables>();
            foreach(ConnectionsInTables con in connectionsToCreate)
            {
                try
                {
                    switch (con.type)
                    {
                        case ConnectionsInTables.ConnectionType.GA:
                            {
                                tmp = new ConnectionBetweenPlayerAndItems(playerTablesToUse, itemTablesToUse, deleteControlCallback);
                                ((ConnectionBetweenPlayerAndItems)tmp).setTables(con.sourceTable, con.targetTable);
                                splitContainer1.Panel1.Controls.Add(tmp);
                                break;
                            }
                        case ConnectionsInTables.ConnectionType.MTM:
                            {
                                tmp = new ConnectionBetweenPlayerTables(playerTablesToUse, deleteControlCallback);
                                ((ConnectionBetweenPlayerTables)tmp).setTables(con.sourceTable, con.targetTable, "∞", "∞");
                                splitContainer1.Panel1.Controls.Add(tmp);
                                break;
                            }
                        case ConnectionsInTables.ConnectionType.MTO:
                            {
                                tmp = new ConnectionBetweenPlayerTables(playerTablesToUse, deleteControlCallback);
                                ((ConnectionBetweenPlayerTables)tmp).setTables(con.sourceTable, con.targetTable, "∞", "1");
                                splitContainer1.Panel1.Controls.Add(tmp);
                                break;
                            }
                        case ConnectionsInTables.ConnectionType.OTM:
                            {
                                tmp = new ConnectionBetweenPlayerTables(playerTablesToUse, deleteControlCallback);
                                ((ConnectionBetweenPlayerTables)tmp).setTables(con.sourceTable, con.targetTable, "1", "∞");
                                splitContainer1.Panel1.Controls.Add(tmp);
                                break;
                            }
                        case ConnectionsInTables.ConnectionType.OTO:
                            {
                                tmp = new ConnectionBetweenPlayerTables(playerTablesToUse, deleteControlCallback);
                                ((ConnectionBetweenPlayerTables)tmp).setTables(con.sourceTable, con.targetTable, "1", "1");
                                splitContainer1.Panel1.Controls.Add(tmp);
                                break;
                            }
                    }
                }
                catch(Exception)
                {
                    toRemove.Add(con);
                }
            }
            foreach(ConnectionsInTables con in toRemove)
            {
                connectionsToCreate.Remove(con);
            }
            toRemove.Clear();
        }

        private void buttonAddPlayerTables_Click(object sender, EventArgs e)
        {
            ConnectionBetweenPlayerTables con = new ConnectionBetweenPlayerTables(playerTablesToUse, deleteControlCallback);
            splitContainer1.Panel1.Controls.Add(con);
            rearangeControls();
        }

        private void buttonAddConnectionToItems_Click(object sender, EventArgs e)
        {
            ConnectionBetweenPlayerAndItems con = new ConnectionBetweenPlayerAndItems(playerTablesToUse, itemTablesToUse, deleteControlCallback);
            splitContainer1.Panel1.Controls.Add(con);
            rearangeControls();
        }
    }
}
