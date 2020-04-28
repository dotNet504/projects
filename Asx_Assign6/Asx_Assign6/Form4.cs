/*********************************************************************************************************
 *                                                                                                       *
 *  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 6					 Spring 2020     *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: Form4
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
    public partial class Form4 : Form
    {
        private readonly List<DataModel> _lstDataModel;
        
        public Form4(List<DataModel> lstData)
        {
            _lstDataModel = lstData;
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            loadData();
        }

        //Method to load data
        private void loadData()
        {
            chart1.Titles.Add("Point Chart of Annual Population per Country ");
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Country";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Population";

            var countryQ = from country in _lstDataModel
                           where (country.CountryCode == "USA" ||  country.CountryCode == "CHN" ||  country.CountryCode == "GBR" ||
            country.CountryCode == "AUS" || country.CountryCode == "NGA" || country.CountryCode == "BEN" )
                           select country;

            foreach (var c in countryQ)
            {
                chart1.Series["2006"].Points.AddXY(c.CountryName, c.PopulationIn2006);
                chart1.Series["2007"].Points.AddXY(c.CountryName, c.PopulationIn2007);
                chart1.Series["2008"].Points.AddXY(c.CountryName, c.PopulationIn2008);
                chart1.Series["2009"].Points.AddXY(c.CountryName, c.PopulationIn2009);
                chart1.Series["2010"].Points.AddXY(c.CountryName, c.PopulationIn2010);
                chart1.Series["2011"].Points.AddXY(c.CountryName, c.PopulationIn2011);
                chart1.Series["2012"].Points.AddXY(c.CountryName, c.PopulationIn2012);
                chart1.Series["2013"].Points.AddXY(c.CountryName, c.PopulationIn2013);
                chart1.Series["2014"].Points.AddXY(c.CountryName, c.PopulationIn2014);
                chart1.Series["2015"].Points.AddXY(c.CountryName, c.PopulationIn2015);
            }

        }

        //Method invoked on Exit button click
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        //Method to show the portal form
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Form1().Show();
        }
    }
}
