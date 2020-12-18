Public Class Print


    Public Shared Function PrintHierarchyRecord(materialNumber As String) As Boolean

        Dim bIsPassed = False

        Try


            Dim App, Connection, session As Object

            Try

                Dim SapGuiAuto = GetObject("SAPGUI")
                App = SapGuiAuto.GetScriptingEngine
                Connection = App.Children(0)
                session = Connection.Children(1) ' grabs the 1st sap session window.

            Catch ex As Exception

                Console.WriteLine("Error : Cannot connect to SAP in Hierarchy transaction..!!")
                Return False
            End Try



            session.findById("wnd[0]/tbar[0]/okcd").Text = "/nzus_hrep"

            session.findById("wnd[0]").sendVKey(0) 'Enter key

            session.findById("wnd[0]/usr/ctxtP_MATNR").Text = materialNumber 'material number

            session.findById("wnd[0]/usr/ctxtS_BUDAT-LOW").Text = DateTime.Now.ToShortDateString()
            session.findById("wnd[0]/usr/ctxtS_BUDAT-LOW").SetFocus
            session.findById("wnd[0]/usr/ctxtS_BUDAT-LOW").caretPosition = 10
            session.findById("wnd[0]/tbar[1]/btn[8]").press

            session.findById("wnd[0]/tbar[0]/btn[86]").press
            session.findById("wnd[1]/tbar[0]/btn[13]").press

            bIsPassed = True
        Catch ex As Exception

        End Try



        Return bIsPassed


    End Function

End Class
