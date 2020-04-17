/*********************************************************************************************************
 *                                                                                                       *
 *  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 5					 Spring 2020     *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: Program
 *  Purpose   : Implementation of chess game using windows application.                                  *
 *********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asx_Assign5
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
