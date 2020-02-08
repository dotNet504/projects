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
        private List<Person> dekalbPersons;
        private List<House> dekalbHouses;
        private List<Apartment> dekalbApartments;
        private List<Person> sycamorePersons;
        private List<House> sycamoreHouses;
        private List<Apartment> sycamoreApartments;
        private List<Community> CommunitiesList;

        public Form1()
        {
            InitializeComponent();
            _businessLayer = new BusinessLayer();
            dekalbPersons = new List<Person>();
            dekalbHouses = new List<House>();
            dekalbApartments = new List<Apartment>();
            sycamorePersons = new List<Person>();
            sycamoreHouses = new List<House>();
            sycamoreApartments = new List<Apartment>();
            CommunitiesList = _businessLayer.Communities;
            // Create method in Business Layer and use in this form for future re-usability
        }

        private void DekalbButton_CheckedChanged(object sender, EventArgs e)
        {
            
            dekalbPersons = _businessLayer.lstDekalbPersons;
            dekalbHouses = _businessLayer.lstDekalbHouses;
            dekalbApartments = _businessLayer.lstDekalbApartments;
            RadioButton dekalbButton = (RadioButton)sender;
            DisplayCommunityResults(dekalbPersons, dekalbHouses, dekalbApartments,"Dekalb");

        }

        private void SycamoreButton_CheckedChanged(object sender, EventArgs e)
        {
            
            sycamorePersons = _businessLayer.lstSycamorePersons;
            sycamoreHouses = _businessLayer.lstSycamoreHouses;
            sycamoreApartments = _businessLayer.lstSycamoreApartments;
            //Button dekalbButton = (Button)sender;
            DisplayCommunityResults(sycamorePersons, sycamoreHouses, sycamoreApartments, "Sycamore");
        }

        private void DisplayCommunityResults(List<Person> personList, List<House> housesList, 
                                            List<Apartment> apartmentsList, String selButton)
        {
            //Sorting of persons - pending
            personListBox.Items.Clear();
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

        private void personSelectionChanged(object sender, EventArgs e)
        {
            string selPerson = personListBox.GetItemText(personListBox.SelectedItem);
            List<Property> prop;
            List<Person> resident;
            foreach (var item in CommunitiesList)
            {
                resident = item.Residents.Where(x => string.Equals(x.FirstName, selPerson.Split(' ')[0], StringComparison.CurrentCultureIgnoreCase)).ToList();
                if (resident.Count > 0)
                {
                    outputRichTextBox.Text = resident[0].FullName + ", Age(" + BusinessLayer.GetAge(resident[0].Birthday)
                                                + "), Occupation: " + resident[0].Occupation + ", who resides at:";
                    prop = item.Props.Where(x => (x.Id == resident[0].NewResidenceId || x.OwnerID == resident[0].Id)).ToList();
                    if(prop.Count > 0)
                    {                        
                        foreach (var p in prop)
                        {
                            outputRichTextBox.Text += "\n\t" + p.StreetAddr;
                        }
                        
                    }
                    
                }
                outputRichTextBox.Text += "\n\n### END OUTPUT ###";



            }
            
            //foreach (Person details in dekalbPersons)
            //{                
            //    if (string.Equals(details.FirstName, selPerson.Split(' ')[0], StringComparison.CurrentCultureIgnoreCase))
            //    {
            //        outputRichTextBox.Text = details.FullName + ", Age(" + BusinessLayer.GetAge(details.Birthday)
            //                                + "), Occupation: " + details.Occupation + ", who resides at:\n"
            //                                +"";
            //    }
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Logic to autosizing the output window
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.AutoSize = true;
            flowPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Controls.Add(flowPanel);
        }
    }
}
