using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Make connection tree for player tables
/// </summary>
namespace RPGHelper
{
    public class TreeOfConnections
    {
        #region Properties

        public TreeOfConnections parentNode { get; set; }

        public Table currentBranchTable { get; set; }

        public int levelOfTree { get; set; }


        /// <summary>
        /// This to upper
        /// </summary>
        public ConnectionsInTables.ConnectionType connectionTypeToUpperLevel { get; set; }

        public List<TreeOfConnections> branches; 

        #endregion

        public TreeOfConnections(Table branchTable, int branchLevel = 0)
        {
            branches = new List<TreeOfConnections>();
            currentBranchTable = branchTable;
            levelOfTree = branchLevel;
        }

        public TreeOfConnections(Table branchTable,TreeOfConnections parent)
        {
            branches = new List<TreeOfConnections>();
            currentBranchTable = branchTable;
            levelOfTree = parent.levelOfTree + 1;
            parentNode = parent;
        }

        /// <summary>
        /// Tries to set tree of connections
        /// </summary>
        /// <param name="connection">List of connections to place in table</param>
        /// <returns>IF connections are set correctly then it returns true. Otherwise, returns false</returns>
        public bool setConnections(List<ConnectionsInTables> connection)
        {
            List<ConnectionsInTables> unhandledConnections = new List<ConnectionsInTables>(connection);
            int lastNumberOfHandledConnections = unhandledConnections.Count;
            while(unhandledConnections.Count > 0)
            {
                for(int i = 0; i<unhandledConnections.Count;)
                {
                    ConnectionsInTables tmp = unhandledConnections[i];
                    if(tmp.type == ConnectionsInTables.ConnectionType.GA)
                    {
                        if(isInTree(tmp.sourceTable))
                        {
                            TreeOfConnections tmpTreeConnection = getConnection(tmp.sourceTable);
                            TreeOfConnections newBranch = new TreeOfConnections(tmp.targetTable, tmpTreeConnection);
                            newBranch.connectionTypeToUpperLevel = tmp.type;
                            tmpTreeConnection.branches.Add(newBranch);
                            unhandledConnections.Remove(tmp);
                            continue;
                        }
                    }
                    if(isInTree(tmp.sourceTable))
                    {
                        if(isInTree(tmp.targetTable))
                        {
                            unhandledConnections.Remove(tmp);
                            continue;
                        }
                        TreeOfConnections tmpTreeConnection = getConnection(tmp.sourceTable);
                        TreeOfConnections newBranch = new TreeOfConnections(tmp.targetTable, tmpTreeConnection);
                        newBranch.connectionTypeToUpperLevel = reverseColumnType(tmp.type);
                        tmpTreeConnection.branches.Add(newBranch);
                        unhandledConnections.Remove(tmp);
                        continue;
                    }
                    else if(isInTree(tmp.targetTable))
                    {
                        TreeOfConnections tmpTreeConnection = getConnection(tmp.targetTable);
                        TreeOfConnections newBranch = new TreeOfConnections(tmp.sourceTable, tmpTreeConnection);
                        newBranch.connectionTypeToUpperLevel = tmp.type;
                        tmpTreeConnection.branches.Add(newBranch);
                        unhandledConnections.Remove(tmp);
                        continue;
                    }
                    else
                    {
                        i++;
                    }
                }
                if (lastNumberOfHandledConnections > unhandledConnections.Count)
                    lastNumberOfHandledConnections = unhandledConnections.Count;
                else
                    return false;
            }
            return true;
        }

        public bool isInTree(Table searchedTable)
        {
            if(currentBranchTable == searchedTable)
               return true;
            foreach (TreeOfConnections branch in branches)
            {
                if (branch.isInTree(searchedTable) == true)
                   return true;
            }
            return false;
        }

        public TreeOfConnections getConnection(Table searchedTable)
        {
            if (!isInTree(searchedTable))
                throw new Exception("This connection does not exists.");
            if (currentBranchTable == searchedTable)
                return this;
            List<TreeOfConnections> currentBranches = branches;
            while (true)
            {
                foreach (TreeOfConnections con in currentBranches)
                {
                    if (con.isInTree(searchedTable))
                        return con.getConnection(searchedTable);
                }
            }
            throw new Exception("Connection does not exist!");
        }
        
        private ConnectionsInTables.ConnectionType reverseColumnType(ConnectionsInTables.ConnectionType type)
        {
            if (type == ConnectionsInTables.ConnectionType.MTO)
            {
                return ConnectionsInTables.ConnectionType.OTM;
            }
            else if (type == ConnectionsInTables.ConnectionType.OTM)
            {
                return ConnectionsInTables.ConnectionType.MTO;
            }
            else
                return type;
        }
    }
}
