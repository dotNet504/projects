using DataLoader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASX_Assign2
{
    public partial class Form1 : Form
    {
        private BusinessLayer _businessLayer;
        public Form1()
        {
            InitializeComponent();
            _businessLayer = new BusinessLayer();
            // Create method in Business Layer and use in this form for future re-usability
        }

        private void DekalbButton_CheckedChanged(object sender, EventArgs e)
        {
            List<Person> dekalbPersons = new List<Person>();
            List<House> dekalbHouses = new List<House>();
            List<Apartment> dekalbApartments = new List<Apartment>();
            dekalbPersons = _businessLayer.lstDekalbPersons;
            dekalbHouses = _businessLayer.lstDekalbHouses;
            dekalbApartments = _businessLayer.lstDekalbApartments;
            RadioButton dekalbButton = (RadioButton)sender;
            displayCommunityResults(dekalbPersons, dekalbHouses, dekalbApartments,"Dekalb");

        }

        private void SycamoreButton_CheckedChanged(object sender, EventArgs e)
        {
            List<Person> sycamorePersons = new List<Person>();
            List<House> sycamoreHouses = new List<House>();
            List<Apartment> sycamoreApartments = new List<Apartment>();
            sycamorePersons = _businessLayer.lstSycamorePersons;
            sycamoreHouses = _businessLayer.lstSycamoreHouses;
            sycamoreApartments = _businessLayer.lstSycamoreApartments;
            //Button dekalbButton = (Button)sender;
            displayCommunityResults(sycamorePersons, sycamoreHouses, sycamoreApartments, "Sycamore");
        }

        private void displayCommunityResults(List<Person> personList, List<House> housesList, 
                                            List<Apartment> apartmentsList, String selButton)
        {
            //Sorting of persons - pending
            personListBox.Items.Clear();
            //personListBox.ColumnWidth = 100;
            foreach (Person details in personList)
            {
                personListBox.Items.Add(String.Format("{0} \t{1}  {2}",
                    details.FirstName, BusinessLayer.GetAge(details.Birthday), details.Occupation));
            }
            residenceListBox.Items.Clear();
            residenceListBox.Items.Add("Houses:");
            residenceListBox.Items.Add("------------");
            foreach (House details in housesList)
            {
                residenceListBox.Items.Add(String.Format("   {0}",
                    details.StreetAddr));
            }
            residenceListBox.Items.Add("");
            residenceListBox.Items.Add("Apartments:");
            residenceListBox.Items.Add("------------");
            foreach (Apartment details in apartmentsList)
            {
                residenceListBox.Items.Add(String.Format("   {0}  # {1}",
                    details.StreetAddr, details.Unit));
            }
            outputRichTextBox.Text = "The residents and properties of " + selButton + " are now listed.";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //this.Text = "URL Opener";

            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.AutoSize = true;
            flowPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Controls.Add(flowPanel);
        }
    }
}
