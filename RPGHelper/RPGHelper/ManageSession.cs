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
    public partial class ManageSession : UserControl
    {
        #region Properties

        public myActionDelegate registerEndSession
        {
            get; set;
        }

        #endregion

        public delegate void myActionDelegate();

        public ManageSession(myActionDelegate endSession ,string databaseName)
        {
            InitializeComponent();
        }

        private void ManageSession_Load(object sender, EventArgs e)
        {

        }
    }
}
