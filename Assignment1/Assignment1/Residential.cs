/*********************************************************************************************************
 *                                                                                                       *
 *  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 1					 Spring 2020     *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: Residential
 *  Purpose   : Console application that displays the property details of Dekalb Community.				 *
 *********************************************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    // Residential class; derived from the Property class
    // @Base class: Property Class
    public class Residential : Property
    {
        private uint bedrooms;
        private uint baths;
        private uint sqft;

        // Constructor, sets base class and adds values to attr
        // @params: String array
        public Residential(string[] args) : base(args) //modified by Xuezhi, I think this part still has problem
        {
            bedrooms = Convert.ToUInt32(args[9]);
            baths = Convert.ToUInt32(args[10]);
            sqft = Convert.ToUInt32(args[11]);
        }

        // Property for bedrooms attr
        // allows: set && get
        public uint Bedrooms
        {
            set { bedrooms = value; }
            get { return bedrooms; }
        }

        // Property for baths attr
        // allows: set && get
        public uint Baths
        {
            set { baths = value; }
            get { return baths; }
        }

        // Property for sqft attr
        // allows: set && get
        public uint Sqft
        {
            set { sqft = value; }
            get { return sqft; }
        }
    }

}
