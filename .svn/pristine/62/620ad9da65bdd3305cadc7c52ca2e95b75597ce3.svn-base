using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hierarchy_Client
{
    public partial class MaterialNumberValidator : MetroForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MaterialNumberValidator()
        {
            InitializeComponent();
        }

        private void tb_MaterialNumber_KeyUp(object sender, KeyEventArgs e)
        {
            ////enter key has been pressed
            //if (e.KeyCode == Keys.Enter)
            //{
            //    string materialNumber = tb_MaterialNumber.Text;

            //    if(materialNumber == string.Empty) { return; };

            //    //check if its a valid material number
            //    bool isValid = Helper.bGetAndAssignMaterialInfo(materialNumber);

            //    if (isValid)
            //    {
            //        //check if it's a cable kit, then switch to that form instead
            //        var CheckForCableKit = KitInfo.Instance.dsMaterialInfo.Tables["Cables"].Select($"CableKit = '{materialNumber}'");
            //        if (CheckForCableKit.Any())
            //        {
            //            //hide this form
            //            this.Hide();

            //            CableKits ck = new CableKits();
            //            ck.ShowDialog();
            //            return;
            //        }
            //        else
            //        {
            //            //switch to hierarchy form
            //            CreateHierarchy ch = new CreateHierarchy();
            //            ch.ShowDialog();
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show($"{materialNumber}  is not a valid material number");
            //    }

            //}
        }

      

        private void MaterialNumberValidator_Load(object sender, EventArgs e)
        {
           //if(!string.IsNullOrEmpty(KitInfo.Instance.MaterialNumber))
           //{
           //     MessageBox.Show($"Material is NOT empty- {KitInfo.Instance.MaterialNumber}");
           //}
        }


        private void metroButton_Submit_Click(object sender, EventArgs e)
        {


            try
            {
                string materialNumber = tb_MaterialNumber.Text;

                if (materialNumber == string.Empty)
                {
                    MessageBox.Show("Enter material number to continue");
                    return;
                }
                else
                {
                    //check if its a valid material number            
                    DataTable dtTempMaterial = Helper.dtGetMaterialInfoUsingMaterialNumber(materialNumber);

                    if (dtTempMaterial != null && dtTempMaterial.Rows.Count > 0)
                    {
                        //material is valid add it to the Kit info class
                        string _description = dtTempMaterial.Rows[0][2].ToString();

                        KitInfo.Instance.MaterialNumber = materialNumber;
                        KitInfo.Instance.Description = _description;
                    }

                    bool isValid = Helper.bGetAndAssignMaterialInfo(dtTempMaterial);

                    if (isValid)
                    {
                        //log
                        logger.Info($"Material number : {materialNumber}");

                        //hide this form
                        this.Hide();
                        this.Close();

                        //check if it's a cable kit, then switch to that form instead
                        if (KitInfo.Instance.bIsCableKit)

                        {
                            CableKits ck = new CableKits();
                            ck.ShowDialog();
                            return;
                        }
                        else
                        {
                            //switch to hierarchy form
                            CreateHierarchy ch = new CreateHierarchy();
                            ch.ShowDialog();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"{materialNumber}  is not a valid material number");
                    }
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex.StackTrace);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

            //kill all the KitInfo variables that have already been established
            KitInfo.Instance.ClearAll();

            MainMenu mm = new MainMenu();
            mm.ShowDialog();
        }
    }
}
