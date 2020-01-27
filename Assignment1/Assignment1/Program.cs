using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Menu
    {
        static void Main(string[] args)
        {
            //string[] attr = { "125", "John", "Doe", "Lawyer", "1992", "5", "19", "25364" };
            //Person me = new Person(attr);
            //Console.WriteLine(me);

            //string[] attr2 = { "1", "John", "Allan", "Lawyer", "1992", "5", "19", "25647" };
            //Person me2 = new Person(attr2);
            //Console.WriteLine(me2);

            //if (me2.CompareTo(me) < 0)
            //{
            //    Console.WriteLine(me2.FullName + " is greater than " + me.FullName);
            //}
            //else
            //    Console.WriteLine(me.FullName + " is greater than " + me2.FullName);



            /*
             * Xuezhi's test code
             house: unique ID | ownerID | x | y | streetAddr | city | state | zip | forSale | bedrooms | baths | sqft | garage | attachedGarage | floors
            * 98213	0	250	250	6000 Mayor St.	DeKalb	Illinois 60115	F	3	2	5000	T	T	2	
            * 
            * 
            * appartment: unique ID | ownerID | x | y | streetAddr | city | state | zip | forSale | bedrooms | baths | sqft | unit
            * 61539	1101	216	216	7031 Lincoln Hwy.	DeKalb	Illinois	60115	T	1	1	2000	PAR
            */
            string[] house_string= { "98213", "0", "250", "250", "6000 Mayor St.", "DeKalb", "Illinois" ,"60115","F","3","2","5000","T","T","2"};
            House test_class = new House(house_string);
            Console.WriteLine(test_class);


            string[] appartment_string = { "61539", "1101", "216", "216", "7031 Lincoln Hwy.", "DeKalb", "Illinois", "60115", "T", "1", "1", "2000", "PAR" };
            Apartment test_class_apartment = new Apartment(appartment_string) ;
            Console.WriteLine(test_class_apartment);
            if (test_class.CompareTo(test_class_apartment) > 0)
            {
                Console.WriteLine("property 1 is great than property 2");
            }
            else if (test_class.CompareTo(test_class_apartment) == 0)
            {
                Console.WriteLine("Equal");
            }
            else 
            {
                Console.WriteLine("property 1 is smaller than property 2");
            }
            /*
             * Test is end
             */


            do
            {
                Console.WriteLine("1. Full property list");
                Console.WriteLine("2.List addresses of either House or Apartment - type properties");
                Console.WriteLine("3.List addresses of all for-sale properties");
                Console.WriteLine("4.List all residents of a community");
                Console.WriteLine("5.List all residents of a property, by street address");
                Console.WriteLine("6.Toggle a property, by street address, as being for-sale or not.");
                Console.WriteLine("7.Buy a for-sale property, by street address");
                Console.WriteLine("8.Add yourself as an occupant to a property.");
                Console.WriteLine("9.Remove yourself as an occupant from a property");
                Console.WriteLine("10.Quit");

                //Reading input files.
                string[] persons = File.ReadAllLines(@"../../InputFiles/p.txt");
                string[] houses = File.ReadAllLines(@"../../InputFiles/r.txt");
                string[] apartments = File.ReadAllLines(@"../../InputFiles/a.txt");

                List<Person> lstPersons = new List<Person>();
                List<House> lstHouses = new List<House>();
                List<Apartment> lstApartments = new List<Apartment>();
                List<Property> lstProperty = new List<Property>();

                foreach (var item in persons)
                {
                    string[] items = item.Split('\t');
                    Person p = new Person(items);
                    lstPersons.Add(p);
                }

                foreach (var item in houses)
                {
                    string[] items = item.Split('\t');
                    House h = new House(items);
                    lstHouses.Add(h);

                }

                    foreach (var item in apartments)
                {
                    string[] items = item.Split('\t');
                    Apartment a = new Apartment(items);
                    lstApartments.Add(a);

                }
                Community community = new Community(lstPersons, lstHouses, lstApartments);

                try
                {
                    Console.WriteLine("press any key from 1-10");
                    string readValue = Console.ReadLine();
                    if (readValue == "10" || readValue.ToLower() == "quit" || readValue.ToLower() == "q" ||
                        readValue.ToLower() == "exit" || readValue.ToLower() == "e")
                        return;

                    switch (readValue)
                    {
                        case "1":
                            Console.WriteLine("<" + community.Id + "> " + community.Name + ". Population(" + community.Population + "). Mayor: " +
                               lstPersons[0].FullName);
                            Console.WriteLine("-------------------------------------------------------------");

                            foreach (var item in community.Props)
                            {
                                Person p = lstPersons.Where(x => x.Id == item.OwnerID).FirstOrDefault();
                                Apartment a = lstApartments.Where(x => x.Id == item.Id).FirstOrDefault();
                                House h = lstHouses.Where(x => x.Id == item.Id).FirstOrDefault();

                                Console.Write("Property Address: " +
                                    item.StreetAddr + " / " +
                                    item.City + " / " +
                                    item.State + " / " +
                                    item.Zip + "\nOwned by " +
                                    p.FullName + ", Age(" +
                                    GetAge(p.Birthday) + ") Occupation: " +
                                    p.Occupation + "\n" +
                                    (item.ForSale ? "(FOR SALE)  " : "(NOT for sale) "));
                                if (a != null)
                                {
                                    Console.Write(a.Bedrooms + " bedrooms \\ " +
                                    a.Baths + " baths \\ " +
                                    a.Sqft + " sq.ft. \n");
                                } else if(h!= null)
                                {
                                    Console.Write(h.Bedrooms + " bedrooms \\ " +
                                   h.Baths + " baths \\ " +
                                   h.Sqft + " sq.ft. \n");
                                }
                            }
                            break;

                        case "2":

                            Console.WriteLine("Enter property type (House/Apartment):");
                            String inputValue = Console.ReadLine();
                            if (inputValue.ToLower() == "apartment")
                            {
                                Console.WriteLine("List of addresses of Apartment properties in the Dekalb community.");
                                Console.WriteLine("-------------------------------------------------------");
                                foreach (var item in lstApartments)
                                {
                                    Console.WriteLine(item.StreetAddr + " Apt.# " +
                                        item.Unit + " " +
                                        item.City + ", " +
                                        item.State + ", " +
                                        item.Zip);
                                    //todo - sorting
                                }
                            }
                            else if (inputValue.ToLower() == "house")
                            {
                                Console.WriteLine("List of addresses of House properties in the Dekalb community.");
                                Console.WriteLine("-------------------------------------------------------");
                                foreach (var item in lstHouses)
                                {
                                    Console.WriteLine(item.StreetAddr + " " +
                                         //item.Unit + " " +
                                         item.City + ", " +
                                         item.State + ", " +
                                         item.Zip);
                                    //todo - sorting and confirmation
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input!");
                                Console.WriteLine("Enter input values as Apartment/House");
                            }

                            break;

                        case "3":
                            Console.WriteLine("List of addresses for all FOR SALE properties in the Dekalb community.");
                            Console.WriteLine("-------------------------------------------------------");
                            foreach (var item in lstApartments)
                            {
                                if (item.ForSale)
                                {
                                    Console.WriteLine(item.StreetAddr + " Apt.# " +
                                        item.Unit + " " +
                                        item.City + ", " +
                                        item.State + ", " +
                                        item.Zip);
                                }
                            }
                            foreach (var item in lstHouses)
                            {
                                if (item.ForSale)
                                {
                                    Console.WriteLine(item.StreetAddr + " " +
                                     //item.Unit + " " +
                                     item.City + ", " +
                                     item.State + ", " +
                                     item.Zip);
                                    //todo - sorting and confirmation
                                }
                            }
                            break;

                        case "4":
                            //todo - This part need to be re-done with community object
                            Console.WriteLine("List of residents living in the Dekalb community.");
                            Console.WriteLine("------------------------------------------------");

                            //todo - for each on community mentioned

                            foreach (var item in lstPersons)
                            {
                                Console.WriteLine(item.FullName + ", " +
                                    "Age (" + GetAge(item.Birthday) + "), Occupation: " + item.Occupation
                                    );
                                Console.WriteLine();
                            }
                            break;

                        case "5":
                            Console.WriteLine("Enter the street address to lookup:");
                            String inputVal = Console.ReadLine();//"1238 Woodcrest Ln."; // 
                            Console.WriteLine("List of residents living at " + inputVal);
                            List<String> residentsExists = new List<string>();

                            foreach (var item in lstApartments)
                            {
                                Person p = lstPersons.Where(x => x.Id == item.OwnerID).FirstOrDefault();
                                if (item.StreetAddr.ToLower() == inputVal.ToLower())
                                {
                                    Console.WriteLine(p.FullName + ", Age(" +
                                        GetAge(p.Birthday) + "), Occupation: " +
                                        p.Occupation);
                                    residentsExists.Add(p.FullName);
                                }
                            }

                            foreach (var item in lstHouses)
                            {
                                Person p = lstPersons.Where(x => x.Id == item.OwnerID).FirstOrDefault();
                                if (item.StreetAddr.ToLower() == inputVal.ToLower())
                                {
                                    Console.WriteLine(p.FullName + ", Age(" +
                                        GetAge(p.Birthday) + "), Occupation: " +
                                        p.Occupation);
                                    residentsExists.Add(p.FullName);
                                }
                            }
                            if (residentsExists == null)
                            {
                                Console.WriteLine("Residents not found for the provided street address.");
                            }

                            break;

                        case "6":
                            Console.WriteLine("Enter the street address to lookup:");
                            string streetAd = Console.ReadLine();  //"906 Stonehenge Rd."; // 
                            foreach (var item in lstApartments)
                            {
                                if (item.StreetAddr.ToLower() == streetAd.ToLower())
                                {
                                    if (item.ForSale)
                                    {
                                        item.ForSale = false;
                                        Console.WriteLine(streetAd + " is now listed as NOT for sale!");
                                    }
                                    else
                                    {
                                        item.ForSale = true; //todo - this is not working 
                                        Console.WriteLine(streetAd + " is now listed as FOR SALE!");
                                    }
                                }
                            }
                            foreach (var item in lstHouses)
                            {
                                if (item.StreetAddr.ToLower() == streetAd.ToLower())
                                {
                                    if (item.ForSale)
                                    {
                                        item.ForSale = false;
                                        Console.WriteLine(streetAd + " is now listed as NOT for sale!");
                                    }
                                    else
                                    {
                                        item.ForSale = true;
                                        Console.WriteLine(streetAd + " is now listed as FOR SALE!");
                                    }

                                }
                            }

                            break;

                        case "7":
                            Console.WriteLine("Enter the street address to lookup:");
                            //string streetAdd = "518 Oak Ave"; // Console.ReadLine();

                            break;

                        default:
                            Console.WriteLine("Invalid input. Choose input value from 1 to 10");
                            // todo
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //Console.ReadKey();
                Console.ReadLine();
            }

            while (true);
        }

        public static int GetAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
            {
                age = age - 1;
            }
            return age;
        }
        
    }
}
