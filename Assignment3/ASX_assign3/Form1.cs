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
            dekalbSchools = new List<School>();
            dekalbBusinesses = new List<Business>();
            sycamoreSchools = new List<School>();
            sycamoreBusinesses = new List<Business>();

            Load_ForSale_Information();
        }

        private void Load_ForSale_Information()
        {
            dekalbHouses = _businessLayer.lstDekalbHouses;
            dekalbApartments = _businessLayer.lstDekalbApartments;
            For_Sale_Residence_ComboBox.Items.Clear();

            foreach (House details in dekalbHouses)
            {
               // if (details.ForSale)
               // {
                    //add houses to the residenceComboBox
                    For_Sale_Residence_ComboBox.Items.Add(String.Format("{0}", details.StreetAddr));
               // }                
            }

            foreach (Apartment details in dekalbApartments)
            {
               //// if (details.ForSale)
                ////{
                    //add apartments to the residenceComboBox
                    For_Sale_Residence_ComboBox.Items.Add(String.Format("{0} # {1}", details.StreetAddr,
                        details.Unit));
                //}               
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
    }
}
