/*********************************************************************************************************
 *                                                                                                       *
 *  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 6					 Spring 2020     *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: Form2
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
using System.IO;

namespace Asx_Assign6
{
    public partial class Form2 : Form
    {
        string[] heartRate = File.ReadAllLines(@"../../../Asx_Assign6/InputFiles/heartratedata.txt");


        public Form2(List<DataModel> lstData)
        {            
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            chart1.ChartAreas[0].AxisX.Maximum = 24;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 300;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Title = "Time";

            chart1.Titles.Add("Heart Rate Varies Throughout the Day(Beats/Minute)");

            int i = 0;
            chart1.Series["Rabbit"].BorderWidth = 5;
            chart1.Series["Human"].BorderWidth = 5;
            chart1.Series["Bird"].BorderWidth = 5;


            foreach (var item in heartRate)
            {
                i = i + 2;
                string[] hearts = item.Split(',');
                chart1.Series["Rabbit"].Points.AddXY(i, Convert.ToUInt32(hearts[0]));
                chart1.Series["Human"].Points.AddXY(i, Convert.ToUInt32(hearts[1]));
                chart1.Series["Bird"].Points.AddXY(i, Convert.ToUInt32(hearts[2]));

            }

            
        }

        //Method invoked on Exit button click
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }


    }
}
