using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;

namespace Mobisys_Automation
{
   
    public static class Tests
    {

        private static void GoBackToHomeScreen(Window window)
        {
            //find all items on window
            var items = window.Items;

            SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("BTN_BACK");
            SearchCriteria searchCriteria2 = SearchCriteria.ByAutomationId("BTN_HEADER1");



            //get the back button info
            bool getBackButton = items.Contains(window.Get<Panel>("BTN_BACK"));
           // bool hasBackHeader = items.Contains(window.Get<Panel>("BTN_HEADER1"));

            //if we find the button
            if (getBackButton)
            {
                Panel getButtonInfo = window.Get<Panel>("BTN_BACK");

                var buttonText = getButtonInfo.Name;

                if (!string.IsNullOrEmpty(buttonText))
                {
                    getButtonInfo.Click();

                    window.WaitWhileBusy();

                    Thread.Sleep(1000);

                    GoBackToHomeScreen(window);
                }
            }


           




        }
       
        public static void MobisysTest1()
        {

            try
            {
                string applicationPath = @"C:\Program Files (x86)\Mobisys GmbH\Mobisys MSB Client\";

                //create a new instance of your application
                var fullPath = Path.Combine(applicationPath, "MobisysClient100.exe");

                //create new application
                //Application application = Application.Launch(fullPath);

                Application application;
                Process[] processes = Process.GetProcessesByName("MobisysClient100");
                if (processes.Length == 0)
                    application = Application.Launch(fullPath);
                else
                    application = Application.Attach(@"MobisysClient100");

                application.WaitWhileBusy();

                //sleep
                Thread.Sleep(3000);

                //get the main window
                Window window = application.GetWindow("MSB Client 3.2.4.5 - SBP", InitializeOption.NoCache);

                       
                window.WaitWhileBusy();

                //make sure we are on the home screen
               // GoBackToHomeScreen(window);

                //get all items on the screen  **Test**
               // var items = window.Items;

                //Use Panel to get the Mobisys UI ******

                //Internal movements
                Panel p = window.Get<Panel>("BTN_MENU40");

                p.Focus();

                //Thread.Sleep(500);
                window.WaitWhileBusy();

                //click button (panel)
                p.Click();

                //************************************************

                //check the items again just a test
                //items = window.Items;

                //IM to WM transfer
                p = window.Get<Panel>("BTN_MENU60");

                window.WaitWhileBusy();

                p.Click();


                //add material number to textbox
                TextBox tb = window.Get<TextBox>("SCN_MATNR_FROM");
                tb.Text = "B2270000";
                tb.KeyIn(KeyboardInput.SpecialKeys.RETURN);

                window.WaitWhileBusy();

                //get all items on screen
                //var items = window.Items;

                // items = window.Items;

                // var getForm = window.Get(SearchCriteria.ByAutomationId("frmStdMainForm"));


                //***************************************************************************
                //var getSR04 = window.Get(SearchCriteria.ByText("SS02"));
                //getSR04.Focus();
                //getSR04.Click();
                //***************************************************************************




                #region Test for data-grid

                //var datagrid = window.Get<TestStack.White.UIItems.TableItems.Table>("GRD_MATERIAL").AutomationElement;

                //var headerLine = datagrid.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Header));
                //var cacheRequest = new CacheRequest { AutomationElementMode = AutomationElementMode.Full, TreeScope = TreeScope.Children };
                //cacheRequest.Add(AutomationElement.NameProperty);
                //cacheRequest.Add(ValuePattern.Pattern);
                //cacheRequest.Push();
                //var gridLines = datagrid.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Custom));

                //var getTable = gridLines[1];
                //cacheRequest.Pop();

                //var gridData = new string[headerLine.Count, gridLines.Count];

                //var headerIndex = 0;
                //foreach (AutomationElement header in headerLine)
                //{
                //    gridData[headerIndex++, 0] = header.Current.Name;
                //}

                //var rowIndex = 1;
                //foreach (AutomationElement row in gridLines)
                //{
                //    foreach (AutomationElement col in row.CachedChildren)
                //    {
                //        // Marry up data with headers (for some reason the orders were different
                //        // when viewing in something like UISpy so this makes sure it's correct
                //        headerIndex = 0;
                //        for (headerIndex = 0; headerIndex < headerLine.Count; headerIndex++)
                //        {
                //            if (gridData[headerIndex, 0] == col.Cached.Name)
                //                break;
                //        }

                //        gridData[headerIndex, rowIndex] = (col.GetCachedPattern(ValuePattern.Pattern) as ValuePattern).Current.Value;
                //    }
                //    rowIndex++;
                //} 


                #endregion




                //var typeTable = getTable.GetType();

                ////Label lblSelect =

                var tryThis = window.Get(SearchCriteria.ByText("Available Text"));
                //var typeTryThis = tryThis.GetType();
                //tryThis.Click();


                // var RatesGrd =(ListView)window.Get(SearchCriteria.ByAutomationId("GRD_MATERIAL"));

                //get the line that has SR04 and is Available stock
                // Table tbl = window.Get<Table>("GRD_MATERIAL");

                //Label lbl = window.Get<Label>("LBL_LINE1");
                // lbl.Click();


                Mouse mouse = Mouse.Instance;
                //mouse.Click(tryThis.ClickablePoint);

                //select button
                p = window.Get<Panel>("BTN_SELECT");
                p.Click();



                //click enter on screen
                
                Label lbl2 = window.Get<Label>("LBL_LINE2");
                lbl2.Focus(); 
                lbl2.KeyIn(KeyboardInput.SpecialKeys.RETURN);



                //put storage location


                TextBox tbStorageloc = window.Get<TextBox>("SCN_LGPLA_TO");
                tbStorageloc.Text= "FG-S12-SU";
                tbStorageloc.KeyIn(KeyboardInput.SpecialKeys.RETURN);


                //set the qty to move
                TextBox tbQty = window.Get<TextBox>("EDT_MENGE");
                tbQty.Text = "1";
                tbQty.KeyIn(KeyboardInput.SpecialKeys.RETURN);

                //continue button
                Panel continueBtn = window.Get<Panel>("BTN_SAVE");
                continueBtn.Focus();
                continueBtn.Click();

                //copy button


                //select serials

                //save



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
