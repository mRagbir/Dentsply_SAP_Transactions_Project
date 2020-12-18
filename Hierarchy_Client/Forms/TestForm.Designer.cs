namespace Hierarchy_Client
{
    partial class TestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.btn_TestHierarchy = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_SapTestDirect = new System.Windows.Forms.Button();
            this.btn_ExcelTest = new System.Windows.Forms.Button();
            this.btn_TestStoredProcedures = new System.Windows.Forms.Button();
            this.btn_dbTest = new System.Windows.Forms.Button();
            this.dg_TestInfo = new System.Windows.Forms.DataGridView();
            this.btn_TestLogin = new System.Windows.Forms.Button();
            this.btn_Home = new System.Windows.Forms.Button();
            this.label_Version = new System.Windows.Forms.Label();
            this.btn_MaterialCheckFromService = new System.Windows.Forms.Button();
            this.btn_GetSAPInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_TestInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(23, 63);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(170, 78);
            this.metroButton1.TabIndex = 14;
            this.metroButton1.Text = "Test SAP Connection";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // btn_TestHierarchy
            // 
            this.btn_TestHierarchy.Location = new System.Drawing.Point(23, 155);
            this.btn_TestHierarchy.Name = "btn_TestHierarchy";
            this.btn_TestHierarchy.Size = new System.Drawing.Size(170, 78);
            this.btn_TestHierarchy.TabIndex = 15;
            this.btn_TestHierarchy.Text = "Test SAP Hierarchy";
            this.btn_TestHierarchy.UseVisualStyleBackColor = true;
            this.btn_TestHierarchy.Click += new System.EventHandler(this.btn_TestHierarchy_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 78);
            this.button1.TabIndex = 16;
            this.button1.Text = "Reflection Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_SapTestDirect
            // 
            this.btn_SapTestDirect.Location = new System.Drawing.Point(214, 63);
            this.btn_SapTestDirect.Name = "btn_SapTestDirect";
            this.btn_SapTestDirect.Size = new System.Drawing.Size(170, 78);
            this.btn_SapTestDirect.TabIndex = 17;
            this.btn_SapTestDirect.Text = "SAP Test Direct to dll no Proxy";
            this.btn_SapTestDirect.UseVisualStyleBackColor = true;
            this.btn_SapTestDirect.Click += new System.EventHandler(this.btn_SapTestDirect_Click);
            // 
            // btn_ExcelTest
            // 
            this.btn_ExcelTest.Location = new System.Drawing.Point(214, 156);
            this.btn_ExcelTest.Name = "btn_ExcelTest";
            this.btn_ExcelTest.Size = new System.Drawing.Size(170, 78);
            this.btn_ExcelTest.TabIndex = 18;
            this.btn_ExcelTest.Text = "Excel Macro test with params";
            this.btn_ExcelTest.UseVisualStyleBackColor = true;
            this.btn_ExcelTest.Click += new System.EventHandler(this.btn_ExcelTest_Click);
            // 
            // btn_TestStoredProcedures
            // 
            this.btn_TestStoredProcedures.Location = new System.Drawing.Point(214, 259);
            this.btn_TestStoredProcedures.Name = "btn_TestStoredProcedures";
            this.btn_TestStoredProcedures.Size = new System.Drawing.Size(170, 78);
            this.btn_TestStoredProcedures.TabIndex = 19;
            this.btn_TestStoredProcedures.Text = "Test Stored Procedures";
            this.btn_TestStoredProcedures.UseVisualStyleBackColor = true;
            this.btn_TestStoredProcedures.Click += new System.EventHandler(this.btn_TestStoredProcedures_Click);
            // 
            // btn_dbTest
            // 
            this.btn_dbTest.Location = new System.Drawing.Point(414, 62);
            this.btn_dbTest.Name = "btn_dbTest";
            this.btn_dbTest.Size = new System.Drawing.Size(170, 78);
            this.btn_dbTest.TabIndex = 20;
            this.btn_dbTest.Text = "Test material number validation using Proxy";
            this.btn_dbTest.UseVisualStyleBackColor = true;
            this.btn_dbTest.Click += new System.EventHandler(this.btn_dbTest_Click);
            // 
            // dg_TestInfo
            // 
            this.dg_TestInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_TestInfo.Location = new System.Drawing.Point(7, 660);
            this.dg_TestInfo.Name = "dg_TestInfo";
            this.dg_TestInfo.Size = new System.Drawing.Size(1427, 133);
            this.dg_TestInfo.TabIndex = 21;
            // 
            // btn_TestLogin
            // 
            this.btn_TestLogin.Location = new System.Drawing.Point(414, 156);
            this.btn_TestLogin.Name = "btn_TestLogin";
            this.btn_TestLogin.Size = new System.Drawing.Size(170, 78);
            this.btn_TestLogin.TabIndex = 22;
            this.btn_TestLogin.Text = "Test Login";
            this.btn_TestLogin.UseVisualStyleBackColor = true;
            this.btn_TestLogin.Click += new System.EventHandler(this.btn_TestLogin_Click);
            // 
            // btn_Home
            // 
            this.btn_Home.Location = new System.Drawing.Point(1312, 26);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Size = new System.Drawing.Size(106, 52);
            this.btn_Home.TabIndex = 23;
            this.btn_Home.Text = "Home";
            this.btn_Home.UseVisualStyleBackColor = true;
            this.btn_Home.Click += new System.EventHandler(this.btn_Home_Click);
            // 
            // label_Version
            // 
            this.label_Version.AutoSize = true;
            this.label_Version.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label_Version.Location = new System.Drawing.Point(1317, 90);
            this.label_Version.Name = "label_Version";
            this.label_Version.Size = new System.Drawing.Size(90, 19);
            this.label_Version.TabIndex = 35;
            this.label_Version.Text = "Version 1.6";
            // 
            // btn_MaterialCheckFromService
            // 
            this.btn_MaterialCheckFromService.Location = new System.Drawing.Point(627, 62);
            this.btn_MaterialCheckFromService.Name = "btn_MaterialCheckFromService";
            this.btn_MaterialCheckFromService.Size = new System.Drawing.Size(170, 78);
            this.btn_MaterialCheckFromService.TabIndex = 36;
            this.btn_MaterialCheckFromService.Text = "Material check directly from Service";
            this.btn_MaterialCheckFromService.UseVisualStyleBackColor = true;
            this.btn_MaterialCheckFromService.Click += new System.EventHandler(this.btn_MaterialCheckFromService_Click);
            // 
            // btn_GetSAPInfo
            // 
            this.btn_GetSAPInfo.Location = new System.Drawing.Point(414, 259);
            this.btn_GetSAPInfo.Name = "btn_GetSAPInfo";
            this.btn_GetSAPInfo.Size = new System.Drawing.Size(170, 78);
            this.btn_GetSAPInfo.TabIndex = 37;
            this.btn_GetSAPInfo.Text = "Get Sap Hierarchy Info";
            this.btn_GetSAPInfo.UseVisualStyleBackColor = true;
            this.btn_GetSAPInfo.Click += new System.EventHandler(this.btn_GetSAPInfo_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1457, 801);
            this.ControlBox = false;
            this.Controls.Add(this.btn_GetSAPInfo);
            this.Controls.Add(this.btn_MaterialCheckFromService);
            this.Controls.Add(this.label_Version);
            this.Controls.Add(this.btn_Home);
            this.Controls.Add(this.btn_TestLogin);
            this.Controls.Add(this.dg_TestInfo);
            this.Controls.Add(this.btn_dbTest);
            this.Controls.Add(this.btn_TestStoredProcedures);
            this.Controls.Add(this.btn_ExcelTest);
            this.Controls.Add(this.btn_SapTestDirect);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_TestHierarchy);
            this.Controls.Add(this.metroButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Test Form";
            this.Load += new System.EventHandler(this.TestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_TestInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.Button btn_TestHierarchy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_SapTestDirect;
        private System.Windows.Forms.Button btn_ExcelTest;
        private System.Windows.Forms.Button btn_TestStoredProcedures;
        private System.Windows.Forms.Button btn_dbTest;
        private System.Windows.Forms.DataGridView dg_TestInfo;
        private System.Windows.Forms.Button btn_TestLogin;
        private System.Windows.Forms.Button btn_Home;
        private System.Windows.Forms.Label label_Version;
        private System.Windows.Forms.Button btn_MaterialCheckFromService;
        private System.Windows.Forms.Button btn_GetSAPInfo;
    }
}