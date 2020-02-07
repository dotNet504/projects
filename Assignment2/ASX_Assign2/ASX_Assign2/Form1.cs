using DataLoader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASX_Assign2
{
    public partial class Form1 : Form
    {
        private BusinessLayer _businessLayer;
        public Form1()
        {
            InitializeComponent();
            _businessLayer = new BusinessLayer();
            // Create method in Business Layer and use in this form for future re-usability
        }

        private void DekalbButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SycamoreButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
