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
            //string[] house_string = { "98213", "0", "250", "250", "6000 Mayor St.", "DeKalb", "Illinois", "60115", "F", "3", "2", "5000", "T", "T", "2" };
            //House test_class = new House(house_string);
            //Console.WriteLine(test_class);


            //string[] appartment_string = { "61539", "1101", "216", "216", "7031 Lincoln Hwy.", "DeKalb", "Illinois", "60115", "T", "1", "1", "2000", "PAR" };
            //Apartment test_class_apartment = new Apartment(appartment_string);
            //Console.WriteLine(test_class_apartment);
            //if (test_class.CompareTo(test_class_apartment) > 0)
            //{
            //    Console.WriteLine("property 1 is great than property 2");
            //}
            //else if (test_class.CompareTo(test_class_apartment) == 0)
            //{
            //    Console.WriteLine("Equal");
            //}
            //else
            //{
            //    Console.WriteLine("property 1 is smaller than property 2");
            //}
            /*
             * Test is end
             */
            //Reading input files.
            string[] persons = File.ReadAllLines(@"../../InputFiles/p.txt");
            string[] houses = File.ReadAllLines(@"../../InputFiles/r.txt");
            string[] apartments = File.ReadAllLines(@"../../InputFiles/a.txt");

            List<Person> lstPersons = new List<Person>();
            List<House> lstHouses = new List<House>();
            List<Apartment> lstApartments = new List<Apartment>();

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
                Console.WriteLine("\n");
                try
                {
                    string streetAddress = "";
                    string readValue = Console.ReadLine();
                    if (readValue == "10" || readValue.ToLower() == "quit" || readValue.ToLower() == "q" ||
                        readValue.ToLower() == "exit" || readValue.ToLower() == "e")
                        return;

                    switch (readValue)
                    {
                        case "1":
                            Console.WriteLine("<" + community.Id + "> " + community.Name + ". Population (" + community.Population + "). Mayor: " + lstPersons[0].FullName);
                            Console.WriteLine("-------------------------------------------------------------");

                            foreach (var item in community.Props)
                            {
                                Person p = lstPersons?.Where(x => x.Id == item.OwnerID).FirstOrDefault();
                                Apartment a = lstApartments?.Where(x => x.Id == item.Id).FirstOrDefault();
                                House h = lstHouses?.Where(x => x.Id == item.Id).FirstOrDefault();

                                Console.Write("Property Address: " + item.StreetAddr + " / " + item.City + " / " + item.State + " / " + item.Zip
                                              + "\nOwned by " + p.FullName + ", Age(" + GetAge(p.Birthday) + ") Occupation: " + p.Occupation
                                              + "\n" + (item.ForSale ? "(FOR SALE)  " : "(NOT for sale) "));
                                if (a != null)
                                {
                                    Console.Write(a.Bedrooms + " bedrooms \\ " + a.Baths + " baths \\ " + a.Sqft + " sq.ft. " + "Apt.# " + a.Unit + "\n");
                                }
                                else if (h != null)
                                {
                                    Console.Write(h.Bedrooms + " bedrooms \\ " + h.Baths + " baths \\ " + h.Sqft + " sq.ft. \n");
                                    if (h.Garage)
                                    {
                                        Console.Write(h.AttachedGarage
                                            ? "... with an attached garage : "
                                            : "... with a detached garage : ");
                                    }
                                    else
                                    {
                                        Console.Write("... with no garage : ");
                                    }
                                    Console.Write(h.Floors + (h.Floors == 1 ? " floor" : " floors"));
                                }
                                Console.WriteLine("\n");
                                //todo - need to remove my name
                            }
                            break;

                        case "2":

                            Console.WriteLine("Enter property type (House/Apartment):");
                            string inputValue = Console.ReadLine();
                            switch (inputValue.ToLower())
                            {
                                case "apartment":
                                    {
                                        Console.WriteLine("\nList of addresses of Apartment properties in the Dekalb community.");
                                        Console.WriteLine("-------------------------------------------------------\n");
                                        foreach (var item in lstApartments)
                                        {
                                            Console.WriteLine(item.StreetAddr + " Apt.# " + item.Unit + " " + item.City + ", " + item.State + ", " + item.Zip);
                                            //todo - sorting
                                        }
                                        break;
                                    }
                                case "house":
                                    {
                                        Console.WriteLine("\nList of addresses of House properties in the Dekalb community.");
                                        Console.WriteLine("-------------------------------------------------------\n");
                                        foreach (var item in lstHouses)
                                        {
                                            Console.WriteLine(item.StreetAddr + " " + item.City + ", " + item.State + ", " + item.Zip);
                                            //todo - sorting and confirmation
                                        }
                                        break;
                                    }
                                default:
                                    Console.WriteLine("Invalid Input!");
                                    break;
                            }
                            break;

                        case "3":
                            Console.WriteLine("List of addresses for all FOR SALE properties in the Dekalb community.");
                            Console.WriteLine("-------------------------------------------------------\n");
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
                            streetAddress = Console.ReadLine();
                            Console.WriteLine("List of residents living at " + streetAddress + ":\n");
                            Console.WriteLine("------------------------------------------------");

                            Property pr = community.Props
                                .FirstOrDefault(x => string.Equals(x.StreetAddr, streetAddress, StringComparison.CurrentCultureIgnoreCase));
                            if (pr != null)
                            {
                                Person p = lstPersons.FirstOrDefault(x => x.Id == pr.OwnerID);
                                if (p != null)
                                {
                                    Console.WriteLine(p.FullName + ", Age(" + GetAge(p.Birthday) + "), Occupation: " + p.Occupation);
                                }
                                else
                                {
                                    Console.WriteLine("Residents not found for the provided street address.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Street Address not found."); // todo
                            }
                            break;

                        case "6":
                            Console.WriteLine("Enter the street address to lookup:");
                            streetAddress = Console.ReadLine(); 

                            Property prop = community.Props
                                .FirstOrDefault(x => string.Equals(x.StreetAddr, streetAddress, StringComparison.CurrentCultureIgnoreCase));

                            if (prop != null)
                            {
                                prop.ForSale = !prop.ForSale;
                                Console.WriteLine(streetAddress + " is now listed as " + (prop.ForSale ? "" : "NOT ") + "for sale!");
                            }
                            else
                            {
                                Console.WriteLine("Street Address not found."); // todo
                            }
                            break;

                        case "7":
                            Console.WriteLine("Enter the street address to lookup:");
                            streetAddress = Console.ReadLine();
                            foreach (var item in community.Props)
                            {
                                if (string.Equals(item.StreetAddr, streetAddress, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    if (item.ForSale)
                                    {
                                        item.ForSale = false;
                                    }
                                    Console.WriteLine(streetAddress);
                                    Console.WriteLine("Congratulations! You have successfully purchased this property!");
                                }
                                else
                                {
                                    Console.WriteLine("Street Address not found."); // todo
                                }
                            }
                            break;
                        case "8":
                            Console.WriteLine("Enter the street address to lookup:");
                            streetAddress = Console.ReadLine();
                            if (community.Props.Any(x => string.Equals(x.StreetAddr, streetAddress, StringComparison.CurrentCultureIgnoreCase)))
                            {
                                Console.WriteLine(streetAddress);
                                Console.WriteLine("You are already a resident at this property!");
                            }
                            else
                            {
                                // todo add other properties
                                Property p = new Property { StreetAddr = streetAddress };
                                community.Props.Add(p);
                                Console.WriteLine(streetAddress);
                                Console.WriteLine("Success! You have been added as a resident at this property!");
                            }
                            break;
                        case "9":
                            Console.WriteLine("Enter the street address to lookup:");
                            streetAddress = Console.ReadLine();
                            if (community.Props.Any(x => string.Equals(x.StreetAddr, streetAddress, StringComparison.CurrentCultureIgnoreCase)))
                            {
                                Console.WriteLine(streetAddress);
                            string streetAdd = Console.ReadLine(); //"518 Oak Ave"; // 

                                Console.WriteLine("You are already a resident at this property!");
                            }
                            else
                            {
                                // todo add other properties
                                Property p = new Property { StreetAddr = streetAddress };
                                community.Props.Add(p);
                                Console.WriteLine(streetAddress);
                                Console.WriteLine("Success! You have been added as a resident at this property!");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid input. Choose input value from 1 to 10");// todo
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }

            while (true);
        }

        private static int GetAge(DateTime dateOfBirth)
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
