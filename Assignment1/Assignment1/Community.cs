/*********************************************************************************************************
 *                                                                                                       *
 *  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 1					 Spring 2020     *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: Community
 *  Purpose   : Console application that displays the property details of Dekalb Community.				 *
 *********************************************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    //Implements Icomparable and IEnumerable interfaces
    public class Community : IComparable, IEnumerable
    {
        private SortedSet<Property> props;
        private SortedSet<Person> residents;
        private readonly uint id;
        private readonly string name;
        private uint mayorID;

        //Default constructor with no arguments
        public Community()
        {
            props = new SortedSet<Property>();
            residents = new SortedSet<Person>();
            id = 0;
            name = "";
            mayorID = 0;
        }

        //Consturctor with input arguments
        public Community(List<Person> persons, List<House> houses, List<Apartment> apartments, uint ID = 99999, string nme = "Dekalb", uint myor = 0)
        {
            id = ID;
            name = nme;
            mayorID = myor;
            props = new SortedSet<Property>(new PropertyComparer());
            residents = new SortedSet<Person>();
            foreach (var per in persons)
            {
                residents.Add(per);
            }
            foreach (var a in apartments)
            {
                props.Add(a);
            }
            foreach (var h in houses)
            {
                props.Add(h);
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {   
            return (IEnumerator) GetEnumerator();
        }

        public CommEnum GetEnumerator()
        {
            return new CommEnum(residents);
        }

        public class CommEnum : IEnumerator
        {                  
            public SortedSet<Person> _residents;
            int position = -1;

            public CommEnum(SortedSet<Person> list)
            {
                _residents = list;
            }
            public bool MoveNext()
            {
                position++;
                return (position < _residents.Count);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public Person Current
            {
                get
                {
                    try
                    {
                        return _residents.ElementAt(position);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        public int CompareTo(object obj)
        {
            //todo
            throw new NotImplementedException();
        }

        //Getter and setter methods for the attributes
        public uint Id => id;
        public SortedSet<Person> Residents { get { return residents; } set { residents = value; } }
        public SortedSet<Property> Props { get { return props; } set { props = value; } }

        public string Name => name;

        public uint MayorID
        {
            set { mayorID = value; }
            get { return mayorID; }
        }

        //Calculating the population using count of residents
        public int Population => residents.Count;
    }

    //Method to compare the Properties sorted set
    public class PropertyComparer : IComparer<Property>
    {

        public int Compare(Property x, Property y)
        {
            
            return x.CompareTo(y);

        }

    }
}
