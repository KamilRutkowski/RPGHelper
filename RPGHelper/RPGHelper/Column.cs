using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper
{
    public abstract class Column
    {
        #region Properties

        public string columnName{ get; set; }
        
        public ColumnType type { get; set; }

        #endregion
        public enum ColumnType
        { Number, Text, Enum }

        public abstract string createMySQLColumn();
    }
}
