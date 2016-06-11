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
    public partial class ConnectionBetweenPlayerAndItems : UserControl, BasicConnectionInterface
    {
        #region Properties

        public Table currentlySelectedPlayerTable
        {
            get; set;            
        }

        public Table currentlySelectedItemTable
        {
            get; set;
        }
        #endregion

        #region Callbacks

        public event EventHandler deleteMe;

        #endregion

        private List<Table> playerTablesToConnect;

        private List<Table> itemTablesToConnect;

        public ConnectionBetweenPlayerAndItems(List<Table> playerTables, List<Table> itemTables, EventHandler DeleteCallback)
        {
            InitializeComponent();
            playerTablesToConnect = playerTables;
            itemTablesToConnect = itemTables;
            deleteMe = DeleteCallback;
            foreach (Table tab in playerTables)
            {
                comboBoxPlayerTables.Items.Add(tab.tableName);
            }
            foreach (Table tab in itemTables)
            {
                comboBoxItemTables.Items.Add(tab.tableName);
            }
            if(comboBoxPlayerTables.Items.Count>0)
                comboBoxPlayerTables.SelectedItem = comboBoxPlayerTables.Items[0];
            if (comboBoxItemTables.Items.Count > 0)
                comboBoxItemTables.SelectedItem = comboBoxItemTables.Items[0];
        }

        public ConnectionsInTables getConnection()
        {
            return new ConnectionsInTables(currentlySelectedPlayerTable, currentlySelectedItemTable, ConnectionsInTables.ConnectionType.GA);

        }

        public void setLocationY(int locationY)
        {
            Location = new Point(Location.X, locationY);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            deleteMe(this, new EventArgs());
        }

        private void comboBoxPlayerTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Table item in playerTablesToConnect)
            {
                if(item.tableName == comboBoxPlayerTables.SelectedItem.ToString())
                {
                    currentlySelectedPlayerTable = item;
                    return;
                }
            }
        }

        private void comboBoxItemTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Table item in itemTablesToConnect)
            {
                if (item.tableName == comboBoxItemTables.SelectedItem.ToString())
                {
                    currentlySelectedItemTable = item;
                    return;
                }
            }
        }

        public void setTables(Table player, Table item)
        {
            currentlySelectedPlayerTable = player;
            currentlySelectedItemTable = item;
            comboBoxPlayerTables.SelectedItem = player.tableName;
            comboBoxItemTables.SelectedItem = item.tableName;
        }
    }
}
