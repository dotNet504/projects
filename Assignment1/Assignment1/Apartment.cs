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

namespace ASX_Assign1
{
    //Apartment class, it stores info a apartment could possess  
    //Apartment class is the son of Residential class 
    public class Apartment : Residential 
    {
        private string unit;

        // Property for unit attr
        // allows: set && get
        public string Unit
        {
            set { unit = value; }
            get { return unit; }
        }

        // constructor for the Apartment class
        // @params: String Array, broken down within the 
        //          constructor to fill attr values
        // Other fields are filled in its base class
        public Apartment(string[] args) : base(args)
        {
            unit = args[12];
        }
        // Tostring method for the Apartment class
        // The purpose of the ToString is to output some fields 
        //         and to test whether house class het all the fields
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
