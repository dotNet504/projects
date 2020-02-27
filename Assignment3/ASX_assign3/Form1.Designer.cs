namespace ASX_assign3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarMax = new System.Windows.Forms.TrackBar();
            this.trackBarMin = new System.Windows.Forms.TrackBar();
            this.SalePriceRangeQuery = new System.Windows.Forms.Button();
            this.checkBox_Scho = new System.Windows.Forms.CheckBox();
            this.checkBox_Busi = new System.Windows.Forms.CheckBox();
            this.checkBox_Resi = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ResidencesRangeQuery = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.schoolComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Query3_Distance = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.Query3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.For_Sale_Residence_ComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.sqFtUpDown = new System.Windows.Forms.NumericUpDown();
            this.bathUpDown = new System.Windows.Forms.NumericUpDown();
            this.bedUpDown = new System.Windows.Forms.NumericUpDown();
            this.attachedCheckBox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.garageCheckBox = new System.Windows.Forms.CheckBox();
            this.apartmentCheckBox = new System.Windows.Forms.CheckBox();
            this.houseCheckBox = new System.Windows.Forms.CheckBox();
            this.querySpecResidence = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.result_ListBox = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMin)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Query3_Distance)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sqFtUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bathUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedUpDown)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.trackBarMax);
            this.groupBox1.Controls.Add(this.trackBarMin);
            this.groupBox1.Controls.Add(this.SalePriceRangeQuery);
            this.groupBox1.Controls.Add(this.checkBox_Scho);
            this.groupBox1.Controls.Add(this.checkBox_Busi);
            this.groupBox1.Controls.Add(this.checkBox_Resi);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 148);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "For Sale Properties Within Price Range";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Max Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Min Price";
            // 
            // trackBarMax
            // 
            this.trackBarMax.Location = new System.Drawing.Point(327, 55);
            this.trackBarMax.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBarMax.Name = "trackBarMax";
            this.trackBarMax.Size = new System.Drawing.Size(171, 45);
            this.trackBarMax.TabIndex = 5;
            this.trackBarMax.Scroll += new System.EventHandler(this.scrollMaxPrice);
            // 
            // trackBarMin
            // 
            this.trackBarMin.Location = new System.Drawing.Point(108, 55);
            this.trackBarMin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBarMin.Name = "trackBarMin";
            this.trackBarMin.Size = new System.Drawing.Size(171, 45);
            this.trackBarMin.TabIndex = 4;
            this.trackBarMin.Scroll += new System.EventHandler(this.scrollMinPrice);
            // 
            // SalePriceRangeQuery
            // 
            this.SalePriceRangeQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalePriceRangeQuery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SalePriceRangeQuery.Location = new System.Drawing.Point(433, 102);
            this.SalePriceRangeQuery.Name = "SalePriceRangeQuery";
            this.SalePriceRangeQuery.Size = new System.Drawing.Size(75, 27);
            this.SalePriceRangeQuery.TabIndex = 3;
            this.SalePriceRangeQuery.Text = "Query";
            this.SalePriceRangeQuery.UseVisualStyleBackColor = true;
            this.SalePriceRangeQuery.Click += new System.EventHandler(this.PropertiesPriceRange);
            // 
            // checkBox_Scho
            // 
            this.checkBox_Scho.AutoSize = true;
            this.checkBox_Scho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Scho.Location = new System.Drawing.Point(6, 70);
            this.checkBox_Scho.Name = "checkBox_Scho";
            this.checkBox_Scho.Size = new System.Drawing.Size(70, 21);
            this.checkBox_Scho.TabIndex = 2;
            this.checkBox_Scho.Text = "School";
            this.checkBox_Scho.UseVisualStyleBackColor = true;
            // 
            // checkBox_Busi
            // 
            this.checkBox_Busi.AutoSize = true;
            this.checkBox_Busi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Busi.Location = new System.Drawing.Point(6, 47);
            this.checkBox_Busi.Name = "checkBox_Busi";
            this.checkBox_Busi.Size = new System.Drawing.Size(84, 21);
            this.checkBox_Busi.TabIndex = 1;
            this.checkBox_Busi.Text = "Business";
            this.checkBox_Busi.UseVisualStyleBackColor = true;
            // 
            // checkBox_Resi
            // 
            this.checkBox_Resi.AutoSize = true;
            this.checkBox_Resi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Resi.Location = new System.Drawing.Point(6, 24);
            this.checkBox_Resi.Name = "checkBox_Resi";
            this.checkBox_Resi.Size = new System.Drawing.Size(94, 21);
            this.checkBox_Resi.TabIndex = 0;
            this.checkBox_Resi.Text = "Residental";
            this.checkBox_Resi.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(26, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(8, 8);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.ResidencesRangeQuery);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.schoolComboBox);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(12, 182);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 79);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "For Sale Residences Within Range of a School";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(345, 43);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(1);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(60, 24);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(343, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Distance";
            // 
            // ResidencesRangeQuery
            // 
            this.ResidencesRangeQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResidencesRangeQuery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ResidencesRangeQuery.Location = new System.Drawing.Point(433, 38);
            this.ResidencesRangeQuery.Name = "ResidencesRangeQuery";
            this.ResidencesRangeQuery.Size = new System.Drawing.Size(75, 27);
            this.ResidencesRangeQuery.TabIndex = 3;
            this.ResidencesRangeQuery.Text = "Query";
            this.ResidencesRangeQuery.UseVisualStyleBackColor = true;
            this.ResidencesRangeQuery.Click += new System.EventHandler(this.FindSaleResNearSchool);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "School";
            // 
            // schoolComboBox
            // 
            this.schoolComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.schoolComboBox.FormattingEnabled = true;
            this.schoolComboBox.Location = new System.Drawing.Point(6, 43);
            this.schoolComboBox.Name = "schoolComboBox";
            this.schoolComboBox.Size = new System.Drawing.Size(274, 25);
            this.schoolComboBox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Query3_Distance);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.Query3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.For_Sale_Residence_ComboBox);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox4.Location = new System.Drawing.Point(12, 281);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(528, 87);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Hiring Business(es) For Sale Within Range of For Sale Residence";
            // 
            // Query3_Distance
            // 
            this.Query3_Distance.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.Query3_Distance.Location = new System.Drawing.Point(195, 49);
            this.Query3_Distance.Margin = new System.Windows.Forms.Padding(1);
            this.Query3_Distance.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.Query3_Distance.Name = "Query3_Distance";
            this.Query3_Distance.Size = new System.Drawing.Size(60, 24);
            this.Query3_Distance.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(190, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Distance";
            // 
            // Query3
            // 
            this.Query3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Query3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Query3.Location = new System.Drawing.Point(362, 46);
            this.Query3.Name = "Query3";
            this.Query3.Size = new System.Drawing.Size(75, 27);
            this.Query3.TabIndex = 3;
            this.Query3.Text = "Query";
            this.Query3.UseVisualStyleBackColor = true;
            this.Query3.Click += new System.EventHandler(this.Query3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "For-Sale Resindence";
            // 
            // For_Sale_Residence_ComboBox
            // 
            this.For_Sale_Residence_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.For_Sale_Residence_ComboBox.FormattingEnabled = true;
            this.For_Sale_Residence_ComboBox.Location = new System.Drawing.Point(6, 49);
            this.For_Sale_Residence_ComboBox.Name = "For_Sale_Residence_ComboBox";
            this.For_Sale_Residence_ComboBox.Size = new System.Drawing.Size(177, 25);
            this.For_Sale_Residence_ComboBox.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.sqFtUpDown);
            this.groupBox5.Controls.Add(this.bathUpDown);
            this.groupBox5.Controls.Add(this.bedUpDown);
            this.groupBox5.Controls.Add(this.attachedCheckBox);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.garageCheckBox);
            this.groupBox5.Controls.Add(this.apartmentCheckBox);
            this.groupBox5.Controls.Add(this.houseCheckBox);
            this.groupBox5.Controls.Add(this.querySpecResidence);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox5.Location = new System.Drawing.Point(12, 386);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(528, 84);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Specific Residence Parameters";
            // 
            // sqFtUpDown
            // 
            this.sqFtUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqFtUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sqFtUpDown.Location = new System.Drawing.Point(186, 51);
            this.sqFtUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.sqFtUpDown.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.sqFtUpDown.Name = "sqFtUpDown";
            this.sqFtUpDown.Size = new System.Drawing.Size(69, 24);
            this.sqFtUpDown.TabIndex = 16;
            this.sqFtUpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // bathUpDown
            // 
            this.bathUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bathUpDown.Location = new System.Drawing.Point(149, 51);
            this.bathUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.bathUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bathUpDown.Name = "bathUpDown";
            this.bathUpDown.Size = new System.Drawing.Size(31, 24);
            this.bathUpDown.TabIndex = 15;
            this.bathUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bedUpDown
            // 
            this.bedUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bedUpDown.Location = new System.Drawing.Point(108, 51);
            this.bedUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.bedUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bedUpDown.Name = "bedUpDown";
            this.bedUpDown.Size = new System.Drawing.Size(31, 24);
            this.bedUpDown.TabIndex = 14;
            this.bedUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // attachedCheckBox
            // 
            this.attachedCheckBox.AutoSize = true;
            this.attachedCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachedCheckBox.Location = new System.Drawing.Point(261, 57);
            this.attachedCheckBox.Name = "attachedCheckBox";
            this.attachedCheckBox.Size = new System.Drawing.Size(92, 22);
            this.attachedCheckBox.TabIndex = 13;
            this.attachedCheckBox.Text = "Attached?";
            this.attachedCheckBox.UseVisualStyleBackColor = true;
            this.attachedCheckBox.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(183, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 18);
            this.label9.TabIndex = 12;
            this.label9.Text = "Min Sq. ft.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(146, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 18);
            this.label8.TabIndex = 11;
            this.label8.Text = "Bath";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(105, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "Bed";
            // 
            // garageCheckBox
            // 
            this.garageCheckBox.AutoSize = true;
            this.garageCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.garageCheckBox.Location = new System.Drawing.Point(261, 30);
            this.garageCheckBox.Name = "garageCheckBox";
            this.garageCheckBox.Size = new System.Drawing.Size(76, 22);
            this.garageCheckBox.TabIndex = 6;
            this.garageCheckBox.Text = "Garage";
            this.garageCheckBox.UseVisualStyleBackColor = true;
            this.garageCheckBox.CheckedChanged += new System.EventHandler(this.garageCheckBox_CheckedChanged);
            // 
            // apartmentCheckBox
            // 
            this.apartmentCheckBox.AutoSize = true;
            this.apartmentCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apartmentCheckBox.Location = new System.Drawing.Point(6, 53);
            this.apartmentCheckBox.Name = "apartmentCheckBox";
            this.apartmentCheckBox.Size = new System.Drawing.Size(94, 22);
            this.apartmentCheckBox.TabIndex = 5;
            this.apartmentCheckBox.Text = "Apartment";
            this.apartmentCheckBox.UseVisualStyleBackColor = true;
            this.apartmentCheckBox.CheckedChanged += new System.EventHandler(this.apartmentCheckBox_CheckedChanged);
            // 
            // houseCheckBox
            // 
            this.houseCheckBox.AutoSize = true;
            this.houseCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.houseCheckBox.Location = new System.Drawing.Point(6, 30);
            this.houseCheckBox.Name = "houseCheckBox";
            this.houseCheckBox.Size = new System.Drawing.Size(71, 22);
            this.houseCheckBox.TabIndex = 4;
            this.houseCheckBox.Text = "House";
            this.houseCheckBox.UseVisualStyleBackColor = true;
            // 
            // querySpecResidence
            // 
            this.querySpecResidence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.querySpecResidence.ForeColor = System.Drawing.SystemColors.ControlText;
            this.querySpecResidence.Location = new System.Drawing.Point(362, 30);
            this.querySpecResidence.Name = "querySpecResidence";
            this.querySpecResidence.Size = new System.Drawing.Size(75, 27);
            this.querySpecResidence.TabIndex = 3;
            this.querySpecResidence.Text = "Query";
            this.querySpecResidence.UseVisualStyleBackColor = true;
            this.querySpecResidence.Click += new System.EventHandler(this.querySpecResidence_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button5);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox6.Location = new System.Drawing.Point(13, 481);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(527, 62);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "List Of Properties Owned by Out-Of-Towners";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Location = new System.Drawing.Point(362, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 27);
            this.button5.TabIndex = 0;
            this.button5.Text = "Query";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.query5_click);
            // 
            // result_ListBox
            // 
            this.result_ListBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result_ListBox.FormattingEnabled = true;
            this.result_ListBox.ItemHeight = 15;
            this.result_ListBox.Location = new System.Drawing.Point(546, 29);
            this.result_ListBox.Name = "result_ListBox";
            this.result_ListBox.Size = new System.Drawing.Size(491, 514);
            this.result_ListBox.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(543, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 18);
            this.label10.TabIndex = 7;
            this.label10.Text = "Query Results";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(913, 573);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.result_ListBox);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "ASX\' Real Estate Querying System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMin)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Query3_Distance)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sqFtUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bathUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedUpDown)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarMax;
        private System.Windows.Forms.TrackBar trackBarMin;
        private System.Windows.Forms.Button SalePriceRangeQuery;
        private System.Windows.Forms.CheckBox checkBox_Scho;
        private System.Windows.Forms.CheckBox checkBox_Busi;
        private System.Windows.Forms.CheckBox checkBox_Resi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ResidencesRangeQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox schoolComboBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Query3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox For_Sale_Residence_ComboBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox garageCheckBox;
        private System.Windows.Forms.CheckBox apartmentCheckBox;
        private System.Windows.Forms.CheckBox houseCheckBox;
        private System.Windows.Forms.Button querySpecResidence;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox result_ListBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox attachedCheckBox;
        private System.Windows.Forms.NumericUpDown sqFtUpDown;
        private System.Windows.Forms.NumericUpDown bathUpDown;
        private System.Windows.Forms.NumericUpDown bedUpDown;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown Query3_Distance;
    }
}

