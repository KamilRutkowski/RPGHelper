using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper
{
    public interface BasicConnectionInterface
    {
        ConnectionsInTables getConnection();
        void setLocationY(int locationY);

        #region callbacks
        
        event EventHandler deleteMe;
        
        #endregion
    }
}
