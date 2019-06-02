Imports Transitions

Public Class Main
    Dim MouseOnButton1 As Boolean = False
    Dim MouseOnButton2 As Boolean = False

    Private Sub FlatClose1_Click(sender As Object, e As MouseEventArgs) Handles FlatClose1.MouseClick
        'Me.Hide()
        Me.Hide()
        'onCloseWindow.ShowBalloonTip(500, "Enjoy", "Infinyctus is running on the background!", ToolTipIcon.Info)


    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'onCloseWindow.InitializeLifetimeService()
        'Me.ShowInTaskbar = False

        MaterialTabControl1.SelectTab(2)

        Dim news() As String = {"Ola", "Amigos", "colegas"}
        Dim images As List(Of String) = New List(Of String)
        images.Add("http://i.telegraph.co.uk/multimedia/archive/02351/Jaguar-F-type-9_2351861k.jpg")
        images.Add("http://i.telegraph.co.uk/multimedia/archive/02351/Jaguar-F-type-5_2351885k.jpg")
        images.Add("http://i.telegraph.co.uk/multimedia/archive/02351/Jaguar-F-type-7_2351893k.jpg")

        Dim il As ImageList = New ImageList()

        DownloadImagesFromWeb(images, il)

        il.ImageSize = New Size(32, 32)
        Dim count As Integer = 0
        ListView1.LargeImageList = il


        For Each objeto As String In news
            Dim lst As ListViewItem = New ListViewItem()
            lst.Text = objeto
            lst.ImageIndex = count + 1
            ListView1.Items.Add(lst)

        Next







    End Sub

    Private Sub DownloadImagesFromWeb(address As List(Of String), il As ImageList)
        For Each img In address
            Dim request As System.Net.WebRequest = System.Net.WebRequest.Create(img)
            Dim response As System.Net.WebResponse = request.GetResponse()
            Dim responseStream As System.IO.Stream = response.GetResponseStream()
            Dim bitmapImage As Bitmap = New Bitmap(responseStream)
            responseStream.Dispose()
            il.Images.Add(bitmapImage)
        Next
    End Sub



    Private Sub onCloseWindow_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles onCloseWindow.MouseDoubleClick
        Me.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Me.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Environment.Exit(0)
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick

    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles BunifuImageButton2.Click
        Dim panelHideTransition As New Transition(New TransitionType_Acceleration(600))

        Dim C As New Color
        C = Color.FromArgb(0, 255, 255, 255)
        panelHideTransition.add(Panel2, "Width", 0)
        panelHideTransition.run()
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Dim panelShowTransition As New Transition(New TransitionType_Deceleration(600))

        Dim C As New Color
        C = Color.FromArgb(255, 255, 255, 255)
        panelShowTransition.add(Panel2, "Width", 226)
        panelShowTransition.run()
    End Sub
End Class