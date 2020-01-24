using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Menu
    {
        static void Main(string[] args)
        {
            string[] attr = { "125", "John", "Doe", "Lawyer", "1992", "5", "19", "25364" };
            Person me = new Person(attr);
            Console.WriteLine(me);

            string[] attr2 = { "1", "John", "Allan", "Lawyer", "1992", "5", "19", "25647" };
            Person me2 = new Person(attr2);
            Console.WriteLine(me2);

            if (me2.CompareTo(me) < 0)
            {
                Console.WriteLine(me2.FullName + " is greater than " + me.FullName);
            }
            else
                Console.WriteLine(me.FullName + " is greater than " + me2.FullName);



            /*
             * Xuezhi's test code
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
