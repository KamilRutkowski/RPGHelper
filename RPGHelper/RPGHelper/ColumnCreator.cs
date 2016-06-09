using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGHelper
{
    public partial class ColumnCreator : UserControl
    {
        #region Properties
        /// <summary>
        /// Name of column to create
        /// </summary>
        public string columnName { get; set; }

        /// <summary>
        /// Type of column to create
        /// </summary>
        public Column.ColumnType type { get; set; }

        /// <summary>
        /// Values in enum, empty when type is not enum
        /// </summary>
        public List<string> enumValues { get; set; }

        #endregion



        public ColumnCreator()
        {
            InitializeComponent();
            //Adding enum options
            comboBoxTypeOfColumn.Items.Add(Column.ColumnType.Number.ToString());
            comboBoxTypeOfColumn.Items.Add(Column.ColumnType.Text.ToString());
            comboBoxTypeOfColumn.Items.Add(Column.ColumnType.Enum.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxTypeOfColumn.SelectedItem.ToString() == Column.ColumnType.Enum.ToString())
            {
                buttonEnum.Visible = true;
            }
            type = (Column.ColumnType)Enum.Parse(typeof(Column.ColumnType),comboBoxTypeOfColumn.SelectedItem.ToString(),true);
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

        private void ColumnCreator_Load(object sender, EventArgs e)
        {
            buttonEnum.Visible = false;
            enumValues = new List<string>();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
