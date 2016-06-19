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

        public string select { get { return this.select; } set { this.select += value; } }

        public string tables { get { return this.tables; } set { this.tables += value; } }

        public string wheres { get { return this.wheres; } set { this.wheres += value; } }

        public string aditionalParameters { get; set; }

        #endregion

        public Query()
        {
            
        }
    }
}
