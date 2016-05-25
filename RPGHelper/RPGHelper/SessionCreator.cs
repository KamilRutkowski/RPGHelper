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
    public partial class SessionCreator : UserControl
    {
        #region Properties

        public myActionDelegate registerdatabaseCreated
        {
            get; set;
        }

        #endregion

        public delegate void myActionDelegate(string database);

        public SessionCreator(myActionDelegate databaseCreated)
        {
            InitializeComponent();
        }

        private void SessionCreator_Load(object sender, EventArgs e)
        {

        }
    }
}
