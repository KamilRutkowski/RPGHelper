using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHelper
{
    public class ConnectionsInTables
    {
        #region Properties

        public Table sourceTable { get; set; }
        public Table targetTable { get; set; }
        public ConnectionType type { get; set; }

        #endregion
        /// <summary>
        /// Connection type between two tables
        /// </summary>
        public enum ConnectionType
        {
            /// <summary>
            /// One to one
            /// </summary>
            OTO,
            /// <summary>
            /// One to many
            /// </summary>
            OTM,
            /// <summary>
            /// Many to one
            /// </summary>
            MTO,
            /// <summary>
            /// Many to many
            /// </summary>
            MTM,
            /// <summary>
            /// Get all - create a table based on of all colums in other table
            /// 
            /// For examlpe:
            /// PlayerWeapons is based on Weapons
            /// </summary>
            GA };

        public ConnectionsInTables(Table src, Table trg, ConnectionType typeOfConnection)
        {
            sourceTable = src;
            targetTable = trg;
            type = typeOfConnection;
        }
    }
}
