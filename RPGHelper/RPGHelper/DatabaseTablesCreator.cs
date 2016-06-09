using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary>
/// TODO:
/// Adding tables to dropdown list
/// Removing tables
/// Chech if table exist before creation
/// Check for no-name colums before creation of new table/chosing other table/going to other step of creation
/// Loading tables
/// !!!Reminder -> ColumnCreator, changing item selected will wipe enum options
/// </summary>

namespace RPGHelper
{
    public partial class DatabaseTablesCreator : UserControl
    {
        #region Properties

        private string actualTableName { get; set; }

        private bool isPlayerType { get; set; }

        #endregion

        #region Callbacks

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
            if(playerTables.Count == 0)
            {
                Table PlayerTable = new Table();
                PlayerTable.tableName = "Players";
                playerTablesToCreate.Add(PlayerTable);
            }
            actualTableName = "Players";
            isPlayerType = true;
            showCreatedTable();
            rearangeColums();
        }
        /// <summary>
        /// This method will draw the current table
        /// </summary>
        private void showCreatedTable()
        {
            if(isPlayerType)
            {
                foreach(Table tab in playerTablesToCreate)
                {
                    if(tab.tableName == actualTableName)
                    {
                        foreach(Column col in tab.columnsInTable)
                        {
                            ColumnCreator colCreator = new ColumnCreator(removeColumn);
                            colCreator.columnName = col.columnName;
                            colCreator.type = col.type;
                            if (col.type == Column.ColumnType.Enum)
                                colCreator.enumValues = col.possibleEnumOptions;
                            splitContainer1.Panel1.Controls.Add(colCreator);
                        }
                        break;
                    }
                }
            }
            else
            {
                foreach (Table tab in itemsTablesToCreate)
                {
                    if (tab.tableName == actualTableName)
                    {
                        foreach (Column col in tab.columnsInTable)
                        {
                            ColumnCreator colCreator = new ColumnCreator(removeColumn);
                            colCreator.columnName = col.columnName;
                            colCreator.type = col.type;
                            if (col.type == Column.ColumnType.Enum)
                                colCreator.enumValues = col.possibleEnumOptions;
                            splitContainer1.Panel1.Controls.Add(colCreator);
                        }
                        break;
                    }
                }
            }
        }

        private void buttonReturnToNameCreation_Click(object sender, EventArgs e)
        {
            saveCurrentColumsInCurrentTable();
            registerPreviousStep();
        }

        private void buttonStopCreation_Click(object sender, EventArgs e)
        {
            registerExit();
        }

        private void buttonNextStep_Click(object sender, EventArgs e)
        {
            saveCurrentColumsInCurrentTable();
            registerNextStep(playerTablesToCreate, connectionsToCreate);
        }
        
        private void buttonAddColumn_Click(object sender, EventArgs e)
        {
            ColumnCreator col = new ColumnCreator(removeColumn);
            splitContainer1.Panel1.Controls.Add(col);
            rearangeColums();
        }

        private void removeColumn(Control sender)
        {
            Controls.Remove(sender);
            sender.Dispose();
            rearangeColums();
        }

        private void rearangeColums()
        {
            int basePositionY = 27;
            foreach(Control col in splitContainer1.Panel1.Controls)
            {
                if (col is ColumnCreator)
                {
                    col.Location = new Point(col.Location.X, basePositionY);
                    basePositionY += 40; //ColumnCreator Height + 10 for space between
                    col.Visible = true;
                }
            }
            buttonAddColumn.Location = new Point(buttonAddColumn.Location.X, basePositionY);
        }

        private void saveCurrentColumsInCurrentTable()
        {
            Table currentTable = getCurrentTable();
            foreach(Control control in splitContainer1.Panel1.Controls)
            {
                if(control is ColumnCreator)
                {
                    Column col = ((ColumnCreator)control).createColumn();
                    currentTable.columnsInTable.Add(col);
                }
            }
        }

        private Table getCurrentTable()
        {
            if(isPlayerType)
            {
                foreach (Table tab in playerTablesToCreate)
                    if (tab.tableName == actualTableName) return tab;
            }
            else
            {
                foreach (Table tab in itemsTablesToCreate)
                    if (tab.tableName == actualTableName) return tab;
            }
            throw new Exception(actualTableName + " : not such table exists! Was playerType? "+isPlayerType.ToString());
        }


        private void addTableForPlayer(string tableName)
        {
            if (tableName == "")
                return;
            saveCurrentColumsInCurrentTable();
            Table tab = new Table();
            tab.tableName = tableName;
            playerTablesToCreate.Add(tab);
            removeAllColums();
            actualTableName = tableName;
            isPlayerType = true;
            rearangeColums();
        }

        private void addTableForItems(string tableName)
        {
            if (tableName == "")
                return;
            saveCurrentColumsInCurrentTable();
            Table tab = new Table();
            tab.tableName = tableName;
            itemsTablesToCreate.Add(tab);
            removeAllColums();
            actualTableName = tableName;
            isPlayerType = false;
            rearangeColums();
        }

        //Remove all 
        private void removeAllColums()
        {
            Control tmp;
            int max = splitContainer1.Panel1.Controls.Count;
            for(int i=0; i < max;)
            {
                tmp = splitContainer1.Panel1.Controls[i];
                if(tmp is ColumnCreator)
                {
                    tmp.Dispose();
                    max -= 1;
                    continue;
                }
                i++;
            }
        }

        //Create table for Player
        private void playerTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTableName addTable = new AddTableName(addTableForPlayer);
            addTable.Show();
        }

        //Create table for Items
        private void itemsTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTableName addTable = new AddTableName(addTableForItems);
            addTable.Show();
        }
    }
}
