using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RPGHelper
{
    public partial class ItemShow : Form
    {
        #region MyProperties

        private string DBName;
        private string tableName;
        private string playerName;
        private string itemsTableName;

        private List<string> columnsInNormalTable;
        private List<string> columnsInItemsTable;

        MySqlConnection connection;
        MySqlDataAdapter adapter;
        DataTable dataSet;

        #endregion

        public ItemShow(string dataBaseName, string entityName, string forName, string itemsName)
        {
            InitializeComponent();
            DBName = dataBaseName;
            tableName = entityName;
            playerName = forName;
            itemsTableName = itemsName;
        }

        private void ItemShow_Load(object sender, EventArgs e)
        {
            textBoxTableName.Text = itemsTableName;
            textBoxFor.Text = playerName;
            newConnection(DBName);
            refreshTable();
        }

        private void newConnection(string databaseName)
        {
            connection = DBReader.connectionCreator(databaseName);
            try
            {
                DBReader.connectionOpen(connection);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBReader.connectionEnd(connection);
            }
        }

        private void refreshTable()
        {
            try
            {
                DBReader.connectionOpen(connection);
                adapter = new MySqlDataAdapter();
                adapter.SelectCommand = DBReader.commandForTheWholeTable(connection, itemsTableName);

                dataSet = new DataTable();
                adapter.Fill(dataSet);
                BindingSource source = new BindingSource();

                source.DataSource = dataSet;
                dataGridViewItems.DataSource = source;
                adapter.Update(dataSet);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBReader.connectionEnd(connection);
            }
        }

        private void dataGridViewItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            List<string> listOfLabelNames = new List<string>();
            List<string> listOfTextBoxNames = new List<string>();
            listOfLabelNames = getColumnsInBothTables(tableName, itemsTableName);
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewItems.Rows[e.RowIndex];
                foreach (string value in listOfLabelNames)
                {
                    string newRowValue = "";
                    newRowValue = row.Cells[value].Value.ToString();
                    listOfTextBoxNames.Add(newRowValue);
                }
            }
            AddItem addItemForm = new AddItem(DBName, tableName, playerName, itemsTableName, listOfLabelNames, listOfTextBoxNames);
            addItemForm.Show();
        }

        private List<string> getColumnsInBothTables(string normalName, string itemsName)
        {
            List<string> columnsInBothTables = new List<string>();
            columnsInNormalTable = new List<string>();
            columnsInItemsTable = new List<string>();

            columnsInNormalTable = DBReader.selectAllColumnNames(connection, normalName);
            columnsInItemsTable = DBReader.selectAllColumnNames(connection, itemsName);

            foreach (string value in columnsInNormalTable)
            {
                for (int i = 0; i < columnsInItemsTable.Count(); i++)
                {
                    if (value == columnsInItemsTable[i])
                    {
                        columnsInBothTables.Add(value);
                    }
                }
            }
            return columnsInBothTables;
        }


    }
}
