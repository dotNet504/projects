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
            this.addRes_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.occupation_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.new_nameTextBox = new System.Windows.Forms.TextBox();
            this.add_prop_groupBox = new System.Windows.Forms.GroupBox();
            this.addProp_button = new System.Windows.Forms.Button();
            this.garage = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.floors_upDown = new System.Windows.Forms.NumericUpDown();
            this.bath_upDown = new System.Windows.Forms.NumericUpDown();
            this.bedrm_upDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.sqFt_textBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.aptNo_textBox = new System.Windows.Forms.TextBox();
            this.streetAdd_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.add_res_groupBox.SuspendLayout();
            this.add_prop_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.floors_upDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bath_upDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedrm_upDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqFt_textBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dekalbRadioButton
            // 
            this.dekalbRadioButton.AutoSize = true;
            this.dekalbRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.dekalbRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
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
            this.sycamoreRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.sycamoreRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
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
            this.personLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Bold);
            this.personLabel.Location = new System.Drawing.Point(744, 25);
            this.personLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.personLabel.Name = "personLabel";
            this.personLabel.Size = new System.Drawing.Size(106, 31);
            this.personLabel.TabIndex = 5;
            this.personLabel.Text = "Person";
            // 
            // residenceLabel
            // 
            this.residenceLabel.AutoSize = true;
            this.residenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Bold);
            this.residenceLabel.Location = new System.Drawing.Point(1154, 25);
            this.residenceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.residenceLabel.Name = "residenceLabel";
            this.residenceLabel.Size = new System.Drawing.Size(360, 31);
            this.residenceLabel.TabIndex = 6;
            this.residenceLabel.Text = "Residence (* == For Sale )";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dekalbRadioButton);
            this.groupBox1.Controls.Add(this.sycamoreRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(4, 48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(282, 150);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communities";
            // 
            // personListBox
            // 
            this.personListBox.FormattingEnabled = true;
            this.personListBox.ItemHeight = 25;
            this.personListBox.Location = new System.Drawing.Point(750, 81);
            this.personListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.personListBox.Name = "personListBox";
            this.personListBox.Size = new System.Drawing.Size(398, 629);
            this.personListBox.TabIndex = 9;
            this.personListBox.SelectedIndexChanged += new System.EventHandler(this.personSelectionChanged);
            // 
            // residenceListBox
            // 
            this.residenceListBox.FormattingEnabled = true;
            this.residenceListBox.ItemHeight = 25;
            this.residenceListBox.Location = new System.Drawing.Point(1160, 81);
            this.residenceListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.residenceListBox.Name = "residenceListBox";
            this.residenceListBox.Size = new System.Drawing.Size(378, 629);
            this.residenceListBox.TabIndex = 10;
            this.residenceListBox.SelectedIndexChanged += new System.EventHandler(this.residenceSelectionChanged);
            // 
            // outputRichTextBox
            // 
            this.outputRichTextBox.Font = new System.Drawing.Font("Arial", 9.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputRichTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.outputRichTextBox.Location = new System.Drawing.Point(62, 844);
            this.outputRichTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.outputRichTextBox.Name = "outputRichTextBox";
            this.outputRichTextBox.Size = new System.Drawing.Size(1424, 177);
            this.outputRichTextBox.TabIndex = 11;
            this.outputRichTextBox.Text = "";
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Bold);
            this.outputLabel.Location = new System.Drawing.Point(68, 794);
            this.outputLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(102, 31);
            this.outputLabel.TabIndex = 12;
            this.outputLabel.Text = "Output";
            // 
            // add_res_groupBox
            // 
            this.add_res_groupBox.Controls.Add(this.addRes_button);
            this.add_res_groupBox.Controls.Add(this.label4);
            this.add_res_groupBox.Controls.Add(this.label3);
            this.add_res_groupBox.Controls.Add(this.occupation_textBox);
            this.add_res_groupBox.Controls.Add(this.label2);
            this.add_res_groupBox.Controls.Add(this.dateTimePicker1);
            this.add_res_groupBox.Controls.Add(this.label1);
            this.add_res_groupBox.Controls.Add(this.new_nameTextBox);
            this.add_res_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_res_groupBox.Location = new System.Drawing.Point(4, 308);
            this.add_res_groupBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.add_res_groupBox.Name = "add_res_groupBox";
            this.add_res_groupBox.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.add_res_groupBox.Size = new System.Drawing.Size(364, 406);
            this.add_res_groupBox.TabIndex = 13;
            this.add_res_groupBox.TabStop = false;
            this.add_res_groupBox.Text = "Add New Resident";
            // 
            // addRes_button
            // 
            this.addRes_button.Location = new System.Drawing.Point(250, 350);
            this.addRes_button.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addRes_button.Name = "addRes_button";
            this.addRes_button.Size = new System.Drawing.Size(102, 44);
            this.addRes_button.TabIndex = 8;
            this.addRes_button.Text = "Add";
            this.addRes_button.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 256);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Residence";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Occupation";
            // 
            // occupation_textBox
            // 
            this.occupation_textBox.Location = new System.Drawing.Point(12, 137);
            this.occupation_textBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.occupation_textBox.Name = "occupation_textBox";
            this.occupation_textBox.Size = new System.Drawing.Size(336, 32);
            this.occupation_textBox.TabIndex = 4;
            this.occupation_textBox.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Birthday";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 212);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(336, 32);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // new_nameTextBox
            // 
            this.new_nameTextBox.Location = new System.Drawing.Point(12, 60);
            this.new_nameTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.new_nameTextBox.Name = "new_nameTextBox";
            this.new_nameTextBox.Size = new System.Drawing.Size(336, 32);
            this.new_nameTextBox.TabIndex = 0;
            this.new_nameTextBox.Tag = "";
            // 
            // add_prop_groupBox
            // 
            this.add_prop_groupBox.Controls.Add(this.addProp_button);
            this.add_prop_groupBox.Controls.Add(this.garage);
            this.add_prop_groupBox.Controls.Add(this.label10);
            this.add_prop_groupBox.Controls.Add(this.label9);
            this.add_prop_groupBox.Controls.Add(this.label8);
            this.add_prop_groupBox.Controls.Add(this.floors_upDown);
            this.add_prop_groupBox.Controls.Add(this.bath_upDown);
            this.add_prop_groupBox.Controls.Add(this.bedrm_upDown);
            this.add_prop_groupBox.Controls.Add(this.label7);
            this.add_prop_groupBox.Controls.Add(this.sqFt_textBox);
            this.add_prop_groupBox.Controls.Add(this.label6);
            this.add_prop_groupBox.Controls.Add(this.label5);
            this.add_prop_groupBox.Controls.Add(this.aptNo_textBox);
            this.add_prop_groupBox.Controls.Add(this.streetAdd_textBox);
            this.add_prop_groupBox.Location = new System.Drawing.Point(380, 304);
            this.add_prop_groupBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.add_prop_groupBox.Name = "add_prop_groupBox";
            this.add_prop_groupBox.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.add_prop_groupBox.Size = new System.Drawing.Size(346, 408);
            this.add_prop_groupBox.TabIndex = 14;
            this.add_prop_groupBox.TabStop = false;
            this.add_prop_groupBox.Text = "Add Property";
            // 
            // addProp_button
            // 
            this.addProp_button.Location = new System.Drawing.Point(228, 354);
            this.addProp_button.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addProp_button.Name = "addProp_button";
            this.addProp_button.Size = new System.Drawing.Size(100, 44);
            this.addProp_button.TabIndex = 14;
            this.addProp_button.Text = "Add";
            this.addProp_button.UseVisualStyleBackColor = true;
            // 
            // garage
            // 
            this.garage.AutoSize = true;
            this.garage.Location = new System.Drawing.Point(12, 263);
            this.garage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.garage.Name = "garage";
            this.garage.Size = new System.Drawing.Size(127, 29);
            this.garage.TabIndex = 13;
            this.garage.Text = "Garage?";
            this.garage.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(246, 185);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 25);
            this.label10.TabIndex = 12;
            this.label10.Text = "Floors";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(122, 185);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 25);
            this.label9.TabIndex = 11;
            this.label9.Text = "Baths";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 183);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "Bedrooms";
            // 
            // floors_upDown
            // 
            this.floors_upDown.Location = new System.Drawing.Point(252, 215);
            this.floors_upDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.floors_upDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.floors_upDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.floors_upDown.Name = "floors_upDown";
            this.floors_upDown.Size = new System.Drawing.Size(76, 31);
            this.floors_upDown.TabIndex = 9;
            this.floors_upDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bath_upDown
            // 
            this.bath_upDown.Location = new System.Drawing.Point(128, 213);
            this.bath_upDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.bath_upDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.bath_upDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bath_upDown.Name = "bath_upDown";
            this.bath_upDown.Size = new System.Drawing.Size(72, 31);
            this.bath_upDown.TabIndex = 8;
            this.bath_upDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bedrm_upDown
            // 
            this.bedrm_upDown.Location = new System.Drawing.Point(12, 213);
            this.bedrm_upDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.bedrm_upDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.bedrm_upDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bedrm_upDown.Name = "bedrm_upDown";
            this.bedrm_upDown.Size = new System.Drawing.Size(68, 31);
            this.bedrm_upDown.TabIndex = 7;
            this.bedrm_upDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 110);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Square Footage";
            // 
            // sqFt_textBox
            // 
            this.sqFt_textBox.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.sqFt_textBox.Location = new System.Drawing.Point(12, 140);
            this.sqFt_textBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.sqFt_textBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.sqFt_textBox.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.sqFt_textBox.Name = "sqFt_textBox";
            this.sqFt_textBox.Size = new System.Drawing.Size(146, 31);
            this.sqFt_textBox.TabIndex = 5;
            this.sqFt_textBox.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 25);
            this.label6.TabIndex = 3;
            this.label6.Text = "Apt. #";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Street Address";
            // 
            // aptNo_textBox
            // 
            this.aptNo_textBox.Location = new System.Drawing.Point(278, 63);
            this.aptNo_textBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.aptNo_textBox.Name = "aptNo_textBox";
            this.aptNo_textBox.Size = new System.Drawing.Size(52, 31);
            this.aptNo_textBox.TabIndex = 1;
            // 
            // streetAdd_textBox
            // 
            this.streetAdd_textBox.Location = new System.Drawing.Point(12, 63);
            this.streetAdd_textBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.streetAdd_textBox.Name = "streetAdd_textBox";
            this.streetAdd_textBox.Size = new System.Drawing.Size(250, 31);
            this.streetAdd_textBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1564, 1131);
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
            ((System.ComponentModel.ISupportInitialize)(this.floors_upDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bath_upDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bedrm_upDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqFt_textBox)).EndInit();
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
        private System.Windows.Forms.TextBox new_nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addRes_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox occupation_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox add_prop_groupBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox aptNo_textBox;
        private System.Windows.Forms.TextBox streetAdd_textBox;
        private System.Windows.Forms.Button addProp_button;
        private System.Windows.Forms.CheckBox garage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown floors_upDown;
        private System.Windows.Forms.NumericUpDown bath_upDown;
        private System.Windows.Forms.NumericUpDown bedrm_upDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown sqFt_textBox;
    }
}

