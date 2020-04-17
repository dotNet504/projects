/*********************************************************************************************************
 *                                                                                                       *
 *  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 5					 Spring 2020     *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: Pieces
 *  Purpose   : Implementation of chess game using windows application.                                  *
 *********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asx_Assign5
{
    public class Pieces
    {
        public string Name { get; set; }
        public Image Icon { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool? isPositionChanged { get; set; }
    }
}
