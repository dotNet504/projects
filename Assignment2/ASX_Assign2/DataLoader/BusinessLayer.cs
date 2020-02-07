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
        public BusinessLayer()
        {
            Communities = new List<Community>();
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
            Communities.Add(community);
        }
        private void LoadSycamoreCommunityData()
        {
            //Reading input files.
            string[] persons = File.ReadAllLines(@"../../../DataLoader/InputFiles/Sycamore/p.txt");
            string[] houses = File.ReadAllLines(@"../../../DataLoader/InputFiles/Sycamore/r.txt");
            string[] apartments = File.ReadAllLines(@"../../../DataLoader/InputFiles/Sycamore/a.txt");

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

            Community community = new Community(lstPersons, lstHouses, lstApartments, "Sycamore");
            Communities.Add(community);
        }
        #endregion
    }
}
