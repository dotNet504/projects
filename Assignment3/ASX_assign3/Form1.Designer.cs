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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(792, 228);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "For Sale Properties Within Price Range";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Max Price";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Min Price";
            // 
            // trackBarMax
            // 
            this.trackBarMax.Location = new System.Drawing.Point(152, 135);
            this.trackBarMax.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.trackBarMax.Name = "trackBarMax";
            this.trackBarMax.Size = new System.Drawing.Size(256, 69);
            this.trackBarMax.TabIndex = 5;
            this.trackBarMax.Scroll += new System.EventHandler(this.scrollMaxPrice);
            // 
            // trackBarMin
            // 
            this.trackBarMin.Location = new System.Drawing.Point(468, 135);
            this.trackBarMin.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.trackBarMin.Name = "trackBarMin";
            this.trackBarMin.Size = new System.Drawing.Size(256, 69);
            this.trackBarMin.TabIndex = 4;
            this.trackBarMin.Scroll += new System.EventHandler(this.scrollMinPrice);
            // 
            // SalePriceRangeQuery
            // 
            this.SalePriceRangeQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalePriceRangeQuery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SalePriceRangeQuery.Location = new System.Drawing.Point(492, 24);
            this.SalePriceRangeQuery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SalePriceRangeQuery.Name = "SalePriceRangeQuery";
            this.SalePriceRangeQuery.Size = new System.Drawing.Size(112, 42);
            this.SalePriceRangeQuery.TabIndex = 3;
            this.SalePriceRangeQuery.Text = "Query";
            this.SalePriceRangeQuery.UseVisualStyleBackColor = true;
            this.SalePriceRangeQuery.Click += new System.EventHandler(this.PropertiesPriceRange);
            // 
            // checkBox_Scho
            // 
            this.checkBox_Scho.AutoSize = true;
            this.checkBox_Scho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Scho.Location = new System.Drawing.Point(9, 108);
            this.checkBox_Scho.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_Scho.Name = "checkBox_Scho";
            this.checkBox_Scho.Size = new System.Drawing.Size(99, 29);
            this.checkBox_Scho.TabIndex = 2;
            this.checkBox_Scho.Text = "School";
            this.checkBox_Scho.UseVisualStyleBackColor = true;
            this.checkBox_Scho.Click += new System.EventHandler(this.SelectTypeProperties);
            // 
            // checkBox_Busi
            // 
            this.checkBox_Busi.AutoSize = true;
            this.checkBox_Busi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Busi.Location = new System.Drawing.Point(9, 72);
            this.checkBox_Busi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_Busi.Name = "checkBox_Busi";
            this.checkBox_Busi.Size = new System.Drawing.Size(118, 29);
            this.checkBox_Busi.TabIndex = 1;
            this.checkBox_Busi.Text = "Business";
            this.checkBox_Busi.UseVisualStyleBackColor = true;
            this.checkBox_Busi.Click += new System.EventHandler(this.SelectTypeProperties);
            // 
            // checkBox_Resi
            // 
            this.checkBox_Resi.AutoSize = true;
            this.checkBox_Resi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Resi.Location = new System.Drawing.Point(9, 37);
            this.checkBox_Resi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_Resi.Name = "checkBox_Resi";
            this.checkBox_Resi.Size = new System.Drawing.Size(129, 29);
            this.checkBox_Resi.TabIndex = 0;
            this.checkBox_Resi.Text = "Residental";
            this.checkBox_Resi.UseVisualStyleBackColor = true;
            this.checkBox_Resi.Click += new System.EventHandler(this.SelectTypeProperties);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(39, 306);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(12, 12);
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
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(18, 280);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(792, 122);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "For Sale Residences Within Range of a School";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(290, 69);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(90, 32);
            this.numericUpDown1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Distance";
            // 
            // ResidencesRangeQuery
            // 
            this.ResidencesRangeQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResidencesRangeQuery.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ResidencesRangeQuery.Location = new System.Drawing.Point(543, 58);
            this.ResidencesRangeQuery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ResidencesRangeQuery.Name = "ResidencesRangeQuery";
            this.ResidencesRangeQuery.Size = new System.Drawing.Size(112, 42);
            this.ResidencesRangeQuery.TabIndex = 3;
            this.ResidencesRangeQuery.Text = "Query";
            this.ResidencesRangeQuery.UseVisualStyleBackColor = true;
            this.ResidencesRangeQuery.Click += new System.EventHandler(this.FindSaleResNearSchool);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "School";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 66);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(264, 34);
            this.comboBox1.TabIndex = 0;
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
            this.groupBox4.Location = new System.Drawing.Point(18, 432);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(792, 134);
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
            this.Query3_Distance.Location = new System.Drawing.Point(292, 75);
            this.Query3_Distance.Margin = new System.Windows.Forms.Padding(2);
            this.Query3_Distance.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.Query3_Distance.Name = "Query3_Distance";
            this.Query3_Distance.Size = new System.Drawing.Size(90, 32);
            this.Query3_Distance.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(285, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Distance";
            // 
            // Query3
            // 
            this.Query3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Query3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Query3.Location = new System.Drawing.Point(543, 71);
            this.Query3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Query3.Name = "Query3";
            this.Query3.Size = new System.Drawing.Size(112, 42);
            this.Query3.TabIndex = 3;
            this.Query3.Text = "Query";
            this.Query3.UseVisualStyleBackColor = true;
            this.Query3.Click += new System.EventHandler(this.Query3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "For-Sale Resindence";
            // 
            // For_Sale_Residence_ComboBox
            // 
            this.For_Sale_Residence_ComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.For_Sale_Residence_ComboBox.FormattingEnabled = true;
            this.For_Sale_Residence_ComboBox.Location = new System.Drawing.Point(9, 75);
            this.For_Sale_Residence_ComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.For_Sale_Residence_ComboBox.Name = "For_Sale_Residence_ComboBox";
            this.For_Sale_Residence_ComboBox.Size = new System.Drawing.Size(264, 34);
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
            this.groupBox5.Location = new System.Drawing.Point(18, 594);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(792, 129);
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
            this.sqFtUpDown.Location = new System.Drawing.Point(279, 78);
            this.sqFtUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.sqFtUpDown.Size = new System.Drawing.Size(104, 32);
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
            this.bathUpDown.Location = new System.Drawing.Point(224, 78);
            this.bathUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.bathUpDown.Size = new System.Drawing.Size(46, 32);
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
            this.bedUpDown.Location = new System.Drawing.Point(162, 78);
            this.bedUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.bedUpDown.Size = new System.Drawing.Size(46, 32);
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
            this.attachedCheckBox.Location = new System.Drawing.Point(392, 88);
            this.attachedCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.attachedCheckBox.Name = "attachedCheckBox";
            this.attachedCheckBox.Size = new System.Drawing.Size(136, 30);
            this.attachedCheckBox.TabIndex = 13;
            this.attachedCheckBox.Text = "Attached?";
            this.attachedCheckBox.UseVisualStyleBackColor = true;
            this.attachedCheckBox.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(274, 46);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 26);
            this.label9.TabIndex = 12;
            this.label9.Text = "Min Sq. ft.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(219, 46);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 26);
            this.label8.TabIndex = 11;
            this.label8.Text = "Bath";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(158, 48);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 26);
            this.label7.TabIndex = 10;
            this.label7.Text = "Bed";
            // 
            // garageCheckBox
            // 
            this.garageCheckBox.AutoSize = true;
            this.garageCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.garageCheckBox.Location = new System.Drawing.Point(392, 46);
            this.garageCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.garageCheckBox.Name = "garageCheckBox";
            this.garageCheckBox.Size = new System.Drawing.Size(110, 30);
            this.garageCheckBox.TabIndex = 6;
            this.garageCheckBox.Text = "Garage";
            this.garageCheckBox.UseVisualStyleBackColor = true;
            this.garageCheckBox.CheckedChanged += new System.EventHandler(this.garageCheckBox_CheckedChanged);
            // 
            // apartmentCheckBox
            // 
            this.apartmentCheckBox.AutoSize = true;
            this.apartmentCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apartmentCheckBox.Location = new System.Drawing.Point(9, 82);
            this.apartmentCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.apartmentCheckBox.Name = "apartmentCheckBox";
            this.apartmentCheckBox.Size = new System.Drawing.Size(139, 30);
            this.apartmentCheckBox.TabIndex = 5;
            this.apartmentCheckBox.Text = "Apartment";
            this.apartmentCheckBox.UseVisualStyleBackColor = true;
            this.apartmentCheckBox.CheckedChanged += new System.EventHandler(this.apartmentCheckBox_CheckedChanged);
            // 
            // houseCheckBox
            // 
            this.houseCheckBox.AutoSize = true;
            this.houseCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.houseCheckBox.Location = new System.Drawing.Point(9, 46);
            this.houseCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.houseCheckBox.Name = "houseCheckBox";
            this.houseCheckBox.Size = new System.Drawing.Size(101, 30);
            this.houseCheckBox.TabIndex = 4;
            this.houseCheckBox.Text = "House";
            this.houseCheckBox.UseVisualStyleBackColor = true;
            // 
            // querySpecResidence
            // 
            this.querySpecResidence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.querySpecResidence.ForeColor = System.Drawing.SystemColors.ControlText;
            this.querySpecResidence.Location = new System.Drawing.Point(543, 46);
            this.querySpecResidence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.querySpecResidence.Name = "querySpecResidence";
            this.querySpecResidence.Size = new System.Drawing.Size(112, 42);
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
            this.groupBox6.Location = new System.Drawing.Point(20, 740);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox6.Size = new System.Drawing.Size(790, 86);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "List Of Properties Owned by Out-Of-Towners";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Location = new System.Drawing.Point(543, 29);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 42);
            this.button5.TabIndex = 0;
            this.button5.Text = "Query";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // result_ListBox
            // 
            this.result_ListBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result_ListBox.FormattingEnabled = true;
            this.result_ListBox.ItemHeight = 20;
            this.result_ListBox.Location = new System.Drawing.Point(819, 45);
            this.result_ListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.result_ListBox.Name = "result_ListBox";
            this.result_ListBox.Size = new System.Drawing.Size(572, 724);
            this.result_ListBox.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(814, 14);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 26);
            this.label10.TabIndex = 7;
            this.label10.Text = "Query Results";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.result_ListBox);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.ComboBox comboBox1;
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

