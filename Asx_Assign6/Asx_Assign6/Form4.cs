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
    public partial class Form4 : Form
    {
        private readonly List<DataModel> _lstDataModel;
        
        public Form4(List<DataModel> lstData)
        {
            _lstDataModel = lstData;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
