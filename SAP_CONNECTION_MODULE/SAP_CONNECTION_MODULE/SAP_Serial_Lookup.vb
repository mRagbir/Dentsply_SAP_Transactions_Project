Public Module SAP_Serial_Lookup


    ' Public Function PerformSapActions(_materialNumber As String, _kitSerial As String, bIsStarterKit As Boolean)

    Public Function SAP_PerformSerialLookup(_materialNumber As String, _kitSerial As String) As Dictionary(Of String, String)

        Dim result As String()
        ' Dim tempSerial As String
        ' Dim tempSub As String
        ' Dim MaterialNumberGathered As String
        ' Dim SerialNumberGathered As String = String.Empty
        ' Dim temp1 As String
        ' Dim temp2 As String
        ' Dim temp3 As String
        Dim material1 As String = String.Empty
        Dim material2 As String = String.Empty
        Dim material3 As String = String.Empty
        Dim material4 As String = String.Empty
        Dim serial1 As String = String.Empty
        Dim serial2 As String = String.Empty
        Dim serial3 As String = String.Empty
        Dim serial4 As String = String.Empty

        Dim dictionary As New Dictionary(Of String, String)

        '  Dim var As New Collection
        '  Dim isStarterKit = bIsStarterKit


        Try
            'connect to SAP
            Dim App, Connection, session As Object
            Dim SapGuiAuto = GetObject("SAPGUI")
            App = SapGuiAuto.GetScriptingEngine
            Connection = App.Children(0)
            session = Connection.Children(0) ' grabs the 1st sap window.

            '~~~> t-code
            session.findById("wnd[0]/tbar[0]/okcd").Text = "/nZUS_EQMOD"
            session.findById("wnd[0]").sendVKey(0) ' enter

            session.findById("wnd[0]/usr/ctxtP_MATNR").Text = _materialNumber
            session.findById("wnd[0]/usr/ctxtP_SERNR").Text = _kitSerial

            session.findById("wnd[0]/usr/ctxtP_SERNR").SetFocus
            session.findById("wnd[0]/usr/ctxtP_SERNR").caretPosition = 10
            session.findById("wnd[0]/tbar[1]/btn[8]").press


            'look for text in text boxes

            'material 1
            material1 = session.findById("wnd[0]/usr/ctxtP_MAT1").Text
            serial1 = session.findById("wnd[0]/usr/ctxtP_SER1").Text

            'material 2
            material2 = session.findById("wnd[0]/usr/ctxtP_MAT2").Text
            serial2 = session.findById("wnd[0]/usr/ctxtP_SER2").Text

            'material 3
            material3 = session.findById("wnd[0]/usr/ctxtP_MAT3").Text
            serial3 = session.findById("wnd[0]/usr/ctxtP_SER3").Text

            'material 4
            material4 = session.findById("wnd[0]/usr/ctxtP_MAT4").Text
            serial4 = session.findById("wnd[0]/usr/ctxtP_SER4").Text

            'result = {material1, serial1, material2, serial2, material3, serial3, material4, serial4}
            dictionary.Add(material1, serial1)
            dictionary.Add(material2, serial2)
            dictionary.Add(material3, serial3)
            dictionary.Add(material4, serial4)

            'If isStarterKit Then

            '    Try
            '        'get the material numbers of the first two text boxes if its a starter kit
            '        tempSerial = Left(session.findById("wnd[0]/usr/ctxtP_MAT1").Text, 2)
            '    Catch ex As Exception
            '        var.Add(4, "Failed")
            '        Return var
            '    End Try


            '    If tempSerial = "B2" Then
            '        MaterialNumberGathered = session.findById("wnd[0]/usr/ctxtP_MAT2").Text
            '        SerialNumberGathered = session.findById("wnd[0]/usr/ctxtP_SER2").Text

            '    Else
            '        MaterialNumberGathered = session.findById("wnd[0]/usr/ctxtP_MAT1").Text
            '        SerialNumberGathered = session.findById("wnd[0]/usr/ctxtP_SER1").Text
            '    End If

            '    'get the sensor kit information

            '    '~~~> t-code
            '    session.findById("wnd[0]/tbar[0]/okcd").Text = "/nZUS_EQMOD"
            '    session.findById("wnd[0]").sendVKey(0) ' enter

            '    session.findById("wnd[0]/usr/ctxtP_MATNR").Text = MaterialNumberGathered
            '    session.findById("wnd[0]/usr/ctxtP_SERNR").Text = SerialNumberGathered

            '    'add to the object
            '    var.Add(MaterialNumberGathered, "Material_Number")

            '    session.findById("wnd[0]/usr/ctxtP_SERNR").SetFocus
            '    session.findById("wnd[0]/usr/ctxtP_SERNR").caretPosition = 10
            '    session.findById("wnd[0]/tbar[1]/btn[8]").press

            '    temp1 = Right(session.findById("wnd[0]/usr/ctxtP_MAT1").Text, 3)
            '    temp2 = Right(session.findById("wnd[0]/usr/ctxtP_MAT2").Text, 3)
            '    temp3 = Right(session.findById("wnd[0]/usr/ctxtP_MAT3").Text, 3)

            '    Select Case "200"
            '        Case temp1
            '            SerialNumberGathered = session.findById("wnd[0]/usr/ctxtP_SER1").Text
            '        Case temp2
            '            SerialNumberGathered = session.findById("wnd[0]/usr/ctxtP_SER2").Text
            '        Case temp3
            '            SerialNumberGathered = session.findById("wnd[0]/usr/ctxtP_SER3").Text
            '        Case Else
            '            SerialNumberGathered = "Failed"
            '            var.Add(4, "Failed")

            '    End Select

            '    'add to the object
            '    var.Add(SerialNumberGathered, "Serial_Number")

            'Else
            '    'temp serial
            '    tempSerial = session.findById("wnd[0]/usr/ctxtP_MAT1").Text

            '    tempSub = Right(tempSerial, 3)

            '    temp1 = Right(session.findById("wnd[0]/usr/ctxtP_MAT1").Text, 3)
            '    temp2 = Right(session.findById("wnd[0]/usr/ctxtP_MAT2").Text, 3)
            '    temp3 = Right(session.findById("wnd[0]/usr/ctxtP_MAT3").Text, 3)

            '    Select Case "200"
            '        Case temp1
            '            SerialNumberGathered = session.findById("wnd[0]/usr/ctxtP_SER1").Text
            '        Case temp2
            '            SerialNumberGathered = session.findById("wnd[0]/usr/ctxtP_SER2").Text
            '        Case temp3
            '            SerialNumberGathered = session.findById("wnd[0]/usr/ctxtP_SER3").Text
            '        Case Else
            '            SerialNumberGathered = "Failed"
            '            var.Add(4, "Failed")

            '    End Select

            '    var.Add(_materialNumber, "Material_Number")
            '    var.Add(SerialNumberGathered, "Serial_Number")


            'End If

            'close screen
            session.findById("wnd[0]/tbar[0]/btn[12]").press

            ' Return var


        Catch ex As Exception
            ' var.Add(3, "Failed")
            'result = {"FAILED"}
            '  Return var
            dictionary.Add("FAILED", ex.Message)
        End Try


        ' Return SerialNumberGathered ' If everything has passed
        '  Return var
        'Return result
        Return dictionary

    End Function

End Module