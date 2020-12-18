using Hierarchy_Client.ProductionUtilitiesService;
using Hierarchy_Client.SchickWeb;
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
    public partial class Login : MetroForm
    {
        private static int _uapid;

        private static ServiceContractsClient ProductionUtils = new ServiceContractsClient();
        private static SensorDataAccessServiceWSSoapClient schickweb = new SensorDataAccessServiceWSSoapClient();

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Login()
        {
            InitializeComponent();
        }



        private void tb_Username_KeyUp(object sender, KeyEventArgs e)
        {
            //enter key has been pressed
            if (e.KeyCode == Keys.Enter)

            {
                //get the scanned barcode string 
                string barcode = tb_Username.Text;

                if (barcode.Length > 8)
                {

                    try
                    {
                        bool isValid = Int32.TryParse(Helper.Login(barcode), out _uapid);
                        if (!isValid)
                        {
                            MessageBox.Show("Invalid Login!!");
                            tb_Username.Text = string.Empty;
                            tb_Password.Text = string.Empty;

                            //log
                            logger.Error($"Invalid login returned for user {_uapid}");
                            return;
                        }
                        else
                        {
                            //assign the UAPID to the KitInfo class
                            KitInfo.Instance.UAPID = _uapid.ToString();
                            logger.Debug($"Valid login for : UAPID : {  KitInfo.Instance.UAPID} - User Name : {  KitInfo.Instance.Username}");

                            //test
                            //MessageBox.Show($"Success UAPID is : {_uapid}");

                            //hide this form
                            this.Hide();

                            //go to the material number form
                            MaterialNumberValidator mnv = new MaterialNumberValidator();
                            mnv.ShowDialog();
                        }
                    }
                    catch (Exception ex)
                    {

                        //log
                        logger.Error(ex.StackTrace);

                        MessageBox.Show($"Invalid Login!!");
                        tb_Username.Text = string.Empty;
                        tb_Password.Text = string.Empty;
                        return;
                    }
                }
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (tb_Username.Text == string.Empty)
            {
                MessageBox.Show("Enter Username !");
                return;
            }
            else if (tb_Password.Text == string.Empty)
            {
                MessageBox.Show("Enter Password !");
                return;
            }


            string[] temp = new string[2];
            temp[0] = tb_Username.Text;
            temp[1] = tb_Password.Text;
            string credentials = ($"{temp[0]}|{temp[1]}");

            try
            {

                bool isValid = Int32.TryParse(Helper.Login(credentials), out _uapid);
                if (!isValid)
                {
                    MessageBox.Show("Invalid Login!!");
                    tb_Username.Text = string.Empty;
                    tb_Password.Text = string.Empty;
                    return;
                }
                else
                {
                    //assign the UAPID to the KitInfo class
                    KitInfo.Instance.UAPID = _uapid.ToString();

                    //test
                    // MessageBox.Show($"Success UAPID is : {_uapid}");

                    //hide this form
                    this.Hide();

                    //go to the material number form
                    MaterialNumberValidator mnv = new MaterialNumberValidator();
                    mnv.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                //log
                logger.Error(ex.StackTrace);

                MessageBox.Show(ex.StackTrace);
                tb_Username.Text = string.Empty;
                tb_Password.Text = string.Empty;
                return;
            }


        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void metroButton_Login_Click(object sender, EventArgs e)
        {
            if (tb_Username.Text == string.Empty)
            {
                MessageBox.Show("Enter Username !");
                return;
            }
            else if (tb_Password.Text == string.Empty)
            {
                MessageBox.Show("Enter Password !");
                return;
            }


            string[] temp = new string[2];
            temp[0] = tb_Username.Text;
            temp[1] = tb_Password.Text;
            string credentials = ($"{temp[0]}|{temp[1]}");

            try
            {

                bool isValid = Int32.TryParse(Helper.Login(credentials), out _uapid);
                if (!isValid)
                {
                    MessageBox.Show("Invalid Login!!");
                    tb_Username.Text = string.Empty;
                    tb_Password.Text = string.Empty;

                    //log
                    logger.Debug($"Invalid login for : {temp[0]}");

                    return;
                }
                else
                {
                    //log
                    logger.Debug($"Valid login for : UAPID {_uapid} - {tb_Username.Text}");

                    //assign the UAPID to the KitInfo class
                    KitInfo.Instance.UAPID = _uapid.ToString();

                    //hide this form
                    this.Hide();
                    this.Close();

                    //go to the main menu number form
                    MainMenu mm = new MainMenu();
                    mm.ShowDialog();
                }
            }
            catch (Exception ex )
            {
                //log
                logger.Error(ex.StackTrace);

                MessageBox.Show(ex.StackTrace);
                tb_Username.Text = string.Empty;
                tb_Password.Text = string.Empty;
                return;
            }
        }

        private void tb_Password_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void metroButton_Home_Click(object sender, EventArgs e)
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
