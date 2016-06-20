using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper
{
    public class Query
    {
        #region Properties

        public string queryName { get; set; }

        public string select { get; set; }

        public string tables { get; set; }

        public string wheres { get; set; }
        
        public bool isPlayerType { get; set; }

        #endregion

        public Query(bool type)
        {
            isPlayerType = type;
        }
    }
}
