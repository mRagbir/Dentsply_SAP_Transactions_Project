Imports System.Configuration
Imports System.Data.SqlClient

Public Class DatabaseConnection

    Public Shared Function GetMaterialList()

        Dim dt As New DataTable()
        Try

            Dim connectionString = ConfigurationManager.ConnectionStrings("ProductionUtilitiesDB").ToString()

            Dim queryString As String =
            "SELECT PART_NUMBER FROM dbo.SAP_Material_Collection;"

            'create connection
            Using connection As New SqlConnection(connectionString)

                'create command
                Dim command As New SqlCommand(queryString, connection)

                'open connection
                connection.Open()

                Dim reader As SqlDataReader = command.ExecuteReader()


                dt.Load(reader)

                Return dt


            End Using

        Catch ex As Exception
            Console.WriteLine($"Error in GetMaterialList - {ex.Message.ToString()}")
        End Try

        Return dt

    End Function


    Public Shared Function EnterMaterialInfo(materialNumber As String, onHand As String, orderQty As String, qtyNeeded As String, qualityInspection As String)

        Dim bIsEntered As Boolean = False


        Try

            Dim connectionString = ConfigurationManager.ConnectionStrings("ProductionUtilitiesDB").ToString()

            Dim queryString As String =
                 $"UPDATE [SAP_Material_Collection] set SAP_ON_HAND = '{onHand.ToString()}',ORDER_QTY = {orderQty.ToString()},QTY_NEEDED={qtyNeeded.ToString()},QUALITY_INSPECTION={qualityInspection.ToString()} WHERE PART_NUMBER like '%{materialNumber}%'"


            'create connection
            Using connection As New SqlConnection(connectionString)

                Using comm As New SqlCommand()
                    With comm
                        .Connection = connection
                        .CommandType = CommandType.Text
                        .CommandText = queryString
                    End With

                    connection.Open()
                    Dim returnVal = comm.ExecuteNonQuery()

                    If returnVal < 1 Then

                        bIsEntered = False
                    Else
                        bIsEntered = True
                    End If


                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine($"Error in EnterMaterialInfo - {ex.Message}")
            bIsEntered = False
        End Try
        Return bIsEntered

    End Function

    Public Shared Function UpdateDatetimeInDB()

        Dim bIsEntered As Boolean = False

        Try

            Dim currentDate As DateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")


            Dim nextRun As DateTime = currentDate.AddMinutes(20)

            Dim connectionString = ConfigurationManager.ConnectionStrings("ProductionUtilitiesDB").ToString()

            Dim queryString As String =
                 $"UPDATE [SAP_Collection_Times] set LastRun = '{currentDate}',NextRun = '{nextRun}' WHERE ID = 1"


            'create connection
            Using connection As New SqlConnection(connectionString)

                Using comm As New SqlCommand()
                    With comm
                        .Connection = connection
                        .CommandType = CommandType.Text
                        .CommandText = queryString
                    End With

                    connection.Open()
                    Dim returnVal = comm.ExecuteNonQuery()

                    If returnVal < 1 Then

                        bIsEntered = False
                    Else
                        bIsEntered = True
                    End If


                End Using
            End Using


        Catch ex As Exception
            Dim errorFound = ex.Message
        End Try

        Return bIsEntered


    End Function




End Class
