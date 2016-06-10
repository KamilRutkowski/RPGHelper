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
        public delegate void myDelegateWithTables(List<Table> tablesOfPlayer, List<Table> tablesOfItems);

        private List<Table> playerTablesToCreate;
        private List<Table> itemsTablesToCreate;

        /// <summary>
        /// Control for creatng tables in database with pre-existiong tables
        /// </summary>
        /// <param name="exit">Delegate for exiting a process of session creation</param>
        /// <param name="previousStep">Delegate for previous step of database creation</param>
        /// <param name="nextStep">Delegate for next step of database creation</param>
        /// <param name="playerTables">Pre-existing tables</param>
        /// <param name="conn">Pre-existing connections</param>
        public DatabaseTablesCreator(myDelegate exit, myDelegate previousStep, myDelegateWithTables nextStep, List<Table> playerTables, List<Table> itemsTables)
        {
            InitializeComponent();
            registerExit = exit;
            registerPreviousStep = previousStep;
            registerNextStep = nextStep;
            playerTablesToCreate = playerTables;
            itemsTablesToCreate = itemsTables;
            if(playerTables.Count == 0)
            {
                Table PlayerTable = new Table();
                PlayerTable.tableName = "Players";
                playerTablesToCreate.Add(PlayerTable);
            }
            setCurrentTable("Players", true);
            showCreatedTable();
            rearangeColums();
            foreach(Table tab in playerTablesToCreate)
            {
                addTableForPlayerToDropDownMenus(tab.tableName);
            }
            foreach (Table tab in itemsTablesToCreate)
            {
                addTableForItemsToDropDownMenus(tab.tableName);
            }
        }


        /// <summary>
        /// Sets the current table
        /// </summary>
        /// <param name="tableName">Name of current table</param>
        /// <param name="isFromPlayerTables">Is this table a player type</param>
        private void setCurrentTable(string tableName, bool isFromPlayerTables)
        {
            actualTableName = tableName;
            isPlayerType = isFromPlayerTables;
        }

        /// <summary>
        /// Checks if given table is actualy used table
        /// </summary>
        /// <param name="tableName">Table name to check</param>
        /// <param name="isFromPlayerTables">Does it have playerType</param>
        /// <returns>True if given table is current table</returns>
        private bool isCurrentTable(string tableName, bool isFromPlayerTables)
        {
            if ((tableName == actualTableName) && (isPlayerType == isFromPlayerTables)) return true;
            return false;
        }

        /// <summary>
        /// This method will draw the current table
        /// </summary>
        private void showCreatedTable()
        {
            Table tmp = getCurrentTable();
            foreach (Column col in tmp.columnsInTable)
            {
                ColumnCreator colCreator = new ColumnCreator(removeColumn);
                colCreator.columnName = col.columnName;
                if (col.type == Column.ColumnType.Enum)
                    colCreator.enumValues = col.possibleEnumOptions;
                colCreator.type = col.type;
                splitContainer1.Panel1.Controls.Add(colCreator);
            }
        }

        /// <summary>
        /// Callback for Previous step of creation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReturnToNameCreation_Click(object sender, EventArgs e)
        {
            if (!saveCurrentColumsInCurrentTable())
            {
                MessageBox.Show("Non titled columns detected! Remove or name them before proceding!", "Invalid column names", MessageBoxButtons.OK);
                return;
            }
            saveCurrentColumsInCurrentTable();
            registerPreviousStep();
        }

        /// <summary>
        /// Callback for exiting the proces of creation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStopCreation_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Do you really wish to exit creation process?","Exiting creation process",MessageBoxButtons.YesNo))
               registerExit();
        }

        /// <summary>
        /// Callback for Click on NextStep button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNextStep_Click(object sender, EventArgs e)
        {
            if (!saveCurrentColumsInCurrentTable())
            {
                MessageBox.Show("Non titled columns detected! Remove or name them before proceding!", "Invalid column names", MessageBoxButtons.OK);
                return;
            }
            registerNextStep(playerTablesToCreate, itemsTablesToCreate);
        }
        
        /// <summary>
        /// Click on AddColumn button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddColumn_Click(object sender, EventArgs e)
        {
            ColumnCreator col = new ColumnCreator(removeColumn);
            splitContainer1.Panel1.Controls.Add(col);
            rearangeColums();
        }


        /// <summary>
        /// Calback for removing ColumnCreator control
        /// </summary>
        /// <param name="sender"></param>
        private void removeColumn(Control sender)
        {
            Controls.Remove(sender);
            sender.Dispose();
            rearangeColums();
        }

        /// <summary>
        /// Sets positions for ColumnCreator and AddColumn button.
        /// </summary>
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

        /// <summary>
        /// Writes a current ColumnCreator controls as a List<Column> in current Table
        /// </summary>
        /// <returns>If all of columns have title, it will return true</returns>
        private bool saveCurrentColumsInCurrentTable()
        {
            Table currentTable = getCurrentTable();
            List<Column>tmp = new List<Column>();
            foreach(Control control in splitContainer1.Panel1.Controls)
            {
                if(control is ColumnCreator)
                {
                    Column col = ((ColumnCreator)control).createColumn();
                    if (col.columnName == "")
                        return false;
                    tmp.Add(col);
                }
            }
            currentTable.columnsInTable = tmp;
            return true;
        }

        /// <summary>
        /// Gets a current table object
        /// </summary>
        /// <returns></returns>
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

        ///<summary>
        ///Adding a table Object to player list and reseting view of columns
        ///</summary>
        private void addTableForPlayer(string tableName)
        {
            if (tableName == "")
                return;
            foreach(Table t in playerTablesToCreate)
            {
                if(t.tableName == tableName)
                {
                    MessageBox.Show("Table like that already exist!", "Same table name", MessageBoxButtons.OK);
                    return;
                }
            }
            Table tab = new Table();
            tab.tableName = tableName;
            playerTablesToCreate.Add(tab);
            removeAllColums();
            setCurrentTable(tableName, true);
            addTableForPlayerToDropDownMenus(tableName);
            rearangeColums();
        }

        private void addTableForPlayerToDropDownMenus(string tableName)
        {
            //For choosing table to load
            ToolStripItem tmp = new ToolStripMenuItem();
            tmp.Text = tableName;
            tmp.Click += choosePlayerTable_Click;
            playerToolStripMenuItem.DropDownItems.Add(tmp);
            //For deleting table
            if(tableName != "Players")
            {
                tmp = new ToolStripMenuItem();
                tmp.Text = tableName;
                tmp.Click += removePlayerTable_Click;
                playerTablesToolStripMenuItem.DropDownItems.Add(tmp);
            }
        }

        private void choosePlayerTable_Click(object sender, EventArgs e)
        {
            getCurrentTable().columnsInTable = new List<Column>();
            if(!saveCurrentColumsInCurrentTable())
            {
                MessageBox.Show("Non titled columns detected! Remove or name them before proceding!", "Invalid column names", MessageBoxButtons.OK);
                return;
            }
            actualTableName=((ToolStripItem)sender).Text;
            isPlayerType = true;
            removeAllColums();
            showCreatedTable();
            rearangeColums();
        }

        private void removePlayerTable_Click(object sender, EventArgs e)
        {
            //Going to default(Player) table if table to delete is a current table
            if(isCurrentTable(((ToolStripItem)sender).Text,true))
            {
                removeAllColums();
                setCurrentTable("Players", true);
                showCreatedTable();
                rearangeColums();
            }
            //Removing table object
            foreach (Table pla in playerTablesToCreate)
            {
                if(pla.tableName == ((ToolStripItem)sender).Text)
                {
                    playerTablesToCreate.Remove(pla);
                    break;
                }
            }
            //Removing go to Table and delete table in drop down menus
            foreach(ToolStripItem item in playerToolStripMenuItem.DropDownItems)
            {
                if(item.Text == ((ToolStripItem)sender).Text)
                {
                    item.Dispose();
                    break;
                }
            }
            ((ToolStripItem)sender).Dispose();
        }

        ///<summary>
        ///Adding a table Object to items list and reseting view of columns
        ///</summary>
        private void addTableForItems(string tableName)
        {
            if (tableName == "")
                return;
            foreach (Table t in itemsTablesToCreate)
            {
                if (t.tableName == tableName)
                {
                    MessageBox.Show("Table like that already exist!", "Same table name", MessageBoxButtons.OK);
                    return;
                }
            }
            saveCurrentColumsInCurrentTable();
            Table tab = new Table();
            tab.tableName = tableName;
            itemsTablesToCreate.Add(tab);
            removeAllColums();
            setCurrentTable(tableName, false);
            rearangeColums();
            addTableForItemsToDropDownMenus(tableName);
        }

        private void addTableForItemsToDropDownMenus(string tableName)
        {
            //For choosing table to load
            ToolStripItem tmp = new ToolStripMenuItem();
            tmp.Text = tableName;
            tmp.Click += chooseItemsTable_Click;
            itemsToolStripMenuItem.DropDownItems.Add(tmp);
            //For deleting table
            tmp = new ToolStripMenuItem();
            tmp.Text = tableName;
            tmp.Click += removeItemsTable_Click;
            itemsTablesToolStripMenuItem.DropDownItems.Add(tmp);
        }

        private void chooseItemsTable_Click(object sender, EventArgs e)
        {
            getCurrentTable().columnsInTable = new List<Column>();
            if (!saveCurrentColumsInCurrentTable())
            {
                MessageBox.Show("Non titled columns detected! Remove or name them before proceding!", "Invalid column names", MessageBoxButtons.OK);
                return;
            }
            setCurrentTable(((ToolStripItem)sender).Text, false);
            removeAllColums();
            showCreatedTable();
            rearangeColums();
        }

        private void removeItemsTable_Click(object sender, EventArgs e)
        {
            //Going to default(Player) table if table to delete is a current table
            if (isCurrentTable(((ToolStripItem)sender).Text, false))
            {
                removeAllColums();
                setCurrentTable("Players", true);
                showCreatedTable();
                rearangeColums();
            }
            //Removing table object
            foreach (Table pla in itemsTablesToCreate)
            {
                if (pla.tableName == ((ToolStripItem)sender).Text)
                {
                    itemsTablesToCreate.Remove(pla);
                    break;
                }
            }
            //Removing go to Table and delete table in drop down menus
            foreach (ToolStripItem item in itemsToolStripMenuItem.DropDownItems)
            {
                if (item.Text == ((ToolStripItem)sender).Text)
                {
                    item.Dispose();
                    break;
                }
            }
            ((ToolStripItem)sender).Dispose();
        }

        /// <summary>
        /// Remove all CreateColumn controls currently on a screen
        /// </summary>
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

        /// <summary>
        /// Create table for Player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playerTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!saveCurrentColumsInCurrentTable())
            {
                MessageBox.Show("Non titled columns detected! Remove or name them before proceding!", "Invalid column names", MessageBoxButtons.OK);
                return;
            }
            AddTableName addTable = new AddTableName(addTableForPlayer);
            addTable.Show();
        }

        /// <summary>
        /// Create table for Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!saveCurrentColumsInCurrentTable())
            {
                MessageBox.Show("Non titled columns detected! Remove or name them before proceding!", "Invalid column names", MessageBoxButtons.OK);
                return;
            }
            AddTableName addTable = new AddTableName(addTableForItems);
            addTable.Show();
        }
    }
}
