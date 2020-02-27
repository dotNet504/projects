/*********************************************************************************************************
 *                                                                                                       *
 *  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 3					 Spring 2020     *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: Form1
 *  Purpose   : Windows application that displays the property details of Dekalb & Sycamore Communities. *
 *********************************************************************************************************/

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

namespace ASX_assign3
{
    public partial class Form1 : Form
    {
        #region - Swathi's Code
        //Declaration of variables
        private BusinessLayer _businessLayer;
        private List<Person> dekalbPersons;
        private List<House> dekalbHouses;
        private List<Apartment> dekalbApartments;
        private List<Person> sycamorePersons;
        private List<House> sycamoreHouses;
        private List<Apartment> sycamoreApartments;
        private List<Community> CommunitiesList;
        private List<School> dekalbSchools;
        private List<School> sycamoreSchools;
        private List<Business> dekalbBusinesses;
        private List<Business> sycamoreBusinesses;

        //Constant Variables declaration
        private const string hyphen = "-----------------------------------------------------------------";
        private const string dekalbVal = "Dekalb:";
        private const string shortHyphen = "-------------";
        private const string sycamoreVal = "Sycamore:";

        public Form1()
        {
            InitializeComponent();
            _businessLayer = new BusinessLayer();
            dekalbPersons = new List<Person>();
            dekalbHouses = _businessLayer.lstDekalbHouses;
            dekalbApartments = _businessLayer.lstDekalbApartments;
            sycamorePersons = new List<Person>();
            sycamoreHouses = _businessLayer.lstSycamoreHouses;
            sycamoreApartments = _businessLayer.lstSycamoreApartments;
            CommunitiesList = _businessLayer.Communities;
            dekalbPersons = _businessLayer.lstDekalbPersons;
            sycamorePersons = _businessLayer.lstSycamorePersons;
            dekalbSchools = new List<School>();
            dekalbSchools = _businessLayer.lstDekalbSchools;
            dekalbBusinesses = _businessLayer.lstDekalbBusiness;
            sycamoreSchools = new List<School>();
            sycamoreSchools = _businessLayer.lstSycamoreSchools;
            sycamoreBusinesses = _businessLayer.lstSycamoreBusiness;

            trackBarMin.Minimum = 65000;
            trackBarMin.Maximum = 310000;
            trackBarMax.Minimum = 65000;
            trackBarMax.Maximum = 310000;
            trackBarMin.Value = 65000;
            trackBarMax.Value = 310000;
            trackBarMin.TickFrequency = (int)(310000 - 65000) / 15;
            trackBarMax.TickFrequency = (int)(310000 - 65000) / 15;
            label1.Text = "Min Price: " + String.Format("{0:$0,0}", trackBarMin.Value);
            label2.Text = "Max Price: " + String.Format("{0:$0,0}", trackBarMax.Value);


            Load_School_Information();
            Load_ForSale_Information();

        }

        #region - Load_ForSale_Information
        //This method invokes other methods to load For Sale Houses and Apartments information
        private void Load_ForSale_Information()
        {
            For_Sale_Residence_ComboBox.Items.Clear();
            For_Sale_Residence_ComboBox.Items.Add(dekalbVal);
            For_Sale_Residence_ComboBox.Items.Add(shortHyphen);
            populateForSaleResidences(dekalbHouses, dekalbApartments);
            For_Sale_Residence_ComboBox.Items.Add("\n");
            For_Sale_Residence_ComboBox.Items.Add(sycamoreVal);
            For_Sale_Residence_ComboBox.Items.Add(shortHyphen);
            populateForSaleResidences(sycamoreHouses, sycamoreApartments);

        }
        #endregion

        #region - populateForSaleResidences
        //This method populates the data for For-Sale Houses and Apartments information in combobox.
        private void populateForSaleResidences(List<House> lstHouses, List<Apartment> lstApartments)
        {
            IEnumerable<House> forSaleHouses = Enumerable.Empty<House>();
            forSaleHouses = from h in lstHouses where h.ForSale select h;
            foreach (House details in forSaleHouses.ToList())
            {
                //add houses to the residenceComboBox
                For_Sale_Residence_ComboBox.Items.Add(String.Format("{0}", details.StreetAddr));
            }
            For_Sale_Residence_ComboBox.Items.Add("\n");

            IEnumerable<Apartment> forSaleApts = Enumerable.Empty<Apartment>();
            forSaleApts = from a in lstApartments where a.ForSale select a;
            foreach (Apartment details in forSaleApts.ToList())
            {
                // add apartments to the residenceComboBox
                For_Sale_Residence_ComboBox.Items.Add(String.Format("{0} # {1}", details.StreetAddr,
                details.Unit));
            }
        }
        #endregion


        #region - Form1_Load
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
        #endregion
        #endregion


        #region A's Code
        private void querySpecResidence_Click(object sender, EventArgs e)
        {

            result_ListBox.Items.Clear();
            // check if user didn't check any of the options
            if (!apartmentCheckBox.Checked && !houseCheckBox.Checked)
            {
                MessageBox.Show("You didn't check any valid option");
                return;
            }
          
            bool garageChecked = garageCheckBox.Checked;
            bool attached = attachedCheckBox.Checked;

            string bed = " bed, ";
            string bath = " bath, ";
            string detGarage = " with a \ndetached garage";
            string noGarage = " without a \n garage";
            string atGarage = " with an \nattached garage";

            if (bedUpDown.Value > 1)
            {
                bed = " beds, ";
            }
            if (bathUpDown.Value > 1)
            {
                bath = " baths, ";
            }

            string hHeader = string.Format("Houses with at least " + bedUpDown.Value + bed + bathUpDown.Value + " " + bath +
                                        sqFtUpDown.Value + " sq footage");

            string aHeader = string.Format("Apartments with at least " + bedUpDown.Value + bed + bathUpDown.Value + " " + bath +
                               sqFtUpDown.Value + " sq footage");

            var finResult = from i in CommunitiesList
                            from j in i.Props.OfType<Residential>()
                            where (j.Bedrooms >= bedUpDown.Value) && (j.Baths >= bathUpDown.Value) &&
                                  (j.Sqft >= sqFtUpDown.Value) && j.ForSale.Equals(true)
                                  orderby j.SalePrice
                            select new
                            {
                                Home = (j is House ? j : null),
                                Apt = (j is Apartment ? j : null),
                                FullName = string.Join("", (from z in i.Residents.OfType<Person>()
                                                            where z.Id == j.OwnerID
                                                            select z.FullName).ToArray()),

                                Unit = string.Join("", (from z in i.Props.OfType<Apartment>()
                                                        where z.Id == j.Id
                                                        select z.Unit).ToArray()),

                                Garage = string.Join("", (from z in i.Props.OfType<House>()
                                                          where z.Id == j.Id && z.Garage.Equals(garageChecked) && z.AttachedGarage.GetValueOrDefault(false).Equals(attached)
                                                          select (bool)z.Garage).ToArray()),

                                Attached = string.Join("", (from z in i.Props.OfType<House>()
                                                            where z.Id == j.Id && z.AttachedGarage.GetValueOrDefault(false).Equals(attached)
                                                            select z.AttachedGarage).ToArray())


                                 ///Find a way to track which houses have detached? during BOTH query

                                //checkGarage = (!(j is House) ? null : (from z in i.Props.OfType<House>()
                                //                                     where z.Id == j.Id && z.Garage.Equals(garage) &&
                                //                                     z.AttachedGarage.GetValueOrDefault(false).Equals(attached)
                                //                                     select z).ToList())

                            };




                            // query for houses with xBed,xBath,xSqFt, where garage is (garageCheckBox.Checked)
                            //                                  and attached is (attachedCheckBox.Checked)
            if (houseCheckBox.Checked && !apartmentCheckBox.Checked)
            {
 
                int resultCounter = 0;
                if (attachedCheckBox.Checked)
                {
                    result_ListBox.Items.Add(hHeader);
                    result_ListBox.Items.Add(atGarage );
                }
                else if (garageCheckBox.Checked)
                {
                    result_ListBox.Items.Add(hHeader);
                    result_ListBox.Items.Add(detGarage);
                }
                else
                {
                    result_ListBox.Items.Add(hHeader );
                    result_ListBox.Items.Add(noGarage);
                }
                
                result_ListBox.Items.Add(hyphen);
                foreach (var h in finResult)
                {

                    if (h.Home != null && h.Garage.Length != 0 && garageChecked.Equals(bool.Parse(h.Garage)))
                    {


                        result_ListBox.Items.Add(h.Home.StreetAddr + " " + h.Home.City + ", " + h.Home.State
                                                                                          + " " + h.Home.Zip);
                        result_ListBox.Items.Add("Owner: " + h.FullName + " | " + h.Home.Bedrooms + " beds, " +
                            h.Home.Baths + " baths, " + h.Home.Sqft + " sqfT. ");
                        string str = string.Format("{0: $0,000}", h.Home.SalePrice);
                        result_ListBox.Items.Add(" " + str + " Garage: " + h.Garage);
                        result_ListBox.Items.Add("\n\n");

                        resultCounter++;
                    }

                }

                if (resultCounter == 0)
                {
                    result_ListBox.Items.Add("Your query didn't generate any result, Please reselect!");
                }

                return;

  
            }



            //query for houses and  apartments with xBed,xBath,xSqFt
            else if (houseCheckBox.Checked && apartmentCheckBox.Checked)
            {

 
                if (finResult.Count() == 0)
                {
                    result_ListBox.Items.Add("Your query didn't generate any result, Please reselect!");
                    return;
                }
  
                //foreach(var ent in qResult)
                //{
                //    if (ent.anyUnit.Length == 0)
                //    {
                //        result_ListBox.Items.Add(ent.anyHome.StreetAddr + " " + ent.anyHome.City + ", " + ent.anyHome.State + " " + ent.anyHome.Zip);
                //        result_ListBox.Items.Add(" | " + ent.anyHome.Bedrooms + " beds, " + ent.anyHome.Baths + " baths, " + ent.anyHome.Sqft + " SqFt.");
                //        string str = string.Format("{0: $0,000}", ent.anyHome.SalePrice);
                //    //    result_ListBox.Items.Add("Garage: " + ent.anyHome.Garage + "  Attached?: " + ent.anyApt.Attached + "  " + str);
                //        result_ListBox.Items.Add("\n\n");
                //    }
                //    else
                //    {
                //        result_ListBox.Items.Add("\n\n");
                //        result_ListBox.Items.Add("Your query didn't generate any result, Please reselect!");
                //        result_ListBox.Items.Add("\n\n");
                //    }
                //}



                //return;




            }

            //query for apartments with xBed,xBath,xSqFt
            else if (apartmentCheckBox.Checked)
            {

            result_ListBox.Items.Add(aHeader);
            result_ListBox.Items.Add(hyphen);
            int resultCounter = 0;
                foreach (var ent in finResult)
                {
                    if (ent.Unit.Length > 0 && ent.Apt != null)
                    {
                        string str = string.Format("{0: $0,000}", ent.Apt.SalePrice);
                        result_ListBox.Items.Add(ent.Apt.StreetAddr + " Apt.# " + ent.Unit + " " + ent.Apt.City + ", " + ent.Apt.State + " " + ent.Apt.Zip);
                        result_ListBox.Items.Add("Owner: " + ent.FullName + " | " + ent.Apt.Bedrooms + " beds, " +
                                                    ent.Apt.Baths + " baths, " + ent.Apt.Sqft + " SqFt.\t" + str);
                        result_ListBox.Items.Add("\n\n");
                        resultCounter++;
                    }
                }

                if (resultCounter == 0)
                {
                    result_ListBox.Items.Add("Your query didn't generate any result, Please reselect!");
                }
                return;

            }
 
        }//End of Event to query 4


        private void query5_click(object sender, EventArgs e)
        {

            result_ListBox.Items.Clear();
            result_ListBox.Items.Add("Properties Owned by Out-Of-Towners");
            result_ListBox.Items.Add(hyphen);
           var rrr = from i in CommunitiesList
                      from j in i.Props
                      where (i.OutOfTowner(j.OwnerID).Equals(false))
                      select j;

            var biz = from i in CommunitiesList
                      from j in i.Props.OfType<Business>()
                      from k in rrr
                      where (j.Id == k.Id)
                      orderby j.City descending , j.SalePrice descending
                      select new
                      {
                          j,
                          k,
                          FullName = string.Join("",( from z in CommunitiesList
                                                      from l in z.Residents
                                     where l.Id == k.OwnerID
                                     select l.FullName).ToArray())
                      };

            foreach (var p in biz.ToList())
            {

                result_ListBox.Items.Add(p.k.StreetAddr + " " + p.k.City + " , " + p.k.State + " " + p.k.Zip);
                result_ListBox.Items.Add("Owner: " + p.FullName + "\t | \t$" + p.j.SalePrice);
                result_ListBox.Items.Add(p.j.Name + ", a " + p.j.Type + " type of business, established in " + p.j.YearEstablished);
                result_ListBox.Items.Add("\n\n");
            }
            result_ListBox.Items.Add("\n\n\n\n");
            result_ListBox.Items.Add("\t\t\t ###END OF OUTPUT###");
            return;
        }


        private void apartmentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (apartmentCheckBox.Checked)
            {
                attachedCheckBox.Checked = false;
                attachedCheckBox.Visible = false;
                garageCheckBox.Checked = false;
                garageCheckBox.Visible = false;
            }
            else
            {
                garageCheckBox.Visible = true;
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

        #endregion

        #region - Swathi's Code
        #region - Query3_Click
        //This method is invoked on click of Query-3 button.
        //It retieves the Businesses within the range of a Property.
        private void Query3_Click(object sender, EventArgs e)
        {
            result_ListBox.Items.Clear();

            //variable declarations
            IEnumerable<Apartment> apartmentData = Enumerable.Empty<Apartment>();
            IEnumerable<House> housesData = Enumerable.Empty<House>();
            IEnumerable<Person> personData = Enumerable.Empty<Person>();
            uint xVal, yVal;

            //Display message if no residence is selected.
            if (For_Sale_Residence_ComboBox.SelectedIndex == -1)
            {
                result_ListBox.Items.Add("Please select a residence.");
                return;
            }

            //Get the selected residence data
            string selResidence = For_Sale_Residence_ComboBox.SelectedItem.ToString();

            //Validate selected data
            if (selResidence != null && selResidence != "" && selResidence != shortHyphen &&
                selResidence != sycamoreVal && selResidence != dekalbVal && selResidence != "\n")
            {
                result_ListBox.Items.Add("Hiring Businesses within " + Query3_Distance.Value +
                                " units of distance ");
                result_ListBox.Items.Add("\tfrom " + selResidence + ".");
                result_ListBox.Items.Add(hyphen);

                if (selResidence.Contains("#"))
                {
                    //Query apartments in Dekalb and Sycamore
                    apartmentData = from dekApt in dekalbApartments
                                    where
                                    (dekApt.StreetAddr.Equals(selResidence.Split('#')[0].Trim()) &&
                                    dekApt.Unit.Equals(selResidence.Split('#')[1].Trim()))
                                    select dekApt;
                    if (!apartmentData.Any())
                    {
                        apartmentData = from sycApt in sycamoreApartments
                                        where
                                        (sycApt.StreetAddr.Equals(selResidence.Split('#')[0].Trim()) &&
                                        sycApt.Unit.Equals(selResidence.Split('#')[1].Trim()))
                                        select sycApt;
                    }

                    xVal = apartmentData.First().X;
                    yVal = apartmentData.First().Y;
                }
                else
                {
                    //Query houses in Dekalb and Sycamore
                    housesData = from dekHse in dekalbHouses
                                 where
                                 (dekHse.StreetAddr.Equals(selResidence))
                                 select dekHse;
                    if (!housesData.Any())
                    {
                        housesData = from sycHse in sycamoreHouses
                                     where
                                     (sycHse.StreetAddr.Equals(selResidence))
                                     select sycHse;
                    }
                    xVal = housesData.First().X;
                    yVal = housesData.First().Y;
                }

                //Query Business in Dekalb and Sycamore within chosen distance range
                var businessQuery = from biz in dekalbBusinesses
                                    where
                                    ((Math.Sqrt(((xVal - biz.X) * (xVal - biz.X)) +
                                    ((yVal - biz.Y) * (yVal - biz.Y))) <= (double)Query3_Distance.Value)
                                    && biz.ActiveRecruitment > 0)
                                    orderby biz.YearEstablished ascending
                                    select biz;

                if (!businessQuery.Any())
                {
                    businessQuery = from biz in sycamoreBusinesses
                                    where
                                    ((Math.Sqrt(((xVal - biz.X) * (xVal - biz.X)) +
                                    ((yVal - biz.Y) * (yVal - biz.Y))) <= (double)Query3_Distance.Value)
                                    && biz.ActiveRecruitment > 0)
                                    orderby biz.YearEstablished ascending
                                    select biz;
                }
                if (businessQuery.Any())
                {
                    //Frame the output with the retrieved query results
                    foreach (var item in businessQuery)
                    {
                        uint distanceVal = (uint)Math.Sqrt(((xVal - item.X) * (xVal - item.X)) +
                                        ((yVal - item.Y) * (yVal - item.Y)));
                        result_ListBox.Items.Add(item.StreetAddr + " " +
                                                 item.City + ", " +
                                                 item.State + " " +
                                                 item.Zip);

                        //Query the property Owner name from Person Data
                        personData = from dekPer in dekalbPersons
                                     where
                                     (dekPer.Id == item.OwnerID)
                                     select dekPer;
                        if (!personData.Any())
                        {
                            personData = from sycPer in sycamorePersons
                                         where
                                         (sycPer.Id == item.OwnerID)
                                         select sycPer;
                        }

                        result_ListBox.Items.Add("Owner: " +
                                                personData.First().FullName
                                                + " | " + distanceVal
                                                + " units away, with " + item.ActiveRecruitment
                                                + " open positions");
                        result_ListBox.Items.Add(item.Name + ", a "
                                                 + item.Type + " type of business, established in "
                                                 + item.YearEstablished);
                        result_ListBox.Items.Add("\n");
                        result_ListBox.Items.Add("\n");
                    }
                }
                else
                {
                    result_ListBox.Items.Add("Your query yielded no matches!");
                    result_ListBox.Items.Add("\n");
                    result_ListBox.Items.Add("\n");
                }

                result_ListBox.Items.Add("### END OF OUTPUT ###");

            }
            else
            {
                result_ListBox.Items.Add("Please select a valid residence!");
            }


        }
        #endregion
        #endregion

        #region Xuezhi's code
        
        //Print House info for properties within the price range
        private void PrintHouseInfo(IEnumerable<Person> allPeople, Property i)
        {
            House tempHouse = (House)i;
            result_ListBox.Items.Add(i.StreetAddr + " " + i.City + ", " + i.State + " " + i.Zip);
            var ownerInfo = from aperson in allPeople where (aperson.Id.CompareTo(i.OwnerID) == 0) select aperson;
            //string ownerFirstName = ownerInfo.First().FirstName;
            //string ownerLastName = ownerInfo.First().LastName;
            result_ListBox.Items.Add("Owner: " + ownerInfo.First().LastName + ", " + ownerInfo.First().FirstName + " | " + tempHouse.Bedrooms.ToString() + " beds, " + tempHouse.Baths.ToString() + " baths, " + tempHouse.Sqft.ToString() + " sq.ft");
            string floorString = tempHouse.Floors > 1 ? "floors" : "floor";
            if (tempHouse.Garage == true)
            {
                if (tempHouse.AttachedGarage == true)
                {
                    result_ListBox.Items.Add(" with a attached garage | " + tempHouse.Floors.ToString() + " " + floorString + ".     " + String.Format("{0:$0,0}", tempHouse.SalePrice));
                    result_ListBox.Items.Add("");
                }
                else
                {
                    result_ListBox.Items.Add(" with a detached garage | " + tempHouse.Floors.ToString() + " " + floorString + ".     " + String.Format("{0:$0,0}", tempHouse.SalePrice));
                    result_ListBox.Items.Add("");
                }
            }
            else
            {
                result_ListBox.Items.Add(" with no grage: " + tempHouse.Floors.ToString() + " "+ floorString + ".     " + String.Format("{0:$0,0}", tempHouse.SalePrice));
                result_ListBox.Items.Add("");
            }
        }

        //Print Aptartment info for properties within the price range
        private void PrintApartmentInfo(IEnumerable<Person> allPeople, Property i)
        {
            Apartment tempApt = (Apartment)i;
            result_ListBox.Items.Add(i.StreetAddr + " Apt. "+ tempApt.Unit+" "+ i.City + ", " + i.State + " " + i.Zip);
            var ownerInfo = from aperson in allPeople where (aperson.Id.CompareTo(i.OwnerID) == 0) select aperson;
            result_ListBox.Items.Add("Owner: " + ownerInfo.First().LastName + ", " + ownerInfo.First().FirstName + " | " + tempApt.Bedrooms.ToString() + " beds, " + tempApt.Baths.ToString() + " baths, " + tempApt.Sqft.ToString() + " sq.ft");
            result_ListBox.Items.Add(String.Format("{0:$0,0}", tempApt.SalePrice));
            result_ListBox.Items.Add("");
        }

        //Print Business info for properties within the price range
        private void PrintBusinessInfo(IEnumerable<Person> allPeople, Property i)
        {
            Business tempBus = (Business)i;
            result_ListBox.Items.Add(i.StreetAddr + " " + i.City + ", " + i.State + " " + i.Zip);
            var ownerInfo = from aperson in allPeople where (aperson.Id.CompareTo(i.OwnerID) == 0) select aperson;
            result_ListBox.Items.Add("Owner: " + ownerInfo.First().LastName + ", " + ownerInfo.First().FirstName + " |      "+ String.Format("{0:$0,0}", tempBus.SalePrice));
            result_ListBox.Items.Add(tempBus.Name+", a " + tempBus.Type.ToString() +"type of bussiness, established in " + tempBus.YearEstablished);
            result_ListBox.Items.Add("");
        }

        //Print School info for properties within the price range
        private void PrintSchoolInfo(IEnumerable<Person> allPeople, Property i)
        {
            School tepSch = (School)i;
            var ownerInfo = from aperson in allPeople where (aperson.Id.CompareTo(i.OwnerID) == 0) select aperson;
            result_ListBox.Items.Add(i.StreetAddr + " " + i.City + ", " + i.State + " " + i.Zip+" | "+ "Owner: " + ownerInfo.First().LastName + ", " + ownerInfo.First().FirstName);
            result_ListBox.Items.Add(tepSch.Name + ", establoshed in " + tepSch.YearEstablished);
            result_ListBox.Items.Add(tepSch.Enrolled.ToString() + " students enrolled       " + String.Format("{0:$0,0}", tepSch.SalePrice));
            result_ListBox.Items.Add("");
        }
        
        // Load school infor to the combobox for Queary 2(For sale Residences within Range of a School)
        private void Load_School_Information()
        {
            schoolComboBox.Items.Clear();

            //load school in Dek
            schoolComboBox.Items.Add("DeKalb:");
            schoolComboBox.Items.Add("------");
            foreach (School details in dekalbSchools)
            {
                schoolComboBox.Items.Add(String.Format("{0}", details.Name));
            }
            schoolComboBox.Items.Add("");


            //load school in Syc
            schoolComboBox.Items.Add("Sycamore:");
            schoolComboBox.Items.Add("------");
            foreach (School details in sycamoreSchools)
            {
                schoolComboBox.Items.Add(String.Format("{0}", details.Name));
            }
        }
        //Queary button 1: (For sale properties within a price range)
        private void PropertiesPriceRange(object sender, EventArgs e)
        {

            IEnumerable<Person> allPeople = Enumerable.Empty<Person>();
            IEnumerable<Property> resiDekSelected = Enumerable.Empty<Property>();
            IEnumerable<Property> busiDekSelected = Enumerable.Empty<Property>();
            IEnumerable<Property> schoDekSelected = Enumerable.Empty<Property>();
            IEnumerable<Property> resiSycSelected = Enumerable.Empty<Property>();
            IEnumerable<Property> busiSycSelected = Enumerable.Empty<Property>();
            IEnumerable<Property> schoSycSelected = Enumerable.Empty<Property>();
            
            IEnumerable<Property> allDek = Enumerable.Empty<Property>();
            IEnumerable<Property> allSyc = Enumerable.Empty<Property>();

            //select Dek and Syc people to the allPople
            var selectedCommunityNameDek = from propDek in CommunitiesList where ((propDek.Name == "Dekalb")) select propDek;
            var selectedCommunityDek = selectedCommunityNameDek.First();
            var selectedCommunityNameSyc = from propDek in CommunitiesList where ((propDek.Name == "Sycamore")) select propDek;
            var selectedCommunitySyc = selectedCommunityNameSyc.First();
            allPeople = selectedCommunitySyc.Residents.Union(selectedCommunityDek.Residents);


            // Select all saleable properties in dekalb          
            var selectedCommunityName = from propDek in CommunitiesList where ((propDek.Name == "Dekalb")) select propDek;
            var selectedCommunity = selectedCommunityName.First();
            var selectProp = from qqq in selectedCommunity.Props where (qqq.ForSale == true) select qqq;
            // Select all saleable properties in dekalb within a price range    
            selectProp = from qqq in selectProp where ((qqq.SalePrice >= trackBarMin.Value) && (qqq.SalePrice <= trackBarMax.Value)) select qqq;

            if (checkBox_Resi.Checked)
            {
                // Select all saleable House or Aptartment in dekalb within a price range   
                resiDekSelected = from qqq in selectProp where ((qqq is House) || (qqq is Apartment)) select qqq;
            }
            if (checkBox_Busi.Checked)
            {
                // Select all saleable business in dekalb within a price range 
                busiDekSelected = from qqq in selectProp where ((qqq is Business)) select qqq;
            }
            if (checkBox_Scho.Checked)
            {
                // Select all saleable school in dekalb within a price range 
                schoDekSelected = from qqq in selectProp where ((qqq is School)) select qqq;
            }

            //Union all the selected properties
            allDek = resiDekSelected.Union(busiDekSelected).Union(schoDekSelected);
            allDek = allDek.OrderBy(a => a.SalePrice);

            // Select all saleable properties in Sycamore
            selectedCommunityName = from propDek in CommunitiesList where ((propDek.Name == "Sycamore")) select propDek;
            selectedCommunity = selectedCommunityName.First();
            selectProp = from qqq in selectedCommunity.Props where (qqq.ForSale == true) select qqq;
            // Select all saleable properties in Sycamore within a price range    
            selectProp = from qqq in selectProp where ((qqq.SalePrice >= trackBarMin.Value) && (qqq.SalePrice <= trackBarMax.Value)) select qqq;


            if (checkBox_Resi.Checked)
            {
                // Select all saleable House or Aptartment in Syc within a price range
                resiSycSelected = from qqq in selectProp where ((qqq is House) || (qqq is Apartment)) select qqq;
            }
            if (checkBox_Busi.Checked)
            {
                // Select all saleable business in Syc within a price range
                busiSycSelected = from qqq in selectProp where ((qqq is Business)) select qqq;
            }
            if (checkBox_Scho.Checked)
            {
                // Select all saleable school in Syc within a price range
                schoSycSelected = from qqq in selectProp where ((qqq is School)) select qqq;
            }

            //Union all the selected properties
            allSyc = resiSycSelected.Union(busiSycSelected).Union(schoSycSelected);
            allSyc = allSyc.OrderBy(a => a.SalePrice);

            //Output selected properties to listbox
            result_ListBox.Items.Clear();
            result_ListBox.Items.Add("Properties for sale within the ["+ String.Format("{0:$0,0}", trackBarMin.Value) +", "+ String.Format("{0:$0,0}", trackBarMax.Value)+ "] price range.");
            result_ListBox.Items.Add("----------------------------------------------------------------");


            //no property is selected
            if ( (allDek.Count() == 0) && (allSyc.Count() == 0) )
            {
                result_ListBox.Items.Add("     #### DeKalb   ####");
                result_ListBox.Items.Add("");
                result_ListBox.Items.Add("     #### Sycamore   ####");
                result_ListBox.Items.Add("");
                result_ListBox.Items.Add("Your query yielded no mathes");
                result_ListBox.Items.Add("");
                result_ListBox.Items.Add("End of Output");
                return;

            }

            //output all selected properties in Dek
            if (allDek.Count() > 0)
            {
                result_ListBox.Items.Add("     #### DeKalb   ####");
                result_ListBox.Items.Add("");
                foreach (var i in allDek)
                {
                    if (i is House)
                    {
                        PrintHouseInfo(allPeople, i);
                    }
                    if (i is Apartment)
                    {
                        PrintApartmentInfo(allPeople, i);
                    }
                    if (i is Business)
                    {
                        PrintBusinessInfo(allPeople, i);
                    }
                    if (i is School)
                    {
                        PrintSchoolInfo(allPeople, i);
                    }
                }
                result_ListBox.Items.Add("");
                result_ListBox.Items.Add("");
            }

            //output no selected properties in Dekalb
            else
            {
                result_ListBox.Items.Add("     #### DeKalb   ####");
                result_ListBox.Items.Add("");
                result_ListBox.Items.Add("Your query yielded no mathes in DeKalb area");
                result_ListBox.Items.Add("");
                result_ListBox.Items.Add("");
            }

            //output all selected properties in Sycamore
            if (allSyc.Count() > 0)
            {
                result_ListBox.Items.Add("     #### Sycamore   ####");
                result_ListBox.Items.Add("");
                foreach (var i in allSyc)
                {
                    if (i is House)
                    {
                        PrintHouseInfo(allPeople, i);
                    }
                    if (i is Apartment)
                    {
                        PrintApartmentInfo(allPeople, i);
                    }
                    if (i is Business)
                    {
                        PrintBusinessInfo(allPeople, i);
                    }
                    if (i is School)
                    {
                        PrintSchoolInfo(allPeople, i);
                    }
                }
            }
            //output no selected properties in Sycamore
            else
            {
                result_ListBox.Items.Add("     #### Sycamore   ####");
                result_ListBox.Items.Add("");
                result_ListBox.Items.Add("Your query yielded no mathes in Sycamore area");
                result_ListBox.Items.Add("");
                result_ListBox.Items.Add("");
            }
            result_ListBox.Items.Add("End of Output");
        }

        //Queary button 2: (For sale residneces within ranges of a school)
        private void FindSaleResNearSchool(object sender, EventArgs e)            
        {

            IEnumerable<Property> SelectedProp = Enumerable.Empty<Property>();
            IEnumerable<Property> allProps = Enumerable.Empty<Property>();
            IEnumerable<Person> allPeople = Enumerable.Empty<Person>();
            IEnumerable<Property> allSaleableProps = Enumerable.Empty<Property>();
            if ((schoolComboBox.SelectedIndex == -1) || (schoolComboBox.SelectedItem == "DeKalb:") || (schoolComboBox.SelectedItem == "Sycamore:")  || (schoolComboBox.SelectedItem == "------") || (schoolComboBox.SelectedItem == ""))
            {
                result_ListBox.Items.Clear();
                result_ListBox.Items.Add("Please select a school.");

                return;
            }

            //select all properties in Dekalb and Sycamore
            var selectedCommunityNameDek = from propDek in CommunitiesList where ((propDek.Name == "Dekalb")) select propDek;
            var selectedCommunityDek = selectedCommunityNameDek.First();
            var selectedCommunityNameSyc = from propDek in CommunitiesList where ((propDek.Name == "Sycamore")) select propDek;
            var selectedCommunitySyc = selectedCommunityNameSyc.First();
            allProps = selectedCommunitySyc.Props.Union(selectedCommunityDek.Props);
            //select all people in Dekalb and Sycamore
            allPeople = selectedCommunitySyc.Residents.Union(selectedCommunityDek.Residents);

            //select the school in the comobox
            var selectSchool = from qqq in allProps where ((qqq is School) && (((School)qqq).Name.CompareTo(schoolComboBox.SelectedItem) == 0)) select qqq;

            //select the saleable house and Apartment with range of the selected school
            allSaleableProps = from qqq in allProps where (  ((qqq is House) || (qqq is Apartment)) && (qqq.ForSale == true)) select qqq;
            var selecteProps = from qqq in allSaleableProps where (((qqq is House) || (qqq is Apartment)) && ((selectSchool.First().X - qqq.X) * (selectSchool.First().X - qqq.X) + (selectSchool.First().Y - qqq.Y) * (selectSchool.First().Y - qqq.Y) <= numericUpDown1.Value* numericUpDown1.Value)) orderby qqq.SalePrice ascending select qqq;


            //output the selected House and Apartment
            result_ListBox.Items.Clear();
            result_ListBox.Items.Add("Residences for sale within " + numericUpDown1.Value.ToString() + " units of distance");
            result_ListBox.Items.Add("       from " + schoolComboBox.Text);
            result_ListBox.Items.Add("----------------------------------------------------------------");

          
            foreach (var i in selecteProps)
            {
                //output house info
                if (i is House)
                {
                    House tempHouse = (House)i;
                    result_ListBox.Items.Add(i.StreetAddr+ " "+i.City+", "+i.State+" "+i.Zip + " "+(int)Math.Sqrt( (selectSchool.First().X - i.X) * (selectSchool.First().X - i.X) + (selectSchool.First().Y - i.Y) * (selectSchool.First().Y - i.Y)) + "units away");
                    var ownerInfo = from aperson in allPeople where (aperson.Id.CompareTo(i.OwnerID) == 0) select aperson;
                    //string ownerFirstName = ownerInfo.First().FirstName;
                    //string ownerLastName = ownerInfo.First().LastName;
                    result_ListBox.Items.Add("Owner: " + ownerInfo.First().LastName + ", " + ownerInfo.First().FirstName + " | " + tempHouse.Bedrooms.ToString() + " beds, " + tempHouse.Baths.ToString() + " baths, " + tempHouse.Sqft.ToString() + " sq.ft" );
                    if (tempHouse.Garage == true)
                    {
                        if (tempHouse.AttachedGarage == true)
                        {
                            result_ListBox.Items.Add(" with a attached garage: " + tempHouse.Floors.ToString()+ " floors.     " + String.Format("{0:$0,0}",tempHouse.SalePrice));
                            result_ListBox.Items.Add("");
                        }
                        else
                        {
                            result_ListBox.Items.Add(" with a detached garage: " + tempHouse.Floors.ToString()+ " floors.     " + String.Format("{0:$0,0}", tempHouse.SalePrice));
                            result_ListBox.Items.Add("");
                        }
                        
                    }
                    else
                    {
                        result_ListBox.Items.Add(" with no grage: "+ tempHouse.Floors.ToString() + " floors.     " + String.Format("{0:$0,0}", tempHouse.SalePrice));
                        result_ListBox.Items.Add("");
                    }
                }
                //output apartment info
                if (i is Apartment)
                {
                    Apartment tempApt = (Apartment)i;
                    result_ListBox.Items.Add(i.StreetAddr + " Apt. " + tempApt.Unit + " " + i.City + ", " + i.State + " " + i.Zip);
                    var ownerInfo = from aperson in allPeople where (aperson.Id.CompareTo(i.OwnerID) == 0) select aperson;
                    result_ListBox.Items.Add("Owner: " + ownerInfo.First().LastName + ", " + ownerInfo.First().FirstName + " | " + tempApt.Bedrooms.ToString() + " beds, " + tempApt.Baths.ToString() + " baths, " + tempApt.Sqft.ToString() + " sq.ft");
                    result_ListBox.Items.Add(String.Format("{0:$0,0}", tempApt.SalePrice));
                    result_ListBox.Items.Add("");
                }

            }
        }
        // scroll trackBarMin
        private void scrollMinPrice(object sender, EventArgs e)
        {

            label1.Text = "Min Price: " + String.Format("{0:$0,0}", trackBarMin.Value);
            //if max value is smaller than min value
            if (trackBarMin.Value > trackBarMax.Value)
            {
                trackBarMax.Value = trackBarMin.Value;
                label2.Text = "Max Price: " + String.Format("{0:$0,0}", trackBarMax.Value);
            }
        }
        // scroll trackBarMax
        private void scrollMaxPrice(object sender, EventArgs e)
        {
            label2.Text = "Max Price: " + String.Format("{0:$0,0}", trackBarMax.Value);
            //if max value is smaller than min value
            if (trackBarMin.Value > trackBarMax.Value)
            {
                trackBarMin.Value = trackBarMax.Value;
                label1.Text = "Min Price: " + String.Format("{0:$0,0}", trackBarMin.Value);
            }
        }







        #endregion


    }
}
