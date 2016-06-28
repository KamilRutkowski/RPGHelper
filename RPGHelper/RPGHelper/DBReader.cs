using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace RPGHelper
{
    static class DBReader
    {
        #region Properties
        public static string Server { get; set; }
        public static string UserID { get; set; }
        public static string Password { get; set; }
        public static uint Port { get; set; }

        #endregion

        /// <summary>
        /// Class responsible for reading values from various databases
        /// </summary>
        static DBReader()
        {
            Server = "127.0.0.1";
            UserID = "root";
            Password = "";
            Port = 3306;
        }

        /// <summary>
        /// Creates MySql connection
        /// </summary>
        /// <param name="databaseToManage">Name of current database</param>
        public static MySqlConnection connectionCreator(string databaseToManage)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = Server;
            builder.UserID = UserID;
            builder.Password = Password;
            builder.Port = Port;
            builder.Database = databaseToManage;
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            return connection;
        }

        public static MySqlConnection connectionCreatorWithNoDatabase()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = Server;
            builder.UserID = UserID;
            builder.Password = Password;
            builder.Port = Port;
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            return connection;
        }

        /// <summary>
        /// Opens new MySql connection
        /// </summary>
        /// /// <param name="connection">Name of the current MySql connection</param>
        public static void connectionOpen(MySqlConnection connection)
        {
            connection.Open();
        }

        /// <summary>
        /// Closes new MySql connection
        /// </summary>
        /// <param name="connection">Name of the current MySql connection</param>
        public static void connectionEnd(MySqlConnection connection)
        {
            connection.Close();
        }

        /// <summary>
        /// Creates a command to read the whole new table from selected database
        /// </summary>
        /// <param name="connection">Name of the current MySql connection</param>
        /// <param name="selectedTable">Name of the selected table</param>
        public static MySqlCommand commandForTheWholeTable(MySqlConnection connection, string selectedTable)
        {
            string commandText = "select * from " + selectedTable + ";";
            MySqlCommand selectDataBase = new MySqlCommand(commandText, connection);
            return selectDataBase;
        }

        /// <summary>
        /// Selects all database names in MySql
        /// </summary>
        /// <param name="connection">Name of the current MySql connection</param>
        public static List<string> selectAllDatabaseNames(MySqlConnection connection)
        {
            List<string> RPGHDatabases = new List<string>();
            string commandText = "show databases like 'RPGH%';";

            MySqlCommand selectDatabases = new MySqlCommand(commandText, connection);
            MySqlDataReader reader = selectDatabases.ExecuteReader();

            while (reader.Read())
            {
                RPGHDatabases.Add(reader[0].ToString());
            }
            reader.Close();

            return RPGHDatabases;
        }

        /// <summary>
        /// Selects all column names in selected table
        /// </summary>
        /// <param name="connection">Name of the current MySql connection</param>
        /// <param name="entityName">Name of the current table name</param>
        public static List<string> selectAllColumnNames(MySqlConnection connection, string entityName)
        {
            List<string> columns = new List<string>();
            string commandText = "show columns from " + entityName + ";";

            MySqlCommand selectColumnNames = new MySqlCommand(commandText, connection);
            MySqlDataReader reader = selectColumnNames.ExecuteReader();

            while (reader.Read())
            {
                columns.Add(reader[0].ToString());
            }
            reader.Close();

            return columns;
        }

        /// <summary>
        /// Selects main player table names in selected database
        /// </summary>
        /// <param name="connection">Name of the current MySql connection</param>
        /// <param name="databaseName">Name of the current database</param>
        private static string selectMainPlayersTableName(MySqlConnection connection, string databaseName)
        {
            string mainPlayersTable = "";
            string commandText = "show tables from " + databaseName + " like 'PlayersMain%';";

            MySqlCommand selectTableNames = new MySqlCommand(commandText, connection);
            MySqlDataReader reader = selectTableNames.ExecuteReader();

            while (reader.Read())
            {
                mainPlayersTable = reader[0].ToString();
            }
            reader.Close();

            return mainPlayersTable;
        }

        /// <summary>
        /// Selects all sub player table names in selected database
        /// </summary>
        /// <param name="connection">Name of the current MySql connection</param>
        /// <param name="databaseName">Name of the current database</param>
        public static List<string> selectAllPlayersTableNames(MySqlConnection connection, string databaseName)
        {
            List<string> tables = new List<string>();
            tables.Add(selectMainPlayersTableName(connection, databaseName));

            string commandText = "show tables from " + databaseName + " like 'PlayersSub%';";

            MySqlCommand selectTableNames = new MySqlCommand(commandText, connection);
            MySqlDataReader reader = selectTableNames.ExecuteReader();

            while (reader.Read())
            {
                tables.Add(reader[0].ToString());
            }
            reader.Close();

            return tables;
        }

        /// <summary>
        /// Selects all items table names in selected database
        /// </summary>
        /// <param name="connection">Name of the current MySql connection</param>
        /// <param name="databaseName">Name of the current database</param>
        public static List<string> selectAllItemsTableNames(MySqlConnection connection, string databaseName)
        {
            List<string> tables = new List<string>();
            string commandText = "show tables from " + databaseName + " like 'Item%';";

            MySqlCommand selectTableNames = new MySqlCommand(commandText, connection);
            MySqlDataReader reader = selectTableNames.ExecuteReader();

            while (reader.Read())
            {
                tables.Add(reader[0].ToString());
            }
            reader.Close();

            return tables;
        }

        /// <summary>
        /// Selects all connector table names in selected database
        /// </summary>
        /// <param name="connection">Name of the current MySql connection</param>
        /// <param name="databaseName">Name of the current database</param>
        public static List<string> selectAllConnectorTableNames(MySqlConnection connection, string databaseName)
        {
            List<string> tables = new List<string>();
            string commandText = "show tables from " + databaseName + " like 'Connector%';";

            MySqlCommand selectTableNames = new MySqlCommand(commandText, connection);
            MySqlDataReader reader = selectTableNames.ExecuteReader();

            while (reader.Read())
            {
                tables.Add(reader[0].ToString());
            }
            reader.Close();

            return tables;
        }

        public static List<int> selectAllPlayersID(MySqlConnection connection, string databaseName)
        {
            List<int> playersID = new List<int>();
            string commandText = "select id_ from PlayersMainPlayers from" + databaseName +";";

            MySqlCommand selectPlayersID = new MySqlCommand(commandText, connection);
            MySqlDataReader reader = selectPlayersID.ExecuteReader();

            while (reader.Read())
            {
                playersID.Add(Int32.Parse(reader[0].ToString()));
            }
            reader.Close();

            return playersID;
        }
    }
}