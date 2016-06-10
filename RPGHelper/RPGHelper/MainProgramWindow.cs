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
            //Creation of first state of program -> main menu
            activeControl = new MainMenuControl(CreateSession,LoadSession,Exit);
            Controls.Add(activeControl);
        }

        private void Exit()
        {
            Close();
        }

        /// <summary>
        /// Creating session process
        /// </summary>
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


        /// <summary>
        /// Loading session from xml preset
        /// </summary>
        private void LoadSession()
        {
            var response = MessageBox.Show("Czy chcesz wczytać testową sesję?", "Wczytać testową sesję?", MessageBoxButtons.YesNoCancel);
            if(response == DialogResult.Yes)
            {
                //Do testów
                activeControl.Dispose();
                activeControl = new ManageSession(endSession, "Test");
                Controls.Add(activeControl);
            }
            if(response == DialogResult.No)
            {

            }
        }

        /// <summary>
        /// Callback for event of database creation process
        /// </summary>
        /// <param name="database">Name of database, if database == "" then user exited the process of database creation</param>
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

        /// <summary>
        /// Callback for ending session in session manager process
        /// </summary>
        private void endSession()
        {
            activeControl.Dispose();
            activeControl = new MainMenuControl(CreateSession, LoadSession, Exit);

        }
    }
}
