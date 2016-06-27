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
    public partial class SessionManager : UserControl
    {

        private myActionDelegate registerEndSession
        {
            get; set;
        }

        public delegate void myActionDelegate();

        private Control activeControl;
        string databaseName;
        
        public SessionManager(myActionDelegate endSession)
        {
            InitializeComponent();
            databaseName = "";
            registerEndSession = endSession;
            activeControl = new DataBaseNameSelector(stopCreation, goToManage);
            Controls.Add(activeControl);
        }

        private void goToManage(string dataBase)
        {
            databaseName = dataBase;
            activeControl.Dispose();
            activeControl = new ManageSession(stopCreation, databaseName);
            Controls.Add(activeControl);
        }

        private void stopCreation()
        {
            registerEndSession();
        }
    }
}
