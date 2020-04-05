/*********************************************************************************************************
 *                                                                                                       *
 *  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 4					 Spring 2020     *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: School
 *  Purpose   : Windows application that displays the property details of Dekalb & Sycamore Communities. *
 *              The properties are plotted as map.                                                       *
 *********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader
{
    public class School : Property
    {
        //variables declaration
        private string name;
        private readonly SchoolType type;
        private string yearEstablished;
        private uint enrolled;
        //enumerator declaration
        public enum SchoolType { Elementary, HighSchool, CommunityCollege, University }

        //Constructor with arguments
        public School(string[] args) : base(args)
        {
            name = args[9];
            yearEstablished = args[10];
            enrolled = Convert.ToUInt32(args[11]);
        }

        //getter and setter for Name
        public String Name
        {
            set { name = value; }
            get { return name; }
        }

        //getter for Type readonly property
        public SchoolType Type
        {            
            get { return type; }
        }

        //getter for YearEstablished readonly property
        public String YearEstablished
        {
            get { return yearEstablished; }
        }

        //getter and setter for Enrolled
        public uint Enrolled
        {
            set { enrolled = value; }
            get { return enrolled; }
        }
    }
}
