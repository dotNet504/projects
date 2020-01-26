using System;
using System.Collections;
using System.Collections.Generic;
using Assignment1;

namespace Assignment1
{
    public class Community:IComparable, IEnumerable
    {
        private SortedSet<Property> props;
        private SortedSet<Person> residents;
        private readonly uint id;
        private readonly string name;
        private uint mayorID;
        //todo - Enum

        public Community()
        {
            props = new SortedSet<Property>();
            residents = new SortedSet<Person>();
            id = 0;
            name = "";
            mayorID = 0;
        }
        public Community( List<Person> persons, List<House> houses, List<Apartment> apartments)
        {
            id = 99999;
            name = "Dekalb";
            mayorID = 0;
            props = new SortedSet<Property>();
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

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            //todo
            throw new NotImplementedException();
        }
        public uint Id => id;
        public SortedSet<Person> Residents { get { return residents; } set { residents = value; } }
        public SortedSet<Property> Props { get { return props; } set { props = value; } }

        public string Name => name;
        public uint MayorID
        {
            set { mayorID = value; }
            get { return mayorID; }
        }
        public int Population => residents.Count;        
    }
}
