/*********************************************************************************************************
 *                                                                                                       *
 *  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 2					 Spring 2020     *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: Person
 *  Purpose   : Windows application that displays the property details of Dekalb & Sycamore Communities. *
 *********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader
{
    //Person class, it stores generic info a person could possess  
    // @implements : IComparable for the "CompareTo" method
    public class Person : IComparable
    {
        //Attributes of the Person Class 
        private readonly uint id;
        private string firstName;
        private string lastName;
        private string occupation;
        private readonly DateTime birthday;
        private List<uint> residenceIds = new List<uint>();

        // Implements CompareTo using FullName,
        //      property as main sorting criteria
        // @returns -> int result of comparison
        // Exception if( Null object found )
        public int CompareTo(Object alpha)
        {
            if (alpha == null) throw new ArgumentNullException("Person object being compared with is NULL");

            Person rightOp = alpha as Person;

            if (rightOp != null)
                return FullName.CompareTo(rightOp.FullName);
            else
                throw new ArgumentNullException("[Person]: CompareTo argument is not a Person");
        }

        // Override ToString method
        // Stringifies object in a well, 
        //     formatted way.
        public override string ToString()
        {             
             return this.Occupation.Length < 13 ? this.Occupation : this.Occupation.Substring(0, 11) + "...";

        }

        //Default constructor
        public Person()
        {
            id = 0;
            this.LastName = this.FirstName = this.Occupation = "";
            birthday = new DateTime(0, 0, 0);
        }

        // Alternate constrictor, allows user add defaults
        // @params: String Array, broken down within the 
        //          constructor to fill attr values
        // Exception if( birthday is in future && if ID value isn't valid )
        public Person(string[] args)
        {
            uint ID = Convert.ToUInt32(args[0]);
            LastName = args[1];
            FirstName = args[2];
            Occupation = args[3];
            int year = Convert.ToInt32(args[4]);
            int month = Convert.ToInt32(args[5]);
            int day = Convert.ToInt32(args[6]);
            residenceIds.Add(Convert.ToUInt32(args[7]));
            //For Sycamore community - a person has multiple residences which is another argument in input file.
            if(args.Length == 9)
                residenceIds.Add(Convert.ToUInt32(args[8]));
                

            DateTime birth = new DateTime(year, month, day);

            if (birth <= DateTime.Now)
            {
                birthday = birth;
            }
            else
            {
                throw new ArgumentNullException("Birthday provided is in the future");
            }

            if (ID > 99999 || ID < 0)
            {
                throw new ArgumentNullException("Invalid ID provided, should be within 0 - 99999");
            }
            else
            {
                id = ID;
            }
        }

        // Property for firstName attr
        // allows: set && get
        public string FirstName
        {
            get => firstName;
            set { firstName = value; }
        }

        // Property for lastName attr
        // allows: set && get
        public string LastName
        {
            get => lastName;
            set { lastName = value; }
        }

        // Property for occupation attr
        // allows: set && get
        public string Occupation
        {
            get => occupation;
            set { occupation = value; }
        }

        //get-only prop for id attr
        public uint Id => id;

        //get-only prop for the residenceID 
        //public uint[] ResidenceIds => residenceIds.ToArray();
        public List<uint> ResidenceIds
        {
            get
            {
                return residenceIds;
            }
            set { residenceIds = value; }
        }

        //ge-only prop for birthday date obj
        public DateTime Birthday => birthday;

        // get-only property for lastName
        //  and firstName concatenate
        public string FullName => LastName + ", " + FirstName;

        
    }
}
