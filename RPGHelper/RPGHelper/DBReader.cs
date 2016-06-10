using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGHelper
{
    public class DBReader
    {
        #region Properties

        private List<List<Table>> selectedDatabase { get; set; }
        private List<Table> playerTables { get; set; }
        private List<Table> itemsTables { get; set; }

        public ToolStripMenuItem lowItem { get; set; }
        public ToolStripMenuItem lowerItem { get; set; }
        public ToolStripMenuItem lowestItem { get; set; }
        #endregion

        public DBReader()
        {
            selectedDatabase = new List<List<Table>>();
            playerTables = new List<Table>();
            itemsTables = new List<Table>();
        }

        public List<List<Table>> createTestDatabase(string tableName1P, string tableName2P, string tableName1I, string tableName2I)
        {
            List<string> tablePlayerNames = new List<string> { tableName1P, tableName2P };
            List<string> tableItemsNames = new List<string> { tableName1I, tableName2I };
            
            foreach (var name in tablePlayerNames)
            {
                Table newTable = new Table();
                newTable.tableName = name;
                newTable.columnsInTable = createTestColumns("Players", "HP", "DP");

                foreach (Column column in newTable.columnsInTable)
                {
                    List<string> valuesInColumns = new List<string> { "Salmon", "GroupBy", "OrderBy" };
                    column.possibleEnumOptions = valuesInColumns;
                }

                playerTables.Add(newTable);
            }

            foreach (var name in tableItemsNames)
            {
                Table newTable = new Table();
                newTable.tableName = name;
                newTable.columnsInTable = createTestColumns("Items", "SP", "Attack");

                foreach (Column column in newTable.columnsInTable)
                {
                    List<string> valuesInColumns = new List<string> { "Magic Missle", "Scissor Blade", "Random Gun" };
                    column.possibleEnumOptions = valuesInColumns;
                }

                itemsTables.Add(newTable);
            }
            selectedDatabase.Add(playerTables);
            selectedDatabase.Add(itemsTables);

            return selectedDatabase;
        }

        private List<Column> createTestColumns(string columnName1, string columnName2, string columnName3)
        {
            List<Column> columnList = new List<Column>();
            List<string> columnNames = new List<string> { columnName1, columnName2, columnName3 };

            foreach (var name in columnNames)
            {
                Column newColumn = new Column();
                newColumn.columnName = name;
                columnList.Add(newColumn);
            }
            return columnList;
        }

        public void readDatabase(ToolStripMenuItem playerItem, ToolStripMenuItem itemsItem, List<List<Table>> database, EventHandler menu_Click)
        {
            database[0] = playerTables;
            database[0] = itemsTables;

            foreach(Table table in playerTables)
            {
                lowItem = new ToolStripMenuItem { Name = table.tableName, Text = table.tableName };
                playerItem.DropDownItems.AddRange(new ToolStripItem[] { lowItem });

                foreach(Column column in table.columnsInTable)
                {
                    lowerItem = new ToolStripMenuItem { Name = column.columnName, Text = column.columnName };
                    lowItem.DropDownItems.AddRange(new ToolStripItem[] { lowerItem });

                    foreach (string value in column.possibleEnumOptions)
                    {
                        lowestItem = new ToolStripMenuItem { Name = value, Text = value };
                        lowerItem.DropDownItems.AddRange(new ToolStripItem[] { lowestItem });

                        lowestItem.Click += new EventHandler(menu_Click);
                    }
                }
            }

            foreach (Table table in itemsTables)
            {
                lowItem = new ToolStripMenuItem { Name = table.tableName, Text = table.tableName };
                itemsItem.DropDownItems.AddRange(new ToolStripItem[] { lowItem });

                foreach (Column column in table.columnsInTable)
                {
                    lowerItem = new ToolStripMenuItem { Name = column.columnName, Text = column.columnName };
                    lowItem.DropDownItems.AddRange(new ToolStripItem[] { lowerItem });

                    foreach (string value in column.possibleEnumOptions)
                    {
                        lowestItem = new ToolStripMenuItem { Name = value, Text = value };
                        lowerItem.DropDownItems.AddRange(new ToolStripItem[] { lowestItem });

                        lowestItem.Click += new EventHandler(menu_Click);
                    }
                }
            }
        }
        
        public void readingMySqlFile()
        {
            OpenFileDialog openFileBox = new OpenFileDialog();
            openFileBox.Filter = "SQL Files|*.sql";
            if (openFileBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
            }
        }
    }
}
