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

        List<List<Table>> DBTest = new List<List<Table>>();
        List<string> newEnumOptions = new List<string>();
        List<List<string>> listOfNewEnumOptions = new List<List<string>>();
        DBReader reader = new DBReader();
        #endregion

        public delegate void myActionDelegate();

        private string DBName;
        private List<Table> playerTablesToManage;
        private List<Table> itemsTablesToManage;
        private int columnIndex = 0;
        private ToolStripMenuItem menuItem;

        private bool firstTimeReading;

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
            //FOR TESTS ONLY
            if (isTestingDatabase())
            {
                firstTimeReading = false;
                textBoxSelectedDatabase.Text = DBName;
                DBTest = reader.createTestDatabase("Players", "Equipment", "Weapons", "Magic", "Player 1", "Player 2", 
                    "Potions","Shields","Swords","Bows","Missile","Bottles");
                playerTablesToManage = DBTest[0];
                itemsTablesToManage = DBTest[1];
                entitiesToMenuStrip();
            }
            else
                MessageBox.Show("New database loaded!", "New database", MessageBoxButtons.OK);   
        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            textBoxSelectedItem.Text = clickedItem.Text;

            firstTimeReading = true;

            foreach (Table table in playerTablesToManage)
            if (clickedItem.Text == table.tableName)
            {
                tableEntity.Columns.Clear();
                entityToManager(table);
            }

            foreach (Table table in itemsTablesToManage)
            if(clickedItem.Text == table.tableName)
            {
                tableEntity.Columns.Clear();
                entityToManager(table);
            }

            tableEntity.Visible = true;
            ValueInColumnIsNull();
            firstTimeReading = false;
        }

        //Testing database from DBReader
        private bool isTestingDatabase()
        {
            if(DBName == "Test")
                return true;
            return false;
        }

        private void ValueInColumnIsNull()
        {
            for(int i = 0; i < tableEntity.ColumnCount; i++)
            {
                for(int j = 0; j < tableEntity.RowCount; j++)
                {
                    if(tableEntity.Rows[j].Cells[i].Value == null)
                    {
                        tableEntity.Rows[j].Cells[i].Value = "";
                    }
                }
            }
        }

        private void entitiesToMenuStrip()
        {
            foreach (Table table in playerTablesToManage)
            {
                menuItem = new ToolStripMenuItem { Name = table.tableName, Text = table.tableName };
                playerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItem });
                menuItem.Click += new EventHandler(playerToolStripMenuItem_Click);
            }

            foreach (Table table in itemsTablesToManage)
            {
                menuItem = new ToolStripMenuItem { Name = table.tableName, Text = table.tableName };
                itemsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItem });
                menuItem.Click += new EventHandler(playerToolStripMenuItem_Click);
            }   

        }

        private void entityToManager(Table selectedEntity)
        {
            foreach (Column column in selectedEntity.columnsInTable)
            {
                tableEntity.Columns.Add("column" + columnIndex.ToString(), column.columnName);
                
                for (int i = 0; i < column.possibleEnumOptions.Count(); i++ )
                {
                    tableEntity.Rows.Add();
                    tableEntity.Rows[i].Cells[columnIndex].Value = column.possibleEnumOptions[i];
                }

                columnIndex++;
            }
            columnIndex = 0;
        }

        private void tableEntity_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(!firstTimeReading)
            {
                tablesHaveChanged(playerTablesToManage);
                tablesHaveChanged(itemsTablesToManage);
            }
        }

        private void tablesHaveChanged(List<Table> listOfChangedTable)
        {
            foreach (Table table in listOfChangedTable)
            {
                if (table.tableName == textBoxSelectedItem.Text)
                {
                    saveColumnsStateTemporarily();
                    loadColumnsStateTemporarily(table);
                }
            }
        }

        private void saveColumnsStateTemporarily()
        {
            ValueInColumnIsNull();
            foreach (DataGridViewColumn column in tableEntity.Columns)
            {
                for (int i = 0; i < tableEntity.RowCount - 1; i++)
                {
                    string newValue = tableEntity.Rows[i].Cells[column.Index].Value.ToString();
                    newEnumOptions.Add(newValue);
                }
                listOfNewEnumOptions.Add(newEnumOptions);
                newEnumOptions = new List<string>();
            }
        }

        private void loadColumnsStateTemporarily(Table chosenTable)
        {
            for (int i = 0; i < chosenTable.columnsInTable.Count(); i++)
            {
                chosenTable.columnsInTable[i].possibleEnumOptions.Clear();                
                chosenTable.columnsInTable[i].possibleEnumOptions = listOfNewEnumOptions[i];
            }
            listOfNewEnumOptions = new List<List<string>>();
        }

        private void readMySqlFile()
        {
            OpenFileDialog openFileBox = new OpenFileDialog();
            openFileBox.Filter = "SQL Files|*.sql";
            if (openFileBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            registerEndSession();
        }

        private void buttonSaveQuit_Click(object sender, EventArgs e)
        {
            DBTest[0] = playerTablesToManage;
            DBTest[1] = itemsTablesToManage;
            registerEndSession();
        }

        private void buttonSaveSession_Click(object sender, EventArgs e)
        {
            DBTest[0] = playerTablesToManage;
            DBTest[1] = itemsTablesToManage;
        }
    }
}
