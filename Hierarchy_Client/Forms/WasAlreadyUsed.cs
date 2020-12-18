using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hierarchy_Client
{
    public partial class WasAlreadyUsed : MetroForm
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public WasAlreadyUsed()
        {
            InitializeComponent();
        }

        private void WasAlreadyUsed_Load(object sender, EventArgs e)
        {

            //label
            lbl_ErrorMessage.Text = KitInfo.Instance.ErrorDescription;

            //data grid source
            dg_MaterialInfo.DataSource = KitInfo.Instance.dsSerialUsed.Tables[0];
            dg_MaterialInfo.AutoResizeColumns();

            //hide 2nd groupbox
            if (KitInfo.Instance.bKitSerialDuplicate)
            {
                gb_Bypass.Visible = false;
                gb_YesNo.Visible = false;
                gb_DuplicateKitFound.Visible = true;
                
            }


            //get app version from appconfig and display on form
            label_Version.Text = $"Version {ConfigurationManager.AppSettings["Version"].ToString()}";
        }

        private void btn_YES_Click(object sender, EventArgs e)
        {
            try
            {
                //get the original material number already used


                // var colPosition = KitInfo.Instance.dsSerialUsed.Tables[0].Columns.IndexOf()

                //DataColumnCollection columns = KitInfo.Instance.dsSerialUsed.Tables[0].Columns;

                //foreach (DataColumn column in KitInfo.Instance.dsSerialUsed.Tables[0].Columns)
                //{
                //    if (column.ColumnName.Contains("KIT") && !column.ColumnName.Contains("SERIAL"))
                //    {
                //        //get the index position of column within table
                //        var index = column.Ordinal;

                //        //get the material number using the ordinal
                //        string OriginalMaterialNumber = KitInfo.Instance.dsSerialUsed.Tables[0].Rows[0][index].ToString().Substring(1);

                //        MessageBox.Show($"You CANNOT bypass this material! \n " +
                //                          Environment.NewLine +
                //                          $"Original material # : {OriginalMaterialNumber} \n" +
                //                          $"Current  material # : {KitInfo.Instance.MaterialNumber} \n " +
                //                          Environment.NewLine +
                //                          $"Please click 'No' to return to the main form"
                //                       );
                //        return;
                //    };
                //}
           

                KitInfo.Instance.Bypass = true;

                //show 2nd groupbox
                gb_Bypass.Visible = true;

                //hide 3rd groupbox
                gb_AddDetails.Visible = false;

                //hide continue button
                btn_Continue.Visible = false;

                //hide this groupbox
                gb_YesNo.Visible = false;

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            KitInfo.Instance.Bypass = false;
            this.Close();
        }

        private void cb_ChooseReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cb_ChooseReason.SelectedIndex == 2)
                {
                    //show 3rd groupbox
                    gb_AddDetails.Visible = true;
                }
                else
                {
                    gb_AddDetails.Visible = false;
                }

                btn_Continue.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            try
            {
                //assign the row id of the row being bypassed in the DB
                KitInfo.Instance.RowIDofBypassInDB = KitInfo.Instance.dsSerialUsed.Tables[0].Rows[0][0].ToString();

                if (tb_AddDetails.Text == string.Empty && cb_ChooseReason.SelectedIndex == 2)
                {
                    MessageBox.Show("Details must be added before continuing");
                }
                else
                {
                    //add the reason
                    KitInfo.Instance.Bypass = true;
                    KitInfo.Instance.ReasonForBypass = cb_ChooseReason.Text;

                    if (KitInfo.Instance.ReasonForBypass == "Other")
                    {
                        KitInfo.Instance.NoteForBypass = tb_AddDetails.Text;
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
           
        }

        private void btn_ReturnToHierarchyForm_Click(object sender, EventArgs e)
        {
            KitInfo.Instance.Bypass = false;
            this.Close();
        }
    }
}
