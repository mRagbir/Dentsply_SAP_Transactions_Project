Imports System.Configuration

Public Class CollectSapInfo

    Public Shared Function GetSapMaterialInfo() As Boolean

        Dim allPassed As Boolean = False

        'Lets calculate how long entire process takes
        'Dim StartTime As Double
        'Dim MinutesElapsed As String


        'Remember time when macro starts
        ' StartTime = Timer

#Region "Original Code"



        '******  SCHICK33 Section ***************

        'Dim partNumbers(0 To 41) As String
        'partNumbers(0) = "100007345"
        'partNumbers(1) = "100007348"
        'partNumbers(2) = "100007346"
        'partNumbers(3) = "100007349"
        'partNumbers(4) = "100007347"
        'partNumbers(5) = "100007350"
        'partNumbers(6) = "B1218000"
        'partNumbers(7) = "B1218001"
        'partNumbers(8) = "B1218002"
        'partNumbers(9) = "B1218051"
        'partNumbers(10) = "B1218052"
        'partNumbers(11) = "B1218053"
        'partNumbers(12) = "B1118000"
        'partNumbers(13) = "B1118001"
        'partNumbers(14) = "B1118002"
        'partNumbers(15) = "B1118051"
        'partNumbers(16) = "B1118052"
        'partNumbers(17) = "B1118053"
        'partNumbers(18) = "B1318000"
        'partNumbers(19) = "B1318001"
        'partNumbers(20) = "B1318002"
        'partNumbers(21) = "B1318051"
        'partNumbers(22) = "B1318052"
        'partNumbers(23) = "B1318053"
        'partNumbers(24) = "B1218200"
        'partNumbers(25) = "B1118200"
        'partNumbers(26) = "B1318200"
        'partNumbers(27) = "B1209120"
        'partNumbers(28) = "B1209121"
        'partNumbers(29) = "B1209122"
        'partNumbers(30) = "B1209155"
        'partNumbers(31) = "B1209156"
        'partNumbers(32) = "B1209157"
        'partNumbers(33) = "B1209020"
        'partNumbers(34) = "B1109020"
        'partNumbers(35) = "B1309020"
        'partNumbers(36) = "B2270000"
        'partNumbers(37) = "B2270020"
        'partNumbers(38) = "B2270000R"
        'partNumbers(39) = "100008586"
        'partNumbers(40) = "100008587"
        'partNumbers(41) = "100008588"

        ''*******  AE Section  *****************

        'Dim AEpartNumbers(0 To 41) As String
        'AEpartNumbers(0) = "100008395"
        'AEpartNumbers(1) = "100008396"
        'AEpartNumbers(2) = "100008358"
        'AEpartNumbers(3) = "100008359"
        'AEpartNumbers(4) = "100008360"
        'AEpartNumbers(5) = "100008361"
        'AEpartNumbers(6) = "100008362"
        'AEpartNumbers(7) = "100008363"
        'AEpartNumbers(8) = "100006036"
        'AEpartNumbers(9) = "100006040"
        'AEpartNumbers(10) = "100006074"
        'AEpartNumbers(11) = "100007219"
        'AEpartNumbers(12) = "100007220"
        'AEpartNumbers(13) = "100007221"
        'AEpartNumbers(14) = "100007222"
        'AEpartNumbers(15) = "100008286"
        'AEpartNumbers(16) = "100008290"
        'AEpartNumbers(17) = "100007020"
        'AEpartNumbers(18) = "100007035"
        'AEpartNumbers(19) = "100007036"
        'AEpartNumbers(20) = "100007037"
        'AEpartNumbers(21) = "100007049"
        'AEpartNumbers(22) = "100007052"
        'AEpartNumbers(23) = "100007053"
        'AEpartNumbers(24) = "100007062"
        'AEpartNumbers(25) = "100007063"
        'AEpartNumbers(26) = "100007064"
        'AEpartNumbers(27) = "100007065"
        'AEpartNumbers(28) = "100007066"
        'AEpartNumbers(29) = "100007067"
        'AEpartNumbers(30) = "100007068"
        'AEpartNumbers(31) = "100007070"
        'AEpartNumbers(32) = "100007071"
        'AEpartNumbers(33) = "100007072"
        'AEpartNumbers(34) = "100007073"
        'AEpartNumbers(35) = "100007074"
        'AEpartNumbers(36) = "100007075"
        'AEpartNumbers(37) = "100007076"
        'AEpartNumbers(38) = "100007223"
        'AEpartNumbers(39) = "100007224"
        'AEpartNumbers(40) = "100007225"
        'AEpartNumbers(41) = "100007226"

        ''XG Part Numbers

        'Dim XIOS_AE_partNumbers(0 To 23) As String

        'XIOS_AE_partNumbers(0) = "100008298"
        'XIOS_AE_partNumbers(1) = "100008433"
        'XIOS_AE_partNumbers(2) = "100008299"
        'XIOS_AE_partNumbers(3) = "100008317"
        'XIOS_AE_partNumbers(4) = "100008315"
        'XIOS_AE_partNumbers(5) = "100008302"
        'XIOS_AE_partNumbers(6) = "100008430"
        'XIOS_AE_partNumbers(7) = "100008307"
        'XIOS_AE_partNumbers(8) = "100008318"
        'XIOS_AE_partNumbers(9) = "100008313"
        'XIOS_AE_partNumbers(10) = "100008306"
        'XIOS_AE_partNumbers(11) = "100008436"
        'XIOS_AE_partNumbers(12) = "100008307"
        'XIOS_AE_partNumbers(13) = "100008318"
        'XIOS_AE_partNumbers(14) = "100008313"
        'XIOS_AE_partNumbers(15) = "100008168"
        'XIOS_AE_partNumbers(16) = "100008179"
        'XIOS_AE_partNumbers(17) = "100008186"
        'XIOS_AE_partNumbers(18) = "100008369"
        'XIOS_AE_partNumbers(19) = "100008370"
        'XIOS_AE_partNumbers(20) = "100008407"
        'XIOS_AE_partNumbers(21) = "100008408"
        'XIOS_AE_partNumbers(22) = "100008334"
        'XIOS_AE_partNumbers(23) = "100008380"


        ''XG SUPREME Part Numbers

        'Dim XG_SUPREME_partNumbers(0 To 58) As String
        'XG_SUPREME_partNumbers(0) = "100004607"
        'XG_SUPREME_partNumbers(1) = "B1215000"
        'XG_SUPREME_partNumbers(2) = "B1215050"
        'XG_SUPREME_partNumbers(3) = "B1215051"
        'XG_SUPREME_partNumbers(4) = "B1215052"
        'XG_SUPREME_partNumbers(5) = "B1215053"
        'XG_SUPREME_partNumbers(6) = "B1215054"
        'XG_SUPREME_partNumbers(7) = "B1215055"
        'XG_SUPREME_partNumbers(8) = "B2452000"
        'XG_SUPREME_partNumbers(9) = "B2452050"
        'XG_SUPREME_partNumbers(10) = "B2452051"
        'XG_SUPREME_partNumbers(11) = "B2452052"
        'XG_SUPREME_partNumbers(12) = "B2452053"
        'XG_SUPREME_partNumbers(13) = "B2452054"
        'XG_SUPREME_partNumbers(14) = "B2452055"
        'XG_SUPREME_partNumbers(15) = "B2452056"
        'XG_SUPREME_partNumbers(16) = "B2452057"
        'XG_SUPREME_partNumbers(17) = "100004612"
        'XG_SUPREME_partNumbers(18) = "B1315000"
        'XG_SUPREME_partNumbers(19) = "B1315050"
        'XG_SUPREME_partNumbers(20) = "B1315051"
        'XG_SUPREME_partNumbers(21) = "B1315052"
        'XG_SUPREME_partNumbers(22) = "B1315053"
        'XG_SUPREME_partNumbers(23) = "B1315054"
        'XG_SUPREME_partNumbers(24) = "B1315055"
        'XG_SUPREME_partNumbers(25) = "B2453000"
        'XG_SUPREME_partNumbers(26) = "B2453050"
        'XG_SUPREME_partNumbers(27) = "B2453051"
        'XG_SUPREME_partNumbers(28) = "B2453052"
        'XG_SUPREME_partNumbers(29) = "B2453053"
        'XG_SUPREME_partNumbers(30) = "B2453054"
        'XG_SUPREME_partNumbers(31) = "B2453055"
        'XG_SUPREME_partNumbers(32) = "B2453056"
        'XG_SUPREME_partNumbers(33) = "B2453057"
        'XG_SUPREME_partNumbers(34) = "100004609"
        'XG_SUPREME_partNumbers(35) = "B1115000"
        'XG_SUPREME_partNumbers(36) = "B1115050"
        'XG_SUPREME_partNumbers(37) = "B1115051"
        'XG_SUPREME_partNumbers(38) = "B1115052"
        'XG_SUPREME_partNumbers(39) = "B1115053"
        'XG_SUPREME_partNumbers(40) = "B1115054"
        'XG_SUPREME_partNumbers(41) = "B1115055"
        'XG_SUPREME_partNumbers(42) = "B2451000"
        'XG_SUPREME_partNumbers(43) = "B2451050"
        'XG_SUPREME_partNumbers(44) = "B2451051"
        'XG_SUPREME_partNumbers(45) = "B2451052"
        'XG_SUPREME_partNumbers(46) = "B2451053"
        'XG_SUPREME_partNumbers(47) = "B2451054"
        'XG_SUPREME_partNumbers(48) = "B2451055"
        'XG_SUPREME_partNumbers(49) = "B2451056"
        'XG_SUPREME_partNumbers(50) = "B2451057"
        'XG_SUPREME_partNumbers(51) = "B1214155"
        'XG_SUPREME_partNumbers(52) = "B1214156"
        'XG_SUPREME_partNumbers(53) = "B1214157"
        'XG_SUPREME_partNumbers(54) = "B1214120"
        'XG_SUPREME_partNumbers(55) = "B1214121"
        'XG_SUPREME_partNumbers(56) = "B1215200"
        'XG_SUPREME_partNumbers(57) = "B1115200"
        'XG_SUPREME_partNumbers(58) = "B1315200"


        ''XG SELECT Part Numbers

        'Dim XG_SELECT_partNumbers(0 To 53) As String
        'XG_SELECT_partNumbers(0) = "100004796"
        'XG_SELECT_partNumbers(1) = "B1214000"
        'XG_SELECT_partNumbers(2) = "B1214050"
        'XG_SELECT_partNumbers(3) = "B1214051"
        'XG_SELECT_partNumbers(4) = "B1214052"
        'XG_SELECT_partNumbers(5) = "B1214053"
        'XG_SELECT_partNumbers(6) = "B1214054"
        'XG_SELECT_partNumbers(7) = "B1214055"
        'XG_SELECT_partNumbers(8) = "B2442000"
        'XG_SELECT_partNumbers(9) = "B2442050"
        'XG_SELECT_partNumbers(10) = "B2442051"
        'XG_SELECT_partNumbers(11) = "B2442052"
        'XG_SELECT_partNumbers(12) = "B2442053"
        'XG_SELECT_partNumbers(13) = "B2442054"
        'XG_SELECT_partNumbers(14) = "B2442055"
        'XG_SELECT_partNumbers(15) = "B2442056"
        'XG_SELECT_partNumbers(16) = "B2442057"
        'XG_SELECT_partNumbers(17) = "100004614"
        'XG_SELECT_partNumbers(18) = "B1114000"
        'XG_SELECT_partNumbers(19) = "B1114050"
        'XG_SELECT_partNumbers(20) = "B1114051"
        'XG_SELECT_partNumbers(21) = "B1114052"
        'XG_SELECT_partNumbers(22) = "B1114053"
        'XG_SELECT_partNumbers(23) = "B1114054"
        'XG_SELECT_partNumbers(24) = "B1114055"
        'XG_SELECT_partNumbers(25) = "B2441000"
        'XG_SELECT_partNumbers(26) = "B2441050"
        'XG_SELECT_partNumbers(27) = "B2441051"
        'XG_SELECT_partNumbers(28) = "B2441052"
        'XG_SELECT_partNumbers(29) = "B2441053"
        'XG_SELECT_partNumbers(30) = "B2441054"
        'XG_SELECT_partNumbers(31) = "B2441055"
        'XG_SELECT_partNumbers(32) = "B2441056"
        'XG_SELECT_partNumbers(33) = "B2441057"
        'XG_SELECT_partNumbers(34) = "100004617"
        'XG_SELECT_partNumbers(35) = "B1314000"
        'XG_SELECT_partNumbers(36) = "B1314050"
        'XG_SELECT_partNumbers(37) = "B1314051"
        'XG_SELECT_partNumbers(38) = "B1314052"
        'XG_SELECT_partNumbers(39) = "B1314053"
        'XG_SELECT_partNumbers(40) = "B1314054"
        'XG_SELECT_partNumbers(41) = "B1314055"
        'XG_SELECT_partNumbers(42) = "B2443000"
        'XG_SELECT_partNumbers(43) = "B2443050"
        'XG_SELECT_partNumbers(44) = "B2443051"
        'XG_SELECT_partNumbers(45) = "B2443052"
        'XG_SELECT_partNumbers(46) = "B2443053"
        'XG_SELECT_partNumbers(47) = "B2443054"
        'XG_SELECT_partNumbers(48) = "B2443055"
        'XG_SELECT_partNumbers(49) = "B2443056"
        'XG_SELECT_partNumbers(50) = "B2443057"
        'XG_SELECT_partNumbers(51) = "B1214200"
        'XG_SELECT_partNumbers(52) = "B1114200"
        'XG_SELECT_partNumbers(53) = "B1314200"


        '' ELITE part numbers
        'Dim ELITE_partNumbers(0 To 32) As String
        'ELITE_partNumbers(0) = "100007351"
        'ELITE_partNumbers(1) = "100007354"
        'ELITE_partNumbers(2) = "100007352"
        'ELITE_partNumbers(3) = "100007355"
        'ELITE_partNumbers(4) = "100007353"
        'ELITE_partNumbers(5) = "100007356"
        'ELITE_partNumbers(6) = "100007359"
        'ELITE_partNumbers(7) = "100007362"
        'ELITE_partNumbers(8) = "100007360"
        'ELITE_partNumbers(9) = "100007363"
        'ELITE_partNumbers(10) = "100007361"
        'ELITE_partNumbers(11) = "100007364"
        'ELITE_partNumbers(12) = "B1207000"
        'ELITE_partNumbers(13) = "B1207001"
        'ELITE_partNumbers(14) = "B1207002"
        'ELITE_partNumbers(15) = "B1207045R"
        'ELITE_partNumbers(16) = "B1207046R"
        'ELITE_partNumbers(17) = "B1107000"
        'ELITE_partNumbers(18) = "B1107001"
        'ELITE_partNumbers(19) = "B1107002"
        'ELITE_partNumbers(20) = "B1107045R"
        'ELITE_partNumbers(21) = "B1107046R"
        'ELITE_partNumbers(22) = "B1307000"
        'ELITE_partNumbers(23) = "B1307001"
        'ELITE_partNumbers(24) = "B1307002"
        'ELITE_partNumbers(25) = "B1307045R"
        'ELITE_partNumbers(26) = "B1307046R"
        'ELITE_partNumbers(27) = "B1207020"
        'ELITE_partNumbers(28) = "B1107020"
        'ELITE_partNumbers(29) = "B1307020"
        'ELITE_partNumbers(30) = "B1207200"
        'ELITE_partNumbers(31) = "B1107200"
        'ELITE_partNumbers(32) = "B1307200"


#End Region

        Try

            'get all the material numbers
            Dim dtTemp As New DataTable()
            dtTemp = DatabaseConnection.GetMaterialList()

            Dim listOfMaterialNumbers As New List(Of String)
            listOfMaterialNumbers = (From item In dtTemp.AsEnumerable() Select item.Field(Of String)(0).TrimEnd).ToList()

            Dim csi = New CollectSapInfo()
            allPassed = csi.GatherSAPInfo(listOfMaterialNumbers)

        Catch ex As Exception
            Console.WriteLine($"Error found in GetSapMaterialInfo - {ex.Message}")
        End Try

        Return allPassed


    End Function

    Private Function GatherSAPInfo(partNumbers As List(Of String)) As Boolean

        Dim bIsPassed As Boolean = False
        Dim bIsTest As Boolean = Convert.ToBoolean(ConfigurationManager.AppSettings("bIsTest").ToString())
        Try

            'SAP section *******************************************

            Dim App, Connection, session As Object
            Dim SapGuiAuto As Object

            SapGuiAuto = GetObject("SAPGUI")
            App = SapGuiAuto.GetScriptingEngine
            Connection = App.Children(0)
            session = Connection.Children(0) ' grabs the 1st sap session window.


            Dim onHandQty As String
            Dim unresUse As String
            Dim salesOrders As String
            Dim delivery As String
            Dim qaQTy As String
            Dim MaterialDescription As String

            Dim materialNumber As String

            For Each materialNumber In partNumbers

                If bIsTest Then
                    Console.WriteLine($"Currently collecting info for - {materialNumber}")
                End If


                'check mmbe values **********************************************

                'navigate to mmbe
                session.FindById("wnd[0]/tbar[0]/okcd").Text = "/nmmbe"
                session.FindById("wnd[0]").sendVKey(0)
                session.FindById("wnd[0]/usr/ctxtMS_MATNR-LOW").Text = materialNumber
                session.FindById("wnd[0]/usr/ctxtVERNU").Text = "13"
                session.FindById("wnd[0]/usr/ctxtVERNU").SetFocus
                session.FindById("wnd[0]/usr/ctxtVERNU").caretPosition = 2
                session.FindById("wnd[0]").sendVKey(0)
                session.FindById("wnd[0]/tbar[1]/btn[8]").press

                'click on the text
                session.FindById("wnd[0]/usr/cntlCC_CONTAINER/shellcont/shell/shellcont[1]/shell[1]").SelectItem("          1", "C          1")


                'select the Unrestricted use value
                unresUse = session.FindById("wnd[0]/usr/cntlCC_CONTAINER/shellcont/shell/shellcont[1]/shell[1]").GetItemText("          1", "C          1")

                'select the sales orders value
                salesOrders = session.FindById("wnd[0]/usr/cntlCC_CONTAINER/shellcont/shell/shellcont[1]/shell[1]").GetItemText("          1", "C          2")

                'select delivery value
                delivery = session.FindById("wnd[0]/usr/cntlCC_CONTAINER/shellcont/shell/shellcont[1]/shell[1]").GetItemText("          1", "C          3")

                'get the quality qty
                qaQTy = session.FindById("wnd[0]/usr/cntlCC_CONTAINER/shellcont/shell/shellcont[1]/shell[1]").GetItemText("          1", "C         12")

                'get the material description
                MaterialDescription = session.FindById("wnd[0]/usr/txtTEXT_MATERIAL").Text

                Dim tempMaterial As String
                tempMaterial = materialNumber



                'add all the orders together
                Dim qa As Long
                Dim OH As Long
                Dim SO As Long
                Dim DelivO As Long
                Dim orderQTy As Long
                Dim qtyNeeded As Long



                If qaQTy <> "" Then
                    qa = CLng(qaQTy)
                Else
                    qa = 0
                End If

                If unresUse <> "" Then
                    OH = CLng(unresUse)
                Else
                    OH = 0
                    onHandQty = 0
                End If

                If salesOrders <> "" Then
                    SO = CLng(salesOrders)
                Else
                    SO = 0
                End If


                If delivery <> "" Then
                    DelivO = CLng(delivery)
                Else
                    DelivO = 0
                End If



                'sales order + delivery orders
                orderQTy = (SO + DelivO)

                'qty needed to full fill all orders
                If orderQTy < 1 Or orderQTy < OH Then
                    qtyNeeded = 0
                Else
                    qtyNeeded = orderQTy - OH
                End If



                'enter value in database according to material number
                Dim tryToEnter As Int32 = Convert.ToInt32(DatabaseConnection.EnterMaterialInfo(materialNumber.ToString(), OH.ToString(), orderQTy.ToString(), qtyNeeded.ToString(), qa.ToString()))

                If bIsTest Then
                    Console.WriteLine($"Database insert for {materialNumber} : {tryToEnter}")
                End If

            Next

            bIsPassed = True

            GoTo finishTransaction


        Catch ex As Exception
            Console.WriteLine($"Error in GatherSAPInfo - {ex.Message}")
            Dim whatIsTheProblemSir = ex.Message
        End Try




finishTransaction:

        Return bIsPassed

    End Function



End Class
