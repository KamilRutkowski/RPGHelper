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
    public abstract partial class BasicRelationControl : UserControl
    {
        public event myDelegate DeleteMe;

        public BasicRelationControl()
        {
            InitializeComponent();
        }

        public delegate void myDelegate(object sender);

        public abstract ConnectionsInTables getConnection();
    }
}
