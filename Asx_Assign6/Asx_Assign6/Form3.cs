/*********************************************************************************************************
 *                                                                                                       *
 *  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 6					 Spring 2020     *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: Form3
 *  Purpose   : Implementation of different Charts.                                                      *
 *********************************************************************************************************/

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
    public partial class Form3 : Form
    {
        private List<DataModel> _lstDataModel;
        public Form3(List<DataModel> lstData)
        {
            _lstDataModel = lstData;
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            SplineChart();
        }

        //Method to populate Spline chart
        private void SplineChart()
        {            
            chart1.Titles.Add("Population Spline Chart");
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Country";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Population";
            var filteredCountries = _lstDataModel.Where(x => x.CountryCode == "USA" || 
            x.CountryCode == "IND" || x.CountryCode == "CHN" || x.CountryCode == "RUS" || x.CountryCode == "GBR" ||
            x.CountryCode == "AUS" || x.CountryCode == "AFG" || x.CountryCode == "ARE" || x.CountryCode == "BGD");

            foreach (var item in filteredCountries)
            {
                chart1.Series["2011"].Points.AddXY(item.CountryName, item.PopulationIn2011);
                chart1.Series["2012"].Points.AddXY(item.CountryName, item.PopulationIn2012);
                chart1.Series["2013"].Points.AddXY(item.CountryName, item.PopulationIn2013);
                chart1.Series["2014"].Points.AddXY(item.CountryName, item.PopulationIn2014);
                chart1.Series["2015"].Points.AddXY(item.CountryName, item.PopulationIn2015);
            }
        }

        //Method invoked on Exit button click
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            new Form1().Show();
        }
    }
}
