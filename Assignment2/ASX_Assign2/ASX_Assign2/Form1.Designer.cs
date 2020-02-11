namespace ASX_Assign2
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
            this.dekalbRadioButton = new System.Windows.Forms.RadioButton();
            this.sycamoreRadioButton = new System.Windows.Forms.RadioButton();
            this.personLabel = new System.Windows.Forms.Label();
            this.residenceLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.personListBox = new System.Windows.Forms.ListBox();
            this.residenceListBox = new System.Windows.Forms.ListBox();
            this.outputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.add_res_groupBox = new System.Windows.Forms.GroupBox();
            this.residenceComboBox = new System.Windows.Forms.ComboBox();
            this.addNewResidentButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.occupationTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bdayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.add_prop_groupBox = new System.Windows.Forms.GroupBox();
            this.addProptButton = new System.Windows.Forms.Button();
            this.garageCheckBox = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.floorsUpDown = new System.Windows.Forms.NumericUpDown();
            this.bathUpDown = new System.Windows.Forms.NumericUpDown();
            this.bedrmUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.sqFtUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.aptNoTextBox = new System.Windows.Forms.TextBox();
            this.streetAddrTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.add_res_groupBox.SuspendLayout();
            this.add_prop_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.floorsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bathUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedrmUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqFtUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // dekalbRadioButton
            // 
            this.dekalbRadioButton.AutoSize = true;
            this.dekalbRadioButton.BackColor = System.Drawing.Color.Black;
            this.dekalbRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dekalbRadioButton.ForeColor = System.Drawing.Color.White;
            this.dekalbRadioButton.Location = new System.Drawing.Point(22, 46);
            this.dekalbRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dekalbRadioButton.Name = "dekalbRadioButton";
            this.dekalbRadioButton.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dekalbRadioButton.Size = new System.Drawing.Size(132, 46);
            this.dekalbRadioButton.TabIndex = 0;
            this.dekalbRadioButton.Text = "Dekalb";
            this.dekalbRadioButton.UseVisualStyleBackColor = false;
            this.dekalbRadioButton.CheckedChanged += new System.EventHandler(this.DekalbButton_CheckedChanged);
            // 
            // sycamoreRadioButton
            // 
            this.sycamoreRadioButton.AutoSize = true;
            this.sycamoreRadioButton.BackColor = System.Drawing.Color.Black;
            this.sycamoreRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.sycamoreRadioButton.ForeColor = System.Drawing.Color.White;
            this.sycamoreRadioButton.Location = new System.Drawing.Point(22, 96);
            this.sycamoreRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sycamoreRadioButton.Name = "sycamoreRadioButton";
            this.sycamoreRadioButton.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.sycamoreRadioButton.Size = new System.Drawing.Size(168, 46);
            this.sycamoreRadioButton.TabIndex = 1;
            this.sycamoreRadioButton.Text = "Sycamore";
            this.sycamoreRadioButton.UseVisualStyleBackColor = false;
            this.sycamoreRadioButton.CheckedChanged += new System.EventHandler(this.SycamoreButton_CheckedChanged);
            // 
            // personLabel
            // 
            this.personLabel.AutoSize = true;
            this.personLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.875F, System.Drawing.FontStyle.Bold);
            this.personLabel.ForeColor = System.Drawing.Color.White;
            this.personLabel.Location = new System.Drawing.Point(805, 33);
            this.personLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.personLabel.Name = "personLabel";
            this.personLabel.Size = new System.Drawing.Size(124, 37);
            this.personLabel.TabIndex = 5;
            this.personLabel.Text = "Person";
            // 
            // residenceLabel
            // 
            this.residenceLabel.AutoSize = true;
            this.residenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.875F, System.Drawing.FontStyle.Bold);
            this.residenceLabel.ForeColor = System.Drawing.Color.White;
            this.residenceLabel.Location = new System.Drawing.Point(1179, 29);
            this.residenceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.residenceLabel.Name = "residenceLabel";
            this.residenceLabel.Size = new System.Drawing.Size(420, 37);
            this.residenceLabel.TabIndex = 6;
            this.residenceLabel.Text = "Residence (* == For Sale )";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dekalbRadioButton);
            this.groupBox1.Controls.Add(this.sycamoreRadioButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(4, 48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(368, 161);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communities";
            // 
            // personListBox
            // 
            this.personListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personListBox.FormattingEnabled = true;
            this.personListBox.ItemHeight = 30;
            this.personListBox.Location = new System.Drawing.Point(813, 81);
            this.personListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.personListBox.Name = "personListBox";
            this.personListBox.Size = new System.Drawing.Size(350, 694);
            this.personListBox.TabIndex = 9;
            this.personListBox.SelectedIndexChanged += new System.EventHandler(this.personSelectionChanged);
            // 
            // residenceListBox
            // 
            this.residenceListBox.FormattingEnabled = true;
            this.residenceListBox.ItemHeight = 25;
            this.residenceListBox.Location = new System.Drawing.Point(1182, 81);
            this.residenceListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.residenceListBox.Name = "residenceListBox";
            this.residenceListBox.Size = new System.Drawing.Size(488, 704);
            this.residenceListBox.TabIndex = 10;
            this.residenceListBox.SelectedIndexChanged += new System.EventHandler(this.residenceSelectionChanged);
            // 
            // outputRichTextBox
            // 
            this.outputRichTextBox.BackColor = System.Drawing.Color.Silver;
            this.outputRichTextBox.Font = new System.Drawing.Font("Arial", 9.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputRichTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.outputRichTextBox.Location = new System.Drawing.Point(3, 913);
            this.outputRichTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.outputRichTextBox.Name = "outputRichTextBox";
            this.outputRichTextBox.Size = new System.Drawing.Size(1638, 248);
            this.outputRichTextBox.TabIndex = 11;
            this.outputRichTextBox.Text = "";
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.875F, System.Drawing.FontStyle.Bold);
            this.outputLabel.ForeColor = System.Drawing.Color.White;
            this.outputLabel.Location = new System.Drawing.Point(5, 866);
            this.outputLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(120, 37);
            this.outputLabel.TabIndex = 12;
            this.outputLabel.Text = "Output";
            // 
            // add_res_groupBox
            // 
            this.add_res_groupBox.Controls.Add(this.residenceComboBox);
            this.add_res_groupBox.Controls.Add(this.addNewResidentButton);
            this.add_res_groupBox.Controls.Add(this.label4);
            this.add_res_groupBox.Controls.Add(this.label3);
            this.add_res_groupBox.Controls.Add(this.occupationTextBox);
            this.add_res_groupBox.Controls.Add(this.label2);
            this.add_res_groupBox.Controls.Add(this.bdayDateTimePicker);
            this.add_res_groupBox.Controls.Add(this.label1);
            this.add_res_groupBox.Controls.Add(this.nameTextBox);
            this.add_res_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_res_groupBox.ForeColor = System.Drawing.Color.White;
            this.add_res_groupBox.Location = new System.Drawing.Point(4, 308);
            this.add_res_groupBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.add_res_groupBox.Name = "add_res_groupBox";
            this.add_res_groupBox.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.add_res_groupBox.Size = new System.Drawing.Size(380, 505);
            this.add_res_groupBox.TabIndex = 13;
            this.add_res_groupBox.TabStop = false;
            this.add_res_groupBox.Text = "Add New Resident";
            // 
            // residenceComboBox
            // 
            this.residenceComboBox.FormattingEnabled = true;
            this.residenceComboBox.Location = new System.Drawing.Point(12, 372);
            this.residenceComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.residenceComboBox.Name = "residenceComboBox";
            this.residenceComboBox.Size = new System.Drawing.Size(336, 45);
            this.residenceComboBox.TabIndex = 9;
            // 
            // addNewResidentButton
            // 
            this.addNewResidentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewResidentButton.ForeColor = System.Drawing.Color.Black;
            this.addNewResidentButton.Location = new System.Drawing.Point(250, 435);
            this.addNewResidentButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addNewResidentButton.Name = "addNewResidentButton";
            this.addNewResidentButton.Size = new System.Drawing.Size(102, 44);
            this.addNewResidentButton.TabIndex = 8;
            this.addNewResidentButton.Text = "Add";
            this.addNewResidentButton.UseVisualStyleBackColor = true;
            this.addNewResidentButton.Click += new System.EventHandler(this.addNewResidentButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 331);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Residence";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Occupation";
            // 
            // occupationTextBox
            // 
            this.occupationTextBox.Location = new System.Drawing.Point(12, 181);
            this.occupationTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.occupationTextBox.Name = "occupationTextBox";
            this.occupationTextBox.Size = new System.Drawing.Size(336, 43);
            this.occupationTextBox.TabIndex = 4;
            this.occupationTextBox.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 244);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Birthday";
            // 
            // bdayDateTimePicker
            // 
            this.bdayDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bdayDateTimePicker.Location = new System.Drawing.Point(12, 281);
            this.bdayDateTimePicker.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.bdayDateTimePicker.Name = "bdayDateTimePicker";
            this.bdayDateTimePicker.Size = new System.Drawing.Size(336, 34);
            this.bdayDateTimePicker.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 96);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(336, 43);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.Tag = "";
            // 
            // add_prop_groupBox
            // 
            this.add_prop_groupBox.Controls.Add(this.addProptButton);
            this.add_prop_groupBox.Controls.Add(this.garageCheckBox);
            this.add_prop_groupBox.Controls.Add(this.label10);
            this.add_prop_groupBox.Controls.Add(this.label9);
            this.add_prop_groupBox.Controls.Add(this.label8);
            this.add_prop_groupBox.Controls.Add(this.floorsUpDown);
            this.add_prop_groupBox.Controls.Add(this.bathUpDown);
            this.add_prop_groupBox.Controls.Add(this.bedrmUpDown);
            this.add_prop_groupBox.Controls.Add(this.label7);
            this.add_prop_groupBox.Controls.Add(this.sqFtUpDown);
            this.add_prop_groupBox.Controls.Add(this.label6);
            this.add_prop_groupBox.Controls.Add(this.label5);
            this.add_prop_groupBox.Controls.Add(this.aptNoTextBox);
            this.add_prop_groupBox.Controls.Add(this.streetAddrTextBox);
            this.add_prop_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_prop_groupBox.ForeColor = System.Drawing.Color.White;
            this.add_prop_groupBox.Location = new System.Drawing.Point(393, 304);
            this.add_prop_groupBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.add_prop_groupBox.Name = "add_prop_groupBox";
            this.add_prop_groupBox.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.add_prop_groupBox.Size = new System.Drawing.Size(401, 509);
            this.add_prop_groupBox.TabIndex = 14;
            this.add_prop_groupBox.TabStop = false;
            this.add_prop_groupBox.Text = "Add Property";
            // 
            // addProptButton
            // 
            this.addProptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addProptButton.ForeColor = System.Drawing.Color.Black;
            this.addProptButton.Location = new System.Drawing.Point(264, 441);
            this.addProptButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addProptButton.Name = "addProptButton";
            this.addProptButton.Size = new System.Drawing.Size(100, 44);
            this.addProptButton.TabIndex = 14;
            this.addProptButton.Text = "Add";
            this.addProptButton.UseVisualStyleBackColor = true;
            this.addProptButton.Click += new System.EventHandler(this.addProptButton_Click);
            // 
            // garageCheckBox
            // 
            this.garageCheckBox.AutoSize = true;
            this.garageCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.garageCheckBox.Location = new System.Drawing.Point(12, 381);
            this.garageCheckBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.garageCheckBox.Name = "garageCheckBox";
            this.garageCheckBox.Size = new System.Drawing.Size(137, 33);
            this.garageCheckBox.TabIndex = 13;
            this.garageCheckBox.Text = "Garage?";
            this.garageCheckBox.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(246, 245);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 29);
            this.label10.TabIndex = 12;
            this.label10.Text = "Floors";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(131, 247);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 29);
            this.label9.TabIndex = 11;
            this.label9.Text = "Baths";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 247);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 29);
            this.label8.TabIndex = 10;
            this.label8.Text = "Bedrooms";
            // 
            // floorsUpDown
            // 
            this.floorsUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.floorsUpDown.Location = new System.Drawing.Point(252, 283);
            this.floorsUpDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.floorsUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.floorsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.floorsUpDown.Name = "floorsUpDown";
            this.floorsUpDown.Size = new System.Drawing.Size(76, 40);
            this.floorsUpDown.TabIndex = 9;
            this.floorsUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bathUpDown
            // 
            this.bathUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bathUpDown.Location = new System.Drawing.Point(136, 283);
            this.bathUpDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            this.bathUpDown.Size = new System.Drawing.Size(72, 40);
            this.bathUpDown.TabIndex = 8;
            this.bathUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bedrmUpDown
            // 
            this.bedrmUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bedrmUpDown.Location = new System.Drawing.Point(12, 282);
            this.bedrmUpDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.bedrmUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.bedrmUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bedrmUpDown.Name = "bedrmUpDown";
            this.bedrmUpDown.Size = new System.Drawing.Size(68, 40);
            this.bedrmUpDown.TabIndex = 7;
            this.bedrmUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 152);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 29);
            this.label7.TabIndex = 6;
            this.label7.Text = "Square Footage";
            // 
            // sqFtUpDown
            // 
            this.sqFtUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sqFtUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sqFtUpDown.Location = new System.Drawing.Point(12, 187);
            this.sqFtUpDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            this.sqFtUpDown.Size = new System.Drawing.Size(130, 40);
            this.sqFtUpDown.TabIndex = 5;
            this.sqFtUpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(277, 57);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 29);
            this.label6.TabIndex = 3;
            this.label6.Text = "Apt. #";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 29);
            this.label5.TabIndex = 2;
            this.label5.Text = "Street Address";
            // 
            // aptNoTextBox
            // 
            this.aptNoTextBox.Location = new System.Drawing.Point(278, 98);
            this.aptNoTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.aptNoTextBox.Name = "aptNoTextBox";
            this.aptNoTextBox.Size = new System.Drawing.Size(52, 43);
            this.aptNoTextBox.TabIndex = 1;
            this.aptNoTextBox.TextChanged += new System.EventHandler(this.aptNoTextBox_TextChanged);
            // 
            // streetAddrTextBox
            // 
            this.streetAddrTextBox.Location = new System.Drawing.Point(12, 98);
            this.streetAddrTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.streetAddrTextBox.Name = "streetAddrTextBox";
            this.streetAddrTextBox.Size = new System.Drawing.Size(250, 43);
            this.streetAddrTextBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1683, 1179);
            this.Controls.Add(this.add_prop_groupBox);
            this.Controls.Add(this.add_res_groupBox);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.outputRichTextBox);
            this.Controls.Add(this.residenceListBox);
            this.Controls.Add(this.personListBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.residenceLabel);
            this.Controls.Add(this.personLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "ASX\' Real Estate Management Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.add_res_groupBox.ResumeLayout(false);
            this.add_res_groupBox.PerformLayout();
            this.add_prop_groupBox.ResumeLayout(false);
            this.add_prop_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.floorsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bathUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedrmUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqFtUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton dekalbRadioButton;
        private System.Windows.Forms.RadioButton sycamoreRadioButton;
        private System.Windows.Forms.Label personLabel;
        private System.Windows.Forms.Label residenceLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox personListBox;
        private System.Windows.Forms.ListBox residenceListBox;
        private System.Windows.Forms.RichTextBox outputRichTextBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.GroupBox add_res_groupBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addNewResidentButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox occupationTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker bdayDateTimePicker;
        private System.Windows.Forms.GroupBox add_prop_groupBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox aptNoTextBox;
        private System.Windows.Forms.TextBox streetAddrTextBox;
        private System.Windows.Forms.Button addProptButton;
        private System.Windows.Forms.CheckBox garageCheckBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown floorsUpDown;
        private System.Windows.Forms.NumericUpDown bathUpDown;
        private System.Windows.Forms.NumericUpDown bedrmUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown sqFtUpDown;
        private System.Windows.Forms.ComboBox residenceComboBox;
    }
}

