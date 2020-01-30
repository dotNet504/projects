/*********************************************************************************************************
 *                                                                                                       *
 *  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 1					 Spring 2020     *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: Menu
 *  Purpose   : Console application that displays the property details of Dekalb Community.				 *
 *********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment1
{
    class Menu
    {
        static void Main(string[] args)
        {

            //Reading input files.
            string[] persons = File.ReadAllLines(@"../../InputFiles/p.txt");
            string[] houses = File.ReadAllLines(@"../../InputFiles/r.txt");
            string[] apartments = File.ReadAllLines(@"../../InputFiles/a.txt");

            List<Person> lstPersons = new List<Person>();
            List<House> lstHouses = new List<House>();
            List<Apartment> lstApartments = new List<Apartment>();

            //Iterating over each of the input files and type casting them to relevant class types.
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
            lstHouses.Sort(new PropertyComparer());

            foreach (var item in apartments)
            {
                string[] items = item.Split('\t');
                Apartment a = new Apartment(items);
                lstApartments.Add(a);
            }
            lstApartments.Sort(new PropertyComparer());

            Community community = new Community(lstPersons, lstHouses, lstApartments);

            do
            {
                //Menu options list
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
                    List<Property> prop;
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
                                PropertyDetails(item, lstPersons, lstApartments, lstHouses);
                            }
                            break;

                        case "2":

                            Console.WriteLine("Enter property type (House/Apartment):");
                            string inputValue = Console.ReadLine();
                            switch (inputValue.ToLower())
                            {
                                case "apartment":
                                    {
                                        Console.WriteLine("\nList of addresses of Apartment properties in the {0} community.", community.Name);
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
                                        Console.WriteLine("\nList of addresses of House properties in the {0} community.", community.Name);
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
                            Console.WriteLine("List of addresses for all FOR SALE properties in the {0} community.", community.Name);
                            Console.WriteLine("-------------------------------------------------------\n");

                            prop = community.Props.Where(x => x.ForSale).ToList();

                            foreach (var p in prop)
                            {
                                Console.Write(p.StreetAddr);
                                if (lstApartments.Any(x => x.OwnerID == p.OwnerID))
                                {
                                    Console.Write(" Apt.# " + lstApartments.FirstOrDefault(x => x.OwnerID == p.OwnerID).Unit + " ");
                                }
                                Console.Write(p.City + ", " + p.State + ", " + p.Zip + "\n");
                            }
                            break;

                        case "4":
                            Console.WriteLine("List of residents living in the {0} community.", community.Name);
                            Console.WriteLine("------------------------------------------------");

                            //Abdul => changed to community foreach 
                            foreach (Person p in community)
                            {
                                Console.WriteLine(p.FullName + ", " +
                                    "Age (" + GetAge(p.Birthday) + "), Occupation: " + p.Occupation);
                                Console.WriteLine();
                            }
                            break;

                        case "5":
                            Console.WriteLine("Enter the street address to lookup:");
                            streetAddress = Console.ReadLine();
                            Console.WriteLine("List of residents living at " + streetAddress + ":\n");
                            Console.WriteLine("------------------------------------------------");

                            prop = community.Props
                                .Where(x => string.Equals(x.StreetAddr, streetAddress, StringComparison.CurrentCultureIgnoreCase)).ToList();
                            if (prop.Count > 0)
                            {
                                foreach (var pr in prop)
                                {
                                    Person p = lstPersons.FirstOrDefault(x => x.Id == pr.OwnerID);
                                    Console.WriteLine(p.FullName + ", Age(" + GetAge(p.Birthday) + "), Occupation: " + p.Occupation);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Street Address not found.");
                            }
                            break;

                        case "6":
                            Console.WriteLine("Enter the street address to lookup:");
                            streetAddress = Console.ReadLine();

                            prop = community.Props
                                .Where(x => string.Equals(x.StreetAddr, streetAddress, StringComparison.CurrentCultureIgnoreCase)).ToList();

                            if (prop.Count > 0)
                            {
                                foreach (var p in prop)
                                {
                                    p.ForSale = !p.ForSale;
                                }
                                Console.WriteLine(streetAddress + " is now listed as " + (prop.FirstOrDefault().ForSale ? "" : "NOT ") + "for sale!");
                            }
                            else
                            {
                                Console.WriteLine("Street Address not found.");
                            }
                            break;

                        case "7":
                            Console.WriteLine("Enter the street address to lookup:");
                            streetAddress = Console.ReadLine();

                            prop = community.Props.Where(x => streetAddress != null && x.StreetAddr.ToLower().Contains(streetAddress.ToLower())).ToList();

                            if (prop.Count > 0)
                            {
                                foreach (var p in prop)
                                {
                                    p.OwnerID = community.MayorID;
                                    p.ForSale = false;
                                }
                                Console.WriteLine("Congratulations! You have successfully purchased this property!\n");
                                PropertyDetails(prop.FirstOrDefault(), lstPersons, lstApartments, lstHouses);
                            }
                            else
                            {
                                Console.WriteLine("Street Address not found.");
                            }
                            break;

                        case "8":
                            Console.WriteLine("Enter the street address to lookup:");
                            streetAddress = Console.ReadLine();
                            prop = community.Props.Where(x => streetAddress != null && x.StreetAddr.ToLower().Contains(streetAddress.ToLower())).ToList();

                            if (prop.Count > 0)
                            {
                                if (prop.All(x => x.OwnerID == community.MayorID))
                                {
                                    Console.WriteLine("You are already a resident at this property!");
                                }
                                else
                                {
                                    foreach (var p in prop)
                                    {
                                        p.OwnerID = community.MayorID;
                                    }
                                    Console.WriteLine("Success! You have been added as a resident at this property.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Street Address not found.");
                            }
                            break;

                        case "9":
                            Console.WriteLine("Enter the street address to lookup:");
                            streetAddress = Console.ReadLine();
                            prop = community.Props.Where(x => streetAddress != null && x.StreetAddr.ToLower().Contains(streetAddress.ToLower())).ToList();

                            if (prop.Count > 0)
                            {
                                if (prop.Any(x => x.OwnerID == community.MayorID))
                                {
                                    foreach (var p in prop)
                                    {
                                        p.OwnerID = 1; // assigning to someone else
                                    }
                                    // use below code in case you want to remove property completely from the list,
                                    // in doing so cannot use this property in other cases unless refresh the list from the file
                                    //foreach (var p in lstpr)
                                    //{
                                    //    lstpr.Remove(p);
                                    //}
                                    Console.WriteLine("Success! You have been removed as a resident at this property.");
                                }
                                else
                                {
                                    Console.WriteLine("You do not currently reside at this property.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("I'm sorry, i don't recognize this address: '" + streetAddress + "'.");
                            }
                            break;
                        case "10":
                            return;

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

        //Re-usable method to print the property details
        private static void PropertyDetails(Property item, List<Person> lstPersons, List<Apartment> lstApartments, List<House> lstHouses)
        {
            Person p = lstPersons?.Where(x => x.Id == item.OwnerID).FirstOrDefault();
            Apartment a = lstApartments?.Where(x => x.Id == item.Id).FirstOrDefault();
            House h = lstHouses?.Where(x => x.Id == item.Id).FirstOrDefault();

            Console.Write("Property Address: " + item.StreetAddr + " / " + item.City + " / " + item.State + " / " + item.Zip
                          + "\n\tOwned by " + p.FullName + ", Age(" + GetAge(p.Birthday) + ") Occupation: " + p.Occupation
                          + "\n\t" + (item.ForSale ? "(FOR SALE)  " : "(NOT for sale) "));
            if (a != null)
            {
                Console.Write(a.Bedrooms + " bedrooms \\ " + a.Baths + " baths \\ " + a.Sqft + " sq.ft. " + "Apt.# " + a.Unit + "\n\t");
            }
            else if (h != null)
            {
                Console.Write(h.Bedrooms + " bedrooms \\ " + h.Baths + " baths \\ " + h.Sqft + " sq.ft. \n\t");

                if (h.AttachedGarage == true)
                {
                    Console.Write("... with an attached garage : ");
                }
                else if (h.AttachedGarage == false)
                {
                    Console.Write("... with a detached garage : ");
                }
                else
                {
                    Console.Write("... with no garage : ");
                }
                /*if (h.Garage)
                {
                    Console.Write(h.AttachedGarage
                        ? "... with an attached garage : "
                        : "... with a detached garage : ");
                }
                else
                {
                    Console.Write("... with no garage : ");
                }*/
                Console.Write(h.Floors + (h.Floors == 1 ? " floor." : " floors."));
            }
            Console.WriteLine("\n");
        }

        //Re-usable method to calculate age of a person
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
