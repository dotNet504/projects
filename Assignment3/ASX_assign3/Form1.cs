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
        private const string hyphen = "-------------------------------------------";

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

            Load_ForSale_Information();
        }

        private void Load_ForSale_Information()
        {            
            For_Sale_Residence_ComboBox.Items.Clear();

            //foreach (Business businessData in dekalbBusinesses)
            //{
            //    if (businessData.ForSale)
            //    {
            //        For_Sale_Residence_ComboBox.Items.Add(String.Format("{0}", businessData.StreetAddr));
            //    }
            //}

            //foreach (Business businessData in sycamoreBusinesses)
            //{
            //    if (businessData.ForSale)
            //    {
            //        For_Sale_Residence_ComboBox.Items.Add(String.Format("{0}", businessData.StreetAddr));
            //    }
            //}

            populateForSaleResidences(dekalbHouses, dekalbApartments);
            populateForSaleResidences(sycamoreHouses, sycamoreApartments);

            
        }

        private void populateForSaleResidences(List<House> lstHouses, List<Apartment> lstApartments)
        {
            foreach (House details in lstHouses)
            {
                if (details.ForSale)
                {
                    //add houses to the residenceComboBox
                    For_Sale_Residence_ComboBox.Items.Add(String.Format("{0}", details.StreetAddr));
                }
            }

            foreach (Apartment details in lstApartments)
            {
                if (details.ForSale)
                {
                    // add apartments to the residenceComboBox
                    For_Sale_Residence_ComboBox.Items.Add(String.Format("{0} # {1}", details.StreetAddr,
                    details.Unit));
                }
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


        #region A's Code
        private void querySpecResidence_Click(object sender, EventArgs e)
        {
            bool garage = (bool) (garageCheckBox.Checked);
            bool attached = (bool) (attachedCheckBox.Checked);

            // query for houses with xBed,xBath,xSqFt, where garage is (garageCheckBox.Checked)
            //                                  and attached is (attachedCheckBox.Checked)
            if (houseCheckBox.Checked && !apartmentCheckBox.Checked)
            {
                var houseQ = from i in CommunitiesList
                             from j in i.Props
                             where ( j.GetType().Equals(typeof(House)) ) && (j.ForSale.Equals(true))
                             select j;

                var houseList = houseQ.OfType<House>();

                var retList = from k in houseList
                              where (k.Bedrooms >= bedUpDown.Value) && (k.Baths >= bathUpDown.Value) &&
                               (k.Sqft >= sqFtUpDown.Value)  && (k.Garage.Equals(garage)) 
                               && ( k.AttachedGarage.GetValueOrDefault(false).Equals(attached) ) 
                               orderby k.City // and price
                              select k;
                                
                foreach (House ent in retList.ToList())
                {
                    MessageBox.Show(ent.ToString() + "\n City: " + ent.City + "\n Floors: "+ ent.Floors.ToString()+
                                        "\n Bedroom: " + ent.Bedrooms.ToString() + "\n Bath: " + ent.Baths.ToString() +
                                        "\n SqFt: "+ ent.Sqft.ToString() + "\n Attached: " + ent.AttachedGarage);
                }
             //   return;
            }


            //query for houses and  apartments with xBed,xBath,xSqFt
            else if(houseCheckBox.Checked && apartmentCheckBox.Checked)
            {
                var qResult = from i in CommunitiesList
                             from j in i.Props
                             where (j.GetType().Equals(typeof(House)) || j.GetType().Equals(typeof(Apartment))) && (j.ForSale.Equals(true))
                             select j;

                var houseList = qResult.OfType<House>();
                var apartmentList = qResult.OfType<Apartment>();

                var retHouseList = from k in houseList
                              where (k.Bedrooms >= bedUpDown.Value) && (k.Baths >= bathUpDown.Value) &&
                                    (k.Sqft >= sqFtUpDown.Value) 
                              orderby k.City //by price
                              select k;

                foreach (House ent in retHouseList.ToList())
                {
                    MessageBox.Show(ent.ToString() + "City: " + ent.City + "\nFloors: " + ent.Floors.ToString() +
                                        "\nBedroom: " + ent.Bedrooms.ToString() + "\nBath: " + ent.Baths.ToString() +
                                        "\nSqFt: " + ent.Sqft.ToString() + "\nAttached: " + ent.AttachedGarage);
                }

                var retApartList = from l in apartmentList
                                   where (l.Bedrooms >= bedUpDown.Value) && (l.Baths >= bathUpDown.Value) &&
                                         (l.Sqft >= sqFtUpDown.Value)
                                   orderby l.City //by price
                                   select l;

                foreach (Apartment a in retApartList.ToList())
                {
                    MessageBox.Show(a.ToString() + "City: " + a.City +"\nBedroom: " + a.Bedrooms.ToString() + 
                                        "\nBath: " + a.Baths.ToString() + "\nSqFt: " + a.Sqft.ToString());
                }
            }

            //query for apartments with xBed,xBath,xSqFt
            else if (apartmentCheckBox.Checked)
            {
                var qResult = from i in CommunitiesList
                              from j in i.Props
                              where ( j.GetType().Equals(typeof(Apartment))) //&& (j.ForSale.Equals(true))
                              select j;

                var apartmentList = qResult.OfType<Apartment>();

                var retList = from k in apartmentList
                                   where (k.Bedrooms >= bedUpDown.Value) && (k.Baths >= bathUpDown.Value) &&
                                    (k.Sqft >= sqFtUpDown.Value)
                                   orderby k.City //change to price
                                   select k;

                foreach (Apartment a in retList.ToList())
                {
                    MessageBox.Show(a.ToString() + "City: " + a.City + "\nBedroom: " + a.Bedrooms.ToString() +
                                        "\nBath: " + a.Baths.ToString() + "\nSqFt: " + a.Sqft.ToString());
                }

            }

        }

        private void apartmentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (apartmentCheckBox.Checked)
            {
                attachedCheckBox.Checked = false;
                attachedCheckBox.Visible = false;
                garageCheckBox.Checked = false;
                garageCheckBox.Visible = false;
            } else
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

        private void Query3_Click(object sender, EventArgs e)
        {
            result_ListBox.Items.Clear();
            string selResidence = For_Sale_Residence_ComboBox.SelectedItem.ToString();
            House housesData;


            if (For_Sale_Residence_ComboBox.SelectedIndex == -1)
            {
                result_ListBox.Items.Add("Please select a residence.");
                return;
            }

            result_ListBox.Items.Add("Hiring Businesses within "+Query3_Distance.Value +
                                    " units of distance ");
            result_ListBox.Items.Add("\tfrom "+ selResidence + ".");            
            result_ListBox.Items.Add(hyphen);

            if (selResidence.Contains("#"))
            {

            }
            else
            {
                housesData = dekalbHouses.FirstOrDefault(x => 
                             x.StreetAddr.Equals(selResidence));
                result_ListBox.Items.Add(housesData.X);
                result_ListBox.Items.Add(housesData.Y);
            }



            List<Business> businessQuery = new List<Business>();
            businessQuery = dekalbBusinesses.Where(x => 
                            x.StreetAddr.Equals(selResidence)).ToList();

            result_ListBox.Items.Add(businessQuery);

            result_ListBox.Items.Add("\n");
            result_ListBox.Items.Add("### END OF OUTPUT ###");
        }
        #region Xuezhi's code



        private void PropertiesPriceRange(object sender, EventArgs e)
        {
            IEnumerable<Property> resiDekSelected = Enumerable.Empty<Property>();
            IEnumerable<Property> busiDekSelected = Enumerable.Empty<Property>();
            IEnumerable<Property> schoDekSelected = Enumerable.Empty<Property>();
            IEnumerable<Property> resiSycSelected = Enumerable.Empty<Property>();
            IEnumerable<Property> busiSycSelected = Enumerable.Empty<Property>();
            IEnumerable<Property> schoSycSelected = Enumerable.Empty<Property>();

            IEnumerable<Property> allSyc = Enumerable.Empty<Property>();
            // FOR dekalb
            IEnumerable<Property> allDek = Enumerable.Empty<Property>();
            List<Property> selectedProps_1 = new List<Property>();
            SortedSet<Property> selectedProps = new SortedSet<Property>();
            var selectedCommunityName = from propDek in CommunitiesList where ((propDek.Name == "Dekalb")) select propDek;
            var selectedCommunity = selectedCommunityName.First();
            var selectProp = from qqq in selectedCommunity.Props where (qqq.ForSale == true) select qqq;
            selectProp = from qqq in selectProp where ((qqq.SalePrice >= trackBarMin.Value) && (qqq.SalePrice <= trackBarMax.Value)) select qqq;

            if (checkBox_Resi.Checked)
            {
                resiDekSelected = from qqq in selectProp where ((qqq is House) || (qqq is Apartment)) select qqq;
            }
            if (checkBox_Busi.Checked)
            {
                busiDekSelected = from qqq in selectProp where ((qqq is Business)) select qqq;
            }
            if (checkBox_Scho.Checked)
            {
                schoDekSelected = from qqq in selectProp where ((qqq is School)) select qqq;
            }

            allDek = resiDekSelected.Union(busiDekSelected).Union(schoDekSelected);
            allDek.OrderBy(a => a.SalePrice);

            foreach (var i in allDek)
            {
                result_ListBox.Items.Add(i.StreetAddr + i.SalePrice.ToString());
            }
            result_ListBox.Items.Add(allDek.Count().ToString());


            selectedCommunityName = from propDek in CommunitiesList where ((propDek.Name == "Sycamore")) select propDek;
            selectedCommunity = selectedCommunityName.First();
            selectProp = from qqq in selectedCommunity.Props where (qqq.ForSale == true) select qqq;
            selectProp = from qqq in selectProp where ((qqq.SalePrice >= trackBarMin.Value) && (qqq.SalePrice <= trackBarMax.Value)) select qqq;

            if (checkBox_Resi.Checked)
            {
                resiSycSelected = from qqq in selectProp where ((qqq is House) || (qqq is Apartment)) select qqq;
            }
            if (checkBox_Busi.Checked)
            {
                busiSycSelected = from qqq in selectProp where ((qqq is Business)) select qqq;
            }
            if (checkBox_Scho.Checked)
            {
                schoSycSelected = from qqq in selectProp where ((qqq is School)) select qqq;
            }
            allSyc = resiSycSelected.Union(busiSycSelected).Union(schoSycSelected);

            foreach (var i in allSyc)
            {
                result_ListBox.Items.Add(i.StreetAddr + i.SalePrice.ToString());
            }
            result_ListBox.Items.Add(allSyc.Count().ToString());







        }

        private void FindSaleResNearSchool(object sender, EventArgs e)
        {

        }







        


        private void SelectTypeProperties(object sender, EventArgs e)
        {
            bool resBox = checkBox_Resi.Checked;
            bool schBox = checkBox_Scho.Checked;
            bool busBox = checkBox_Busi.Checked;

            double resMax = -9999999999;
            double resMin = +999999999;

            double busMax = -9999999999;
            double busMin = +999999999;

            double schMax = -9999999999;
            double schMin = +999999999;

            double? maxPrice;
            double? minPrice;

            if ((checkBox_Resi.Checked == false) && (checkBox_Scho.Checked == false) && (checkBox_Busi.Checked == false))
            {
                maxPrice = null;
                minPrice = null;
                trackBarMin.Minimum = 0;
                trackBarMin.Maximum = 10;
                trackBarMin.Value = 0;
                trackBarMin.TickFrequency = 1;

                trackBarMax.Minimum = 0;
                trackBarMax.Maximum = 10;
                trackBarMax.Value = 0;
                trackBarMax.TickFrequency = 1;
                label1.Text = "Min Price";
                label2.Text = "Max Price";
                return;

            }


            if (true)//(checkBox_Resi.Checked)
            {

                var saleableDekHouse = from propDek in dekalbHouses where (propDek.ForSale == true) select propDek;
                var saleableDekApartment = from propDek in dekalbApartments where (propDek.ForSale == true) select propDek;
                var saleableSycHouse = from propSyc in sycamoreHouses where (propSyc.ForSale == true) select propSyc;
                var saleableSycApartment = from propSyc in sycamoreApartments where (propSyc.ForSale == true) select propSyc;


                double dekHouseMax = saleableDekHouse.Max(a => a.SalePrice);
                double dekHouseMin = saleableDekHouse.Min(a => a.SalePrice);
                double dekAptMax = saleableDekApartment.Max(a => a.SalePrice);
                double dekAptMin = saleableDekApartment.Min(a => a.SalePrice);

                double sycHouseMax = saleableSycHouse.Max(a => a.SalePrice);
                double sycHouseMin = saleableSycHouse.Min(a => a.SalePrice);
                double sycAptMax = saleableSycApartment.Max(a => a.SalePrice);
                double sycAptMin = saleableSycApartment.Min(a => a.SalePrice);

                double[] sequence_prop = { dekHouseMax, dekHouseMin, dekAptMax, dekAptMin, sycHouseMax, sycHouseMin, sycAptMax, sycAptMin };
                resMax = sequence_prop.Max();
                schMin = sequence_prop.Min();
            }
            if (true)//(checkBox_Scho.Checked)
            {

                var saleableDekSchool = from schoolDek in dekalbSchools where (schoolDek.ForSale == true) select schoolDek;
                var saleableSycSchool = from schoolSyc in sycamoreSchools where (schoolSyc.ForSale == true) select schoolSyc;

                double dekSchMax = saleableDekSchool.Max(a => a.SalePrice);
                double dekSchMin = saleableDekSchool.Min(a => a.SalePrice);
                double sycSchMax = saleableSycSchool.Max(a => a.SalePrice);
                double sycSchMin = saleableSycSchool.Min(a => a.SalePrice);

                double[] sequenceSchool = { dekSchMax, dekSchMin, sycSchMax, sycSchMin };
                schMax = sequenceSchool.Max();
                resMin = sequenceSchool.Min();

            }

            if (true)//(checkBox_Busi.Checked)
            {
                var saleableDekBusiness = from businessDek in dekalbBusinesses where (businessDek.ForSale == true) select businessDek;
                var saleableBusiness = from businessSyc in sycamoreBusinesses where (businessSyc.ForSale == true) select businessSyc;

                busMax = saleableDekBusiness.Max(a => a.SalePrice);
                busMin = saleableDekBusiness.Min(a => a.SalePrice);
            }

            double?[] maxList = { resMax, schMax, busMax };
            double?[] minList = { resMin, schMin, busMin };

            maxPrice = maxList.Max();
            minPrice = minList.Min();


            trackBarMin.Minimum = (int)minPrice;
            trackBarMin.Maximum = (int)maxPrice;

            label1.Text = "Min Price: " + trackBarMin.Value.ToString();

            trackBarMax.Minimum = (int)minPrice;
            trackBarMax.Maximum = (int)maxPrice;
            label2.Text = "Max Price: " + trackBarMax.Value.ToString();

            trackBarMin.TickFrequency = (int)(minPrice - maxPrice) / 15;
            trackBarMax.TickFrequency = (int)(minPrice - maxPrice) / 15;
        }
        #endregion

        private void scrollMinPrice(object sender, EventArgs e)
        {
            if (trackBarMin.Maximum<=10)
            {
                label1.Text = "Min Price";
            }
            else
                label1.Text = "Min Price: " + trackBarMin.Value.ToString();
        }

        private void scrollMaxPrice(object sender, EventArgs e)
        {
            if (trackBarMax.Maximum <= 10)
            {
                label2.Text = "Max Price";
            }
            else
                label2.Text = "Max Price: " + trackBarMax.Value.ToString();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
