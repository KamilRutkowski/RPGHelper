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
    public partial class AddItem : Form
    {
        #region MyProperties

        MySqlConnection connection;

        private string DBName;
        private string tableName;
        private string playerName;
        private string itemsTableName;

        private List<string> valuesInLabels;
        private List<string> valuesInTextBoxes;

        #endregion

        public AddItem(string dataBaseName, string entityName, string forName, string itemsName,
            List<string> labelItems, List<string> textBoxItems)
        {
            InitializeComponent();
            valuesInLabels = labelItems;
            valuesInTextBoxes = textBoxItems;
            DBName = dataBaseName;
            tableName = entityName;
            playerName = forName;
            itemsTableName = itemsName;
        }

        private void AddItem_Load(object sender, EventArgs e)
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

        private void namesToTextBoxes()
        {
            textBoxEntity.Text = tableName;
            textBoxFor.Text = playerName;
        }

        private void addNewRowEditor()
        {
            for (int i = 0; i < valuesInLabels.Count(); i++)
            {
                RowEditor editor = new RowEditor(valuesInLabels[i], "");
                editor.valueName = valuesInTextBoxes[i];
                splitContainer1.Panel2.Controls.Add(editor);
            }
        }

        private void placeRowEditors()
        {
            int basePositionY = 27;
            foreach (Control editorControl in splitContainer1.Panel2.Controls)
            {
                if (editorControl is RowEditor)
                {
                    editorControl.Location = new Point(editorControl.Location.X, basePositionY);
                    basePositionY += 45;
                    editorControl.Visible = true;
                }
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string columnValuesForInsert = "";
            string textBoxValuesForInsert = "'";
            try
            {
                DBReader.connectionOpen(connection);
                foreach (string columnName in DBReader.selectAllColumnNames(connection, tableName))
                {
                    columnValuesForInsert += columnName + ", ";
                }
                columnValuesForInsert = columnValuesForInsert.Remove(columnValuesForInsert.Length - 2);

                foreach (RowEditor editorControl in splitContainer1.Panel2.Controls)
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

            string commandText = "insert into " + tableName + " (" + columnValuesForInsert + ") values(" + textBoxValuesForInsert + ");";
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

    }
}
