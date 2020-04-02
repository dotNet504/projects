using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLoader;

namespace Assignment4
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
        private const string dekalbVal = "Dekalb:";
        private const string sycamoreVal = "Sycamore:";
        private const string shortHyphen = "-------------";

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



            trackBarMin.Minimum = 0;
            trackBarMin.Maximum = 350000;
            trackBarMax.Minimum = 0;
            trackBarMax.Maximum = 350000;
            trackBarMin.Value = 0;
            trackBarMax.Value = 0;
            trackBarMin.TickFrequency = (int)(350000 - 0) / 15;
            trackBarMax.TickFrequency = (int)(350000 - 0) / 15;
            label9.Text = "Min Price: " + String.Format("{0:$#,0}", trackBarMin.Value);
            label8.Text = "Max Price: " + String.Format("{0:$#,0}", trackBarMax.Value);

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


        // Load school infor to the combobox for Queary 2(For sale Residences within Range of a School)
        private void Load_School_Information()
        {
            schoolComboBox.Items.Clear();

            //load school in Dek
            schoolComboBox.Items.Add("DeKalb:");
            schoolComboBox.Items.Add("------");

            dekalbSchools.Sort(new PropertyComparer());
            foreach (School details in dekalbSchools)
            {
                schoolComboBox.Items.Add(String.Format("{0}", details.Name));
            }
            schoolComboBox.Items.Add("");


            //load school in Syc
            schoolComboBox.Items.Add("Sycamore:");
            schoolComboBox.Items.Add("------");
            sycamoreSchools.Sort(new PropertyComparer());
            foreach (School details in sycamoreSchools)
            {
                schoolComboBox.Items.Add(String.Format("{0}", details.Name));
            }
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

        //This method is invoked when Apartment checkbox is changed
        private void apartmentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (apartmentCheckBox.Checked)
            {
                attachedCheckBox.Checked = false;
                attachedCheckBox.Visible = false;
                garageCheckBox.Checked = false;
                garageCheckBox.Visible = false;
            }
            else //apartment is not checked
                garageCheckBox.Visible = true;

        }

        //This method is invoked when Garage checkbox is changed
        private void garageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (garageCheckBox.Checked)
            {
                attachedCheckBox.Visible = true;
            }
            else //garage is not checked
                attachedCheckBox.Visible = false;

        }

        private void scrollMaxPrice(object sender, EventArgs e)
        {
            label8.Text = "Max Price: " + String.Format("{0:$#,0}", trackBarMax.Value);
            //if max value is smaller than min value
            if (trackBarMin.Value > trackBarMax.Value)
            {
                trackBarMin.Value = trackBarMax.Value;
                label9.Text = "Min Price: " + String.Format("{0:$#,0}", trackBarMin.Value);
            }
        }

        private void scrollMinPrice(object sender, EventArgs e)
        {

            label9.Text = "Min Price: " + String.Format("{0:$#,0}", trackBarMin.Value);
            //if max value is smaller than min value
            if (trackBarMin.Value > trackBarMax.Value)
            {
                trackBarMax.Value = trackBarMin.Value;
                label8.Text = "Max Price: " + String.Format("{0:$#,0}", trackBarMax.Value);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Brushes.Black);
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
               fontFamily,
               10,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
            var lstDekalb = CommunitiesList.FirstOrDefault();
            var tst = lstDekalb.Props.GroupBy(x => x.StreetName);
            foreach (var item in tst)
            {
                if (item.Count() == 1)
                {
                    var data = item.FirstOrDefault();
                    var x = 2 * data.X;
                    var y = 2 * data.Y;
                    e.Graphics.DrawLine(p, x, 0, x, y);
                   // e.Graphics.DrawString(data.StreetName, font, Brushes.Black, x, y);
                    e.Graphics.DrawLine(p, 0, y, x, y);
                }
                else
                {
                    List<Point> pfs = new List<Point>();
                    foreach (var point in item)
                    {
                        pfs.Add(new Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)));
                    }

                    var data = item.FirstOrDefault();
                    var x = 2 * data.X;
                    var y = 2 * data.Y;
                    e.Graphics.DrawCurve(p, pfs.ToArray());
                   // e.Graphics.DrawString(data.StreetName, font, Brushes.Black, x, y);
                    //e.Graphics.DrawCurve(p, 0, y, x, y);
                }
                //var x = 2 * item.X;
                //var y = 2 * item.Y;
                //e.Graphics.DrawLine(p, x, 0, x, y);
                ////e.Graphics.DrawString(item.StreetName, font, Brushes.Black, x, y);
                //e.Graphics.DrawLine(p, 0, y, x, y);

            }


            e.Dispose();
        }
    }
}
