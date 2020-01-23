using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Person : IComparable
    {
        private readonly uint id;
        private string firstName;
        private string lastName;
        private string occupation;
        private readonly DateTime birthday;
        private List<uint> residenceIds = new List<uint>();


        public int CompareTo(Object alpha)
        {
            if (alpha == null) throw new ArgumentNullException("Person object being compared with is NULL");

            Person rightOp = alpha as Person;

            if (rightOp != null)
                return FullName.CompareTo(rightOp.FullName);
            else
                throw new ArgumentNullException("[Person]: CompareTo argument is not a Person");
        }

        public override string ToString()
        {
            string ret = String.Format("Id         : {0 , -10 }\n", id);
            ret += String.Format("FirstName  : {0}\n", FirstName);
            ret += String.Format("LastName   : {0}\n", LastName);
            ret += String.Format("Occupation : {0}\n", Occupation);
            ret += String.Format("Birthday   : {0}\n", Birthday);
            return ret;
        }

        public Person()
        {
            id = 0;
            this.LastName = "";
            this.FirstName = "";
            this.Occupation = "";
            birthday = new DateTime(0, 0, 0);
        }

        public Person(string[] args)
        {
            uint ID = Convert.ToUInt32(args[0]);
            string lastname = args[1];
            string firstname = args[2];
            string occu = args[3];
            int year = Convert.ToInt32(args[4]);
            int month = Convert.ToInt32(args[5]);
            int day = Convert.ToInt32(args[6]);

            DateTime birth = new DateTime(year, month, day);

            FirstName = firstname;
            LastName = lastname;
            Occupation = occu;

            if (birth <= DateTime.Now)
            {
                birthday = birth;
            }
            else
            {
                throw new ArgumentNullException("Birthday provided is in the future");
            }

            if (ID > 99999 || ID < 1)
            {
                throw new ArgumentNullException("Invalid ID provided, should be within 1 - 99999");
            }
            else if (residenceIds.Contains(ID))
            {
                throw new ArgumentNullException("ID already exists, enter a new ID within 1 - 99999");
            }
            else
            {
                id = ID;
                residenceIds.Add(ID);
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }

        public uint Id
        {
            get { return id; }
        }

        public uint[] ResidenceIds
        {
            get { return residenceIds.ToArray(); }
        }

        public DateTime Birthday
        {
            get { return birthday; }
        }

        //get-only property
        public string FullName => LastName + ", " + FirstName;

    }

}
