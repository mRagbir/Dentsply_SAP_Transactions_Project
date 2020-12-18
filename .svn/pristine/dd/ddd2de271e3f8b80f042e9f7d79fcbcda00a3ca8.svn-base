Public Class OpenNewInstance

    Public Shared Function CreateNewSapObject()

        Dim bIsCreated As Boolean = False

        'check if process is running
        Dim p() As Process

        Try



            p = Process.GetProcessesByName("saplogon")

            If p.Count > 0 Then
                ' Process is running
                bIsCreated = True
            Else
                ' Process is not running


                'open process
                Process.Start("C:\Program Files (x86)\SAP\FrontEnd\SAPgui\saplogon.exe")
                bIsCreated = True


            End If

        Catch ex As Exception

        End Try


        Return bIsCreated








    End Function
End Class
