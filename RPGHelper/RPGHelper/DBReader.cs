using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RPGHelper
{
    public class DBReader
    {
        #region Properties

        public List<List<Table>> selectedDatabase { get; set; }
        public List<Table> playerTables { get; set; }
        public List<Table> itemsTables { get; set; }

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

        public List<List<Table>> createTestDatabase(string tableName1P, string tableName2P, string tableName1I, string tableName2I,
            string column1P1, string column1P2, string column2P1, string column2P2, string column1I1, string column1I2, string column2I1, string column2I2)
        {
            List<string> tablePlayerNames = new List<string> { tableName1P, tableName2P };
            List<string> tableItemsNames = new List<string> { tableName1I, tableName2I };
            
            Table newTable1 = new Table();
            newTable1.tableName = tablePlayerNames[0];
            newTable1.columnsInTable = createTestColumns(column1P1, column1P2, Column.ColumnType.Number, Column.ColumnType.Enum);

            Table newTable2 = new Table();
            newTable2.tableName = tablePlayerNames[1];
            newTable2.columnsInTable = createTestColumns(column2P1, column2P2, Column.ColumnType.Enum, Column.ColumnType.Text);

            playerTables.Add(newTable1);
            playerTables.Add(newTable2);

            Table newTable3 = new Table();
            newTable3.tableName = tableItemsNames[0];
            newTable3.columnsInTable = createTestColumns(column1I1, column1I2, Column.ColumnType.Enum, Column.ColumnType.Text);

            Table newTable4 = new Table();
            newTable4.tableName = tableItemsNames[1];
            newTable4.columnsInTable = createTestColumns(column2I1, column2I2, Column.ColumnType.Number, Column.ColumnType.Text);

            itemsTables.Add(newTable3);
            itemsTables.Add(newTable4);
            
            selectedDatabase.Add(playerTables);
            selectedDatabase.Add(itemsTables);

            return selectedDatabase;
        }

        private List<Column> createTestColumns(string columnName1, string columnName2, Column.ColumnType type1, Column.ColumnType type2)
        {
            List<Column> columnList = new List<Column>();
            List<string> columnNames = new List<string> { columnName1, columnName2 };
            List<Column.ColumnType> columnTypes = new List<Column.ColumnType> { type1, type2 };

            foreach (var name in columnNames)
            {
                Column newColumn = new Column();
                newColumn.columnName = name;
                newColumn.type = columnTypes[0];
                if(newColumn.type == Column.ColumnType.Enum)
                {
                    List<string> testEnumOptions = new List<string> { "Test1", "Test2", "Test3", "Test 4" };
                    newColumn.possibleEnumOptions = testEnumOptions;
                }
                columnTypes.RemoveAt(0);
                columnList.Add(newColumn);
            }
            return columnList;
        }
    }
}
