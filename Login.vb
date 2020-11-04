
Imports System.Collections.Generic
Imports System
Imports System.Linq
Imports System.Web
Imports System.Data.SqlClient
Imports System.Configuration
Imports Anten
Public Class Login
    Property Sys_Acc As String
    Property Sys_Pwd As String
    Property Sys_Location As String

    Public Function LoginCheck(ByVal Sys_Acc As String, ByVal Sys_Pwd As String) As List(Of System_Manager)
        Dim Login_datas As List(Of System_Manager) = New List(Of System_Manager)()
        Dim SqlConnection As New SqlConnection(ConfigurationManager.ConnectionStrings("DBConnectionString").ConnectionString)
        Dim SqlCommand As New SqlCommand("SELECT * FROM System_Manager WHERE Sys_Acc = '" & Sys_Acc & "' AND Sys_Pwd = '" & Sys_Pwd & "'") With {
            .Connection = SqlConnection
        }
        SqlConnection.Open()
        Dim reader As SqlDataReader = SqlCommand.ExecuteReader()
        If (reader.HasRows()) Then
            While (reader.Read())
                Dim login_data As System_Manager = New System_Manager With {
                    .Sys_Acc = reader.GetString(reader.GetOrdinal("Sys_acc")),
                    .Sys_Pwd = reader.GetString(reader.GetOrdinal("Sys_Pwd")),
                    .Sys_Location = reader.GetString(reader.GetOrdinal("Sys_Location"))
                    }
                Login_datas.Add(login_data)
                End While
            Else
            Console.WriteLine("資料庫無此帳號資料")
        End If
        SqlConnection.Close()
        Return Login_datas
    End Function
End Class
