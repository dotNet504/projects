﻿/*********************************************************************************************************
 *                                                                                                       *
 *  CSCI:504-MSTR PROGRAMMING PRINCIPLES IN .NET	      Assignment 4					 Spring 2020     *                                          
 *																										 *
 *  Programmer's: Swathi Reddy Konatham (Z1864290),
 *                Abdulsalam Olaoye (Z1836477),
 *                Xuezhi Cang (Z1747635)                                                                 *  	                           
 *																										 *
 *  Class Name: Form1
 *  Purpose   : Windows application that displays the property details of Dekalb & Sycamore Communities. *
 *              The properties are plotted as map.                                                       *
 *********************************************************************************************************/

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

namespace ASX_Assign4
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

        //obtain the properties from the searched results
        public IEnumerable<Property> temp_finQuery = Enumerable.Empty<Property>();
        private static bool Qreload = false;


        //Constant Variables declaration
        private const string dekalbVal = "Dekalb:";
        private const string sycamoreVal = "Sycamore:";
        private const string shortHyphen = "-------------";
        public float zoom = 1f;

        //create the range of original PT
        
        public int minX = 0;
        public int maxX = 0;
        public int minY = 0;
        public int maxY = 0;
        

        //record the displacement
        public int xDiff = 0;
        public int yDiff = 0;

        private Boolean panelReset = true;
        int Sleep = 0;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            //set the range of trackbar 1 from 100% to 175%
            trackBar1.Minimum = 100;
            trackBar1.Maximum = 175;
            // at the begining the scale is 100% so we diable the two scrollbars          
            minX = 0;
            maxX = Convert.ToInt32(panel3.Width * zoom) - panel3.Width;
            minY = 0;
            maxY = Convert.ToInt32(panel3.Height * zoom) - panel3.Height;
            
            label10.Text = "Scale: " + trackBar1.Value + " %";



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

            label11.Text = "Scale: " + trackBar1.Value + " %";
            zoom = trackBar1.Value / 100f;


            string underScoreSym = "";
            int underScoreNum = 0;
            underScoreNum = 5 + Convert.ToInt32(trackBar1.Value / 10);
            for (int i = 0; i < 10 + underScoreNum; i++)

            {
                underScoreSym = underScoreSym + '-';
            }
            label11.Text = '|' + underScoreSym + '|' + underScoreSym + '|';
            label14.Location = new Point(label11.Location.X + label11.Size.Width - Convert.ToInt32(label14.Width / 2), label14.Location.Y);
            label15.Location = new Point(label11.Location.X + Convert.ToInt32(label11.Size.Width / 2) - Convert.ToInt32(label15.Width / 2), label14.Location.Y);
            label16.Location = new Point(label11.Location.X + Convert.ToInt32(label11.Size.Width / 4) - Convert.ToInt32(label16.Width / 2), label14.Location.Y);
            label17.Location = new Point(label11.Location.X + Convert.ToInt32(3 * label11.Size.Width / 4) - Convert.ToInt32(label17.Width / 2), label14.Location.Y);



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

        #region - Minor Helper Methods
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

        //This method is used for Max price scroll bar
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

        //This method is used for Min price scroll bar
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
        #endregion

        #region Queries       

        // This method handles querying used for the map_drawing
        private void do_query(PaintEventArgs e)
        {
            //reset the coordinate


            var finQuery = from comms in CommunitiesList
                           from props in comms.Props.OfType<Property>()
                           select new
                           {
                               PropT = props,
                               OwnerName = string.Join("", (from z in comms.Residents.OfType<Person>()
                                                            where z.Id == props.OwnerID
                                                            select z.FullName).ToArray())
                           };

            #region Query_1
            if (residentialCheckBox.Checked || businessCheckBox.Checked || schoolCheckBox.Checked)
            {
                var query_One = from props in finQuery
                                where (((props.PropT.GetType().Equals(typeof(Apartment)) || props.PropT.GetType().Equals(typeof(House))) && (residentialCheckBox.Checked))
                                || ((props.PropT.GetType().Equals(typeof(Business))) && (businessCheckBox.Checked))
                                || ((props.PropT.GetType().Equals(typeof(School))) && (schoolCheckBox.Checked)))
                                where (props.PropT.ForSale.Equals(true)) && (props.PropT.SalePrice <= trackBarMax.Value && props.PropT.SalePrice >= trackBarMin.Value)
                                select props;

                finQuery = query_One;
            }
            #endregion

            #region Query_2
            if ((schoolComboBox.SelectedIndex != -1) && (schoolComboBox.SelectedItem.ToString() != "DeKalb:") && (schoolComboBox.SelectedItem.ToString() != "Sycamore:")
                            && (schoolComboBox.SelectedItem.ToString() != "------") && (schoolComboBox.SelectedItem.ToString() != ""))
            {
                var selectSchool = from z in CommunitiesList
                                   from school in z.Props.OfType<School>()
                                   where school.Name.Equals(schoolComboBox.SelectedItem.ToString())
                                   select school;

                uint schoolX = selectSchool.First().X;
                uint schoolY = selectSchool.First().Y;

                var otherProps = from res in finQuery
                                 where res.PropT.GetType().Equals(typeof(Business)) || res.PropT.GetType().Equals(typeof(School))
                                 select res;

                var query_Two = from res in finQuery
                                where (res.PropT.GetType().Equals(typeof(Apartment)) || res.PropT.GetType().Equals(typeof(House)))
                                where ((schoolX - res.PropT.X) * (schoolX - res.PropT.X) + (schoolY - res.PropT.Y) * (schoolY - res.PropT.Y)
                                                 <= schoolDistanceUpDown.Value * schoolDistanceUpDown.Value)
                                select res;

                var qResult = query_Two.Concat(otherProps);
                finQuery = qResult;
            }
            #endregion

            #region Query_3
            //Validate selected data
            if (For_Sale_Residence_ComboBox.SelectedValue != null && For_Sale_Residence_ComboBox.SelectedIndex != -1 && For_Sale_Residence_ComboBox.SelectedItem.ToString() != ""
                && For_Sale_Residence_ComboBox.SelectedItem.ToString() != shortHyphen && For_Sale_Residence_ComboBox.SelectedItem.ToString() != sycamoreVal
                && For_Sale_Residence_ComboBox.SelectedItem.ToString() != dekalbVal && For_Sale_Residence_ComboBox.SelectedItem.ToString() != "\n")
            {
                //Get selected data
                var selectRes = from z in CommunitiesList
                                from resdnt in z.Props.OfType<Residential>()
                                where resdnt.StreetAddr.Equals(For_Sale_Residence_ComboBox.SelectedItem.ToString())
                                select resdnt;

                if (For_Sale_Residence_ComboBox.SelectedItem.ToString().Contains("#"))
                {
                    //Query apartments in Dekalb and Sycamore for selected Index full data
                    selectRes = from zComm in CommunitiesList
                                from aProps in zComm.Props.OfType<Residential>()
                                where (aProps.StreetAddr.Equals(For_Sale_Residence_ComboBox.SelectedItem.ToString().Split('#')[0].Trim()) &&
                                        (aProps as Apartment).Unit.Equals(For_Sale_Residence_ComboBox.SelectedItem.ToString().Split('#')[1].Trim()))
                                select aProps;
                }

                //query all businesses that are hiring, result could contain duplicates of businesses in finQuery
                var queryThree = finQuery.Concat(from comms in CommunitiesList
                                                 from biz in comms.Props.OfType<Property>()
                                                 where ((biz.GetType().Equals(typeof(Business))) &&
                                                             ((selectRes.First().X - biz.X) * (selectRes.First().X - biz.X) +
                                                             (selectRes.First().Y - biz.Y) * (selectRes.First().Y - biz.Y)
                                                                <= residenceDistanceUpDown.Value * residenceDistanceUpDown.Value) &&
                                                           ((biz as Business).ActiveRecruitment > 0)
                                                         )
                                                 select new
                                                 {
                                                     PropT = biz,
                                                     OwnerName = string.Join("", (from z in comms.Residents.OfType<Person>()
                                                                                  where z.Id == biz.OwnerID
                                                                                  select z.FullName).ToArray())
                                                 });

                finQuery = queryThree;
            }
            #endregion

            #region Query_4
            if (houseCheckBox.Checked || apartmentCheckBox.Checked)
            {
                bool houseChecked = (houseCheckBox.Checked.Equals(true) && apartmentCheckBox.Checked.Equals(false));

                //Save all other properties from finQuery result
                var otherProps = from res in finQuery
                                 where res.PropT.GetType().Equals(typeof(Business)) || res.PropT.GetType().Equals(typeof(School))
                                 select res;

                // General query for Q4
                var query_Four = from res in finQuery
                                 where res.PropT.GetType().Equals(typeof(House)) && houseCheckBox.Checked
                                       || res.PropT.GetType().Equals(typeof(Apartment)) && apartmentCheckBox.Checked
                                 where (((res.PropT as Residential).Bedrooms >= bedUpDown.Value) && ((res.PropT as Residential).Baths >= bathUpDown.Value)
                                        && ((res.PropT as Residential).Sqft >= sqFtUpDown.Value))
                                 select res;

                // If only House was checked, Queries from Q4 and dumps it's result into query_FOur
                if (houseChecked)
                {
                    var qHouse = from res in query_Four
                                 where res.PropT.GetType().Equals(typeof(House))
                                 where ((res.PropT as House).Garage.Equals(garageCheckBox.Checked) && (res.PropT as House).AttachedGarage.GetValueOrDefault(false).Equals(attachedCheckBox.Checked))
                                 select res;
                    query_Four = qHouse;
                }

                finQuery = otherProps.Concat(query_Four);
            }


            temp_finQuery = from temp_property in finQuery where (temp_property.PropT is Property) select temp_property.PropT;


            if (Qreload)
            {

                List<House> dHouse = new List<House>();
                List<House> sHouse = new List<House>();
                List<Apartment> dApartment = new List<Apartment>();
                List<Apartment> sApartment = new List<Apartment>();

                foreach (var res in finQuery)
                {
                    if ((res.PropT is House) && (res.PropT.City == "DeKalb"))
                    {
                        dHouse.Add(res.PropT as House);
                    }
                    else if ((res.PropT is Apartment) && (res.PropT.City == "DeKalb"))
                    {
                        dApartment.Add(res.PropT as Apartment);
                    }
                    else if ((res.PropT is House) && (res.PropT.City == "Sycamore"))
                    {
                        sHouse.Add(res.PropT as House);
                    }
                    else if ((res.PropT is Apartment) && (res.PropT.City == "Sycamore"))
                    {
                        sApartment.Add(res.PropT as Apartment);
                    }
                }

                var temp = For_Sale_Residence_ComboBox.SelectedItem;

                For_Sale_Residence_ComboBox.Items.Clear();
                For_Sale_Residence_ComboBox.Items.Add(dekalbVal);
                For_Sale_Residence_ComboBox.Items.Add(shortHyphen);
                populateForSaleResidences(dHouse, dApartment);
                For_Sale_Residence_ComboBox.Items.Add("\n");
                For_Sale_Residence_ComboBox.Items.Add(sycamoreVal);
                For_Sale_Residence_ComboBox.Items.Add(shortHyphen);
                populateForSaleResidences(sHouse, sApartment);

                For_Sale_Residence_ComboBox.SelectedItem = temp;

            }

            Qreload = true;


            // draw lines
            Pen p = new Pen(Brushes.Black);
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);

            var dklbF = finQuery.Where(x => x.PropT.City.ToLower() == "dekalb");
            var sycaF = finQuery.Where(x => x.PropT.City == "Sycamore");

            var grpdklb = dklbF.GroupBy(x => x.PropT.StreetName);
            var grpsyca = sycaF.GroupBy(x => x.PropT.StreetName);

            // lines for dekalb
            foreach (var g in grpdklb)
            {
                if (g.Count() == 1)
                {
                    var gi = g.FirstOrDefault();
                    var x = 2 * gi.PropT.X;
                    var y = 2 * gi.PropT.Y;

                    StringFormat strF = new StringFormat();
                    strF.Alignment = StringAlignment.Far;
                    e.Graphics.DrawLine(p, x * zoom - xDiff, 0 * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    e.Graphics.DrawString(gi.PropT.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                    e.Graphics.DrawLine(p, 0 * zoom - xDiff, y * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    strF.FormatFlags = StringFormatFlags.DirectionVertical;
                    e.Graphics.DrawString(gi.PropT.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);

                }
                else if (g.Count() > 1)
                {
                    List<Point> pfs = new List<Point>();
                    var drawStringCurve = true;
                    foreach (var point in g)
                    {
                        var x = 2 * point.PropT.X;
                        var y = 2 * point.PropT.Y;

                        pfs.Add(new Point(Convert.ToInt32(x * zoom) - xDiff, Convert.ToInt32(y * zoom) - yDiff));

                        if (drawStringCurve)
                        {
                            StringFormat strF = new StringFormat();
                            strF.Alignment = StringAlignment.Far;
                            e.Graphics.DrawString(point.PropT.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                            drawStringCurve = false;
                        }
                    }
                    e.Graphics.DrawCurve(p, pfs.ToArray());
                }
            }

            // lines for sycamore
            foreach (var g in grpsyca)
            {
                if (g.Count() == 1)
                {
                    var gi = g.FirstOrDefault();
                    var x = 250 + (2 * gi.PropT.X);
                    var y = 2 * gi.PropT.Y;

                    StringFormat strF = new StringFormat();
                    strF.Alignment = StringAlignment.Far;
                    e.Graphics.DrawLine(p, x * zoom - xDiff, 0 * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    e.Graphics.DrawString(gi.PropT.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                    e.Graphics.DrawLine(p, 0 * zoom - xDiff, y * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    strF.FormatFlags = StringFormatFlags.DirectionVertical;
                    e.Graphics.DrawString(gi.PropT.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);

                }
                else if (g.Count() > 1)
                {
                    List<Point> pfs = new List<Point>();
                    var drawStringCurve = true;
                    foreach (var point in g)
                    {
                        var x = 250 + (2 * point.PropT.X);
                        var y = 2 * point.PropT.Y;

                        pfs.Add(new Point(Convert.ToInt32(x * zoom) - xDiff, Convert.ToInt32(y * zoom) - yDiff));

                        if (drawStringCurve)
                        {
                            StringFormat strF = new StringFormat();
                            strF.Alignment = StringAlignment.Far;
                            e.Graphics.DrawString(point.PropT.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                            drawStringCurve = false;
                        }
                    }
                    e.Graphics.DrawCurve(p, pfs.ToArray());
                }
            }
            // Adding icons
            foreach (var item in finQuery)
            {
                var x = 2 * item.PropT.X;
                var y = 2 * item.PropT.Y;
                if (item.PropT.City == "Sycamore")
                {
                    x = x + 250;
                }
                StringFormat strF = new StringFormat();
                strF.Alignment = StringAlignment.Near;
                if (item.PropT.GetType().Equals(typeof(House)) || item.PropT.GetType().Equals(typeof(Apartment)))
                {
                    e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Home.png"),
                  new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                    e.Graphics.DrawString("     House#: " + item.PropT.AddNumber.ToString(), font, Brushes.Red, x * zoom - xDiff, y * zoom - yDiff, strF);
                }
                if (item.PropT.GetType().Equals(typeof(School)))
                {
                    var s = (School)item.PropT;
                    e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/School.png"),
                  new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                    e.Graphics.DrawString("     " + s.Name, font, Brushes.DarkBlue, x * zoom - xDiff, y * zoom - yDiff, strF);
                }
                if (item.PropT.GetType().Equals(typeof(Business)))
                {
                    var b = (Business)item.PropT;
                    e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Business.png"),
                  new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                    e.Graphics.DrawString("     " + b.Name, font, Brushes.DarkOrange, x * zoom - xDiff, y * zoom - yDiff, strF);
                }
                #endregion
            }
        }

        #endregion

        //This method is invoked on Search button click
        private void searchButton_Click(object sender, EventArgs e)
        {
            panelReset = false;
            xDiff = 0;
            yDiff = 0;
            trackBar1.Value = 100;
            zoom = trackBar1.Value / 100f;
            label10.Text = "Scale: " + trackBar1.Value + " %";


            panel3.Refresh();
            //MessageBox.Show(xDiff.ToString() + "  " + yDiff.ToString());
        }

        //This method is used for drawing map on the panel
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

            if (panelReset == false)
            {
                do_query(e);
                return;
            }

            Pen p = new Pen(Brushes.Black);
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);
            zoom = trackBar1.Value / 100f;

            var lstDekalb = CommunitiesList.Where(x => x.Name.ToLower() == "dekalb").FirstOrDefault();
            var grpDlk = lstDekalb.Props.GroupBy(x => x.StreetName);
            foreach (var item in grpDlk)
            {
                if (item.Count() == 1)
                {
                    var data = item.FirstOrDefault();
                    var x = 2 * data.X;
                    var y = 2 * data.Y;
                    StringFormat strF = new StringFormat();
                    strF.Alignment = StringAlignment.Near;
                    if (dekalbHouses.Any(house => house.Id == data.Id))
                    {
                        e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Home.png"),
                       new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));

                        e.Graphics.DrawString("     House#: " + dekalbHouses.FirstOrDefault(house => house.Id == data.Id).AddNumber.ToString(), font, Brushes.Red, x * zoom - xDiff, y * zoom - yDiff, strF);

                    }
                    if (dekalbSchools.Any(school => school.Id == data.Id))
                    {
                        e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/School.png"),
                       new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                        e.Graphics.DrawString("      " + dekalbSchools.FirstOrDefault(house => house.Id == data.Id).Name, font, Brushes.DarkBlue, x * zoom - xDiff, y * zoom - yDiff, strF);

                    }
                    if (dekalbBusinesses.Any(business => business.Id == data.Id))
                    {
                        e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Business.png"),
                       new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));

                        e.Graphics.DrawString("      " + dekalbBusinesses.FirstOrDefault(house => house.Id == data.Id).Name, font, Brushes.DarkOrange, x * zoom - xDiff, y * zoom - yDiff, strF);
                    }

                    strF.Alignment = StringAlignment.Far;
                    e.Graphics.DrawLine(p, x * zoom - xDiff, 0 * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    e.Graphics.DrawString(data.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                    e.Graphics.DrawLine(p, 0 * zoom - xDiff, y * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    strF.FormatFlags = StringFormatFlags.DirectionVertical;
                    e.Graphics.DrawString(data.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                }
                else
                {
                    List<Point> pfs = new List<Point>();
                    var drawStringCurve = true;
                    foreach (var point in item)
                    {
                        var x = 2 * point.X;
                        var y = 2 * point.Y;
                        StringFormat strF = new StringFormat();
                        strF.Alignment = StringAlignment.Near;
                        if (dekalbHouses.Any(house => house.Id == point.Id))
                        {
                            e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Home.png"),
                           new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                            e.Graphics.DrawString("     House#: " + dekalbHouses.FirstOrDefault(house => house.Id == point.Id).AddNumber.ToString(), font, Brushes.Red, x * zoom - xDiff, y * zoom - yDiff, strF);

                        }
                        if (dekalbSchools.Any(school => school.Id == point.Id))
                        {
                            e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/School.png"),
                           new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));

                            e.Graphics.DrawString("      " + dekalbSchools.FirstOrDefault(house => house.Id == point.Id).Name, font, Brushes.DarkBlue, x * zoom - xDiff, y * zoom - yDiff, strF);
                        }
                        if (dekalbBusinesses.Any(business => business.Id == point.Id))
                        {
                            e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Business.png"),
                           new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));

                            e.Graphics.DrawString("      " + dekalbBusinesses.FirstOrDefault(house => house.Id == point.Id).Name, font, Brushes.DarkOrange, x * zoom - xDiff, y * zoom - yDiff, strF);
                        }
                        pfs.Add(new Point(Convert.ToInt32(x * zoom) - xDiff, Convert.ToInt32(y * zoom) - yDiff));

                        if (drawStringCurve)
                        {

                            strF.Alignment = StringAlignment.Far;
                            e.Graphics.DrawString(point.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                            drawStringCurve = false;
                        }
                    }
                    e.Graphics.DrawCurve(p, pfs.ToArray());

                }

            }

            var lstSycamore = CommunitiesList.Where(x => x.Name == "Sycamore").FirstOrDefault();
            var grpSyc = lstSycamore.Props.GroupBy(x => x.StreetName);
            foreach (var item in grpSyc)
            {
                if (item.Count() == 1)
                {
                    var data = item.FirstOrDefault();
                    var x = 250 + (2 * data.X);
                    var y = 2 * data.Y;
                    StringFormat strF = new StringFormat();
                    strF.Alignment = StringAlignment.Near;
                    if (sycamoreHouses.Any(house => house.Id == data.Id))
                    {
                        e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Home.png"),
                       new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                        e.Graphics.DrawString("     House#: " + sycamoreHouses.FirstOrDefault(house => house.Id == data.Id).AddNumber.ToString(), font, Brushes.Red, x * zoom - xDiff, y * zoom - yDiff, strF);

                    }
                    if (sycamoreSchools.Any(school => school.Id == data.Id))
                    {
                        e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/School.png"),
                       new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                        e.Graphics.DrawString("      " + sycamoreSchools.FirstOrDefault(house => house.Id == data.Id).Name, font, Brushes.DarkBlue, x * zoom - xDiff, y * zoom - yDiff, strF);

                    }
                    if (sycamoreBusinesses.Any(business => business.Id == data.Id))
                    {
                        e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Business.png"),
                       new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                        e.Graphics.DrawString("      " + sycamoreBusinesses.FirstOrDefault(house => house.Id == data.Id).Name, font, Brushes.DarkOrange, x * zoom - xDiff, y * zoom - yDiff, strF);

                    }
                    strF.Alignment = StringAlignment.Far;
                    e.Graphics.DrawLine(p, x * zoom - xDiff, 0 * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    e.Graphics.DrawString(data.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                    e.Graphics.DrawLine(p, 0 * zoom - xDiff, y * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    strF.FormatFlags = StringFormatFlags.DirectionVertical;
                    e.Graphics.DrawString(data.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                }
                else
                {
                    List<Point> pfs = new List<Point>();
                    var drawStringCurve = true;
                    foreach (var point in item)
                    {
                        var x = 250 + (2 * point.X);
                        var y = 2 * point.Y;
                        StringFormat strF = new StringFormat();
                        strF.Alignment = StringAlignment.Near;
                        if (sycamoreHouses.Any(house => house.Id == point.Id))
                        {
                            e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Home.png"),
                           new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                            e.Graphics.DrawString("     House#: " + sycamoreHouses.FirstOrDefault(house => house.Id == point.Id).AddNumber.ToString(), font, Brushes.Red, x * zoom - xDiff, y * zoom - yDiff, strF);

                        }
                        if (sycamoreSchools.Any(school => school.Id == point.Id))
                        {
                            e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/School.png"),
                           new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                            e.Graphics.DrawString("      " + sycamoreSchools.FirstOrDefault(house => house.Id == point.Id).Name, font, Brushes.DarkBlue, x * zoom - xDiff, y * zoom - yDiff, strF);

                        }
                        if (sycamoreBusinesses.Any(business => business.Id == point.Id))
                        {
                            e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Business.png"),
                           new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                            e.Graphics.DrawString("      " + sycamoreBusinesses.FirstOrDefault(house => house.Id == point.Id).Name, font, Brushes.DarkOrange, x * zoom - xDiff, y * zoom - yDiff, strF);

                        }
                        pfs.Add(new Point(Convert.ToInt32(x * zoom) - xDiff, Convert.ToInt32(y * zoom) - yDiff));

                        if (drawStringCurve)
                        {
                            strF.Alignment = StringAlignment.Far;
                            e.Graphics.DrawString(point.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                            drawStringCurve = false;
                        }
                    }
                    e.Graphics.DrawCurve(p, pfs.ToArray());
                }

            }


            e.Dispose();
        }


        //This method is used for zoom track bar
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label10.Text = "Scale: " + trackBar1.Value + " %";
            zoom = trackBar1.Value / 100f;
            
            // adding the distance bar
            string underScoreSym = "";
            int underScoreNum = 5 + Convert.ToInt32(trackBar1.Value / 10);
            for (int i = 0; i < 10 + underScoreNum; i++)

            {
                underScoreSym = underScoreSym + '-';
            }
            label11.Text = '|' + underScoreSym + '|' + underScoreSym + '|';
            label14.Location = new Point(label11.Location.X + label11.Size.Width - Convert.ToInt32(label14.Width / 2), label14.Location.Y);
            label15.Location = new Point(label11.Location.X + Convert.ToInt32(label11.Size.Width / 2) - Convert.ToInt32(label15.Width / 2), label14.Location.Y);
            label16.Location = new Point(label11.Location.X + Convert.ToInt32(label11.Size.Width / 4) - Convert.ToInt32(label16.Width / 2), label14.Location.Y);
            label17.Location = new Point(label11.Location.X + Convert.ToInt32(3 * label11.Size.Width / 4) - Convert.ToInt32(label17.Width / 2), label14.Location.Y);

            //reset the range of the drawing area
            minX = 0;
            maxX = Convert.ToInt32(panel3.Width * zoom) - panel3.Width;
            minY = 0;
            maxY = Convert.ToInt32(panel3.Height * zoom) - panel3.Height;

            //if displacement cross the boundary, then drag it to the boundary
            if (xDiff < 0)
            {
                xDiff = 0;
            }
            if (xDiff > maxX)
            {
                xDiff = maxX;
            }

            if (yDiff < 0)
            {
                yDiff = 0;
            }

            if (yDiff > maxY)
            {
                yDiff = maxY;
            }

            panel3.Refresh();

        }


        //record the mouse down and mouse up
        public Point startPt;
        public Point endPt;


        //This method is used on movedown of map panel 
        private void panel3_move_down(object sender, MouseEventArgs e)
        { 
            //record the starting points
            startPt.X = e.X;
            startPt.Y = e.Y;
        }


        //This method is used on moveup of map panel 
        private void panel3_move_up(object sender, MouseEventArgs e)
        {
            //record the end points 
            endPt.X = e.X;
            endPt.Y = e.Y;

            //calculate the delta
            int xdelta = startPt.X - endPt.X;
            int ydelta = startPt.Y - endPt.Y;


            //calculate the displacement
            xDiff = xDiff + xdelta;
            yDiff = yDiff + ydelta;

            //if displacement cross the boundary, then drag it back
            if (xDiff < 0)
            {
                xDiff = 0;
            }
            if (xDiff > maxX)
            {
                xDiff = maxX;
            }

            if (yDiff < 0)
            {
                yDiff = 0;
            }

            if (yDiff > maxY)
            {
                yDiff = maxY;
            }

            panel3.Refresh();
        }

        //This method is used on Key Down
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panelReset = false;
                panel3.Refresh();
            }
        }

        //This method is used on MouseMOve to display tooltip information
        private void panel3MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.Active = true;
            var pos = panel3.PointToClient(Cursor.Position);
            IEnumerable<Person> allPeople = Enumerable.Empty<Person>();
            //select Dek and Syc people to the allPople
            var selectedCommunityNameDek = from propDek in CommunitiesList where ((propDek.Name == "Dekalb")) select propDek;
            var selectedCommunityDek = selectedCommunityNameDek.First();
            var selectedCommunityNameSyc = from propDek in CommunitiesList where ((propDek.Name == "Sycamore")) select propDek;
            var selectedCommunitySyc = selectedCommunityNameSyc.First();
            allPeople = selectedCommunitySyc.Residents.Union(selectedCommunityDek.Residents);

            int X = pos.X;
            int Y = pos.Y;
            float xProjected = 0;
            float yProjected = 0;
            int distanceThreshold = 20;
            string propertyInfor = "";


            if (panelReset == true)
            {

                var lstDekalb = CommunitiesList.Where(x => x.Name.ToLower() == "dekalb").FirstOrDefault();
                var grpDek = lstDekalb.Props;

                foreach (var item in grpDek)
                {
                    if ((Math.Abs(X - (2 * item.X * zoom - xDiff)) < distanceThreshold) && (Math.Abs(Y - (2 * item.Y * zoom - yDiff)) < distanceThreshold))
                    {

                        if (item is House)
                        {
                            propertyInfor = PrintHouseInfo(allPeople, item);
                        }
                        if (item is Apartment)
                        {
                            propertyInfor = PrintApartmentInfo(allPeople, item);
                        }
                        if (item is School)
                        {
                            propertyInfor = PrintSchoolInfo(allPeople, item); ;
                        }
                        if (item is Business)
                        {
                            propertyInfor = PrintBusinessInfo(allPeople, item);
                        }

                    }
                }
                var lstSycamore = CommunitiesList.Where(x => x.Name.ToLower() == "Sycamore".ToLower()).FirstOrDefault();
                var grpSyc = lstSycamore.Props;
                foreach (var item in grpSyc)
                {
                    if ((Math.Abs(X - ((250 + (2 * item.X)) * zoom - xDiff)) < distanceThreshold) && (Math.Abs(Y - (2 * item.Y * zoom - yDiff)) < distanceThreshold))
                    {
                        if (item is House)
                        {
                            propertyInfor = PrintHouseInfo(allPeople, item);
                        }
                        if (item is Apartment)
                        {
                            propertyInfor = PrintApartmentInfo(allPeople, item);
                        }
                        if (item is School)
                        {
                            propertyInfor = PrintSchoolInfo(allPeople, item);
                        }
                        if (item is Business)
                        {
                            propertyInfor = PrintBusinessInfo(allPeople, item);
                        }
                    }
                }
            }

            //for the searched results
            else
            {
                foreach (var res in temp_finQuery)
                {
                    if ((res.City.ToLower() == "DeKalb".ToLower()))
                    {
                        xProjected = (2 * res.X) * zoom - xDiff;
                        yProjected = (2 * res.Y) * zoom - yDiff;
                    }
                    else
                    {
                        xProjected = (250 + (2 * res.X)) * zoom - xDiff;
                        yProjected = (2 * res.Y) * zoom - yDiff;
                    }
                    if ((Math.Abs(X - xProjected) < distanceThreshold) && (Math.Abs(Y - yProjected) < distanceThreshold))
                    {
                        if (res is House)
                        {
                            propertyInfor = PrintHouseInfo(allPeople, res);
                        }
                        if (res is Apartment)
                        {
                            propertyInfor = PrintApartmentInfo(allPeople, res);
                        }
                        if (res is School)
                        {
                            propertyInfor = PrintSchoolInfo(allPeople, res);
                        }
                        if (res is Business)
                        {
                            propertyInfor = PrintBusinessInfo(allPeople, res);
                        }
                    }

                }
            }
            toolTip1.Show(propertyInfor, panel3);

            if (Sleep > 75)
            {
                System.Threading.Thread.Sleep(200);
            }
            Sleep++;
        }

        //Print House info 
        public string PrintHouseInfo(IEnumerable<Person> allPeople, Property i)
        {
            House tempHouse = (House)i;
            string houseInfo = "";
            string SalePriceString = "";

            houseInfo = i.StreetAddr + " " + i.City + ", " + i.State + " " + i.Zip;
            var ownerInfo = from aperson in allPeople where (aperson.Id.CompareTo(i.OwnerID) == 0) select aperson;

            houseInfo = houseInfo + "\nOwner: " + ownerInfo.First().LastName + ", " + ownerInfo.First().FirstName + " | " + tempHouse.Bedrooms.ToString() + " beds, " + tempHouse.Baths.ToString() + " baths, " + tempHouse.Sqft.ToString() + " sq.ft.";

            string floorString = tempHouse.Floors > 1 ? "floors" : "floor";
            if (tempHouse.Garage == true)
            {
                if (tempHouse.SalePrice > 100)
                {
                    SalePriceString = String.Format("{0:$0,0}", tempHouse.SalePrice);
                }
                else
                {
                    SalePriceString = "";
                }
                if (tempHouse.AttachedGarage == true)
                {
                    houseInfo = houseInfo + "\n with an attached garage | " + tempHouse.Floors.ToString() + " " + floorString + ".     " + SalePriceString;
                }
                else
                {
                    houseInfo = houseInfo + "\n with a detached garage | " + tempHouse.Floors.ToString() + " " + floorString + ".     " + SalePriceString;
                }
            }
            else
            {
                houseInfo = houseInfo + "\n with no garage: " + tempHouse.Floors.ToString() + " " + floorString + ".     " + SalePriceString;
            }
            return houseInfo;
        }
        //
        //Print Aptartment info for properties within the price range
        public string PrintApartmentInfo(IEnumerable<Person> allPeople, Property i)
        {
            Apartment tempApt = (Apartment)i;
            string aptInfo = "";
            string SalePriceString = "";

            aptInfo = i.StreetAddr + " Apt. " + tempApt.Unit + " " + i.City + ", " + i.State + " " + i.Zip;
            var ownerInfo = from aperson in allPeople where (aperson.Id.CompareTo(i.OwnerID) == 0) select aperson;

            aptInfo = aptInfo + "\nOwner: " + ownerInfo.First().LastName + ", " + ownerInfo.First().FirstName + " | " + tempApt.Bedrooms.ToString() + " beds, " + tempApt.Baths.ToString() + " baths, " + tempApt.Sqft.ToString() + " sq.ft.";

            if (tempApt.SalePrice > 100)
            {
                SalePriceString = String.Format("{0:$0,0}", tempApt.SalePrice);
            }
            else
            {
                SalePriceString = "";
            }
            aptInfo = aptInfo + "\n" + SalePriceString;
            //result_ListBox.Items.Add("");
            return aptInfo;
        }

        //Print Business info for properties within the price range
        public string PrintBusinessInfo(IEnumerable<Person> allPeople, Property i)
        {
            Business tempBus = (Business)i;
            string businessInfo = "";
            string SalePriceString = "";
            businessInfo = i.StreetAddr + " " + i.City + ", " + i.State + " " + i.Zip;
            var ownerInfo = from aperson in allPeople where (aperson.Id.CompareTo(i.OwnerID) == 0) select aperson;
            if (tempBus.SalePrice > 100)
            {
                SalePriceString = String.Format("{0:$0,0}", tempBus.SalePrice);
            }
            else
            {
                SalePriceString = "";
            }
            businessInfo = businessInfo + "\nOwner: " + ownerInfo.First().LastName + ", " + ownerInfo.First().FirstName + " |      " + SalePriceString;
            businessInfo = businessInfo + "\n" + tempBus.Name + ", a " + tempBus.Type.ToString() + " type of business, established in " + tempBus.YearEstablished;

            return businessInfo;
        }

        //Print School info for properties within the price range
        public string PrintSchoolInfo(IEnumerable<Person> allPeople, Property i)
        {
            School tepSch = (School)i;
            string schoolInfo = "";
            string SalePriceString = "";
            var ownerInfo = from aperson in allPeople where (aperson.Id.CompareTo(i.OwnerID) == 0) select aperson;
            schoolInfo = schoolInfo + i.StreetAddr + " " + i.City + ", " + i.State + " " + i.Zip + " | " + "Owner: " + ownerInfo.First().LastName + ", " + ownerInfo.First().FirstName;
            schoolInfo = schoolInfo + "\n" + tepSch.Name + ", established in " + tepSch.YearEstablished;

            if (tepSch.SalePrice > 100)
            {
                SalePriceString = String.Format("{0:$0,0}", tepSch.SalePrice);
            }
            else
            {
                SalePriceString = "";
            }
            schoolInfo = schoolInfo + "\n" + tepSch.Enrolled.ToString() + " students enrolled       " + SalePriceString;

            return schoolInfo;
        }
    }
}
