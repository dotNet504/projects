using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Asx_Assign6
{
    public partial class Form1 : Form
    {
        private readonly List<DataModel> _lstDataModel;
        public Form1()
        {
            _lstDataModel = new List<DataModel>();
            InitializeComponent();
            InitializeData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 chart1 = new Form2(_lstDataModel);
            chart1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 chart2 = new Form3(_lstDataModel);            
            chart2.ShowDialog();
            // Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 chart3 = new Form4(_lstDataModel);
            chart3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 chart4 = new Form5(_lstDataModel);
            chart4.Visible = true;
        }

        private void InitializeData()
        {
            string path = @"../../../Asx_Assign6/InputFiles/PopulationByCountry.csv";

            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                if (columns[0] == "Country") continue;
                var pop2011 = !string.IsNullOrEmpty(columns[53]) ? Convert.ToDecimal(columns[53]) : 0;
                var pop2012 = !string.IsNullOrEmpty(columns[54]) ? Convert.ToDecimal(columns[54]) : 0;
                var pop2013 = !string.IsNullOrEmpty(columns[55]) ? Convert.ToDecimal(columns[55]) : 0;
                var pop2014 = !string.IsNullOrEmpty(columns[56]) ? Convert.ToDecimal(columns[56]) : 0;
                var pop2015 = !string.IsNullOrEmpty(columns[57]) ? Convert.ToDecimal(columns[57]) : 0;

                var dataModel = new DataModel
                {
                    CountryName = columns[0],
                    CountryCode = columns[1],
                    PopulationIn2011 = Convert.ToInt64(decimal.Truncate(pop2011)),
                    PopulationIn2012 = Convert.ToInt64(decimal.Truncate(pop2012)),
                    PopulationIn2013 = Convert.ToInt64(decimal.Truncate(pop2013)),
                    PopulationIn2014 = Convert.ToInt64(decimal.Truncate(pop2014)),
                    PopulationIn2015 = Convert.ToInt64(decimal.Truncate(pop2015))
                };
                _lstDataModel.Add(dataModel);
            }
        }
    }
}
