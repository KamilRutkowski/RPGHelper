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
    public partial class ConnectionBetweenPlayerTables : UserControl, BasicConnectionInterface
    {
        #region Properties

        public string firstConnectionCount
        {
            set
            {
                if (comboBoxFirstTableConnectionCount.Items.Contains(value))
                    comboBoxFirstTableConnectionCount.SelectedItem = value;
            }
            get
            {
                return comboBoxFirstTableConnectionCount.SelectedItem.ToString();
            }
        }

        public string secondConnectionCount
        {
            set
            {
                if (comboBoxSecondTableConnectionCount.Items.Contains(value))
                    comboBoxSecondTableConnectionCount.SelectedItem = value;
            }
            get
            {
                return comboBoxSecondTableConnectionCount.SelectedItem.ToString();
            }
        }

        public Table firstTable
        {
            get; set;
        }

        public Table secondTable
        {
            get; set;
        }

        #endregion

        #region Callbacks

        public event EventHandler deleteMe;

        #endregion

        private List<Table> playerTablesToConnect;

        public ConnectionBetweenPlayerTables(List<Table> playerTables, EventHandler DeleteMeCallback)
        {
            InitializeComponent();
            playerTablesToConnect = playerTables;
            deleteMe = DeleteMeCallback;
            List<string> tmpList = new List<string>();
            foreach (Table tmp in playerTables)
            {
                tmpList.Add(tmp.tableName);
            }
            //Filing first table list 
            comboBoxFirstTable.Items.AddRange(tmpList.ToArray());
            if(comboBoxFirstTable.Items.Count>0)
                comboBoxFirstTable.SelectedItem = comboBoxFirstTable.Items[0];
            //Filing second table list
            comboBoxSecondTable.Items.Clear();
            comboBoxSecondTable.Items.AddRange(tmpList.ToArray());
            comboBoxSecondTable.Items.Remove(comboBoxFirstTable.SelectedItem);
            if (comboBoxSecondTable.Items.Count > 0)
                comboBoxSecondTable.SelectedItem = comboBoxSecondTable.Items[0];
            comboBoxFirstTableConnectionCount.SelectedItem = comboBoxFirstTableConnectionCount.Items[0];
            comboBoxSecondTableConnectionCount.SelectedItem = comboBoxSecondTableConnectionCount.Items[0];
        }

        public ConnectionsInTables getConnection()
        {
            if(firstConnectionCount == "1")
            {
                if(secondConnectionCount == "1")
                {
                    return new ConnectionsInTables(firstTable, secondTable, ConnectionsInTables.ConnectionType.OTO);
                }
                else
                {
                    return new ConnectionsInTables(firstTable, secondTable, ConnectionsInTables.ConnectionType.OTM);
                }
            }
            else
            {
                if (secondConnectionCount == "1")
                {
                    return new ConnectionsInTables(firstTable, secondTable, ConnectionsInTables.ConnectionType.MTO);
                }
                else
                {
                    return new ConnectionsInTables(firstTable, secondTable, ConnectionsInTables.ConnectionType.MTM);
                }
            }
        }

        public void setLocationY(int locationY)
        {
            Location = new Point(Location.X, locationY);
        }

        private void buttonRemoveConnection_Click(object sender, EventArgs e)
        {
            deleteMe(this, new EventArgs());
        }

        private void comboBoxFirstTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Table item in playerTablesToConnect)
            {
                if(item.tableName == comboBoxFirstTable.SelectedItem.ToString())
                {
                    firstTable = item;
                    List<string> tmpList = new List<string>();
                    foreach (Table tmp in playerTablesToConnect)
                    {
                        tmpList.Add(tmp.tableName);
                    }
                    comboBoxSecondTable.Items.Clear();
                    comboBoxSecondTable.Items.AddRange(tmpList.ToArray());
                    comboBoxSecondTable.Items.Remove(comboBoxFirstTable.SelectedItem);
                    if (comboBoxSecondTable.Items.Count > 0)
                        comboBoxSecondTable.SelectedItem = comboBoxSecondTable.Items[0];
                    return;
                }
            }
        }

        private void comboBoxSecondTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Table item in playerTablesToConnect)
            {
                if (item.tableName == comboBoxSecondTable.SelectedItem.ToString())
                {
                    secondTable = item;
                    return;
                }
            }
        }

        public void setTables(Table tableOne, Table tableTwo, string relationOne, string relationTwo)
        {
            firstConnectionCount = relationOne;
            secondConnectionCount = relationTwo;
            firstTable = tableOne;
            secondTable = tableTwo;
            comboBoxFirstTable.SelectedItem = tableOne.tableName;
            comboBoxSecondTable.SelectedItem = tableTwo.tableName;
        }
    }
}
