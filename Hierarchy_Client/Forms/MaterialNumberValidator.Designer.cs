namespace Hierarchy_Client
{
    partial class MaterialNumberValidator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialNumberValidator));
            this.tb_MaterialNumber = new System.Windows.Forms.TextBox();
            this.metroButton_Submit = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Home = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_MaterialNumber
            // 
            this.tb_MaterialNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tb_MaterialNumber.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_MaterialNumber.Location = new System.Drawing.Point(122, 104);
            this.tb_MaterialNumber.Name = "tb_MaterialNumber";
            this.tb_MaterialNumber.Size = new System.Drawing.Size(252, 27);
            this.tb_MaterialNumber.TabIndex = 0;
            this.tb_MaterialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_MaterialNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_MaterialNumber_KeyUp);
            // 
            // metroButton_Submit
            // 
            this.metroButton_Submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.metroButton_Submit.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton_Submit.Location = new System.Drawing.Point(122, 171);
            this.metroButton_Submit.Name = "metroButton_Submit";
            this.metroButton_Submit.Size = new System.Drawing.Size(252, 52);
            this.metroButton_Submit.TabIndex = 3;
            this.metroButton_Submit.Text = "Submit";
            this.metroButton_Submit.UseCustomBackColor = true;
            this.metroButton_Submit.UseSelectable = true;
            this.metroButton_Submit.Click += new System.EventHandler(this.metroButton_Submit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(463, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 81);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Home
            // 
            this.btn_Home.Location = new System.Drawing.Point(503, 258);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Size = new System.Drawing.Size(99, 49);
            this.btn_Home.TabIndex = 8;
            this.btn_Home.Text = "Home";
            this.btn_Home.UseVisualStyleBackColor = true;
            this.btn_Home.Click += new System.EventHandler(this.btn_Home_Click);
            // 
            // MaterialNumberValidator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 330);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Home);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroButton_Submit);
            this.Controls.Add(this.tb_MaterialNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MaterialNumberValidator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scan or type Material Number ";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MaterialNumberValidator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_MaterialNumber;
        private MetroFramework.Controls.MetroButton metroButton_Submit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Home;
    }
}