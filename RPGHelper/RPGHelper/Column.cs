using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper
{
    public class Column
    {
        #region Properties

        public string columnName { get; set; }
        
        public ColumnType type { get; set; }

        public List<string> possibleEnumOptions { get; set; }

        #endregion
        public enum ColumnType
        { Number, Text, Enum }

        public Column()
        { }
    }
}
