Imports System.Configuration
Imports System.Data.SqlClient


Public Class TestClass



    'Public Shared Function TryTupleAsArg(ByVal args As (String, String, String, Integer))

    '    ''  Dim tup = (TestStuff1:=args.Item1, TestStuff2:=args.Item2, TestStuff3:=args.Item3, TestStuff4:=args.Item4)
    '    ' Return tup


    'End Function

    Public Shared Function TestDbUpdate() As Boolean

        Dim bIsPassed = False
        Dim materialNumber As String = "B1218200"
        Dim onHand As String = "1"
        Dim orderQty As String = "1"
        Dim qtyNeeded As String = "1"
        Dim qualityInspection As String = "1"




        Try

            Dim connectionString = ConfigurationManager.ConnectionStrings("ProductionUtilitiesDB").ToString()

            Dim queryString As String =
                 $"UPDATE [SAP_Material_Collection] set SAP_ON_HAND = '{onHand.ToString()}',
                                                    ORDER_QTY = {orderQty.ToString()},
                                                    QTY_NEEDED={qtyNeeded.ToString()},
                                                    QUALITY_INSPECTION={qualityInspection.ToString()} 
                                                    WHERE PART_NUMBER like '%{materialNumber}%'"
            '$"UPDATE [SAP_Material_Collection] set SAP_ON_HAND = '{10}' WHERE PART_NUMBER like '{100007345}'"

            'create connection
            Using connection As New SqlConnection(connectionString)

                Using comm As New SqlCommand()
                    With comm
                        .Connection = connection
                        .CommandType = CommandType.Text
                        .CommandText = queryString
                        'comm.Parameters.Add("@materialNumber", SqlDbType.NVarChar).Value = "100007345"
                        'comm.Parameters.Add("@OH", SqlDbType.NVarChar).Value = 0.ToString()
                        'comm.Parameters.Add("@OrderQty", SqlDbType.NVarChar).Value = 0.ToString()
                        'comm.Parameters.Add("@QtyNeeded", SqlDbType.NVarChar).Value = 0.ToString()
                        'comm.Parameters.Add("@QtyAvail", SqlDbType.NVarChar).Value = 0.ToString()

                    End With

                    connection.Open()
                    Dim returnVal = comm.ExecuteNonQuery()

                    If returnVal < 1 Then

                        bIsPassed = False
                    Else
                        bIsPassed = True
                    End If


                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine($"Error in EnterMaterialInfo - {ex.Message}")
            bIsPassed = False
        End Try


        Return bIsPassed

    End Function

    Public Shared Function TestUpdateDatetimeInDB()

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
