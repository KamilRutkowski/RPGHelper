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

        private List<Table> AdditionalTablesToCreate { get; set; }

        private MySqlConnection connectionWithDB { get; set; }

        private List<string> additionalForeignKeys { get; set; }

        #endregion


        public DBCreator(TreeOfConnections connectionsInTables, string dataName)
        {
            List<Query> queriesToDatabase = new List<Query>();
            AdditionalTablesToCreate = new List<Table>();
            additionalForeignKeys = new List<string>();
            dataName = "RPGH" + dataName;
            createDatabase(dataName);
            setPrefixes(connectionsInTables);
            makeConnectionInDatabase(queriesToDatabase, connectionsInTables);
            addIDs(connectionsInTables);
            connectionWithDB.Open(); 
            createTables(connectionsInTables);
            createAdditionalTables();
            createProcedures(queriesToDatabase);
            addForeignKeys();
            connectionWithDB.Close();
        }

        private void addForeignKeys()
        {
            foreach (string command in additionalForeignKeys)
            {
                MySqlCommand com = new MySqlCommand(command, connectionWithDB);
                com.ExecuteNonQuery();
            }
        }

private void addIDs(TreeOfConnections connectionsInTables)
        {
            Column col = new Column();
            col.columnName = "id_";
            col.type = Column.ColumnType.Number;
            connectionsInTables.currentBranchTable.addColumn(col);
            foreach(TreeOfConnections con in connectionsInTables.branches)
            {
                addIDs(con);
            }
        }

        private void createProcedures(List<Query> queriesToDatabase)
        {
            foreach (Query queryToMake in queriesToDatabase)
            {
                if(queryToMake.isPlayerType)
                {
                    createMySQLProcedureForPlayer(queryToMake);
                }
                else
                {
                    createMySQLProcedureForItem(queryToMake);
                }
            }
        }

        private void createMySQLProcedureForItem(Query queryToMake)
        {
            string command = "Create procedure " + queryToMake.queryName + "() Select \"" + queryToMake.select + "\"";
            MySqlCommand com = new MySqlCommand(command, connectionWithDB);
            com.ExecuteNonQuery();
        }

        private void createMySQLProcedureForPlayer(Query queryToMake)
        {
            string command = "Create procedure " + queryToMake.queryName + "(playerID int) Select " + queryToMake.select + " from " 
                + queryToMake.tables + " where " + queryToMake.wheres + " and PlayersMainPlayers.id_ = playerID;";
            MySqlCommand com = new MySqlCommand(command, connectionWithDB);
            com.ExecuteNonQuery();
        }

        private void createAdditionalTables()
        {
            foreach(Table tab in AdditionalTablesToCreate)
            {
                string command = "Create table " + tab.tableName + "(";
                foreach (Column col in tab.columnsInTable)
                {
                    command += col.columnName;
                    string que = "Alter table " + tab.tableName + " add constraint fk_" + col.columnName + " foreign key (" + col.columnName
                    +") References " + col.columnName.Substring(6) + "(id_);";
                    additionalForeignKeys.Add(que);
                    switch (col.type)
                    {
                        case Column.ColumnType.Enum:
                            {
                                command += " enum(";
                                foreach(string option in col.possibleEnumOptions)
                                {
                                    command += "\"" + option + "\"";
                                    if (col.possibleEnumOptions.Last() != option)
                                        command += ",";
                                }
                                command += ")";
                                break;
                            }
                        case Column.ColumnType.Number:
                            {
                                command += " int";
                                break;
                            }
                        case Column.ColumnType.Text:
                            {
                                command += " varchar(100)";
                                break;
                            }
                        default:
                            {
                                throw new Exception("Whoops! Something went wrong!");
                            }
                    }
                    if(col != tab.columnsInTable.Last())
                    {
                        command += ",";
                    }
                }
                command += ");";
                MySqlCommand com = new MySqlCommand(command, connectionWithDB);
                com.ExecuteNonQuery();
            }
        }

        private void createTables(TreeOfConnections connections)
        {
            Table tab = connections.currentBranchTable;
            string command = "Create table " + tab.tableName + "(";
            foreach (Column col in tab.columnsInTable)
            {
                command += col.columnName;
                if (col.columnName.StartsWith("id_") && (col.columnName != "id_"))
                {
                    string que = "Alter table " + tab.tableName + " add constraint fk_" + col.columnName + " foreign key (" + col.columnName
                    + ") References " + col.columnName.Substring(6) + "(id_);";
                    additionalForeignKeys.Add(que);
                }
                switch (col.type)
                {
                    case Column.ColumnType.Enum:
                        {
                            command += " enum(";
                            foreach (string option in col.possibleEnumOptions)
                            {
                                command += "\"" + option + "\"";
                                if (col.possibleEnumOptions.Last() != option)
                                    command += ",";
                            }
                            command += ")";
                            break;
                        }
                    case Column.ColumnType.Number:
                        {
                            command += " int";
                            break;
                        }
                    case Column.ColumnType.Text:
                        {
                            command += " varchar(100)";
                            break;
                        }
                    default:
                        {
                            throw new Exception("Whoops! Something went wrong!");
                        }
                }
                if(col.columnName == "id_")
                {
                    command += " primary key auto_increment";
                }
                if (col != tab.columnsInTable.Last())
                {
                    command += ",";
                }
            }
            command += ");";
            MySqlCommand com = new MySqlCommand(command, connectionWithDB);
            com.ExecuteNonQuery();
            foreach(TreeOfConnections tree in connections.branches)
            {
                createTables(tree);
            }
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
                        currentQuery.tables += currentNode.parentNode.currentBranchTable.tableName + ", " + currentNode.currentBranchTable.tableName;
                        currentQuery.wheres += 
                            currentNode.currentBranchTable.tableName + ".id_For" + currentNode.parentNode.currentBranchTable.tableName
                            + "  = " + currentNode.parentNode.currentBranchTable.tableName + ".id_For" + currentNode.currentBranchTable.tableName;
                        currentQuery.select = currentNode.currentBranchTable.tableName + ".* ";
                        currentQuery.queryName = "ShowForPlayer" + currentNode.currentBranchTable.tableName;
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
                        currentQuery.tables += currentNode.parentNode.currentBranchTable.tableName + ", " + currentNode.currentBranchTable.tableName;
                        currentQuery.wheres +=
                            currentNode.currentBranchTable.tableName + ".id_"
                            + "  = " + currentNode.parentNode.currentBranchTable.tableName + ".id_For" + currentNode.currentBranchTable.tableName;
                        currentQuery.select = currentNode.currentBranchTable.tableName + ".* ";
                        currentQuery.queryName = "ShowForPlayer" + currentNode.currentBranchTable.tableName;
                        Column col = new Column();
                        col.columnName = "id_For" + currentNode.currentBranchTable.tableName;
                        col.type = Column.ColumnType.Number;
                        currentNode.parentNode.currentBranchTable.addColumn(col);
                        break;
                    }
                case ConnectionsInTables.ConnectionType.MTO:
                    {
                        currentQuery.tables += currentNode.parentNode.currentBranchTable.tableName + ", " + currentNode.currentBranchTable.tableName;
                        currentQuery.wheres +=
                            currentNode.currentBranchTable.tableName + ".id_For" + currentNode.parentNode.currentBranchTable.tableName
                            + "  = " + currentNode.parentNode.currentBranchTable.tableName + ".id_";
                        currentQuery.select = currentNode.currentBranchTable.tableName + ".* ";
                        currentQuery.queryName = "ShowForPlayer" + currentNode.currentBranchTable.tableName;
                        Column col = new Column();
                        col.columnName = "id_For" + currentNode.parentNode.currentBranchTable.tableName;
                        col.type = Column.ColumnType.Number;
                        currentNode.currentBranchTable.addColumn(col);
                        break;
                    }
                case ConnectionsInTables.ConnectionType.MTM:
                    {
                        string connectorTableName = "Connector" + currentNode.parentNode.currentBranchTable.tableName + currentNode.currentBranchTable.tableName;
                        currentQuery.tables += currentNode.parentNode.currentBranchTable.tableName + ", " + connectorTableName + ", " + currentNode.currentBranchTable.tableName;
                        currentQuery.wheres += 
                            connectorTableName + ".id_For" + currentNode.parentNode.currentBranchTable.tableName + " = "
                            + currentNode.parentNode.currentBranchTable.tableName + ".id_ and " +
                            connectorTableName + ".id_For" + currentNode.currentBranchTable.tableName + " = "
                            + currentNode.currentBranchTable.tableName + ".id_";
                        currentQuery.select = currentNode.currentBranchTable.tableName + ".* ";
                        currentQuery.queryName = "ShowForPlayer" + currentNode.currentBranchTable.tableName;
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
                currentNode.parentNode.currentBranchTable.addColumn(col);
            }
            Query currentQuery = new Query(false);
            currentQuery.queryName = "GetItemsFor" + currentNode.parentNode.currentBranchTable.tableName;
            if (currentNode.parentNode.currentBranchTable.tableName == "Players")
                currentQuery.queryName = "GetItemsFor" + currentNode.parentNode.currentBranchTable.tableName;
            currentQuery.select = "" + currentNode.currentBranchTable.tableName;
            return currentQuery;
        }

        private void createDatabase(string name)
        {
            string Server = "127.0.0.1";
            string User = "root";
            string Passwd = "";
            uint Port = 3306;
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = Server;
            builder.UserID = User;
            builder.Password = Passwd;
            builder.Port = Port;
            MySqlConnection conn = new MySqlConnection(builder.ConnectionString);
            conn.Open();
            string queryText = "Create database if not exists " + name + ";";
            MySqlCommand command = new MySqlCommand(queryText, conn);
            command.ExecuteReader();
            conn.Close();
            builder.Database = name;
            connectionWithDB = new MySqlConnection(builder.ConnectionString);
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

        /// <summary>
        /// Checks if asked database exists
        /// </summary>
        /// <param name="databaseName">Database name you are searching for</param>
        /// <returns>True if it exists, otherwise false</returns>
        public static bool doesDatabaseExists(string databaseName)
        {
            string Server = "127.0.0.1";
            string User = "root";
            string Passwd = "";
            uint Port = 3306;
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = Server;
            builder.UserID = User;
            builder.Password = Passwd;
            builder.Port = Port;
            MySqlConnection conn = new MySqlConnection(builder.ConnectionString);
            conn.Open();
            string queryText = "Show databases;";
            MySqlCommand command = new MySqlCommand(queryText, conn);
            MySqlDataReader databases = command.ExecuteReader();
            databaseName = databaseName.ToLower();
            if(databases.HasRows)
            {
                while (databases.Read())
                {
                    if (databases.GetString(0) == databaseName)
                    {
                        conn.Close();
                        return true;
                    }
                }
            }
            conn.Close();
            return false;
        }
    }
}
