namespace Hierarchy_Client.SAP_Barcode_Form
{
    partial class Parse_UDI_Barcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Parse_UDI_Barcode));
            this.btn_clear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_TypeOfMaterial = new System.Windows.Forms.ComboBox();
            this.btn_PerformCopy = new System.Windows.Forms.Button();
            this.lbl_Qty = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_Serials = new System.Windows.Forms.ListBox();
            this.tb_Barcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SAPSerials = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_OrderNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_PickLocation = new System.Windows.Forms.TextBox();
            this.checkBox_Remotes = new System.Windows.Forms.CheckBox();
            this.checkBox_Sensors = new System.Windows.Forms.CheckBox();
            this.btn_Home = new System.Windows.Forms.Button();
            this.label_Version = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Location = new System.Drawing.Point(416, 455);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(143, 42);
            this.btn_clear.TabIndex = 17;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Material Type";
            // 
            // cb_TypeOfMaterial
            // 
            this.cb_TypeOfMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_TypeOfMaterial.FormattingEnabled = true;
            this.cb_TypeOfMaterial.Items.AddRange(new object[] {
            "SENSOR",
            "REMOTE"});
            this.cb_TypeOfMaterial.Location = new System.Drawing.Point(167, 184);
            this.cb_TypeOfMaterial.Name = "cb_TypeOfMaterial";
            this.cb_TypeOfMaterial.Size = new System.Drawing.Size(392, 28);
            this.cb_TypeOfMaterial.TabIndex = 15;
            // 
            // btn_PerformCopy
            // 
            this.btn_PerformCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_PerformCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_PerformCopy.Location = new System.Drawing.Point(416, 307);
            this.btn_PerformCopy.Name = "btn_PerformCopy";
            this.btn_PerformCopy.Size = new System.Drawing.Size(143, 111);
            this.btn_PerformCopy.TabIndex = 14;
            this.btn_PerformCopy.Text = "Perform Copy";
            this.btn_PerformCopy.UseVisualStyleBackColor = false;
            this.btn_PerformCopy.Click += new System.EventHandler(this.btn_PerformCopy_Click_1);
            // 
            // lbl_Qty
            // 
            this.lbl_Qty.AutoSize = true;
            this.lbl_Qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Qty.Location = new System.Drawing.Point(206, 593);
            this.lbl_Qty.Name = "lbl_Qty";
            this.lbl_Qty.Size = new System.Drawing.Size(17, 18);
            this.lbl_Qty.TabIndex = 13;
            this.lbl_Qty.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 596);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "QTY :";
            // 
            // lb_Serials
            // 
            this.lb_Serials.FormattingEnabled = true;
            this.lb_Serials.Location = new System.Drawing.Point(164, 283);
            this.lb_Serials.Name = "lb_Serials";
            this.lb_Serials.Size = new System.Drawing.Size(194, 264);
            this.lb_Serials.TabIndex = 11;
            // 
            // tb_Barcode
            // 
            this.tb_Barcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Barcode.Location = new System.Drawing.Point(164, 236);
            this.tb_Barcode.Name = "tb_Barcode";
            this.tb_Barcode.Size = new System.Drawing.Size(395, 24);
            this.tb_Barcode.TabIndex = 10;
            this.tb_Barcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_Barcode_KeyUp_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Scan Barcode";
            // 
            // btn_SAPSerials
            // 
            this.btn_SAPSerials.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_SAPSerials.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SAPSerials.Location = new System.Drawing.Point(416, 565);
            this.btn_SAPSerials.Name = "btn_SAPSerials";
            this.btn_SAPSerials.Size = new System.Drawing.Size(143, 162);
            this.btn_SAPSerials.TabIndex = 18;
            this.btn_SAPSerials.Text = "Perform Migo GI";
            this.btn_SAPSerials.UseVisualStyleBackColor = false;
            this.btn_SAPSerials.Click += new System.EventHandler(this.btn_SAPSerials_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Order Number";
            // 
            // tb_OrderNumber
            // 
            this.tb_OrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_OrderNumber.Location = new System.Drawing.Point(164, 97);
            this.tb_OrderNumber.Name = "tb_OrderNumber";
            this.tb_OrderNumber.Size = new System.Drawing.Size(395, 24);
            this.tb_OrderNumber.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Pick Location";
            // 
            // tb_PickLocation
            // 
            this.tb_PickLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_PickLocation.Location = new System.Drawing.Point(164, 145);
            this.tb_PickLocation.Name = "tb_PickLocation";
            this.tb_PickLocation.Size = new System.Drawing.Size(395, 22);
            this.tb_PickLocation.TabIndex = 22;
            // 
            // checkBox_Remotes
            // 
            this.checkBox_Remotes.AutoSize = true;
            this.checkBox_Remotes.Location = new System.Drawing.Point(613, 159);
            this.checkBox_Remotes.Name = "checkBox_Remotes";
            this.checkBox_Remotes.Size = new System.Drawing.Size(115, 17);
            this.checkBox_Remotes.TabIndex = 23;
            this.checkBox_Remotes.Text = "Remotes Complete";
            this.checkBox_Remotes.UseVisualStyleBackColor = true;
            // 
            // checkBox_Sensors
            // 
            this.checkBox_Sensors.AutoSize = true;
            this.checkBox_Sensors.Location = new System.Drawing.Point(613, 194);
            this.checkBox_Sensors.Name = "checkBox_Sensors";
            this.checkBox_Sensors.Size = new System.Drawing.Size(111, 17);
            this.checkBox_Sensors.TabIndex = 24;
            this.checkBox_Sensors.Text = "Sensors Complete";
            this.checkBox_Sensors.UseVisualStyleBackColor = true;
            // 
            // btn_Home
            // 
            this.btn_Home.Location = new System.Drawing.Point(613, 455);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Size = new System.Drawing.Size(143, 42);
            this.btn_Home.TabIndex = 25;
            this.btn_Home.Text = "Home";
            this.btn_Home.UseVisualStyleBackColor = true;
            this.btn_Home.Click += new System.EventHandler(this.btn_Home_Click);
            // 
            // label_Version
            // 
            this.label_Version.AutoSize = true;
            this.label_Version.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label_Version.Location = new System.Drawing.Point(700, 754);
            this.label_Version.Name = "label_Version";
            this.label_Version.Size = new System.Drawing.Size(90, 19);
            this.label_Version.TabIndex = 35;
            this.label_Version.Text = "Version 1.6";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(651, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 77);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // Parse_UDI_Barcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 793);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_Version);
            this.Controls.Add(this.btn_Home);
            this.Controls.Add(this.checkBox_Sensors);
            this.Controls.Add(this.checkBox_Remotes);
            this.Controls.Add(this.tb_PickLocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_OrderNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_SAPSerials);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_TypeOfMaterial);
            this.Controls.Add(this.btn_PerformCopy);
            this.Controls.Add(this.lbl_Qty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_Serials);
            this.Controls.Add(this.tb_Barcode);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Parse_UDI_Barcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Parse_UDI_Barcode";
            this.Load += new System.EventHandler(this.Parse_UDI_Barcode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_TypeOfMaterial;
        private System.Windows.Forms.Button btn_PerformCopy;
        protected System.Windows.Forms.Label lbl_Qty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lb_Serials;
        private System.Windows.Forms.TextBox tb_Barcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SAPSerials;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_OrderNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_PickLocation;
        private System.Windows.Forms.CheckBox checkBox_Remotes;
        private System.Windows.Forms.CheckBox checkBox_Sensors;
        private System.Windows.Forms.Button btn_Home;
        private System.Windows.Forms.Label label_Version;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}