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
    public partial class RowEditor : UserControl
    {
        #region MyProperties
        public string valueName
        {
            get { return textBoxValueInRow.Text; }
            set { textBoxValueInRow.Text = value; }
        }

        public string labelName
        {
            get { return labelColumnName.Text; }
            set { labelColumnName.Text = value; }
        }
        #endregion

        string currentPlayer;

        /// <summary>
        /// Control for inserting/updating/deleting each column in table
        /// </summary>
        /// <param name="columnName">Selected column name</param>
        public RowEditor(string columnName, string playerName)
        {
            InitializeComponent();
            labelColumnName.Text = columnName;
            currentPlayer = playerName;
            ifPlayer();
        }

        private void ifPlayer()
        {
            if(currentPlayer.StartsWith("Player "))
            {
                if(labelColumnName.Text == "id_")
                {
                    textBoxValueInRow.Text = currentPlayer.Substring(7, currentPlayer.Length - 7);
                    textBoxValueInRow.Enabled = false;
                }
            }
        }
    }
}