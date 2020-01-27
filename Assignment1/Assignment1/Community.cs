using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    public class Community : IComparable, IEnumerable
    {
        private SortedSet<Property> props;
        private SortedSet<Person> residents;
        private readonly uint id;
        private readonly string name;
        private uint mayorID;


        public Community()
        {
            props = new SortedSet<Property>();
            residents = new SortedSet<Person>();
            id = 0;
            name = "";
            mayorID = 0;
        }
        public Community(List<Person> persons, List<House> houses, List<Apartment> apartments)
        {
            id = 99999;
            name = "Dekalb";
            mayorID = 0;
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
            return GetEnumerator();
        }

        public CommEnum GetEnumerator()
        {
            return new CommEnum(residents);
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

    public class CommEnum : IEnumerator
    {
        public SortedSet<Person> _people;
        int position = -1;

        public CommEnum(SortedSet<Person> list)
        {
            _people = list;
        }
        public bool MoveNext()
        {

            position++;
            return (position < _people.Count);
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
                    return _people.ElementAt(position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
    public class PropertyComparer : IComparer<Property>
    {

        public int Compare(Property x, Property y)
        {
            return x.CompareTo(y);
            //return x.Id.CompareTo(y.Id);
        }



    }
}
