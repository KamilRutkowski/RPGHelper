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
    public partial class EntityManager : Form
    {
        #region MyProperties

        MySqlConnection connection;

        private string DBName;
        private string tableName;

        #endregion

        /// <summary>
        /// Form for inserting/updating/deleting rows in table
        /// </summary>
        /// <param name="dataBaseName">Selected column name</param>
        /// <param name="entityName">Selected column name</param>
        public EntityManager(string dataBaseName, string entityName)
        {
            InitializeComponent();
            DBName = dataBaseName;
            tableName = entityName;
        }

        /// <summary>
        /// Opens everything when EntityManager is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EntityManager_Load(object sender, EventArgs e)
        {
            namesToTextBoxes();

            connection = DBReader.connectionCreator(DBName);
            try
            {
                DBReader.connectionOpen(connection);
                addNewRowEditor();
                placeRowEditors();
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

        /// <summary>
        /// Loads database and table names to TextBoxes
        /// </summary>
        private void namesToTextBoxes()
        {
            textBoxDatabase.Text = DBName;
            textBoxEntity.Text = tableName;
        }

        /// <summary>
        /// Adds new RowEditor controls to splitContainer's Panel2
        /// </summary>
        private void addNewRowEditor()
        {
            List<string> allColumns = DBReader.selectAllColumnNames(connection, textBoxEntity.Text);
            for (int i = 0; i < allColumns.Count(); i++)
            {
                RowEditor editor = new RowEditor(allColumns[i]);
                splitContainer.Panel2.Controls.Add(editor);
            }
        }

        /// <summary>
        /// Places RowEditors in different positions
        /// </summary>
        private void placeRowEditors()
        {
            int basePositionY = 27;
            foreach (Control editorControl in splitContainer.Panel2.Controls)
            {
                if (editorControl is RowEditor)
                {
                    editorControl.Location = new Point(editorControl.Location.X, basePositionY);
                    basePositionY += 45;
                    editorControl.Visible = true;
                }
            }
        }

        /// <summary>
        /// Inserts values in table when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string columnValuesForInsert = "";
            string textBoxValuesForInsert = "'";
            try
            {
                DBReader.connectionOpen(connection);
                foreach (string columnName in DBReader.selectAllColumnNames(connection, textBoxEntity.Text))
                {
                    columnValuesForInsert += columnName + ", ";
                }
                columnValuesForInsert = columnValuesForInsert.Remove(columnValuesForInsert.Length - 2);

                foreach (RowEditor editorControl in splitContainer.Panel2.Controls)
                {
                    textBoxValuesForInsert += editorControl.valueName + "','";
                }
                textBoxValuesForInsert = textBoxValuesForInsert.Remove(textBoxValuesForInsert.Length - 2);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBReader.connectionEnd(connection);
            }

            string commandText = "insert into " + textBoxEntity.Text + " (" + columnValuesForInsert + ") values(" + textBoxValuesForInsert + ");";
            MySqlCommand insertCommand = new MySqlCommand(commandText, connection);
            MySqlDataReader reader;

            try
            {
                DBReader.connectionOpen(connection);
                reader = insertCommand.ExecuteReader();
                MessageBox.Show("Data was added to the " + textBoxEntity.Text);
                while (reader.Read())
                {

                }
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

        /// <summary>
        /// Updates values in table when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string columnAndTextBoxValuesForUpdate = "";
            List<RowEditor> listOfRowEditors = new List<RowEditor>();
            List<string> listOfColumns = new List<string>();
            try
            {
                DBReader.connectionOpen(connection);
                listOfColumns = DBReader.selectAllColumnNames(connection, textBoxEntity.Text);

                foreach (RowEditor editorControl in splitContainer.Panel2.Controls)
                {
                    listOfRowEditors.Add(editorControl);
                }

                for (int i = 0; i < listOfColumns.Count(); i++)
                {
                    columnAndTextBoxValuesForUpdate += DBReader.selectAllColumnNames(connection, textBoxEntity.Text)[i] + "='" + listOfRowEditors[i].valueName + "',";
                }
                columnAndTextBoxValuesForUpdate = columnAndTextBoxValuesForUpdate.Remove(columnAndTextBoxValuesForUpdate.Length - 1);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBReader.connectionEnd(connection);
            }

            string commandText = "update " + textBoxEntity.Text + " set " + columnAndTextBoxValuesForUpdate + "where " + listOfColumns[0] + "='" + listOfRowEditors[0].valueName + "' ;";
            MySqlCommand updateCommand = new MySqlCommand(commandText, connection);
            MySqlDataReader reader;

            try
            {
                DBReader.connectionOpen(connection);
                reader = updateCommand.ExecuteReader();
                MessageBox.Show("Data was updated");
                while (reader.Read())
                {
                    
                }
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

        /// <summary>
        /// Deletes values in table when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            List<RowEditor> listOfRowEditors = new List<RowEditor>();
            List<string> listOfColumns = new List<string>();

            try
            {
                DBReader.connectionOpen(connection);
                listOfColumns = DBReader.selectAllColumnNames(connection, textBoxEntity.Text);

                foreach (RowEditor editorControl in splitContainer.Panel2.Controls)
                {
                    listOfRowEditors.Add(editorControl);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBReader.connectionEnd(connection);
            }

            string commandText = "delete from " + textBoxEntity.Text + " where " + listOfColumns[0] + "='" + listOfRowEditors[0].valueName + "' ;";
            MySqlCommand deleteCommand = new MySqlCommand(commandText, connection);
            MySqlDataReader reader;

            try
            {
                DBReader.connectionOpen(connection);
                reader = deleteCommand.ExecuteReader();
                MessageBox.Show("Data was deleted");
                while (reader.Read())
                {

                }
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

        /// <summary>
        /// Closes EntityManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFinish_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
