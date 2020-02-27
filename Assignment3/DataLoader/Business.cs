/*********************************************************************************************************
 *                                                                                                       *
 *  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 3					 Spring 2020     *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: Business
 *  Purpose   : Windows application that displays the Business details of Dekalb & Sycamore Communities. *
 *********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader
{
    public class Business : Property
    {
        //variables declaration
        private String name;
        private readonly BusinessType type;
        private readonly string yearEstablished;
        private uint activeRecruitment;
        
        //enumerator declaration
        public enum BusinessType { Grocery, Bank, Repair, FastFood, Department_Store };

        //Constructor with arguments
        public Business(String[] args) : base(args)
        {
            name = args[9];
            type = ((BusinessType)Convert.ToUInt32(args[10]));
            yearEstablished = args[11];
            activeRecruitment = Convert.ToUInt32(args[12]);

        }

        //getter and setter for Name
        public String Name
        {
            set { name = value; }
            get { return name; }
        }

        //getter and setter for Type
        public BusinessType Type
        {
            get { return type; }
        }

        //Getter for YearEstablished readonly property
        public String YearEstablished
        {
            get { return yearEstablished; }
        }

        //getter and setter for ActiveRecruitment
        public uint ActiveRecruitment
        {
            set { activeRecruitment = value; }
            get { return activeRecruitment; }
        }
    }
}
