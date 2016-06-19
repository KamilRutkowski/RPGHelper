using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RPGHelper
{
    public class DBCreator
    {
        #region Properties
        
        public string databaseName { get; set; }

        //private 

        #endregion


        public DBCreator(TreeOfConnections connectionsInTables, string dataName)
        {
            List<Query> queriesToDatabase = new List<Query>();
            createDatabase(dataName);
            makeConnectionInDatabase(queriesToDatabase, connectionsInTables);
        }

        /// <summary>
        /// Create ID's for connection and create 
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        private Query createProcedureForPlayer(TreeOfConnections currentNode)
        {
            throw new NotImplementedException();
        }

        private Query createProcedureForItems(TreeOfConnections currentNode)
        {
            throw new NotImplementedException();
        }

        private void createDatabase(string name)
        {
            //string 
        }

        private void makeConnectionInDatabase(List<Query> querries, TreeOfConnections node)
        {
            if(node.levelOfTree > 0)
            {
                //if()
            }
            foreach (TreeOfConnections connection in node.branches)
            {
                makeConnectionInDatabase(querries, connection);
            }
        }
    }
}
