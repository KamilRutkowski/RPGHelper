using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Status: completed

namespace RPGHelper
{
    public partial class ColumnCreator : UserControl
    {
        #region Properties
        /// <summary>
        /// Name of column to create
        /// </summary>
        public string columnName
        {
            get { return textBoxName.Text; }
            set { textBoxName.Text = value; }
        }

        /// <summary>
        /// Type of column to create
        /// </summary>
        public Column.ColumnType type
        {
            get { return (Column.ColumnType)Enum.Parse(typeof(Column.ColumnType), comboBoxTypeOfColumn.Text); }
            set
            {
                comboBoxTypeOfColumn.Text = Enum.GetName(typeof(Column.ColumnType), value);
                if (value == Column.ColumnType.Enum) buttonEnum.Visible = true;
            }
        }

        /// <summary>
        /// Values in enum, empty when type is not enum
        /// </summary>
        public List<string> enumValues { get; set; }

        #endregion

        #region Callbacks

        private myDelegate deleteMe { get; set; }

        #endregion

        public delegate void myDelegate(Control sender);
        private List<char> notAllowedCharacters;

        public ColumnCreator(myDelegate deleteCallback)
        {
            InitializeComponent();
            buttonEnum.Visible = false;
            notAllowedCharacters = new List<char>(new char[] { ' ', '_', '*' });
            enumValues = new List<string>();
            //Adding enum options
            foreach (Column.ColumnType a in Enum.GetValues(typeof(Column.ColumnType)))
            {
                comboBoxTypeOfColumn.Items.Add(a);
            }
            comboBoxTypeOfColumn.SelectedItem = comboBoxTypeOfColumn.Items[0];
            deleteMe = deleteCallback;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxTypeOfColumn.SelectedItem.ToString() == Column.ColumnType.Enum.ToString())
            {
                buttonEnum.Visible = true;
            }
            else
            {
                buttonEnum.Visible = false;
            }
            type = (Column.ColumnType)Enum.Parse(typeof(Column.ColumnType),comboBoxTypeOfColumn.SelectedItem.ToString(),true);
            if(!buttonEnum.Visible && (enumValues.Count > 0))
            {
                enumValues.Clear();
            }
        }

        private void buttonEnum_Click(object sender, EventArgs e)
        {
            ListOfItemsInEnum enumForm = new ListOfItemsInEnum(enumValuesCallback, enumValues);
            enumForm.Show();
        }

        private void enumValuesCallback(List<string> values)
        {
            enumValues = values;
        }

        /// <summary>
        /// Creates a Column object from this control
        /// </summary>
        /// <returns></returns>
        public Column createColumn()
        {
            Column createdColumn = new Column();
            createdColumn.columnName = columnName;
            createdColumn.type = type;
            if (type == Column.ColumnType.Enum) createdColumn.possibleEnumOptions = enumValues;
            return createdColumn;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to remove column " + textBoxName.Text + "?", "Removing column", MessageBoxButtons.YesNo) == DialogResult.Yes)
                deleteMe(this);
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (notAllowedCharacters.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public bool isOK()
        {
            if (textBoxName.Text.Length > 0)
            {
                if (comboBoxTypeOfColumn.SelectedItem.ToString() == "Enum")
                {
                    if (enumValues.Count > 0)
                    { return true; }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
