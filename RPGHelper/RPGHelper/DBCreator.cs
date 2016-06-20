using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


/// <summary>
/// DOdać prawidłowe selecty i nazwy procedur
/// Utworzenie procedur na podstawie queriesToDatabase
/// Dokończenie komunikacji z bazą
/// </summary>
namespace RPGHelper
{
    public class DBCreator
    {
        #region Properties
        
        public string databaseName { get; set; }

        private List<Table> AdditionalTablesToCreate { get; set; }
        
        #endregion


        public DBCreator(TreeOfConnections connectionsInTables, string dataName)
        {
            List<Query> queriesToDatabase = new List<Query>();
            AdditionalTablesToCreate = new List<Table>();
            createDatabase(dataName);
            setPrefixes(connectionsInTables);
            makeConnectionInDatabase(queriesToDatabase, connectionsInTables);
            addIDs(connectionsInTables);
            createTables();
            createAdditionalTables();
            createProcedures(queriesToDatabase);
        }

        private void addIDs(TreeOfConnections connectionsInTables)
        {
            throw new NotImplementedException();
        }

        private void createProcedures(List<Query> queriesToDatabase)
        {
            throw new NotImplementedException();
        }

        private void createAdditionalTables()
        {
            throw new NotImplementedException();
        }

        private void createTables()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DO NOT CALL IT ON YOUR OWN! It's a part of createMajorProcedureForPlayer, and it's not supposed to be used alone
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="currentQuery"></param>
        private void createProcedureForPlayer(TreeOfConnections currentNode, Query currentQuery)
        {
            switch (currentNode.connectionTypeToUpperLevel)
            {
                case ConnectionsInTables.ConnectionType.OTO:
                    {
                        currentQuery.tables += ", " + currentNode.parentNode.currentBranchTable.tableName;
                        currentQuery.wheres += " and "
                            + currentNode.currentBranchTable.tableName + ".id_For" + currentNode.parentNode.currentBranchTable.tableName
                            + "  = " + currentNode.parentNode.currentBranchTable.tableName + ".id_For" + currentNode.currentBranchTable.tableName;

                        break;
                    }
                case ConnectionsInTables.ConnectionType.OTM:
                    {
                        currentQuery.tables += ", " + currentNode.parentNode.currentBranchTable.tableName;
                        currentQuery.wheres += " and "
                            + currentNode.currentBranchTable.tableName + ".id_"
                            + "  = " + currentNode.parentNode.currentBranchTable.tableName + ".id_For" + currentNode.currentBranchTable.tableName;
                        break;
                    }
                case ConnectionsInTables.ConnectionType.MTO:
                    {
                        currentQuery.tables += ", " + currentNode.parentNode.currentBranchTable.tableName;
                        currentQuery.wheres += " and "
                            + currentNode.currentBranchTable.tableName + ".id_For" + currentNode.parentNode.currentBranchTable.tableName
                            + "  = " + currentNode.parentNode.currentBranchTable.tableName + ".id_";
                        break;
                    }
                case ConnectionsInTables.ConnectionType.MTM:
                    {
                        string connectorTableName = "Connector" + currentNode.parentNode.currentBranchTable.tableName + currentNode.currentBranchTable.tableName;
                        currentQuery.tables += ", " + currentNode.parentNode.currentBranchTable.tableName + ", " + connectorTableName;
                        currentQuery.wheres += " and " +
                            connectorTableName + ".id_For" + currentNode.parentNode.currentBranchTable.tableName + " = "
                            + currentNode.parentNode.currentBranchTable.tableName + ".id_ and " +
                            connectorTableName + ".id_For" + currentNode.currentBranchTable.tableName + " = "
                            + currentNode.currentBranchTable.tableName + ".id_";
                        break;
                    }
                default:
                    {
                        throw new Exception("Wrong tree structure");
                    }
            }
            if (currentNode.levelOfTree > 1)
            {
                createProcedureForPlayer(currentNode.parentNode, currentQuery);
            }
        }

        /// <summary>
        /// Create ID's for connection and create 
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns></returns>
        private Query createMajorProcedureForPlayer(TreeOfConnections currentNode)
        {
            Query currentQuery = new Query(true);
            switch (currentNode.connectionTypeToUpperLevel)
            {
                case ConnectionsInTables.ConnectionType.OTO:
                    {
                        currentQuery.tables += currentNode.parentNode.currentBranchTable.tableName;
                        currentQuery.wheres += 
                            currentNode.currentBranchTable.tableName + ".id_For" + currentNode.parentNode.currentBranchTable.tableName
                            + "  = " + currentNode.parentNode.currentBranchTable.tableName + ".id_For" + currentNode.currentBranchTable.tableName;
                        Column col = new Column();
                        col.columnName = "id_For" + currentNode.parentNode.currentBranchTable.tableName;
                        col.type = Column.ColumnType.Number;
                        currentNode.currentBranchTable.addColumn(col);
                        col = new Column();
                        col.columnName = "id_For" + currentNode.currentBranchTable.tableName;
                        col.type = Column.ColumnType.Number;
                        currentNode.parentNode.currentBranchTable.addColumn(col);
                        break;
                    }
                case ConnectionsInTables.ConnectionType.OTM:
                    {
                        currentQuery.tables += currentNode.parentNode.currentBranchTable.tableName;
                        currentQuery.wheres +=
                            currentNode.currentBranchTable.tableName + ".id_"
                            + "  = " + currentNode.parentNode.currentBranchTable.tableName + ".id_For" + currentNode.currentBranchTable.tableName;
                        Column col = new Column();
                        col.columnName = "id_For" + currentNode.currentBranchTable.tableName;
                        col.type = Column.ColumnType.Number;
                        currentNode.parentNode.currentBranchTable.addColumn(col);
                        break;
                    }
                case ConnectionsInTables.ConnectionType.MTO:
                    {
                        currentQuery.tables += currentNode.parentNode.currentBranchTable.tableName;
                        currentQuery.wheres +=
                            currentNode.currentBranchTable.tableName + ".id_For" + currentNode.parentNode.currentBranchTable.tableName
                            + "  = " + currentNode.parentNode.currentBranchTable.tableName + ".id_";
                        Column col = new Column();
                        col.columnName = "id_For" + currentNode.parentNode.currentBranchTable.tableName;
                        col.type = Column.ColumnType.Number;
                        currentNode.currentBranchTable.addColumn(col);
                        break;
                    }
                case ConnectionsInTables.ConnectionType.MTM:
                    {
                        string connectorTableName = "Connector" + currentNode.parentNode.currentBranchTable.tableName + currentNode.currentBranchTable.tableName;
                        currentQuery.tables += currentNode.parentNode.currentBranchTable.tableName + ", " + connectorTableName;
                        currentQuery.wheres += 
                            connectorTableName + ".id_For" + currentNode.parentNode.currentBranchTable.tableName + " = "
                            + currentNode.parentNode.currentBranchTable.tableName + ".id_ and " +
                            connectorTableName + ".id_For" + currentNode.currentBranchTable.tableName + " = "
                            + currentNode.currentBranchTable.tableName + ".id_";
                        Table tab = new Table();
                        tab.tableName = connectorTableName;
                        Column col = new Column();
                        col.columnName = "id_For" + currentNode.parentNode.currentBranchTable.tableName;
                        col.type = Column.ColumnType.Number;
                        tab.addColumn(col);
                        col = new Column();
                        col.columnName = "id_For" + currentNode.currentBranchTable.tableName;
                        col.type = Column.ColumnType.Number;
                        tab.addColumn(col);
                        AdditionalTablesToCreate.Add(tab);
                        break;
                    }
                default:
                    {
                        throw new Exception("Wrong tree structure");
                    }
            }
            if(currentNode.levelOfTree > 1)
            {
                createProcedureForPlayer(currentNode.parentNode, currentQuery);
            }
            return currentQuery;
        }

        private Query createProcedureForItems(TreeOfConnections currentNode)
        {
            foreach (Column col in currentNode.currentBranchTable.columnsInTable)
            {
                for(int i=0;i< currentNode.parentNode.currentBranchTable.columnsInTable.Count;i++)
                {
                    Column colInParent = currentNode.parentNode.currentBranchTable.columnsInTable[i];
                    if ((col.columnName == colInParent.columnName)&&(col.type==colInParent.type))
                    {
                        if(col.type == Column.ColumnType.Enum)
                        {
                            colInParent.possibleEnumOptions = col.possibleEnumOptions;
                        }
                        continue;
                    }
                    currentNode.parentNode.currentBranchTable.columnsInTable.Add(col);
                }
            }
            Query currentQuery = new Query(false);
            if (currentNode.parentNode.currentBranchTable.tableName == "Players")
                currentQuery.queryName = "GetItemsFor" + currentNode.parentNode.currentBranchTable.tableName;
            currentQuery.select = "" + currentNode.currentBranchTable.tableName;
            return currentQuery;
        }

        private void createDatabase(string name)
        {
            //string 
        }

        private void makeConnectionInDatabase(List<Query> querries, TreeOfConnections node)
        {
            if(node.levelOfTree > 0)
            {
                if (node.currentBranchTable.tableName.StartsWith("Items"))
                    querries.Add(createProcedureForItems(node));
                else
                    querries.Add(createMajorProcedureForPlayer(node));                  
            }
            foreach (TreeOfConnections connection in node.branches)
            {
                makeConnectionInDatabase(querries, connection);
            }
        }

        private void setPrefixes(TreeOfConnections currentNode)
        {
            currentNode.currentBranchTable.tableName = "PlayersMain" + currentNode.currentBranchTable.tableName;
            foreach (TreeOfConnections item in currentNode.branches)
            {
                setPrefixesMinor(item);
            }
        }

        private void setPrefixesMinor(TreeOfConnections currentNode)
        {
            if (currentNode.connectionTypeToUpperLevel != ConnectionsInTables.ConnectionType.GA)
                currentNode.currentBranchTable.tableName = "PlayersSub" + currentNode.currentBranchTable.tableName;
            else
                currentNode.currentBranchTable.tableName = "Items" + currentNode.currentBranchTable.tableName;
            foreach (TreeOfConnections item in currentNode.branches)
            {
                setPrefixesMinor(item);
            }
        }
    }
}
