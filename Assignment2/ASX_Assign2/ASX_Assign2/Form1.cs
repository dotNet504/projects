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

        #region Swathi's code
        private void DekalbButton_CheckedChanged(object sender, EventArgs e)
        {
            dekalbHouses = _businessLayer.lstDekalbHouses;
            dekalbApartments = _businessLayer.lstDekalbApartments;
            //RadioButton dekalbButton = (RadioButton)sender;
            DisplayCommunityResults(dekalbPersons, dekalbHouses, dekalbApartments, "Dekalb");

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
            //add house-data to the residenceListBox
            residenceListBox.Items.Clear();
            residenceListBox.Items.Add(houseVal);
            residenceListBox.Items.Add(hyphen);

            //add house-data to the residenceComboBox --> Abdul
            residenceComboBox.Items.Clear();
            residenceComboBox.Items.Add(houseVal);
            residenceComboBox.Items.Add(hyphen);
            foreach (House details in housesList)
            {
                //add houses to the residenceListBox --> Abdul
                residenceListBox.Items.Add(String.Format("{0} {1}",
                    details.StreetAddr, (details.ForSale ? "*" : "")));

                //add houses to the residenceComboBox --> Abdul
                residenceComboBox.Items.Add(String.Format("{0}", details.StreetAddr));
            }
            // Add apartment-data to the residenceListBox
            residenceListBox.Items.Add("");
            residenceListBox.Items.Add(apartmentVal);
            residenceListBox.Items.Add(hyphen);

            // Add apartment-data to the residenceComboBox --> Abdul
            residenceComboBox.Items.Add("");
            residenceComboBox.Items.Add(apartmentVal);
            residenceComboBox.Items.Add(hyphen);
            foreach (Apartment details in apartmentsList)
            {
                //add apartments to the residenceListBox
                residenceListBox.Items.Add(String.Format("{0}\t# {1} {2}",
                    details.StreetAddr, details.Unit, (details.ForSale ? "*" : "")));

                //add apartments to the residenceComboBox --> Abdul
                residenceComboBox.Items.Add(String.Format("{0}\t# {1}", details.StreetAddr,
                    details.Unit));
            }
            outputRichTextBox.Text = "The residents and properties of " + selButton + " are now listed.";
        }

        private void personSelectionChanged(object sender, EventArgs e)
        {
            string selPerson = personListBox.GetItemText(personListBox.SelectedItem);
            List<Property> prop;
            List<Person> resident;
            if (selPerson != null && selPerson != "")
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
            string selResidence = residenceListBox.GetItemText(residenceListBox.SelectedItem).TrimEnd(' ','*');
            if (dekalbRadioButton.Checked)
                communityVal = "Dekalb";
            else
                communityVal = "Sycamore";
            if (selResidence != null && selResidence != "" && selResidence != houseVal &&
                selResidence != hyphen && selResidence != apartmentVal)
            {
                List<Person> resident = new List<Person>();
                List<Property> prop = new List<Property>();              

                foreach (var item in CommunitiesList)
                {
                    if (item.Name.ToString() == communityVal)
                    {
                        List<Apartment> lstApt = new List<Apartment>();
                        if (selResidence.Contains("#"))
                        {  
                            if (communityVal == "Dekalb")
                            {
                                lstApt = dekalbApartments.Where
                                        (x => ((x.Unit == selResidence.Split('#')[1].Trim() &&
                                        (string.Equals(x.StreetAddr, selResidence.Split('#')[0].Split('\t')[0],
                                StringComparison.CurrentCultureIgnoreCase))))).ToList();
                            }
                            else
                            {                                
                                lstApt = sycamoreApartments.Where
                                        (x => ((x.Unit == selResidence.Split('#')[1].Trim() &&
                                        (string.Equals(x.StreetAddr, selResidence.Split('#')[0].Split('\t')[0],
                                StringComparison.CurrentCultureIgnoreCase))))).ToList();
                            }

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
                                    outputRichTextBox.Text += String.Format("{0} \t{1}  \t{2}",
                                                                res.FullName,
                                                                BusinessLayer.GetAge(res.Birthday),
                                                                res.Occupation) + "\n";
                                   
                                }
                            }
                        }
                        if(lstApt.Count > 0)
                        {
                            resident = item.Residents
                                .Where(x => (x.Id == lstApt[0].OwnerID || x.ResidenceIds.Contains(lstApt[0].Id))).ToList();

                            if (resident.Count > 0)
                            {
                                outputRichTextBox.Text = "Residents living at " + selResidence + ", " + communityVal
                                                            + ", owned by " + resident[0].FullName + ":";
                                outputRichTextBox.Text += "\n------------------------------------------------------------\n";
                                foreach (var res in resident)
                                {                                   
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
        #endregion

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
        public override string ToString()
        {
            //todo
            return base.ToString();
        }

        #region Abdul's code
        private void aptNoTextBox_TextChanged(object sender, EventArgs e)
        {
            //Disable garage and floors for apt(!empty).
            if(aptNoTextBox.Text.Length > 0)
            {
                garageCheckBox.Visible = false;
                floorsUpDown.Enabled = false;
            }          
            else if (aptNoTextBox.Text.Length == 0)
            {
                garageCheckBox.Visible = true;
                floorsUpDown.Enabled = true;
            }
        }

        private void addNewResidentButton_Click(object sender, EventArgs e)
        {
            string newName = nameTextBox.Text;
            string newOccu = occupationTextBox.Text;
            DateTime newBday = bdayDateTimePicker.Value;
            string newStreetAddr = residenceComboBox.Text;
            string newFirst, newLast, presentCommunity;
            bool nameError, bdayError, occuError, resError; // Error messages flags
            nameError = bdayError = occuError = resError = false;
            newFirst = newLast = presentCommunity= "";

            //validate all above properties
            if ((newName.Length != 0) && newName.Contains(' '))
            {
                string[] fullrName = newName.Split(' ');
                if (fullrName.Length == 2)
                {
                    newFirst = fullrName[0];
                    newLast = fullrName[1];
                }
                else
                {
                    //error message
                    nameError = true;
                    outputRichTextBox.Text = "ERROR: Please enter valid name for resident (Name should contain" +
                         "First-Name space then Last-Name e.g John Doe";
                }
            }
            else
            {
                //error message
                nameError = true;
                outputRichTextBox.Text = "ERROR: Please enter valid name for resident (Name should contain" +
                    "First-Name space then Last-Name e.g John Doe";
            }

            string fullName = newLast + ", " + newFirst;

            //Validation of names 
            if (newFirst.Length < 1 || newLast.Length < 1)
            {
                //error message
                nameError = true;
                outputRichTextBox.Text = "ERROR: Please enter valid name for resident (Name should contain" +
                    "First-Name space then Last-Name e.g John Doe";
            }

            //validate newBday is not in the future
            if ((newBday > DateTime.Now) && !nameError)
            {
                //error message
                bdayError = true;
                outputRichTextBox.Text = "ERROR: Choose a valid birthday (You don't live in the future)";
            }

            //Occupation length isn't empty
            if (!(newOccu.Length > 0) && !nameError && !bdayError)
            {
                //error message
                occuError = true;
                outputRichTextBox.Text = "ERROR: Please enter a valid Occupation " +
                    "(Enter \"none\" if in-between jobs)";
            }

            //Get checked community
            if (dekalbRadioButton.Checked)
            {
                presentCommunity = "Dekalb";
            }
            else if (sycamoreRadioButton.Checked)
            {
                presentCommunity = "Sycamore";
            }

            //Validate residence choice
            if (!nameError && !bdayError && !nameError && !occuError)
            {
                if (!(newStreetAddr.Length > 0) || (newStreetAddr == hyphen)
                    || (newStreetAddr == apartmentVal) || (newStreetAddr == houseVal))
                {
                    //error message
                    resError = true;
                    outputRichTextBox.Text = "ERROR: You have chosen an invalid residence choice!";
                }
                else if (personExists(fullName, presentCommunity)) //check person already in community
                {
                    //error message
                    resError = true;
                    outputRichTextBox.Text = "ERROR: This person already exists in the selected Community!";
                    return;
                }
                else
                {
                    uint resID = getApartmentId(newStreetAddr, presentCommunity);

                    //add resident to the person list
                    string[] newPerson = { "0" , newLast, newFirst, newOccu, newBday.Year.ToString(),
                                             newBday.Month.ToString(),newBday.Day.ToString(),resID.ToString()};

                    Person p = new Person(newPerson);
                    addPersonToList(p, presentCommunity);

                    outputRichTextBox.Text = "Success! " + newFirst + " has been added as" +
                        " a resident to " + presentCommunity + "!"; 
                    nameTextBox.Clear();
                    occupationTextBox.Clear();
                    residenceComboBox.ResetText();
                    bdayDateTimePicker.ResetText();
               
                }
            }
        }

        private void addProptButton_Click(object sender, EventArgs e)
        {
            string newStrAddr = streetAddrTextBox.Text;
            decimal newSqFt = sqFtUpDown.Value;
            decimal newBedrm = bedrmUpDown.Value;
            decimal newFlr = 0;
            string presentCommunity = "";
            bool hasGarage = false;
            bool garageAttached = false;
            string newApt = aptNoTextBox.Text;

            //Get checked community
            if (dekalbRadioButton.Checked)
            {
                presentCommunity = "Dekalb";
            }
            else if (sycamoreRadioButton.Checked)
            {
                presentCommunity = "Sycamore";
            }
            else     //Check if user selected a community, return error else
            {
                outputRichTextBox.Text = "ERROR: Please choose valid property Community!";
                return;
            }

            if (newApt.Length != 0)
            {
                newFlr = floorsUpDown.Value;
                if (garageCheckBox.Checked)
                {
                    hasGarage = true;
                    if (attachedCheckBox.Checked)
                    {
                        garageAttached = true;
                    }
                }
            }

            //Check if the address already exists
            propertyExists(newStrAddr,newApt, presentCommunity);

            //else add property to property

            //write a method to refresh the ListBoxes after new resident or propt is added
        }

        private void garageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (garageCheckBox.Checked)
            {
                attachedCheckBox.Visible = true;
            }
            else
            {
                attachedCheckBox.Visible = false;
            }
        }
        //
        // Helper methods
        //
        private bool personExists(string fullName, string community)
        {
            if (community == "Dekalb")
            {
                //loop and find person in Dekalb
                foreach (Person p in _businessLayer.lstDekalbPersons)
                {
                    if (p.FullName.ToLower().CompareTo(fullName.ToLower()) == 0)
                    {
                        return true;
                    }
                }
            }
            else if (community == "Sycamore")
            {
                //loop and find person in Sycamore
                foreach (Person p in _businessLayer.lstSycamorePersons)
                {
                    if (p.FullName.ToLower().CompareTo(fullName.ToLower()) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void addPersonToList(Person p, string community)
        {
            if(community == "Dekalb")
            { 
                _businessLayer.lstDekalbPersons.Add(p);
                return;
            }
            else if (community == "Sycamore")
            {
                _businessLayer.lstSycamorePersons.Add(p);
                return;
            }
        }

        private uint getApartmentId(string srtAddr, string community)
        {
            string street, unit;

            if (community == "Dekalb")
            {
                if (srtAddr.Contains("#"))
                {
                    //loop though, if streetAddr is same and unit number is same
                    string[] addr = srtAddr.Split('#');
                    street = addr[0];
                    unit = addr[1];
                    foreach(Apartment a in _businessLayer.lstDekalbApartments)
                    {
                        if((street == a.StreetAddr) && (unit == a.Unit))
                        {
                            return a.Id;
                        }
                    }
                }
                else
                {
                    foreach (House h in _businessLayer.lstDekalbHouses)
                    {
                        if (srtAddr == h.StreetAddr)
                        {
                            return h.Id;
                        }
                    }
                }
            }
            else if (community == "Sycamore")
            {
                if (srtAddr.Contains("#"))
                {
                    //loop though, if streetAddr is same and unit number is same
                    string[] addr = srtAddr.Split('#');
                    street = addr[0];
                    unit = addr[1];
                    foreach (Apartment a in _businessLayer.lstSycamoreApartments)
                    {
                        if ((street == a.StreetAddr) && (unit == a.Unit))
                        {
                            return a.Id;
                        }
                    }
                }
                else
                {
                    foreach (House h in _businessLayer.lstSycamoreHouses)
                    {
                        if (srtAddr == h.StreetAddr)
                        {
                            return h.Id;
                        }
                    }
                }

            }
            return 0;
        }

        private bool propertyExists(string newStrAddr, string newApt, string community)
        {
            return true;
        }

        #endregion

        #region Tony's code
        private void RemoveResident_click(object sender, EventArgs e)
        {
            if ((residenceListBox.SelectedItem == houseVal) || (residenceListBox.SelectedItem == hyphen) || (residenceListBox.SelectedItem == apartmentVal) || (residenceListBox.SelectedItem == "") || (residenceListBox.SelectedIndex == -1) || (personListBox.SelectedIndex == -1))
            {
                outputRichTextBox.Text = "You should select one preperty and one person";
                return;
            }
            List<Property> propRemoveResident_lst = null;
            List<Person> personRemoveResident_lst = null;
            string[] personStringArr = personListBox.SelectedItem.ToString().Split();
            string personBuyerFirstName = personStringArr[0];
            string communityName = null;
            string addressByUnit = null;
            uint apartmentID = 1;


            string[] addressStringArr = residenceListBox.SelectedItem.ToString().Split();
            string addressByStreetNum = addressStringArr[0] + " " + addressStringArr[1] + " " + addressStringArr[2];

            if (dekalbRadioButton.Checked)
                communityName = "Dekalb";
            else
                communityName = "Sycamore";


            foreach (var item in CommunitiesList)  //seaech person
            {
                if (item.Name == communityName)
                {
                    personRemoveResident_lst = item.Residents.Where(x => x.FirstName.ToLower().Equals(personBuyerFirstName.ToLower())).ToList();
                }

            }


            if (addressStringArr.Contains("#")) //search property
            {
                foreach (var item in CommunitiesList)
                {
                    if (item.Name == communityName)
                    {
                        addressByUnit = addressStringArr[4];
                        foreach (var apt_temp in item.Props)
                        {
                            if (apt_temp is Apartment)
                            {
                                Apartment temp = (Apartment)apt_temp;
                                if (temp.Unit == addressByUnit)
                                {
                                    apartmentID = temp.Id;
                                }
                            }
                        }
                        if (item.Name == communityName)
                        {
                            propRemoveResident_lst = item.Props.Where(x => (x.Id == apartmentID)).ToList();
                        }
                    }
                }
            }
            else
            {
                foreach (var item in CommunitiesList)
                {
                    if (item.Name == communityName)
                    {
                        propRemoveResident_lst = item.Props.Where(x => x.StreetAddr.ToLower().Equals(addressByStreetNum.ToLower())).ToList();
                    }
                }
            }
            //MessageBox.Show(propRemoveResident_lst[0].Id.ToString());


            if ( personRemoveResident_lst[0].ResidenceIds.Contains(propRemoveResident_lst[0].Id)==false)
            {
                outputRichTextBox.Text = "ERROR: " + personRemoveResident_lst[0].FirstName + " does not already reside at the property at " + residenceListBox.SelectedItem.ToString().TrimEnd('*');
                return;
            }



            if ((propRemoveResident_lst.Count == 1) && (personRemoveResident_lst.Count == 1))
            {
                foreach (var p_temp in personRemoveResident_lst)
                {
                    p_temp.ResidenceIds.Remove(propRemoveResident_lst[0].Id);
                    outputRichTextBox.Text = "Success! " + personRemoveResident_lst[0].FirstName + " no longer resides at the property at " + residenceListBox.SelectedItem.ToString().TrimEnd('*') + " !";


                }

            }
        }

        private void AddResident_click(object sender, EventArgs e)
        {
            if ((residenceListBox.SelectedItem == houseVal) || (residenceListBox.SelectedItem == hyphen) || (residenceListBox.SelectedItem == apartmentVal) || (residenceListBox.SelectedItem == "") || (residenceListBox.SelectedIndex == -1) || (personListBox.SelectedIndex == -1))
            {
                outputRichTextBox.Text = "You should select one preperty and one person";
                return;
            }

            List<Property> propAddResident_lst = null;
            List<Person> personAddResident_lst = null;
            string communityName = null;
            uint apartmentID = 1;


            string[] personStringArr = personListBox.SelectedItem.ToString().Split();
            string personBuyerFirstName = personStringArr[0];


            string[] addressStringArr = residenceListBox.SelectedItem.ToString().Split();
            string addressByStreetNum = addressStringArr[0] + " " + addressStringArr[1] + " " + addressStringArr[2];
            string addressByUnit = null;

            if (dekalbRadioButton.Checked)
                communityName = "Dekalb";
            else
                communityName = "Sycamore";



            foreach (var item in CommunitiesList) //search person
            {
                if (item.Name == communityName)
                {
                    personAddResident_lst = item.Residents.Where(x => x.FirstName.ToLower().Equals(personBuyerFirstName.ToLower())).ToList();
                }

            }

            if (addressStringArr.Contains("#")) //search property
            {
                foreach (var item in CommunitiesList)
                {
                    if (item.Name == communityName)
                    {
                        addressByUnit = addressStringArr[4];
                        foreach (var apt_temp in item.Props)
                        {
                            if (apt_temp is Apartment)
                            {
                                Apartment temp = (Apartment)apt_temp;
                                if (temp.Unit == addressByUnit)
                                {
                                    apartmentID = temp.Id;
                                }
                            }
                        }
                        if (item.Name == communityName)
                        {
                            propAddResident_lst = item.Props.Where(x => (x.Id == apartmentID)).ToList();
                        }
                    }
                }
            }
            else
            {
                foreach (var item in CommunitiesList)
                {
                    if (item.Name == communityName)
                    {
                        propAddResident_lst = item.Props.Where(x => x.StreetAddr.ToLower().Equals(addressByStreetNum.ToLower())).ToList();
                    }
                }
            }
            if (personAddResident_lst[0].ResidenceIds.Contains(propAddResident_lst[0].Id))
            {
                outputRichTextBox.Text = "ERROR: " + personAddResident_lst[0].FirstName + " already resides at the property at " + residenceListBox.SelectedItem.ToString().TrimEnd('*');
                return;
            }
            if ((propAddResident_lst.Count == 1) && (personAddResident_lst.Count == 1))
            {
                foreach (var p_temp in personAddResident_lst)
                {
                    p_temp.ResidenceIds.Add(propAddResident_lst[0].Id);
                    outputRichTextBox.Text = "Success!" + personAddResident_lst[0].FirstName + " now resides at the property at " + residenceListBox.SelectedItem.ToString().TrimEnd('*') + " !";

                    //test msg box
                    //for (int i = 0; i < p_temp.ResidenceIds.ToArray().Count(); i++)
                    //   MessageBox.Show(p_temp.ResidenceIds.ToArray()[i].ToString());

                }

            }
        }

        private void BuyProperty_click(object sender, EventArgs e)
        {
            //if user select wrong thing(s)
            if((residenceListBox.SelectedItem == houseVal) || (residenceListBox.SelectedItem == hyphen) || (residenceListBox.SelectedItem == apartmentVal) || (residenceListBox.SelectedItem == "")||(residenceListBox.SelectedIndex==-1) || (personListBox.SelectedIndex == -1))
            {
                outputRichTextBox.Text = "You should select one preperty and one person";
                return;
            }
            List<Property> propBuyProperty_lst = null;
            List<Person> personBuyProperty_lst = null;
            string[] personStringArr = personListBox.SelectedItem.ToString().Split();
            string communityName = null;
            string addressByUnit = null;
            uint apartmentID = 1;
            string personBuyerFirstName = personStringArr[0];
            

            string[] addressStringArr = residenceListBox.SelectedItem.ToString().Split();
            string addressByStreetNum = addressStringArr[0] + " " + addressStringArr[1] + " " + addressStringArr[2];

            if (dekalbRadioButton.Checked)
                communityName = "Dekalb";
            else
                communityName = "Sycamore";

            
            //search the selected person
            foreach (var item in CommunitiesList)
            {
                if (item.Name == communityName)
                {

                    personBuyProperty_lst = item.Residents.Where(x => x.FirstName.ToLower().Equals(personBuyerFirstName.ToLower())).ToList();
                }

            }
            //MessageBox.Show(personBuyProperty_lst[0].Id.ToString());

            //search the selected property
            if (addressStringArr.Contains("#"))
            {
                foreach (var item in CommunitiesList)
                {
                    if (item.Name == communityName)
                    {
                        addressByUnit = addressStringArr[4];
                        foreach (var apt_temp in item.Props)
                        {
                            if (apt_temp is Apartment)
                            {
                                Apartment temp = (Apartment)apt_temp;
                                if (temp.Unit == addressByUnit)
                                {
                                    apartmentID = temp.Id;
                                }
                            }
                        }
                        if (item.Name == communityName)
                        {
                            propBuyProperty_lst = item.Props.Where(x => (x.Id == apartmentID)).ToList();
                        }
                    }
                }
            }
            else
            {
                foreach (var item in CommunitiesList)
                {
                    if (item.Name == communityName)
                    {
                        propBuyProperty_lst = item.Props.Where(x => x.StreetAddr.ToLower().Equals(addressByStreetNum.ToLower())).ToList();
                    }
                }
            }
            // MessageBox.Show(propBuyProperty_lst[0].StreetAddr);
            if (propBuyProperty_lst[0].OwnerID == personBuyProperty_lst[0].Id )
            {
                outputRichTextBox.Text = "ERROR: " + personBuyProperty_lst[0].FirstName + " already owns the property fount at " + residenceListBox.SelectedItem.ToString().TrimEnd('*');
                return;
            }
            if (propBuyProperty_lst[0].ForSale == false)
            {
                outputRichTextBox.Text = "ERROR: could not purchase the property at " + residenceListBox.SelectedItem.ToString().TrimEnd('*') + "as it is not listed for sale";
                return;
            }

            if ((personBuyProperty_lst.Count == 1) && (personBuyProperty_lst.Count == 1))
            {
                foreach (var p_temp in propBuyProperty_lst)
                {
                    p_temp.OwnerID = personBuyProperty_lst[0].Id;
                    //MessageBox.Show(propBuyProperty_lst[0].OwnerID.ToString());

                    outputRichTextBox.Text = "Success: " + personBuyProperty_lst[0].FirstName + "has purchased the property at " + residenceListBox.SelectedItem.ToString().TrimEnd('*');
                    residenceListBox.Items[residenceListBox.SelectedIndex] = residenceListBox.SelectedItem.ToString().TrimEnd('*');
                    //residenceListBox.ClearSelected();
                    //personListBox.ClearSelected();
                }
                //Console.WriteLine(streetAddress + " is now listed as " + (prop.FirstOrDefault().ForSale ? "" : "NOT ") + "for sale!");
            }
        }

        private void ToggleForSale_click(object sender, EventArgs e)
        {

            if ((residenceListBox.SelectedItem == houseVal)|| (residenceListBox.SelectedItem == hyphen)|| (residenceListBox.SelectedItem == apartmentVal)||(residenceListBox.SelectedItem =="")|| (residenceListBox.SelectedIndex == -1)) //no property is selected
            {
                MessageBox.Show("No property is selected. Please select one");
                return;
            }

            List<Property> prop_forToggle = null;
            string[] addressStringArr = residenceListBox.SelectedItem.ToString().Split();
            string addressByStreetNum = null;
            string addressByUnit = null;
            uint apartmentID = 1;
            addressByStreetNum = addressStringArr[0] + " " + addressStringArr[1] + " " + addressStringArr[2];
            string communityName = null;

            if (dekalbRadioButton.Checked)
                communityName = "Dekalb";
            else
                communityName = "Sycamore";




            if (addressStringArr.Contains("#"))//apartment
            {

                foreach (var item in CommunitiesList)
                {
                    if (item.Name == communityName)
                    {
                        addressByUnit = addressStringArr[4];
                        foreach (var apt_temp in item.Props)
                        {
                            if (apt_temp is Apartment)
                            {
                                Apartment temp = (Apartment)apt_temp;
                                if (temp.Unit == addressByUnit)
                                {
                                    apartmentID = temp.Id;
                                }
                            }
                        }
                        if (item.Name == communityName)
                        {
                            prop_forToggle = item.Props.Where(x => (x.Id == apartmentID)).ToList();
                        }
                    }
                }
            }
            else //house
            {
                foreach (var item in CommunitiesList)
                {
                    if (item.Name == communityName)
                    {
                        prop_forToggle = item.Props.Where(x => x.StreetAddr.ToLower().Equals(addressByStreetNum.ToLower())).ToList();
                    }
                }
            }
            if (prop_forToggle.Count > 0)
            {
                foreach (var p_temp in prop_forToggle)
                {
                    if (p_temp.ForSale == true)
                    {
                        p_temp.ForSale = !p_temp.ForSale;
                        //MessageBox.Show("this is not for sale now!!:( SAd");
                        residenceListBox.Items[residenceListBox.SelectedIndex] = residenceListBox.SelectedItem.ToString().TrimEnd('*');
                        outputRichTextBox.Text = residenceListBox.SelectedItem.ToString() +" is not for sale now.";
                    }
                    else
                    {
                        p_temp.ForSale = !p_temp.ForSale;
                        //MessageBox.Show("this is for sale:( Nice!");
                        residenceListBox.Items[residenceListBox.SelectedIndex] = residenceListBox.SelectedItem.ToString()+"*";
                        outputRichTextBox.Text = residenceListBox.SelectedItem.ToString().TrimEnd('*') + " is for sale now.";
                    }
                    //MessageBox.Show(prop_forToggle.Count.ToString());

                }


                //Console.WriteLine(streetAddress + " is now listed as " + (prop.FirstOrDefault().ForSale ? "" : "NOT ") + "for sale!");
            }


        }
        #endregion


    }
}
