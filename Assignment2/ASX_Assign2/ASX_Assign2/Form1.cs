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
                    details.FirstName, BusinessLayer.GetAge(details.Birthday), details.ToString()));
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
                    /*foreach (var y in item.Residents)
                    {
                        var g = y.FirstName;
                        var k = selPerson.Split(' ')[0];
                    }*/
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
            string selResidence = residenceListBox.GetItemText(residenceListBox.SelectedItem).TrimEnd(' ', '*');
            if (dekalbRadioButton.Checked)
                communityVal = "Dekalb";
            else
                communityVal = "Sycamore";
            if (selResidence != null && selResidence != "" && selResidence != houseVal &&
                selResidence != hyphen && selResidence != apartmentVal)
            {
                List<Person> resident = new List<Person>();
                List<Property> prop = new List<Property>();

                List<Person> landlord = new List<Person>();

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
                        if (prop.Count > 0)
                        {
                            landlord = item.Residents
                                .Where(x => (x.Id == prop[0].OwnerID)).ToList();
                            resident = item.Residents
                                .Where(x => (x.ResidenceIds.Contains(prop[0].Id))).ToList();

                            //resident = item.Residents
                            //    .Where(x => (x.Id == prop[0].OwnerID || x.ResidenceIds.Contains(prop[0].Id))).ToList();
                            if ((landlord.Count==0) && (resident.Count == 0) )
                            {
                                outputRichTextBox.Text = "Residents living at " + selResidence + ", " + communityVal
                                                        + ", owned by " + ":";
                                outputRichTextBox.Text += "\n------------------------------------------------------------\n";
                                outputRichTextBox.Text += "No resident lives in this property.\n";
                            }

                            else if ((landlord.Count > 0) && (resident.Count == 0) )
                            {
                                outputRichTextBox.Text = "Residents living at " + selResidence + ", " + communityVal
                                                        + ", owned by " + landlord[0].FullName + ":";
                                outputRichTextBox.Text += "\n------------------------------------------------------------\n";
                                outputRichTextBox.Text += "No resident lives in this property.\n";
                            }
                            else if ((landlord.Count == 0) && (resident.Count > 0) )
                            {
                                outputRichTextBox.Text = "Residents living at " + selResidence + ", " + communityVal
                                                        + ", owned by " +  ":";
                                outputRichTextBox.Text += "\n------------------------------------------------------------\n";
                                foreach (var res in resident)
                                {
                                    outputRichTextBox.Text += String.Format("{0} \t{1}  \t{2}",
                                                                res.FullName,
                                                                BusinessLayer.GetAge(res.Birthday),
                                                                res.Occupation) + "\n";

                                }
                            }
                            else
                            {
                                outputRichTextBox.Text = "Residents living at " + selResidence + ", " + communityVal
                                                            + ", owned by " + landlord[0].FullName + ":";
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
                        if (lstApt.Count > 0)
                        {
                            //resident = item.Residents
                                //.Where(x => (x.Id == lstApt[0].OwnerID || x.ResidenceIds.Contains(lstApt[0].Id))).ToList();
                            
                            landlord = item.Residents
                                .Where(x => (x.Id == lstApt[0].OwnerID)).ToList();
                            resident = item.Residents
                                .Where(x => (x.ResidenceIds.Contains(lstApt[0].Id))).ToList();
                            if ((landlord.Count == 0) && (resident.Count == 0))
                            {
                                outputRichTextBox.Text = "Residents living at " + selResidence + ", " + communityVal
                                                        + ", owned by " + ":";
                                outputRichTextBox.Text += "\n------------------------------------------------------------\n";
                                outputRichTextBox.Text += "No resident lives in this property.\n";
                            }

                            else if ((landlord.Count > 0) && (resident.Count == 0))
                            {
                                outputRichTextBox.Text = "Residents living at " + selResidence + ", " + communityVal
                                                        + ", owned by " + landlord[0].FullName + ":";
                                outputRichTextBox.Text += "\n------------------------------------------------------------\n";
                                outputRichTextBox.Text += "No resident lives in this property.\n";
                            }
                            else if ((landlord.Count == 0) && (resident.Count > 0))
                            {
                                outputRichTextBox.Text = "Residents living at " + selResidence + ", " + communityVal
                                                        + ", owned by " + ":";
                                outputRichTextBox.Text += "\n------------------------------------------------------------\n";
                                foreach (var res in resident)
                                {
                                    outputRichTextBox.Text += String.Format("{0} \t{1}  \t{2}",
                                                                res.FullName,
                                                                BusinessLayer.GetAge(res.Birthday),
                                                                res.Occupation) + "\n";

                                }
                            }

                            else
                            {
                                outputRichTextBox.Text = "Residents living at " + selResidence + ", " + communityVal
                                                            + ", owned by " + landlord[0].FullName + ":";
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
       
        #region Abdul's code
        private void aptNoTextBox_TextChanged(object sender, EventArgs e)
        {
            //Disable garage and floors for apt(!empty).
            if (aptNoTextBox.Text.Length > 0)
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
            newFirst = newLast = presentCommunity = "";

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
                         "First-Name space then Last-Name e.g John Doe)";
                }
            }
            else
            {
                //error message
                nameError = true;
                outputRichTextBox.Text = "ERROR: Please enter valid name for resident (Name should contain" +
                    "First-Name space then Last-Name e.g John Doe)";
            }

            string fullName = newLast + ", " + newFirst;

            //Validation of names 
            if (newFirst.Length < 1 || newLast.Length < 1)
            {
                //error message
                nameError = true;
                outputRichTextBox.Text = "ERROR: Please enter valid name for resident (Name should contain" +
                    "First-Name space then Last-Name e.g John Doe)";
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

                    //
                    //generate a new ID for the new person
                    //
                    Random rand = new Random();
                    bool newPersonIDValid = false;
                    List<Person> personSelected = null;
                    int newPersonID = rand.Next(2000);
                    while (newPersonIDValid ==false) //make sure the id is unique
                    {
                        newPersonID = rand.Next(2000);
                        foreach (var item in CommunitiesList)  
                        {
                            if (item.Name == presentCommunity)
                            {
                                personSelected = item.Residents.Where(x => x.Id.Equals(newPersonID)).ToList();
                            }

                        }
                        if(personSelected.Count ==0)
                        {
                            newPersonIDValid = true;
                        }
                    }
                    //
                    //a new ID is generatered.
                    //

                    string[] newPerson = { newPersonID.ToString() , newLast, newFirst, newOccu, newBday.Year.ToString(),
                                             newBday.Month.ToString(),newBday.Day.ToString(),resID.ToString()};
                    MessageBox.Show(newPersonID.ToString());
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
            decimal newBath = bathUpDown.Value;
            decimal newFlr = 0;
            string presentCommunity, strNo, strName, strType;
            presentCommunity = strNo = strName = strType = "";
            string hasGarage = "";
            string garageAttached = "";
            string newApt = aptNoTextBox.Text;
            string[] strInfo = newStrAddr.Split(' ');

            //Get checked community
            if (dekalbRadioButton.Checked)
            {
                presentCommunity = "Dekalb";
            }
            else if (sycamoreRadioButton.Checked)
            {
                presentCommunity = "Sycamore";
            }
            else     //Check if user selected a community,else return error 
            {
                outputRichTextBox.Text = "ERROR: Please choose valid property Community!";
                return;
            }

            if ( (strInfo.Length != 3) || !(strInfo[0].All(char.IsDigit)) )
            {
                outputRichTextBox.Text = "ERROR: Please enter a valid street Address!";
                return;
            }else if (!(strInfo[2].Length > 0))
            {
                outputRichTextBox.Text = "ERROR: Please enter a valid street Address!";
                return;
            }

            if (newApt.Length == 0)
            {
                newFlr = floorsUpDown.Value;
                if (garageCheckBox.Checked)
                {
                    hasGarage = "T";
                    if (attachedCheckBox.Checked)
                    {
                        garageAttached = "T";
                    }
                }
            }


            //Check if the address already exists
           if( propertyExists(newStrAddr, newApt, presentCommunity))
            {
                outputRichTextBox.Text = "ERROR: This property already exists!";
                return;
            }
            else //else add property to property
            {
                string[] aptArray = { "0", "9999", "98", "50" , newStrAddr,
                                              presentCommunity, "Illinois", "60505",
                                           "T",newBedrm.ToString(), newBath.ToString(),newSqFt.ToString(),
                                            }; //12
                List<string> newProperty = aptArray.ToList();
                if (newFlr > 0)
                {
                    newProperty.Add(hasGarage);
                    newProperty.Add(garageAttached);
                    newProperty.Add(newFlr.ToString());
                    addPropertyToList(newProperty.ToArray(), false, presentCommunity);
                }
                else
                {
                    newProperty.Add(newApt);
                    addPropertyToList(newProperty.ToArray(), true, presentCommunity);
                }

            }

            
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
            if (community == "Dekalb")
            {
                _businessLayer.lstDekalbPersons.Add(p);
                _businessLayer.Communities.FirstOrDefault(x => x.Name == "Dekalb").Residents.Add(p);

                _businessLayer.lstDekalbPersons.Sort(new BusinessLayer.PersonComparer());//sort the people in the _businessLayer.lstDekalbPersons
                DisplayCommunityResults(_businessLayer.lstDekalbPersons,
                                        _businessLayer.lstDekalbHouses,
                                        _businessLayer.lstDekalbApartments, community);
                return;
            }
            else if (community == "Sycamore")
            {
                _businessLayer.lstSycamorePersons.Add(p);
                _businessLayer.Communities.FirstOrDefault(x => x.Name == "Sycamore").Residents.Add(p);
                _businessLayer.lstSycamorePersons.Sort(new BusinessLayer.PersonComparer()); // sort the people in the _businessLayer.lstDekalbPersons
                DisplayCommunityResults(_businessLayer.lstSycamorePersons,
                                        _businessLayer.lstSycamoreHouses,
                                        _businessLayer.lstSycamoreApartments, community);
                return;
            }
        }

        private void addPropertyToList(string [] arr, bool isApt, string community)
        {
            if (community == "Dekalb")
            {
                if (isApt)
                {
                    Apartment a = new Apartment(arr);
                    _businessLayer.lstDekalbApartments.Add(a);
                    _businessLayer.Communities.FirstOrDefault(x => x.Name == "Dekalb").Props.Add(a);
                    _businessLayer.lstDekalbApartments.Sort(new PropertyComparer());
                } else
                {
                    House house = new House(arr);
                    _businessLayer.lstDekalbHouses.Add(house);
                    _businessLayer.Communities.FirstOrDefault(x => x.Name == "Dekalb").Props.Add(house);
                    _businessLayer.lstDekalbHouses.Sort(new PropertyComparer());
                }
                DisplayCommunityResults(_businessLayer.lstDekalbPersons,
                                        _businessLayer.lstDekalbHouses,
                                        _businessLayer.lstDekalbApartments, community);
                return;
            }
            else if (community == "Sycamore")
            {
                if (isApt)
                {
                    Apartment a = new Apartment(arr);
                    _businessLayer.lstSycamoreApartments.Add(a);
                    _businessLayer.Communities.FirstOrDefault(x => x.Name == "Sycamore").Props.Add(a);
                    _businessLayer.lstSycamoreApartments.Sort(new PropertyComparer());
                }
                else
                {
                    House house = new House(arr);
                    _businessLayer.lstSycamoreHouses.Add(house);
                    _businessLayer.Communities.FirstOrDefault(x => x.Name == "Sycamore").Props.Add(house);
                    _businessLayer.lstSycamoreHouses.Sort(new PropertyComparer());
                }
                DisplayCommunityResults(_businessLayer.lstSycamorePersons,
                                        _businessLayer.lstSycamoreHouses,
                                        _businessLayer.lstSycamoreApartments, community);
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
                    foreach (Apartment a in _businessLayer.lstDekalbApartments)
                    {
                        if ((street == a.StreetAddr) && (unit == a.Unit))
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
            //dismatle newStrAddr
            string tempAdd = newStrAddr;
            if (community == "Dekalb")
            {
                if (newApt.Length > 0)
                {
                    foreach (Apartment a in _businessLayer.lstDekalbApartments)
                    {
                        newStrAddr = tempAdd;
                        if (((a.StreetAddr.LastIndexOf('.')) == (a.StreetAddr.Length - 1))
                             && ((newStrAddr.LastIndexOf('.')) != (newStrAddr.Length - 1)))
                        {
                            newStrAddr += '.';
                        }
                        if (a.StreetAddr.ToLower().CompareTo(newStrAddr.ToLower()) == 0)
                        {
                            if(a.Unit.ToLower().CompareTo(newApt.ToLower()) == 0)
                                return true;
                        }
                    }
                } else
                {
                    foreach (House house in _businessLayer.lstDekalbHouses)
                    {
                        newStrAddr = tempAdd;
                        if (((house.StreetAddr.LastIndexOf('.')) == (house.StreetAddr.Length - 1))
                            && ((newStrAddr.LastIndexOf('.')) != (newStrAddr.Length - 1)))
                        {
                            newStrAddr += '.';
                        }

                        if (house.StreetAddr.ToLower().CompareTo(newStrAddr.ToLower()) == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            else if (community == "Sycamore")
            {
                if (newApt.Length > 0)
                {
                    foreach (Apartment a in _businessLayer.lstSycamoreApartments)
                    {
                        newStrAddr = tempAdd;
                        if (((a.StreetAddr.LastIndexOf('.')) == (a.StreetAddr.Length - 1))
                            && ((newStrAddr.LastIndexOf('.')) != (newStrAddr.Length - 1)))
                        {
                            newStrAddr += '.';
                        }
                        if (a.StreetAddr.ToLower().CompareTo(newStrAddr.ToLower()) == 0)
                        {
                            if (a.Unit.ToLower().CompareTo(newApt.ToLower()) == 0)
                                return true;
                        }
                    }
                }
                else
                {
                    foreach (House house in _businessLayer.lstSycamoreHouses)
                    {
                        newStrAddr = tempAdd;
                        if (((house.StreetAddr.LastIndexOf('.')) == (house.StreetAddr.Length - 1))
                             && ((newStrAddr.LastIndexOf('.')) != (newStrAddr.Length - 1)))
                        {
                            newStrAddr += '.';
                        }
                        if (house.StreetAddr.ToLower().CompareTo(newStrAddr.ToLower()) == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        #endregion

        #region Xuezhi's code


        //search the selected person
        //  return the list<person> which includes selected person in the personListBox
        private List<Person> SearchSelectedPerson()
        {
            List<Person> personSelected = null;        
            string communityName = null; //record the commuynity name, eg.Dekalb or sycamore
            string[] personStringArr = personListBox.SelectedItem.ToString().Split();
            string personFirstName = null; //record the first name in the personListBox
            personFirstName = personStringArr[0];

            //identify which community the user is looking for
            if (dekalbRadioButton.Checked)
                communityName = "Dekalb";
            else
                communityName = "Sycamore";

            //if the person in CommunitiesList has the same first name with the selected
            //  add it to the List<Person>
            foreach (var item in CommunitiesList)  //seaech person
            {
                if (item.Name == communityName)
                {
                    personSelected = item.Residents.Where(x => x.FirstName.ToLower().Equals(personFirstName.ToLower())).ToList();
                }

            }

            //return the list including selected person
            return personSelected;
        }

        //search selected property
        //  return the list<property> which is selected in the residence listbox
        private List<Property> SearchSelectedProperty()
        {
            List<Property> propsSelected = null;
            string communityName = null; //record the commuynity name, eg.Dekalb or sycamore
            string addressByStreetNum = null; //record the street address of the residenceListBox
            string addressByUnit = null; // record the unit of the residenceListBox if user selects an apartment
            uint apartmentID = 1; // record the id of the selected apartment
            string[] addressStringArr = residenceListBox.SelectedItem.ToString().Split();

            addressByStreetNum = addressStringArr[0] + " " + addressStringArr[1] + " " + addressStringArr[2];

            //identify which community the user is looking for
            if (dekalbRadioButton.Checked)
                communityName = "Dekalb";
            else
                communityName = "Sycamore";

            //if the property in CommunitiesList has the same address with the selected property
            //  add it to the List<Property>
            if (addressStringArr.Contains("#")) //if user selects an apartment, the unit and street addres would be compared
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

                                if ((temp.Unit == addressByUnit) && (addressByStreetNum.CompareTo(temp.StreetAddr))==0)
                                {

                                    apartmentID = temp.Id;
                                }
                            }
                        }
                        if (item.Name == communityName)
                        {
                            propsSelected = item.Props.Where(x => (x.Id == apartmentID)).ToList();
                        }
                    }
                }
            }
            else //if user selects a house, the street addres would be compared
            {
                foreach (var item in CommunitiesList)
                {
                    if (item.Name == communityName)
                    {
                        propsSelected = item.Props.Where(x => x.StreetAddr.ToLower().Equals(addressByStreetNum.ToLower())).ToList();
                    }
                }
            }

            //return the list including selected property
            return propsSelected;


        }


        // Remove the a resident to a property
        // After user selects a person and a property,
        //         then click the Remove Resident button,
        //         the id of property is removed from the residnet list of the person
        private void RemoveResident_click(object sender, EventArgs e)
        {
            // if user selects wrong thing(s), return message and quit this method
            if ((residenceListBox.SelectedItem == houseVal) || (residenceListBox.SelectedItem == hyphen) || (residenceListBox.SelectedItem == apartmentVal) || (residenceListBox.SelectedItem == "") || (residenceListBox.SelectedIndex == -1) || (personListBox.SelectedIndex == -1))
            {
                outputRichTextBox.Text = "You should select one preperty and one person";
                return;
            }

            // search selected person and property in the listbox
            List<Property> propRemoveResident_lst = null;
            List<Person> personRemoveResident_lst = null;
            personRemoveResident_lst = SearchSelectedPerson();
            propRemoveResident_lst = SearchSelectedProperty();

            // if the selected person is not a resident in this property, return message and quit this method
            if (personRemoveResident_lst[0].ResidenceIds.Contains(propRemoveResident_lst[0].Id) == false)
            {
                outputRichTextBox.Text = "ERROR: " + personRemoveResident_lst[0].FirstName + " doesn't currently reside at the property at " + residenceListBox.SelectedItem.ToString().TrimEnd('*') + ".";
                return;
            }

            // if one property and one person is selected, this method change the the resident list of person 
            // the ID of house is removed from the person' resident list
            if ((propRemoveResident_lst.Count == 1) && (personRemoveResident_lst.Count == 1))
            {
                foreach (var p_temp in personRemoveResident_lst)
                {
                    p_temp.ResidenceIds.Remove(propRemoveResident_lst[0].Id);                    
                }
                outputRichTextBox.Text = "Success! " + personRemoveResident_lst[0].FirstName + " no longer resides at the property at " + residenceListBox.SelectedItem.ToString().TrimEnd('*') + "!";
            }
        }

        // Add the a resident to a property
        // After user selects a person and a property,
        //         then click the Add Resident button,
        //         the id of property is added to the residnet list of the person
        
        private void AddResident_click(object sender, EventArgs e)
        {
            // if user selects wrong thing(s), return message and quit this method
            if ((residenceListBox.SelectedItem == houseVal) || (residenceListBox.SelectedItem == hyphen) || (residenceListBox.SelectedItem == apartmentVal) || (residenceListBox.SelectedItem == "") || (residenceListBox.SelectedIndex == -1) || (personListBox.SelectedIndex == -1))
            {
                outputRichTextBox.Text = "You should select one preperty and one person";
                return;
            }

            // search selected person and property in the listbox
            List<Property> propAddResident_lst = null;
            List<Person> personAddResident_lst = null;
            personAddResident_lst = SearchSelectedPerson();
            propAddResident_lst = SearchSelectedProperty();

            // if the selected person is already as resident in this property, return message and quit this method
            if (personAddResident_lst[0].ResidenceIds.Contains(propAddResident_lst[0].Id))
            {
                outputRichTextBox.Text = "ERROR: " + personAddResident_lst[0].FirstName + " already resides at the property at " + residenceListBox.SelectedItem.ToString().TrimEnd('*') + ".";
                return;
            }

            // if one property and one person is selected, this method change the the resident list of person 
            // the ID of house is add to the person' resident list
            if ((propAddResident_lst.Count == 1) && (personAddResident_lst.Count == 1))
            {
                foreach (var p_temp in personAddResident_lst)
                {
                    p_temp.ResidenceIds.Add(propAddResident_lst[0].Id);
                    outputRichTextBox.Text = "Success! " + personAddResident_lst[0].FirstName + " now resides at the property at " + residenceListBox.SelectedItem.ToString().TrimEnd('*') + "!";
                }

            }
        }

        // Change the owner of a property
        // After user select a person and a property,
        //         then click the buy Property button,
        //         the onwer of the property will be changed to selectded person
        private void BuyProperty_click(object sender, EventArgs e)
        {
            // if user selects wrong thing(s), return message and quit this method
            if ((residenceListBox.SelectedItem == houseVal) || (residenceListBox.SelectedItem == hyphen) || (residenceListBox.SelectedItem == apartmentVal) || (residenceListBox.SelectedItem == "") || (residenceListBox.SelectedIndex == -1) || (personListBox.SelectedIndex == -1))
            {
                outputRichTextBox.Text = "You should select one preperty and one person";
                return;
            }

            // search selected items in the listbox
            List<Property> propBuyProperty_lst = null;
            List<Person> personBuyProperty_lst = null;
            propBuyProperty_lst = SearchSelectedProperty();
            personBuyProperty_lst = SearchSelectedPerson();

            // if the person is the owner of the property, return message and quit this method
            if (propBuyProperty_lst[0].OwnerID == personBuyProperty_lst[0].Id)
            {
                outputRichTextBox.Text = "ERROR: " + personBuyProperty_lst[0].FirstName + " already owns the property found at " + residenceListBox.SelectedItem.ToString().TrimEnd('*') + ".";
                return;
            }

            // if the property is not for sall, return message and quit this method
            if (propBuyProperty_lst[0].ForSale == false)
            {
                outputRichTextBox.Text = "ERROR: Could not purchase the property at " + residenceListBox.SelectedItem.ToString().TrimEnd('*') + ", as it is not listed for sale.";
                return;
            }

            // if one property and one person is selected, this method change the owner of property
            if ((personBuyProperty_lst.Count == 1) && (personBuyProperty_lst.Count == 1))
            {
                foreach (var p_temp in propBuyProperty_lst)
                {
                    p_temp.OwnerID = personBuyProperty_lst[0].Id;
                    residenceListBox.Items[residenceListBox.SelectedIndex] = residenceListBox.SelectedItem.ToString().TrimEnd('*');
                }
                outputRichTextBox.Text = "Success! " + personBuyProperty_lst[0].FirstName + "has purchased the property at " + residenceListBox.SelectedItem.ToString().TrimEnd('*') + "!";

            }
        }

        // Change the forsale variable of a property
        // After user select  a property,
        //         then click the ToggleForSale button,
        //         the forsale variable of a property will be negated
        private void ToggleForSale_click(object sender, EventArgs e)
        {
            // if user selects wrong thing(s), return message and quit this method
            if ((residenceListBox.SelectedItem == houseVal) || (residenceListBox.SelectedItem == hyphen) || (residenceListBox.SelectedItem == apartmentVal) || (residenceListBox.SelectedItem == "") || (residenceListBox.SelectedIndex == -1)) //no property is selected
            {
                MessageBox.Show("No property is selected. Please select one");
                return;
            }

            // search selectedproperty in the listbox
            List<Property> prop_forToggle = null;
            prop_forToggle = SearchSelectedProperty();

            // if one property is selected,change the forsale variable and then output the message
            if (prop_forToggle.Count ==1 )
            {
                foreach (var p_temp in prop_forToggle)
                {
                    if (p_temp.ForSale == true)
                    {
                        p_temp.ForSale = !p_temp.ForSale;
                        //MessageBox.Show("this is not for sale now!!:( SAd");
                        residenceListBox.Items[residenceListBox.SelectedIndex] = residenceListBox.SelectedItem.ToString().TrimEnd('*');
                        outputRichTextBox.Text = residenceListBox.SelectedItem.ToString() + " is not for sale now.";
                    }
                    else
                    {
                        p_temp.ForSale = !p_temp.ForSale;
                        //MessageBox.Show("this is for sale:( Nice!");
                        residenceListBox.Items[residenceListBox.SelectedIndex] = residenceListBox.SelectedItem.ToString() + "*";
                        outputRichTextBox.Text = residenceListBox.SelectedItem.ToString().TrimEnd('*') + " is now listed FOR SALE!";
                    }
                    //MessageBox.Show(prop_forToggle.Count.ToString());

                }
            }
        }
        #endregion

    }
}
