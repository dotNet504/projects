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
        public BusinessLayer()
        {
            Communities = new List<Community>();
            lstDekalbPersons = new List<Person>();
            lstSycamorePersons = new List<Person>();
            lstDekalbHouses = new List<House>();
            lstDekalbApartments = new List<Apartment>();
            lstSycamoreHouses = new List<House>();
            lstSycamoreApartments = new List<Apartment>();
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

            //List<Person> lstPersons = new List<Person>();
            //List<House> lstHouses = new List<House>();
            //List<Apartment> lstApartments = new List<Apartment>();

            //Iterating over each of the input files and type casting them to relevant class types.
            foreach (var item in persons)
            {
                string[] items = item.Split('\t');
                Person p = new Person(items);
                lstDekalbPersons.Add(p);
            }

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

            Community community = new Community(lstDekalbPersons, lstDekalbHouses, lstDekalbApartments);
            Communities.Add(community);
        }
        private void LoadSycamoreCommunityData()
        {
            //Reading input files.
            string[] persons = File.ReadAllLines(@"../../../DataLoader/InputFiles/Sycamore/p.txt");
            string[] houses = File.ReadAllLines(@"../../../DataLoader/InputFiles/Sycamore/r.txt");
            string[] apartments = File.ReadAllLines(@"../../../DataLoader/InputFiles/Sycamore/a.txt");

            //List<Person> lstPersons = new List<Person>();
            ////List<House> lstHouses = new List<House>();
            //List<Apartment> lstApartments = new List<Apartment>();

            //Iterating over each of the input files and type casting them to relevant class types.
            foreach (var item in persons)
            {
                string[] items = item.Split('\t');
                Person p = new Person(items);
                lstSycamorePersons.Add(p);
            }

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

            Community community = new Community(lstSycamorePersons, lstSycamoreHouses, lstSycamoreApartments, "Sycamore");
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
