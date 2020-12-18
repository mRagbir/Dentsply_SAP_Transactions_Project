using SAPFEWSELib;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SAP_CSharp_Connection
{
    public static class MakeNewSapConnection
    {

        private  static GuiApplication SapGuiApp { get; set; }
        private static GuiConnection SapConnection { get; set; }
        private static GuiSession SapSession { get; set; }
        private static GuiFrameWindow SapFrame { get; set; }

        private static bool bTriedOnce = false;
        private static bool bIsSuccessfull = false;

        //public static CSapROTWrapper SAPROTWrapper { get; set; }
        //public static object SAPGuiRot { get; set; }
        //public static GuiConnection GUIConnection { get; set; }
        //public static GuiSession GUISession { get; set; }
        //public static GuiApplication GUIApp { get; set; }
        //public static GuiFrameWindow GUIFrameWindow { get; set; }





        private static bool MakeConnection(string userName ,string password,string client,string language)
        {
            bool bIsSuccessful = false;

            try
            {
                //test
               // ConnectToRunningSapInstance();

                string tryToMakeNewConnection = openSap();

                if (!tryToMakeNewConnection.ToUpper().Contains("ERROR") || !tryToMakeNewConnection.ToUpper().Contains("FALSE"))
                {

   
                    bool bTryLogin = login(client, userName, password, language);

                    if (bTryLogin)
                    {

                        //test session controls 
                        // TestSessionControls();
                        //PerformRemoteInspection();

                         //success
                         bIsSuccessful = true;
                    }
                  
                }
            }
            catch (Exception ex)
            {

                
            }

            return bIsSuccessful;

        }

        private static string openSap()
        {
            string isCreated = false.ToString();
            try
            {

                SapGuiApp = new GuiApplication();

                string connectString = ".ECC production (SBP)";

                SapConnection = SapGuiApp.OpenConnection(connectString, Sync: true); //creates connection
                SapSession = (GuiSession)SapConnection.Sessions.Item(0); //creates the Gui session off the connection you made

                isCreated = true.ToString();

            }
            catch (Exception ex)
            {
                isCreated = "Error : " +ex.InnerException.ToString();
            }

            return isCreated;
        }


        public static bool ConnectToRunningSapInstance(string userName, string password, string client)
        {
            bool bIsConnected = false;
            try
            {

                #region Test
                //Get the Windows Running Object Table
                //CSapROTWrapper sapROTWrapper = new SapROTWr.CSapROTWrapper();

                ////Get the ROT Entry for the SAP Gui to connect to the COM
                //object SapGuilRot = sapROTWrapper.GetROTEntry("SAPGUI");

                ////Get the reference to the Scripting Engine
                //object engine = SapGuilRot.GetType().InvokeMember("GetSCriptingEngine", System.Reflection.BindingFlags.InvokeMethod,null, SapGuilRot, null);
                ////Get the reference to the running SAP Application Window
                //GuiApplication GuiApp = (GuiApplication)engine;

                ////Get the reference to the first open connection
                //GuiConnection connection = (GuiConnection)GuiApp.Connections.ElementAt(0);

                ////get the first available session
                //GuiSession session = (GuiSession)connection.Children.ElementAt(0);

                ////Get the reference to the main "Frame" in which to send virtual key commands
                //GuiFrameWindow frame = (GuiFrameWindow)session.FindById("wnd[0]");

                //((GuiOkCodeField)SapSession.FindById("wnd[0]/tbar[0]/okcd")).Text = "/nmmbe";

                //SAPROTWrapper = new CSapROTWrapper();
                //SAPGuiRot = SAPROTWrapper.GetROTEntry("SAPGUI");

                //if (SAPGuiRot == null)
                //{
                //    GUIApp = (GuiApplication)Activator.CreateInstance(Type.GetTypeFromProgID("SapGui.ScriptingCtrl.1"));
                //}
                //else
                //{
                //    GUIApp =
                //        SAPGuiRot.GetType()
                //            .InvokeMember("GetScriptingEngine", System.Reflection.BindingFlags.InvokeMethod, null,
                //                SAPGuiRot, null) as GuiApplication;
                //}

                //working
                //SapGuiApp = new GuiApplication();

                //string strProg = @"C:\Program Files (x86)\SAP\FrontEnd\SAPgui\sapshcut.exe";
                //string strParam = "-system=SBP -client=700 -user=mragbir -password=Mitchxps170!! -language=EN";
                //System.Diagnostics.Process.Start(strProg, strParam);
                //*********************************************************888

                //SapGuiApp = new GuiApplication();
                //var x = SapGuiApp.Connections.Count; //GuiApplication Connections.Count();

                //GuiApplication guiApp = (GuiApplication)System.Activator.CreateInstance(Type.GetTypeFromProgID("SapGui.ScriptingCtrl.1"));
                ////var x =  Microsoft.VisualBasic.Interaction.GetObject("SAPGUISERVER", "");
                ////Get the Windows Running Object Table
                //CSapROTWrapper sapROTWrapper = new SapROTWr.CSapROTWrapper();

                ////Get the ROT Entry for the SAP Gui to connect to the COM
                //object SapGuilRot = sapROTWrapper.GetROTEntry("SAPGUI");

                ////Get the reference to the Scripting Engine
                //object engine = SapGuilRot.GetType().InvokeMember("GetSCriptingEngine", System.Reflection.BindingFlags.InvokeMethod, null, SapGuilRot, null);

                // SapGuiApp = new GuiApplication();

                // SapSession = (GuiSession)SapConnection.Sessions.Item(0);

                //TestSessionControls();


                #endregion

                
                SapROTWr.CSapROTWrapper sapROT = new SapROTWr.CSapROTWrapper();
                object objSapGui = sapROT.GetROTEntry("SAPGUI");

                object objEngine = objSapGui.GetType().InvokeMember("GetScriptingEngine", System.Reflection.BindingFlags.InvokeMethod, null, objSapGui, null);

                for (int x = 0; x < (objEngine as GuiApplication).Children.Count; x++)
                {
                    SapConnection = ((objEngine as GuiApplication).Children.ElementAt(x) as GuiConnection);
                   // string strDescr = (SapConnection.Name);
                }

                SapSession=(GuiSession)SapConnection.Children.ElementAt(0);

                bIsSuccessfull = true;
                bIsConnected = true;
                // TestSessionControls();

                //PerformRemoteInspection();
            }
            catch (Exception ex)
            {

                if (!bTriedOnce && !bIsSuccessfull)
                {
                    SapGuiApp = new GuiApplication();

                    string strProg = @"C:\Program Files (x86)\SAP\FrontEnd\SAPgui\sapshcut.exe";
                    string strParam = $"-system=SBP -client={client} -user={userName} -password={password} -language=EN";
                    System.Diagnostics.Process.Start(strProg, strParam);


                    bTriedOnce = true;
                    Thread.Sleep(3000);
                    ConnectToRunningSapInstance(userName,password,client);
                }
            }

            return bIsConnected;

        }


        private static bool login(string myclient, string mylogin, string mypass, string mylang)
        {
            bool bisPassed = false;

            try
            {
                GuiTextField client = (GuiTextField)SapSession.ActiveWindow.FindByName("RSYST-MANDT", "GuiTextField");
                GuiTextField login = (GuiTextField)SapSession.ActiveWindow.FindByName("RSYST-BNAME", "GuiTextField");
                GuiTextField pass = (GuiTextField)SapSession.ActiveWindow.FindByName("RSYST-BCODE", "GuiPasswordField");
                GuiTextField language = (GuiTextField)SapSession.ActiveWindow.FindByName("RSYST-LANGU", "GuiTextField");

                client.SetFocus();
                client.Text = myclient;
                login.SetFocus();
                login.Text = mylogin;
                pass.SetFocus();
                pass.Text = mypass;
                language.SetFocus();
                language.Text = mylang;

                //Press the green check mark button which is about the same as the enter key 
                GuiButton btn = (GuiButton)SapSession.FindById("/app/con[0]/ses[0]/wnd[0]/tbar[0]/btn[0]");
                btn.SetFocus();
                btn.Press();

                bisPassed = true;

            }
            catch (Exception ex)
            {

               
            }

            return bisPassed;


        }

        public static void KillSapConnection()
        {
            SapFrame = null;
            SapSession = null;
            SapConnection = null;
            SapGuiApp = null;
        }



        private static void EnterKey()
        {
            try
            {
                GuiButton btn = (GuiButton)SapSession.ActiveWindow.FindByName("btn[0]", "GuiButton");
                btn.SetFocus();
                btn.Press();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private static void ClickGreenCheckButton()
        {
            GuiButton btn = (GuiButton)SapSession.ActiveWindow.FindByName("btn[8]", "GuiButton");
            btn.SetFocus();
            btn.Press();
        }

      


        public static bool TestSessionControls()
        {
            bool bIsPassed = false;
            try
            {

                // var transCode = (GuiTextField)SapSession.FindById(@"wnd[0]/tbar[0]/okcd");
               // transCode.Text = "/nmmbe";

                //transaction code
                //SapSession.StartTransaction("/nnmmbe");


                ((GuiOkCodeField)SapSession.FindById("wnd[0]/tbar[0]/okcd")).Text = "/nmmbe";

                //enter
                EnterKey();

                //test input of a part number
                GuiTextField matNum = ((GuiTextField)SapSession.FindById("wnd[0]/usr/ctxtMS_MATNR-LOW"));
                matNum.Text = "B1218000";

                ClickGreenCheckButton();

                bIsPassed = true;
            }
            catch (Exception ex)
            {

                bIsPassed = false;
            }

            return bIsPassed;
        }


        public static bool PerformRemoteInspection(string inspectionLot)
        {
            bool bIsPassed = false;

            try
            {
                //~~~> t-code
                ((GuiOkCodeField)SapSession.FindById("wnd[0]/tbar[0]/okcd")).Text = "/nQE51N";

                //enter
                EnterKey();

                //click the inspection lot tab
                var selectTab1 = (GuiTab)SapSession.FindById("wnd[0]/usr/tabsTABSTRIP_OBJECT/tabpTAB_LOS");
                selectTab1.Select();



                //enter the inspection lot number
                GuiTextField lotNumber = (GuiTextField)SapSession.FindById("wnd[0]/usr/tabsTABSTRIP_OBJECT/tabpTAB_LOS/ssub%_SUBSCREEN_OBJECT:SAPLQEES:0510/ctxtQL_PRLOS-LOW");
                var x = lotNumber.GetType();
                lotNumber.Text = inspectionLot;






                //enter
                EnterKey();

                ClickGreenCheckButton();

                GuiTextField pass1 = (GuiTextField)SapSession.FindById("wnd[0]/usr/tabsEE_DATEN/tabpSISP/ssubSUB_EE_DATEN:SAPLQEEM:0202/tblSAPLQEEMSUMPLUS/ctxtQAQEE-SUMPLUS[9,0]");
                pass1.Text = "P";

                Thread.Sleep(1000);
                EnterKey();

                GuiTextField pass2 = (GuiTextField)SapSession.FindById("wnd[0]/usr/tabsEE_DATEN/tabpSISP/ssubSUB_EE_DATEN:SAPLQEEM:0202/tblSAPLQEEMSUMPLUS/ctxtQAQEE-SUMPLUS[9,1]");
                pass1.Text = "P";

                Thread.Sleep(1000);
                EnterKey();

                GuiTextField pass3 = (GuiTextField)SapSession.FindById("wnd[0]/usr/tabsEE_DATEN/tabpSISP/ssubSUB_EE_DATEN:SAPLQEEM:0202/tblSAPLQEEMSUMPLUS/ctxtQAQEE-SUMPLUS[9,2]");
                pass1.Text = "P";

                Thread.Sleep(1000);
                EnterKey();

                GuiTextField pass4 = (GuiTextField)SapSession.FindById("wnd[0]/usr/tabsEE_DATEN/tabpSISP/ssubSUB_EE_DATEN:SAPLQEEM:0202/tblSAPLQEEMSUMPLUS/ctxtQAQEE-SUMPLUS[9,3]");
                pass1.Text = "P";

                Thread.Sleep(1000);

                EnterKey();

                GuiButton btn = (GuiButton)SapSession.ActiveWindow.FindByName("btn[11]", "GuiButton");
                btn.SetFocus();
                btn.Press();

                var getCol = SapSession.FindById("wnd[0]/shellcont/shellcont/shell/shellcont[1]/shell");

                bIsPassed = true;
            }
            catch (Exception ex)
            {
                bIsPassed = false;

            }

            return bIsPassed;
        }

    }
}
