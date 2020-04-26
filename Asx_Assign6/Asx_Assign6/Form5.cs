using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asx_Assign6
{
    public partial class Form5 : Form
    {
        private readonly List<DataModel> _lstDataModel;
        public Form5()
        {
            InitializeComponent();
        }
        public Form5(List<DataModel> lstData)
        {
            _lstDataModel = lstData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
