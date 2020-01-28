/*********************************************************************************************************
 *                                                                                                       *
 *  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 1					 Spring 2020     *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: Apartment
 *  Purpose   : Console application that displays the property details of Dekalb Community.				 *
 *********************************************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    
    public class Apartment : Residential 
    {
        private string unit;


        public string Unit
        {
            set { unit = value; }
            get { return unit; }
        }
        public Apartment(string[] args) : base(args)
        {
            unit = args[12];
        }
        public override string ToString()
        {
            string ret = String.Format("Id         : {0 , -10 }\n", Id);
            ret += String.Format("OwnerID  : {0}\n", OwnerID);
            ret += String.Format("Forsale   : {0}\n", ForSale);
            ret += String.Format("Unit   : {0}\n", unit);
            return ret;
        }



    }
}
