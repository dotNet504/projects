/*********************************************************************************************************
 *                                                                                                       *
*  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 3					 Spring 2020         *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: Business Layer
 *  Purpose   : Windows application that displays the property details of Dekalb & Sycamore Communities. *
 *********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader
{
    public class BusinessLayer
    {
        public List<Community> Communities { get; set; }
        public List<Person> lstDekalbPersons { get; set; }
        public List<Person> lstSycamorePersons { get; set; }
        public List<House> lstDekalbHouses { get; set; }
        public List<Apartment> lstDekalbApartments { get; set; }
        public List<House> lstSycamoreHouses { get; set; }
        public List<Apartment> lstSycamoreApartments { get; set; }
        public List<School> lstDekalbSchools { get; set; }
        public List<Business> lstDekalbBusiness { get; set; }
        public List<School> lstSycamoreSchools { get; set; }
        public List<Business> lstSycamoreBusiness { get; set; }

        public BusinessLayer()
        {
            Communities = new List<Community>();
            lstDekalbPersons = new List<Person>();
            lstSycamorePersons = new List<Person>();
            lstDekalbHouses = new List<House>();
            lstDekalbApartments = new List<Apartment>();
            lstSycamoreHouses = new List<House>();
            lstSycamoreApartments = new List<Apartment>();
            lstDekalbSchools = new List<School>();
            lstSycamoreSchools = new List<School>();
            lstDekalbBusiness = new List<Business>();
            lstSycamoreBusiness = new List<Business>();
            LoadDekalbCommunityData();
            LoadSycamoreCommunityData();
        }
        #region Reading InputFiles
        private void LoadDekalbCommunityData()
        {
            //Reading input files.
            string[] persons = File.ReadAllLines(@"../../../DataLoader/InputFiles/Dekalb/p.txt");
            string[] houses = File.ReadAllLines(@"../../../DataLoader/InputFiles/Dekalb/r.txt");
            string[] apartments = File.ReadAllLines(@"../../../DataLoader/InputFiles/Dekalb/a.txt");
            string[] schools = File.ReadAllLines(@"../../../DataLoader/InputFiles/Dekalb/s.txt");
            string[] business = File.ReadAllLines(@"../../../DataLoader/InputFiles/Dekalb/b.txt");


            //Iterating over each of the input files and type casting them to relevant class types.
            foreach (var item in persons)
            {
                string[] items = item.Split('\t');
                Person p = new Person(items);
                lstDekalbPersons.Add(p);
            }
            lstDekalbPersons.Sort(new PersonComparer());

            foreach (var item in houses)
            {
                string[] items = item.Split('\t');
                House h = new House(items);
                lstDekalbHouses.Add(h);
            }
            lstDekalbHouses.Sort(new PropertyComparer());

            foreach (var item in apartments)
            {
                string[] items = item.Split('\t');
                Apartment a = new Apartment(items);
                lstDekalbApartments.Add(a);
            }
            lstDekalbApartments.Sort(new PropertyComparer());

            foreach (var item in schools)
            {
                string[] items = item.Split('\t');
                School s = new School(items);
                lstDekalbSchools.Add(s);
            }

            foreach (var item in business)
            {
                string[] items = item.Split('\t');
                Business b = new Business(items);
                lstDekalbBusiness.Add(b);
            }

            Community community = new Community(lstDekalbPersons, lstDekalbHouses, 
                                                lstDekalbApartments, lstDekalbSchools,
                                                lstDekalbBusiness);
            Communities.Add(community);
        }
        public class PersonComparer : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.CompareTo(y);
            }
        }
        private void LoadSycamoreCommunityData()
        {
            //Reading input files.
            string[] persons = File.ReadAllLines(@"../../../DataLoader/InputFiles/Sycamore/p.txt");
            string[] houses = File.ReadAllLines(@"../../../DataLoader/InputFiles/Sycamore/r.txt");
            string[] apartments = File.ReadAllLines(@"../../../DataLoader/InputFiles/Sycamore/a.txt");
            string[] schools = File.ReadAllLines(@"../../../DataLoader/InputFiles/Sycamore/s.txt");
            string[] business = File.ReadAllLines(@"../../../DataLoader/InputFiles/Sycamore/b.txt");
                        
            //Iterating over each of the input files and type casting them to relevant class types.
            foreach (var item in persons)
            {
                string[] items = item.Split('\t');
                Person p = new Person(items);
                lstSycamorePersons.Add(p);
            }
            lstSycamorePersons.Sort(new PersonComparer());

            foreach (var item in houses)
            {
                string[] items = item.Split('\t');
                House h = new House(items);
                lstSycamoreHouses.Add(h);
            }
            lstSycamoreHouses.Sort(new PropertyComparer());

            foreach (var item in apartments)
            {
                string[] items = item.Split('\t');
                Apartment a = new Apartment(items);
                lstSycamoreApartments.Add(a);
            }
            lstSycamoreApartments.Sort(new PropertyComparer());

            foreach (var item in schools)
            {
                string[] items = item.Split('\t');
                School s = new School(items);
                lstSycamoreSchools.Add(s);
            }

            foreach (var item in business)
            {
                string[] items = item.Split('\t');
                Business b = new Business(items);
                lstSycamoreBusiness.Add(b);
            }

            Community community = new Community(lstSycamorePersons, lstSycamoreHouses, 
                                                lstSycamoreApartments, lstSycamoreSchools,
                                                lstSycamoreBusiness, "Sycamore");
            Communities.Add(community);
        }
        #endregion

        //Re-usable method to calculate age of a person
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
