using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP_CSharp_Connection
{
    class Program
    {
        static void Main(string[] args)
        {
            //for testing
            string user = "mragbir";
            string pass = "Mitchxps170!!";
            string client = "700";

            string inspectionLot = "010001298473";

            try
            {
                //test connection
                bool bIsPass = MakeNewSapConnection.ConnectToRunningSapInstance(user, pass, client);
                Console.WriteLine($"ConnectToRunningSapInstance results : {bIsPass}");
                Console.ReadLine();

                //test controls
                bIsPass = MakeNewSapConnection.TestSessionControls();

                Console.WriteLine($"TestSessionControls results : {bIsPass}");
                Console.ReadLine();

                //test remote inspection
                bIsPass = MakeNewSapConnection.PerformRemoteInspection(inspectionLot);
                Console.WriteLine($"PerformRemoteInspection results : {bIsPass}");
                Console.ReadLine();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error : {ex.Message}");
                Console.ReadLine();
            }






        }
    }
}
