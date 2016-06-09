using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGHelper
{
    public partial class AddTableName : Form
    {
        #region Callbacks

        private myDelegate registerTableNameCalback { get; set; }

        #endregion

        public delegate void myDelegate(string tableName);

        public AddTableName(myDelegate tableNameCallback)
        {
            InitializeComponent();
            registerTableNameCalback = tableNameCallback;
        }

        private void buttonNameTable_Click(object sender, EventArgs e)
        {
            if (textBoxTableName.Text.Trim() == "") 
            {
                MessageBox.Show("Table name can not be left blank!", "No table name", MessageBoxButtons.OK);
                return;
            }
            if (textBoxTableName.Text.Contains("_"))
            {
                MessageBox.Show("Table name can not contain \"_\"!", "Invalid table name", MessageBoxButtons.OK);
                return;
            }
            registerTableNameCalback(textBoxTableName.Text);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            registerTableNameCalback("");
            Close();
        }
    }
}
