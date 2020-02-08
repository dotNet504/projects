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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dekalbRadioButton
            // 
            this.dekalbRadioButton.AutoSize = true;
            this.dekalbRadioButton.BackColor = System.Drawing.SystemColors.Control;
            this.dekalbRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dekalbRadioButton.Location = new System.Drawing.Point(22, 46);
            this.dekalbRadioButton.Name = "dekalbRadioButton";
            this.dekalbRadioButton.Padding = new System.Windows.Forms.Padding(5);
            this.dekalbRadioButton.Size = new System.Drawing.Size(134, 44);
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
            this.sycamoreRadioButton.Name = "sycamoreRadioButton";
            this.sycamoreRadioButton.Padding = new System.Windows.Forms.Padding(5);
            this.sycamoreRadioButton.Size = new System.Drawing.Size(170, 44);
            this.sycamoreRadioButton.TabIndex = 1;
            this.sycamoreRadioButton.Text = "Sycamore";
            this.sycamoreRadioButton.UseVisualStyleBackColor = false;
            this.sycamoreRadioButton.CheckedChanged += new System.EventHandler(this.SycamoreButton_CheckedChanged);
            // 
            // personLabel
            // 
            this.personLabel.AutoSize = true;
            this.personLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Bold);
            this.personLabel.Location = new System.Drawing.Point(599, 25);
            this.personLabel.Name = "personLabel";
            this.personLabel.Size = new System.Drawing.Size(106, 31);
            this.personLabel.TabIndex = 5;
            this.personLabel.Text = "Person";
            // 
            // residenceLabel
            // 
            this.residenceLabel.AutoSize = true;
            this.residenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Bold);
            this.residenceLabel.Location = new System.Drawing.Point(1055, 25);
            this.residenceLabel.Name = "residenceLabel";
            this.residenceLabel.Size = new System.Drawing.Size(360, 31);
            this.residenceLabel.TabIndex = 6;
            this.residenceLabel.Text = "Residence (* == For Sale )";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dekalbRadioButton);
            this.groupBox1.Controls.Add(this.sycamoreRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(40, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 183);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communities";
            // 
            // personListBox
            // 
            this.personListBox.FormattingEnabled = true;
            this.personListBox.ItemHeight = 25;
            this.personListBox.Location = new System.Drawing.Point(598, 80);
            this.personListBox.Name = "personListBox";
            this.personListBox.Size = new System.Drawing.Size(420, 629);
            this.personListBox.TabIndex = 9;
            this.personListBox.SelectedIndexChanged += new System.EventHandler(this.personSelectionChanged);
            // 
            // residenceListBox
            // 
            this.residenceListBox.FormattingEnabled = true;
            this.residenceListBox.ItemHeight = 25;
            this.residenceListBox.Location = new System.Drawing.Point(1066, 80);
            this.residenceListBox.Name = "residenceListBox";
            this.residenceListBox.Size = new System.Drawing.Size(428, 629);
            this.residenceListBox.TabIndex = 10;
            this.residenceListBox.SelectedIndexChanged += new System.EventHandler(this.residenceSelectionChanged);
            // 
            // outputRichTextBox
            // 
            this.outputRichTextBox.Font = new System.Drawing.Font("Arial", 9.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputRichTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.outputRichTextBox.Location = new System.Drawing.Point(62, 844);
            this.outputRichTextBox.Name = "outputRichTextBox";
            this.outputRichTextBox.Size = new System.Drawing.Size(1423, 178);
            this.outputRichTextBox.TabIndex = 11;
            this.outputRichTextBox.Text = "";
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.875F, System.Drawing.FontStyle.Bold);
            this.outputLabel.Location = new System.Drawing.Point(68, 795);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(102, 31);
            this.outputLabel.TabIndex = 12;
            this.outputLabel.Text = "Output";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1561, 1171);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.outputRichTextBox);
            this.Controls.Add(this.residenceListBox);
            this.Controls.Add(this.personListBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.residenceLabel);
            this.Controls.Add(this.personLabel);
            this.Name = "Form1";
            this.Text = "ASX\' Real Estate Management Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}

