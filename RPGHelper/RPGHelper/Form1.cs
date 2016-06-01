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
    public partial class RPGHelperMainWindow : Form
    {
        #region Properties

        #endregion

        private Control activeControl;

        public RPGHelperMainWindow()
        {
            InitializeComponent();
        }

        private void RPGHelperMainWindow_Load(object sender, EventArgs e)
        {
            activeControl = new MainMenuControl(CreateSession,LoadSession,Exit);
            Controls.Add(activeControl);
        }

        private void Exit()
        {
            Close();
        }

        private void CreateSession()
        {
            var response = MessageBox.Show("Czy chcesz skorzystać z szablonu sesji?", "Użyć szablonu?", MessageBoxButtons.YesNoCancel);
            if (response == DialogResult.Yes)
            {
                //Use preset
            }
            else if (response == DialogResult.No)
            {
                //Database creation
                activeControl.Dispose();
                activeControl = new SessionCreator(databaseWasCreated);
                Controls.Add(activeControl);
            }
        }

        private void LoadSession()
        {
            //Loading session from XML preset
        }

        private void databaseWasCreated(string database)
        {
            activeControl.Dispose();
            if (database == "")
            {
                activeControl = new MainMenuControl(CreateSession, LoadSession, Exit);
                Controls.Add(activeControl);
            }
            else
            {
                activeControl = new ManageSession(endSession, database);
                Controls.Add(activeControl);
            }            
            
        }

        private void endSession()
        {
            activeControl.Dispose();
            activeControl = new MainMenuControl(CreateSession, LoadSession, Exit);

        }
    }
}
