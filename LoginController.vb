Imports System.Web.Mvc
Imports System.Drawing
Imports System.IO
Imports Anten.Login
Namespace Controllers
    Public Class LoginController
        Inherits Controller


        ' GET: Login
        Function Index() As ActionResult

            Return View()

        End Function

        Function Logout() As ActionResult
            Session.Abandon()
            Return RedirectToAction("/Index")

        End Function


        <HttpPost>
        Function Index(ByVal post As FormCollection) As ActionResult
            Dim Sys_Acc As String = post("Sys_Acc")
            Dim Sys_Pwd As String = post("Sys_Pwd")
            Dim Code As String = post("Code")
            '驗證
            Dim d1 As New Login()
            Dim Login_datas As List(Of System_Manager) = d1.LoginCheck(Sys_Acc, Sys_Pwd)
            If (Code = TempData("Code").ToString()) Then
                If (Login_datas.Count > 0) Then
                    Session("acc") = Sys_Acc
                    Session("loc") = Login_datas(0).Sys_Location
                    Response.Redirect("../Order/Index")
                Else
                    ViewBag.Msg = "輸入資料有誤，登入失敗....."
                    Return View()
                End If
            Else
                ViewBag.Msg = "驗證碼輸入有誤，請重新輸入....."
                Return View()
            End If
        End Function

        '隨機產生驗證碼
        Public Function RandomCode(ByVal length As Integer)
            Dim s As String = "0123456789zxcvbnmasdfghjklqwertyuiop"
            Dim sb As New StringBuilder()
            Dim rand As New Random()
            Dim index As Integer
            For i As Integer = 0 To length
                index = rand.Next(0, s.Length)
                sb.Append(s(index))
            Next
            Return sb.ToString()
        End Function

        '繪出圖形驗證碼
        Function GetValidateCode() As ActionResult

            Dim data As Byte() = Nothing
            Dim Code As String = RandomCode(5)
            TempData("Code") = Code

            ''定義畫板
            Dim ms As New MemoryStream()
            Using map As New Bitmap(100, 40)
                ''畫筆畫圖
                ''g.Dispose()
                Using g As Graphics = Graphics.FromImage(map)
                    g.Clear(Color.White)
                    g.DrawString(Code, New Font("黑體", 18.0F), Brushes.Blue, New Point(10, 8))
                End Using
                map.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            End Using
            data = ms.GetBuffer()
            Return File(data, "image/jpeg")
        End Function

    End Class
End Namespace