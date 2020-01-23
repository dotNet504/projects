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
            string ret= String.Format("Id         : {0 , -10 }\n", id);
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
            uint ID             = Convert.ToUInt32(args[0]);
            string lastname     = args[1];
            string firstname    = args[2];
            string occu         = args[3];
            int year            = Convert.ToInt32(args[4]);
            int month           = Convert.ToInt32(args[5]);
            int day             = Convert.ToInt32(args[6]);

            DateTime birth      = new DateTime(year, month, day);
 
            FirstName           = firstname;
            LastName            = lastname;
            Occupation          = occu;

            if (birth <= DateTime.Now)
            {
                birthday = birth;
            } else
            {
                throw new ArgumentNullException("Birthday provided is in the future");
            }

            if (ID > 99999 || ID < 1)
            {
                throw new ArgumentNullException("Invalid ID provided, should be within 1 - 99999");
            } else if (residenceIds.Contains(ID)) {
                throw new ArgumentNullException("ID already exists, enter a new ID within 1 - 99999");
            } else {
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

    class Property : IComparable
    {
        private readonly uint id;
        private uint ownerID;
        private readonly uint x;
        private readonly uint y;
        private string streetAddr;
        private string city;
        private string state;
        private string zip;
        private bool forSale;


        public Property()
        {
            id = 0;
            ownerID = 0;
            x = 0;
            y = 0;
            streetAddr = "";
            city = "";
            state = "";
            zip = "";
            forSale = false;
        }

        public Property(string [] args)
        {
            id = Convert.ToUInt32(args[0]);
            ownerID = Convert.ToUInt32(args[1]);
            x = Convert.ToUInt32(args[2]);
            y = Convert.ToUInt32(args[3]);
            streetAddr = args[4];
            city = args[5]; ;
            state = args[6]; ;
            zip = args[7]; ;
            forSale = Convert.ToBoolean(args[8]);
        }

        public int CompareTo(Object alpha)
        {
            //if (alpha == null) throw new ArgumentNullException("Person object being compared with is NULL");

            //Person rightOp = alpha as Person;

            //if (rightOp != null)
            //    return FullName().CompareTo(rightOp.FullName());
            //else
            //    throw new ArgumentNullException("Person object being compared with is NULL");
            return 0;
        }

        public uint Id
        {
            get { return id; }
        }
        public uint OwnerID
        {
            set { ownerID = value; }
            get { return ownerID; }
        }
        public uint X
        {
            get { return x; }
        }
        public uint Y
        {
            get { return y; }
        }
        public string StreetAddr
        {
            set { streetAddr = value; }
            get { return streetAddr; }
        }
        public string City
        {
            set { city = value; }
            get { return city; }
        }
        public string State
        {
            set { state = value; }
            get { return state; }
        }
        public string Zip
        {
            set { zip = value; }
            get { return zip; }
        }
        public bool ForSale
        {
            set { forSale = value; }
            get { return forSale; }
        }
    }

    class Resident : Property
    {
        private uint bedrooms;
        private uint baths;
        private uint sqft;

        public Resident(string [] args) : base (args ) //modified by Xuezhi, I think this part still has problem
        {
            bedrooms = Convert.ToUInt32(args[9]);
            baths = Convert.ToUInt32(args[10]);
            sqft = Convert.ToUInt32(args[11]);
        }

        public uint Bedrooms
        {
            set { bedrooms = value; }
            get { return bedrooms; }
        }

        public uint Baths
        {
            set { baths = value; }
            get { return baths; }
        }

        public uint Sqft
        {
            set { sqft = value; }
            get { return sqft; }
        }


    }

    class Menu
    {
        static void Main(string[] args)
        {
            string[] attr = { "125", "John", "Doe", "Lawyer", "1992", "5", "19" };
            Person me = new Person(attr);
            Console.WriteLine(me);

            string[] attr2 = { "1", "John", "Allan", "Lawyer", "1992", "5", "19" };
            Person me2 = new Person(attr2);
            Console.WriteLine(me2);

            if (me2.CompareTo(me) < 0)
            {
                Console.WriteLine(me2.FullName + " is greater than " + me.FullName);
            }
            else
                Console.WriteLine(me.FullName + " is greater than " + me2.FullName);



            /*
             * Tony's test code
             house: unique ID | ownerID | x | y | streetAddr | city | state | zip | forSale | bedrooms | baths | sqft | garage | attachedGarage | floors
            * 98213	0	250	250	6000 Mayor St.	DeKalb	Illinois 60115	F	3	2	5000	T	T	2	
            * 
            * 
            * appartment: unique ID | ownerID | x | y | streetAddr | city | state | zip | forSale | bedrooms | baths | sqft | unit
            * 61539	1101	216	216	7031 Lincoln Hwy.	DeKalb	Illinois	60115	T	1	1	2000	PAR
            */
            string[] house_string= { "98213", "0", "250", "250", "6000 Mayor St.", "DeKalb", "Illinois" ,"60115","False","3","2","5000","True","True","2"};
            House test_class = new House(house_string);
            Console.WriteLine(test_class);

            string[] appartment_string = { "61539", "1101", "216", "216", "7031 Lincoln Hwy.", "DeKalb", "Illinois", "60115", "True", "1", "1", "2000", "PAR" };
            Apartment test_class_apartment = new Apartment(appartment_string);
            Console.WriteLine(test_class_apartment);


            /*
             * Test is end
             */


            Console.ReadKey();
        }
    }
}
