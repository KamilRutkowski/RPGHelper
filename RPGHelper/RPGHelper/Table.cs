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
    }
}
