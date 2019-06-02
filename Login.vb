Imports System.Security.Cryptography
Imports System.Text
Imports MaterialSkin
Imports MySql.Data.MySqlClient

Public Class Login
    Private Sub OnLoadLoginWindow(sender As Object, e As EventArgs) Handles MyBase.Load
        MaterialSingleLineTextField1.Text = Username.Text
        MaterialSingleLineTextField2.Text = Password.Text
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Function MDhash(ByVal password As String)
        Dim md5 As MD5 = New MD5CryptoServiceProvider()
        Dim result As Byte()
        result = md5.ComputeHash(Encoding.ASCII.GetBytes(password))
        Dim strBuilder As New StringBuilder()
        For i As Integer = 0 To result.Length - 1
            strBuilder.Append(result(i).ToString("x2"))
        Next
        Return strBuilder.ToString()
    End Function

    Private Sub doLogin(emailval As String, passwordval As String)
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://drive.google.com/uc?authuser=0&id=1CEc1XtYVqX4ma7iwTFR_WDXNv1N8brwZ&export=download")
        Dim response As System.Net.HttpWebResponse = request.GetResponse()
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
        Dim newestversion As String = sr.ReadToEnd()
        Dim connection As New MySqlConnection(newestversion)
        Dim hashedpassword = MDhash(passwordval)

        connection.Open()
        Dim command As New MySqlCommand("SELECT * FROM `u115781387_members` WHERE `email` = @email AND `password` = @password", connection)

        command.Parameters.Add("@email", MySqlDbType.VarChar).Value = emailval
        command.Parameters.Add("@password", MySqlDbType.VarChar).Value = hashedpassword

        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)
        If table.Rows.Count = 0 Then

        Else
            Username.Text = MaterialSingleLineTextField1.Text
            Password.Text = MaterialSingleLineTextField2.Text


            Dim sqlreader As MySqlDataReader = command.ExecuteReader()
            While (sqlreader.Read())
                Main.Label2.Text = sqlreader("username").ToString()
                Main.Label3.Text = sqlreader("date_update").ToString()
            End While

            My.Settings.Save()
            Me.Hide()
            Main.Show()
        End If
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        doLogin(MaterialSingleLineTextField1.Text, MaterialSingleLineTextField2.Text)
    End Sub
End Class
