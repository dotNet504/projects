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
            dekalbBusinesses = _businessLayer.lstDekalbBusiness;
            sycamoreSchools = new List<School>();
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

        private void querySpecResidence_Click(object sender, EventArgs e)
        {

            //if(houseCheckBox.Checked)
            // query for houses with xBed,xBath,xSqFt, where garage is (garageCheckBox.Checked)
            //                                  and attached is (attachedCheckBox.Checked)

            //if(houseCheckBox.Checked && apartmentsCheckBox.Checked)
            //query for houses and  apartments with xBed,xBath,xSqFt

            //if(apartmentsCheckBox.Checked)
            //query for apartments with xBed,xBath,xSqFt
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
            double resMax = -9999999;
            double resMin = 99999999;

            double busMax = -9999999;
            double busMin = 99999999;

            double schMax = -9999999;
            double schMin = 99999999;

            bool resBox = checkBox_Resi.Checked;
            bool schBox = checkBox_Busi.Checked;
            bool busBox = checkBox_Scho.Checked;

            var test =
                from res_test in dekalbHouses
                where (res_test.ForSale == true)
                select res_test;

            if (resBox = true)
            {

                var saleableDekHouse = from propDek in dekalbHouses where (propDek.ForSale == true) select propDek;
                var saleableDekApartment = from propDek in dekalbApartments where (propDek.ForSale == true) select propDek;
                var saleableSycHouse = from propSyc in sycamoreHouses where (propSyc.ForSale == true) select propSyc;
                var saleableSycApartment = from propSyc in sycamoreApartments where (propSyc.ForSale == true) select propSyc;


                double dekHouseMax = saleableDekHouse.Max(a => a.SalePrice);
                double dekHouseMin = saleableDekHouse.Min(a => a.SalePrice);
                double dekAptMax = saleableDekApartment.Max(a => a.SalePrice);
                double dekAptMin = saleableDekApartment.Min(a => a.SalePrice);

                double SycHouseMax = saleableSycHouse.Max(a => a.SalePrice);
                double SycHouseMin = saleableSycHouse.Min(a => a.SalePrice);
                double SycAptMax = saleableSycApartment.Max(a => a.SalePrice);
                double SycAptMin = saleableSycApartment.Min(a => a.SalePrice);

                //double dekAptarMax = dekalbApartments.Min(a => a.SalePrice);

                //ouble dekAptarMin = sycamoreApartments.Min(a => a.SalePrice);

                double[] sequence = {dekHouseMax, dekHouseMin, dekAptMax, dekAptMin, SycHouseMax, SycHouseMin, SycAptMax, SycAptMin };
                resMax = sequence.Max();
                resMin = sequence.Min();

                MessageBox.Show("heighe:   " + resMax.ToString());
                MessageBox.Show("lowest:   " + resMin.ToString());


            }


            if (schBox == true)
            {
               schMax = dekalbSchools.Max(a => a.SalePrice);
               schMin = dekalbSchools.Min(a => a.SalePrice);
            }

            if (busBox == true)
            {
                busMax = dekalbBusinesses.Max(a => a.SalePrice);
                busMin = dekalbBusinesses.Min(a => a.SalePrice);
            }

            /*
            if (resBox = true)
            {
                int eeee = 1;
                foreach (Property i in dekalbBusinesses)
                {
                    if (i.ForSale==true)
                    {
                        MessageBox.Show(i.SalePrice.ToString());
                    }
                }
                //var theLevel = dekalbHouses.Characters.Where(z => z.UserId == UserID).Max(z => z.LevelID);
            }*/

            var res = dekalbBusinesses.Max(a => a.SalePrice);
            //MessageBox.Show("heighe:   "+ res.ToString());
            double max_res = 
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 100;
            trackBar1.TickFrequency = 20;
            MessageBox.Show(trackBar1.Value.ToString());





        }

        private void FindSaleResNearSchool(object sender, EventArgs e)
        {

        }
        private void SelectTypeProperties(object sender, EventArgs e)
        {
            MessageBox.Show("fdfdfdsfsd");
        }





        #endregion


    }
}
