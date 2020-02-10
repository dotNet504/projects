﻿using DataLoader;
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
        private const string houseVal = "Houses:";
        private const string hyphen = "---------------------------";
        private const string apartmentVal = "Apartments:";

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
            dekalbPersons = _businessLayer.lstDekalbPersons;
            sycamorePersons = _businessLayer.lstSycamorePersons;
            outputRichTextBox.Text = "There are " + dekalbPersons.Count() + " people living in Dekalb.\n";
            outputRichTextBox.Text += "There are " + sycamorePersons.Count() + " people living in Sycamore.";
            // Create method in Business Layer and use in this form for future re-usability
        }

        private void DekalbButton_CheckedChanged(object sender, EventArgs e)
        {           
            dekalbHouses = _businessLayer.lstDekalbHouses;
            dekalbApartments = _businessLayer.lstDekalbApartments;
            //RadioButton dekalbButton = (RadioButton)sender;
            DisplayCommunityResults(dekalbPersons, dekalbHouses, dekalbApartments,"Dekalb");

        }

        private void SycamoreButton_CheckedChanged(object sender, EventArgs e)
        {     
            sycamoreHouses = _businessLayer.lstSycamoreHouses;
            sycamoreApartments = _businessLayer.lstSycamoreApartments;
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
            residenceListBox.Items.Add(houseVal);
            residenceListBox.Items.Add(hyphen);
            foreach (House details in housesList)
            {
                residenceListBox.Items.Add(String.Format("{0}",
                    details.StreetAddr));
            }
            residenceListBox.Items.Add("");
            residenceListBox.Items.Add(apartmentVal);
            residenceListBox.Items.Add(hyphen);
            foreach (Apartment details in apartmentsList)
            {
                residenceListBox.Items.Add(String.Format("{0}\t# {1}",
                    details.StreetAddr, details.Unit));
            }
            outputRichTextBox.Text = "The residents and properties of " + selButton + " are now listed.";
        }

        private void personSelectionChanged(object sender, EventArgs e)
        {
            string selPerson = personListBox.GetItemText(personListBox.SelectedItem);
            List<Property> prop;
            List<Person> resident;
            if(selPerson != null && selPerson != "")
            {
                foreach (var item in CommunitiesList)
                {
                    resident = item.Residents.Where(x => string.Equals(x.FirstName, selPerson.Split(' ')[0], StringComparison.CurrentCultureIgnoreCase)).ToList();
                    if (resident.Count > 0)
                    {
                        outputRichTextBox.Text = resident[0].FullName + ", Age(" + BusinessLayer.GetAge(resident[0].Birthday)
                                                    + "), Occupation: " + resident[0].Occupation + ", who resides at:";
                        //sort the addresses here
                        prop = item.Props.Where(x => (resident[0].ResidenceIds.Contains(x.Id) || x.OwnerID == resident[0].Id)).ToList();
                        if (prop.Count > 0)
                        {
                            foreach (var p in prop)
                            {
                                outputRichTextBox.Text += "\n\t" + p.StreetAddr;
                            }

                        }

                    }
                }
                outputRichTextBox.Text += "\n\n### END OUTPUT ###";
            }           
        }

        private void residenceSelectionChanged(object sender, EventArgs e)
        {
            string communityVal;
            string selResidence = residenceListBox.GetItemText(residenceListBox.SelectedItem);
            if (dekalbRadioButton.Checked)
                communityVal = "Dekalb";
            else
                communityVal = "Sycamore";
            if (selResidence != null && selResidence != "" && selResidence != houseVal && 
                selResidence != hyphen && selResidence != apartmentVal)
            {
                List<Property> prop;
                List<Person> resident;
                foreach (var item in CommunitiesList)
                {
                    if (item.Name == communityVal)
                    {                        
                        if (selResidence.Contains("#"))
                        {                            
                            prop = item.Props.Where(
                                x => ((string.Equals(x.StreetAddr, selResidence.Split('#')[0].Split('\t')[0],
                                StringComparison.CurrentCultureIgnoreCase)
                                 ))).ToList();
                            
                        }
                        else
                        {
                            prop = item.Props
                            .Where(x => x.StreetAddr.ToLower().Equals(selResidence.ToLower())).ToList();
                        }
                        if(prop.Count > 0) { 
                            resident = item.Residents
                                .Where(x => (x.Id == prop[0].OwnerID || x.ResidenceIds.Contains(prop[0].Id))).ToList();
                            
                            if (resident.Count > 0)
                            {
                                outputRichTextBox.Text = "Residents living at " + selResidence + ", " + communityVal
                                                            + ", owned by " + resident[0].FullName + ":";
                                outputRichTextBox.Text += "\n------------------------------------------------------------\n";
                                foreach (var res in resident)
                                {
                                    //Apartment Logic pending..
                                    //var aptResident = dekalbApartments.Where
                                    //    (x => (x.Unit == selResidence.Split('#')[1] && x.OwnerID == res.Id)).ToList();
                                    outputRichTextBox.Text += String.Format("{0} \t{1}  \t{2}",
                                                                res.FullName,
                                                                BusinessLayer.GetAge(res.Birthday),
                                                                res.Occupation) + "\n";
                                   
                                }
                            }
                        }
                    }                    
                }
                outputRichTextBox.Text += "\n### END OUTPUT ###";
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Logic to autosize the output window
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            flowPanel.AutoSize = true;
            flowPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Controls.Add(flowPanel);
            
        }
    }
}
