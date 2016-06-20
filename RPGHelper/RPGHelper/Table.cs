using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper
{
    public class Table
    {
        #region Properties

        public string tableName { get; set; }

        public List<Column> columnsInTable { get; set; }

        #endregion

        public Table()
        {
            columnsInTable = new List<Column>();
        }

        public void addColumn(Column askedColumn)
        {
            foreach (Column col in columnsInTable)
            {
                if((col.columnName == askedColumn.columnName)&&(col.type == askedColumn.type))
                {
                    if(col.type == Column.ColumnType.Enum)
                    {
                        col.possibleEnumOptions = askedColumn.possibleEnumOptions;
                    }
                    return;
                }
            }
            columnsInTable.Add(askedColumn);
        }
    }
}
