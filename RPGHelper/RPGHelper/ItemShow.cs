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

        MySqlConnection connection;
        MySqlDataAdapter adapter;
        DataTable dataSet;

        #endregion

        public ItemShow(string dataBaseName, string entityName, string forName)
        {
            InitializeComponent();
            DBName = dataBaseName;
            tableName = entityName;
            playerName = forName;
        }

        private void ItemShow_Load(object sender, EventArgs e)
        {
            textBoxTableName.Text = tableName;
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
                adapter.SelectCommand = DBReader.commandForTheWholeTable(connection, tableName);

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

        private void dataGridViewItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("DZIAŁA!", "New database", MessageBoxButtons.OK);
            AddItem addItemForm = new AddItem(DBName, tableName, playerName);
            addItemForm.Show();
        }
    }
}
