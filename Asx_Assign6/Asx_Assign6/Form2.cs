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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private readonly List<DataModel> _lstDataModel;
        public Form2(List<DataModel> lstData)
        {
            _lstDataModel = lstData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}
