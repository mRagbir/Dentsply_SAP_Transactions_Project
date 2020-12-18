namespace Hierarchy_Client
{
    partial class CableKits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CableKits));
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_MaterialNumber = new System.Windows.Forms.Label();
            this.gb_Step1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_StorageLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_Step2 = new System.Windows.Forms.GroupBox();
            this.tb_OrderNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gb_Step3 = new System.Windows.Forms.GroupBox();
            this.tb_ScanSerial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gb_Step4 = new System.Windows.Forms.GroupBox();
            this.metroButton_Submit = new MetroFramework.Controls.MetroButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Qty = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_MaterialDescription = new System.Windows.Forms.Label();
            this.metroButton_ClearList = new MetroFramework.Controls.MetroButton();
            this.metroButton_Home = new MetroFramework.Controls.MetroButton();
            this.listbox_Serials1 = new System.Windows.Forms.ListBox();
            this.label_Version = new System.Windows.Forms.Label();
            this.gb_Step1.SuspendLayout();
            this.gb_Step2.SuspendLayout();
            this.gb_Step3.SuspendLayout();
            this.gb_Step4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kit Part Number :";
            // 
            // lbl_MaterialNumber
            // 
            this.lbl_MaterialNumber.AutoSize = true;
            this.lbl_MaterialNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaterialNumber.Location = new System.Drawing.Point(148, 30);
            this.lbl_MaterialNumber.Name = "lbl_MaterialNumber";
            this.lbl_MaterialNumber.Size = new System.Drawing.Size(104, 19);
            this.lbl_MaterialNumber.TabIndex = 1;
            this.lbl_MaterialNumber.Text = "placeholder";
            // 
            // gb_Step1
            // 
            this.gb_Step1.Controls.Add(this.label7);
            this.gb_Step1.Controls.Add(this.tb_StorageLocation);
            this.gb_Step1.Controls.Add(this.label2);
            this.gb_Step1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Step1.ForeColor = System.Drawing.Color.Red;
            this.gb_Step1.Location = new System.Drawing.Point(12, 84);
            this.gb_Step1.Name = "gb_Step1";
            this.gb_Step1.Size = new System.Drawing.Size(324, 134);
            this.gb_Step1.TabIndex = 2;
            this.gb_Step1.TabStop = false;
            this.gb_Step1.Text = "Step 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(65, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Default location : FG-S11";
            // 
            // tb_StorageLocation
            // 
            this.tb_StorageLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_StorageLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_StorageLocation.Location = new System.Drawing.Point(43, 69);
            this.tb_StorageLocation.Name = "tb_StorageLocation";
            this.tb_StorageLocation.Size = new System.Drawing.Size(200, 27);
            this.tb_StorageLocation.TabIndex = 1;
            this.tb_StorageLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_StorageLocation.TextChanged += new System.EventHandler(this.tb_StorageLocation_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(69, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Storage Location";
            // 
            // gb_Step2
            // 
            this.gb_Step2.Controls.Add(this.tb_OrderNumber);
            this.gb_Step2.Controls.Add(this.label3);
            this.gb_Step2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Step2.ForeColor = System.Drawing.Color.Red;
            this.gb_Step2.Location = new System.Drawing.Point(12, 247);
            this.gb_Step2.Name = "gb_Step2";
            this.gb_Step2.Size = new System.Drawing.Size(324, 141);
            this.gb_Step2.TabIndex = 3;
            this.gb_Step2.TabStop = false;
            this.gb_Step2.Text = "Step 2";
            // 
            // tb_OrderNumber
            // 
            this.tb_OrderNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_OrderNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_OrderNumber.Location = new System.Drawing.Point(43, 80);
            this.tb_OrderNumber.Name = "tb_OrderNumber";
            this.tb_OrderNumber.Size = new System.Drawing.Size(200, 27);
            this.tb_OrderNumber.TabIndex = 1;
            this.tb_OrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_OrderNumber.TextChanged += new System.EventHandler(this.tb_OrderNumber_TextChanged);
            this.tb_OrderNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_OrderNumber_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(69, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Order Number";
            // 
            // gb_Step3
            // 
            this.gb_Step3.Controls.Add(this.tb_ScanSerial);
            this.gb_Step3.Controls.Add(this.label4);
            this.gb_Step3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Step3.ForeColor = System.Drawing.Color.Red;
            this.gb_Step3.Location = new System.Drawing.Point(16, 425);
            this.gb_Step3.Name = "gb_Step3";
            this.gb_Step3.Size = new System.Drawing.Size(320, 187);
            this.gb_Step3.TabIndex = 4;
            this.gb_Step3.TabStop = false;
            this.gb_Step3.Text = "Step 3";
            // 
            // tb_ScanSerial
            // 
            this.tb_ScanSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_ScanSerial.Location = new System.Drawing.Point(39, 93);
            this.tb_ScanSerial.Name = "tb_ScanSerial";
            this.tb_ScanSerial.Size = new System.Drawing.Size(200, 27);
            this.tb_ScanSerial.TabIndex = 1;
            this.tb_ScanSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ScanSerial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_ScanSerial_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(69, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Scan each cable";
            // 
            // gb_Step4
            // 
            this.gb_Step4.Controls.Add(this.metroButton_Submit);
            this.gb_Step4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Step4.ForeColor = System.Drawing.Color.Red;
            this.gb_Step4.Location = new System.Drawing.Point(16, 618);
            this.gb_Step4.Name = "gb_Step4";
            this.gb_Step4.Size = new System.Drawing.Size(320, 140);
            this.gb_Step4.TabIndex = 5;
            this.gb_Step4.TabStop = false;
            this.gb_Step4.Text = "Step 4";
            // 
            // metroButton_Submit
            // 
            this.metroButton_Submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.metroButton_Submit.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton_Submit.ForeColor = System.Drawing.Color.Black;
            this.metroButton_Submit.Location = new System.Drawing.Point(42, 43);
            this.metroButton_Submit.Name = "metroButton_Submit";
            this.metroButton_Submit.Size = new System.Drawing.Size(240, 68);
            this.metroButton_Submit.TabIndex = 14;
            this.metroButton_Submit.Text = "Submit";
            this.metroButton_Submit.UseCustomBackColor = true;
            this.metroButton_Submit.UseCustomForeColor = true;
            this.metroButton_Submit.UseSelectable = true;
            this.metroButton_Submit.Click += new System.EventHandler(this.metroButton_Submit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(395, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "List of scanned serials";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(615, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "QTY";
            // 
            // tb_Qty
            // 
            this.tb_Qty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_Qty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tb_Qty.Location = new System.Drawing.Point(587, 239);
            this.tb_Qty.Name = "tb_Qty";
            this.tb_Qty.Size = new System.Drawing.Size(100, 27);
            this.tb_Qty.TabIndex = 9;
            this.tb_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(690, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 86);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_MaterialDescription
            // 
            this.lbl_MaterialDescription.AutoSize = true;
            this.lbl_MaterialDescription.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaterialDescription.Location = new System.Drawing.Point(261, 30);
            this.lbl_MaterialDescription.Name = "lbl_MaterialDescription";
            this.lbl_MaterialDescription.Size = new System.Drawing.Size(114, 19);
            this.lbl_MaterialDescription.TabIndex = 13;
            this.lbl_MaterialDescription.Text = "placeholder2";
            // 
            // metroButton_ClearList
            // 
            this.metroButton_ClearList.Location = new System.Drawing.Point(587, 584);
            this.metroButton_ClearList.Name = "metroButton_ClearList";
            this.metroButton_ClearList.Size = new System.Drawing.Size(106, 56);
            this.metroButton_ClearList.TabIndex = 14;
            this.metroButton_ClearList.Text = "Clear Serial List";
            this.metroButton_ClearList.UseSelectable = true;
            this.metroButton_ClearList.Click += new System.EventHandler(this.metroButton_ClearList_Click);
            // 
            // metroButton_Home
            // 
            this.metroButton_Home.Location = new System.Drawing.Point(587, 673);
            this.metroButton_Home.Name = "metroButton_Home";
            this.metroButton_Home.Size = new System.Drawing.Size(106, 56);
            this.metroButton_Home.TabIndex = 15;
            this.metroButton_Home.Text = "Home";
            this.metroButton_Home.UseSelectable = true;
            this.metroButton_Home.Click += new System.EventHandler(this.metroButton_Home_Click);
            // 
            // listbox_Serials1
            // 
            this.listbox_Serials1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.listbox_Serials1.ItemHeight = 19;
            this.listbox_Serials1.Location = new System.Drawing.Point(399, 153);
            this.listbox_Serials1.Name = "listbox_Serials1";
            this.listbox_Serials1.Size = new System.Drawing.Size(153, 593);
            this.listbox_Serials1.TabIndex = 17;
            // 
            // label_Version
            // 
            this.label_Version.AutoSize = true;
            this.label_Version.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label_Version.Location = new System.Drawing.Point(731, 755);
            this.label_Version.Name = "label_Version";
            this.label_Version.Size = new System.Drawing.Size(90, 19);
            this.label_Version.TabIndex = 18;
            this.label_Version.Text = "Version 1.6";
            // 
            // CableKits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 794);
            this.ControlBox = false;
            this.Controls.Add(this.label_Version);
            this.Controls.Add(this.metroButton_Home);
            this.Controls.Add(this.metroButton_ClearList);
            this.Controls.Add(this.lbl_MaterialDescription);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tb_Qty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listbox_Serials1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gb_Step4);
            this.Controls.Add(this.gb_Step3);
            this.Controls.Add(this.gb_Step2);
            this.Controls.Add(this.gb_Step1);
            this.Controls.Add(this.lbl_MaterialNumber);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CableKits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.CableKits_Load);
            this.gb_Step1.ResumeLayout(false);
            this.gb_Step1.PerformLayout();
            this.gb_Step2.ResumeLayout(false);
            this.gb_Step2.PerformLayout();
            this.gb_Step3.ResumeLayout(false);
            this.gb_Step3.PerformLayout();
            this.gb_Step4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_MaterialNumber;
        private System.Windows.Forms.GroupBox gb_Step1;
        private System.Windows.Forms.TextBox tb_StorageLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb_Step2;
        private System.Windows.Forms.TextBox tb_OrderNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gb_Step3;
        private System.Windows.Forms.TextBox tb_ScanSerial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gb_Step4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Qty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_MaterialDescription;
        private MetroFramework.Controls.MetroButton metroButton_Submit;
        private MetroFramework.Controls.MetroButton metroButton_ClearList;
        private MetroFramework.Controls.MetroButton metroButton_Home;
        private System.Windows.Forms.ListBox listbox_Serials1;
        private System.Windows.Forms.Label label_Version;
    }
}