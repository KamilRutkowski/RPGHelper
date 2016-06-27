using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RPGHelper
{
    public partial class DataBaseNameSelector : UserControl
    {
        #region Callbacks
        /// <summary>
        /// Register a callback delegate for buttonBack.Click event 
        /// </summary>
        private myActionDelegate registerBackToMenu
        {
            get; set;
        }

        /// <summary>
        /// Register a callback delegate for next step of creation button
        /// </summary>
        private myActionDelegateWithDatabaseName registerNextStepToManage
        {
            get; set;
        }
        #endregion

        public delegate void myActionDelegate();
        public delegate void myActionDelegateWithDatabaseName(string databaseName);
        MySqlConnection connection;

        public DataBaseNameSelector(myActionDelegate exit, myActionDelegateWithDatabaseName nextStep)
        {
            InitializeComponent();
            registerBackToMenu = exit;
            registerNextStepToManage = nextStep;
        }

        private void DataBaseNameSelector_Load(object sender, EventArgs e)
        {
            connection = DBReader.connectionCreatorWithNoDatabase();
            try
            {
                DBReader.connectionOpen(connection);
                comboBoxFill();
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

        private void comboBoxFill()
        {
            comboBoxSelectDatabase.Items.Clear();
            for (int i = 0; i < DBReader.selectAllDatabaseNames(connection).Count(); i++)
            {
                string newDatabaseName = "";
                newDatabaseName = DBReader.selectAllDatabaseNames(connection)[i];
                comboBoxSelectDatabase.Items.Add(newDatabaseName.Substring(4, newDatabaseName.Length - 4));
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            registerBackToMenu();
        }

        private void buttonToManage_Click(object sender, EventArgs e)
        {
            if(textBoxSelectedDatabase.Text != "")
            {
                string newDataBase = textBoxSelectedDatabase.Text;
                registerNextStepToManage(newDataBase);
            }
            else
            {
                MessageBox.Show("Choose a session to manage!", "Error!", MessageBoxButtons.OK);
            }
        }

        private void comboBoxSelectDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxSelectedDatabase.Text = comboBoxSelectDatabase.SelectedItem.ToString();
        }


    }
}
