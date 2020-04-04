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
        public int xDiff;
        public int yDiff;

        private Boolean panelReset = true;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ////Logic to autosize the output window
            //this.AutoSize = true;
            //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            //FlowLayoutPanel flowPanel = new FlowLayoutPanel();
            //flowPanel.AutoSize = true;
            //flowPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //this.Controls.Add(flowPanel);

            //set the range of trackbar 1 from 100% to 300%
            trackBar1.Minimum = 100;
            trackBar1.Maximum = 400;
            // at the begining the scale is 100% so we diable the two scrollbars

            minX = 0;
            maxX = Convert.ToInt32(panel3.Width * zoom) - panel3.Width;
            minY = 0;
            maxY = Convert.ToInt32(panel3.Height * zoom) - panel3.Height;


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
        #endregion

        #region Queries

        // This method handles querying used for the map_drawing
        private void do_query(PaintEventArgs e)
        {

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


                For_Sale_Residence_ComboBox.Items.Clear();
                For_Sale_Residence_ComboBox.Items.Add(dekalbVal);
                For_Sale_Residence_ComboBox.Items.Add(shortHyphen);
                populateForSaleResidences(dHouse, dApartment);
                For_Sale_Residence_ComboBox.Items.Add("\n");
                For_Sale_Residence_ComboBox.Items.Add(sycamoreVal);
                For_Sale_Residence_ComboBox.Items.Add(shortHyphen);
                populateForSaleResidences(sHouse, sApartment);

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
                    strF.Alignment = StringAlignment.Center;
                    e.Graphics.DrawLine(p, x * zoom - xDiff, 0 * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    e.Graphics.DrawString(gi.PropT.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                    e.Graphics.DrawLine(p, 0 * zoom - xDiff, y * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    strF.FormatFlags = StringFormatFlags.DirectionVertical;
                    e.Graphics.DrawString(gi.PropT.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);

                }
                else if (g.Count() > 1)
                {
                    List<Point> pfs = new List<Point>();
                    foreach (var point in g)
                    {
                        var x = 2 * point.PropT.X;
                        var y = 2 * point.PropT.Y;

                        pfs.Add(new Point(Convert.ToInt32(x * zoom) - xDiff, Convert.ToInt32(y * zoom) - yDiff));
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
                    strF.Alignment = StringAlignment.Center;
                    e.Graphics.DrawLine(p, x * zoom - xDiff, 0 * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    e.Graphics.DrawString(gi.PropT.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                    e.Graphics.DrawLine(p, 0 * zoom - xDiff, y * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    strF.FormatFlags = StringFormatFlags.DirectionVertical;
                    e.Graphics.DrawString(gi.PropT.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);

                }
                else if (g.Count() > 1)
                {
                    List<Point> pfs = new List<Point>();
                    foreach (var point in g)
                    {
                        var x = 250 + (2 * point.PropT.X);
                        var y = 2 * point.PropT.Y;

                        pfs.Add(new Point(Convert.ToInt32(x * zoom) - xDiff, Convert.ToInt32(y * zoom) - yDiff));
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
                if (item.PropT.GetType().Equals(typeof(House)) || item.PropT.GetType().Equals(typeof(Apartment)))
                {
                    e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Home.png"),
                  new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                }
                if (item.PropT.GetType().Equals(typeof(School)))
                {
                    e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/School.png"),
                  new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                }
                if (item.PropT.GetType().Equals(typeof(Business)))
                {
                    e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Business.png"),
                  new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                }
                #endregion
            }
        }

        #endregion

        //This method is invoked on Search button click
        private void searchButton_Click(object sender, EventArgs e)
        {
            panelReset = false;
            panel3.Refresh();
        }

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

            var lstDekalb = CommunitiesList.Where(x => x.Name.ToLower() == "dekalb").FirstOrDefault();
            var grpDlk = lstDekalb.Props.GroupBy(x => x.StreetName);
            foreach (var item in grpDlk)
            {
                if (item.Count() == 1)
                {
                    var data = item.FirstOrDefault();
                    var x = 2 *data.X;
                    var y = 2 *data.Y;
                    if (dekalbHouses.Any(house => house.Id == data.Id))
                    {
                        e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Home.png"),
                       new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                    }
                    if (dekalbSchools.Any(school => school.Id == data.Id))
                    {
                        e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/School.png"),
                       new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                    }
                    if (dekalbBusinesses.Any(business => business.Id == data.Id))
                    {
                        e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Business.png"),
                       new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                    }
                    StringFormat strF = new StringFormat();
                    strF.Alignment = StringAlignment.Center;
                    e.Graphics.DrawLine(p, x * zoom - xDiff, 0 * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    e.Graphics.DrawString(data.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                    e.Graphics.DrawLine(p, 0 * zoom - xDiff, y * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    strF.FormatFlags = StringFormatFlags.DirectionVertical;
                    e.Graphics.DrawString(data.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                }
                else
                {
                    List<Point> pfs = new List<Point>();
                    foreach (var point in item)
                    {
                        var x = 2 * point.X;
                        var y = 2 * point.Y;
                        if (dekalbHouses.Any(house => house.Id == point.Id))
                        {
                            e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Home.png"),
                           new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                        }
                        if (dekalbSchools.Any(school => school.Id == point.Id))
                        {
                            e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/School.png"),
                           new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                        }
                        if (dekalbBusinesses.Any(business => business.Id == point.Id))
                        {
                            e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Business.png"),
                           new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                        }
                        pfs.Add(new Point(Convert.ToInt32(x * zoom) - xDiff, Convert.ToInt32(y * zoom) - yDiff));
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
                    if (sycamoreHouses.Any(house => house.Id == data.Id))
                    {
                        e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Home.png"),
                       new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                    }
                    if (sycamoreSchools.Any(school => school.Id == data.Id))
                    {
                        e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/School.png"),
                       new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                    }
                    if (sycamoreBusinesses.Any(business => business.Id == data.Id))
                    {
                        e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Business.png"),
                       new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                    }
                    StringFormat strF = new StringFormat();
                    strF.Alignment = StringAlignment.Center;
                    e.Graphics.DrawLine(p, x * zoom - xDiff, 0 * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    e.Graphics.DrawString(data.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                    e.Graphics.DrawLine(p, 0 * zoom - xDiff, y * zoom - yDiff, x * zoom - xDiff, y * zoom - yDiff);
                    strF.FormatFlags = StringFormatFlags.DirectionVertical;
                    e.Graphics.DrawString(data.StreetName, font, Brushes.Black, x * zoom - xDiff, y * zoom - yDiff, strF);
                }
                else
                {
                    List<Point> pfs = new List<Point>();
                    foreach (var point in item)
                    {
                        var x = 250 + (2 * point.X);
                        var y = 2 * point.Y;
                        if (sycamoreHouses.Any(house => house.Id == point.Id))
                        {
                            e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Home.png"),
                           new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                        }
                        if (sycamoreSchools.Any(school => school.Id == point.Id))
                        {
                            e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/School.png"),
                           new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                        }
                        if (sycamoreBusinesses.Any(business => business.Id == point.Id))
                        {
                            e.Graphics.DrawImage(Image.FromFile(@"../../../DataLoader/Icons/Business.png"),
                           new Rectangle(Convert.ToInt32(x * zoom - xDiff), Convert.ToInt32(y * zoom - yDiff), 15, 15));
                        }
                        pfs.Add(new Point(Convert.ToInt32(x * zoom) - xDiff, Convert.ToInt32(y * zoom) - yDiff));
                    }
                    e.Graphics.DrawCurve(p, pfs.ToArray());
                }

            }


            e.Dispose();
        }



        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            zoom = trackBar1.Value / 100f;

            //reset the range of the drawing area
            minX = 0;
            maxX = Convert.ToInt32(panel3.Width * zoom) - panel3.Width;
            minY = 0;
            maxY = Convert.ToInt32(panel3.Height * zoom) - panel3.Height;


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

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            panel3.Refresh();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            panel3.Refresh();
        }


        //record the mouse down and mouse up
        public Point startPt;
        public Point endPt;


        private void panel3_move_down(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.X.ToString() + " " + e.Y.ToString());
            startPt.X = e.X;
            startPt.Y = e.Y;
        }


        private void panel3_move_up(object sender, MouseEventArgs e)
        {

            endPt.X = e.X;
            endPt.Y = e.Y;
            int xdelta = startPt.X - endPt.X;
            int ydelta = startPt.Y - endPt.Y;

            xDiff = xDiff + xdelta;
            yDiff = yDiff + ydelta;

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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                panelReset = false;
                panel3.Refresh();
            }
        }
    }
}
