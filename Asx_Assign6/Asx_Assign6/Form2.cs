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

        private readonly List<DataModel> _lstDataModel;
        public Form2(List<DataModel> lstData)
        {
            _lstDataModel = lstData;
            InitializeComponent();



            chart1.Series["Series1"].Points.AddXY(0, 5);
            chart1.Series["Series1"].Points.AddXY(10, 3);
            chart1.Series["Series1"].Points.AddXY(150 ,5);
            chart1.Series["Series1"].Points.AddXY(200, 2);
            chart1.Series["Series1"].Points.AddXY(300, 2);
            chart1.Series["Series1"].Points.AddXY(900, 6);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}
