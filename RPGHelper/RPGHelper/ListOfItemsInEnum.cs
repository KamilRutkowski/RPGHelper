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
    public partial class ListOfItemsInEnum : Form
    {
        #region Properties

        private myDelegate registerEnumValuesCallback { get; set; }

        #endregion

        public delegate void myDelegate(List<string> enumValues);

        public ListOfItemsInEnum(myDelegate enumValuesCallback, List<string> startingValues)
        {
            InitializeComponent();
            registerEnumValuesCallback = enumValuesCallback;
            if(startingValues.Count > 0 )
                listBoxOptions.Items.AddRange(startingValues.Cast<string>().ToArray());
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBoxInput.Text !="" && !listBoxOptions.Items.Contains(textBoxInput.Text))
            {
                listBoxOptions.Items.Add(textBoxInput.Text);
                textBoxInput.Text = "";
                textBoxInput.Focus();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if(listBoxOptions.SelectedIndex != -1)
            {
                if(DialogResult.Yes == MessageBox.Show("Czy jesteś pewien, że chcesz usunąć: " + listBoxOptions.SelectedItem.ToString(),"Usuwanie elementu",MessageBoxButtons.YesNo))
                {
                    listBoxOptions.Items.Remove(listBoxOptions.SelectedItem);
                }
            }
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            List<string> tmp = listBoxOptions.Items.Cast<string>().ToList();
            registerEnumValuesCallback(tmp);
            Close();
        }
    }
}
