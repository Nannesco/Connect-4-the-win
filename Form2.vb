Imports System.ComponentModel
Imports System.Net
Public Class Form2
    Dim WithEvents downloader As New System.Net.WebClient()
    Dim a = 1
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value <= 90 Then
            ProgressBar1.Value = ProgressBar1.Value + 10
        ElseIf ProgressBar1.Value = 100 Then
            Form1.Show()
            Me.Hide()
            Form1.reboot = False
            ProgressBar1.Value = 0
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)
        My.Computer.FileSystem.CreateDirectory(Form1.appdata)
        If System.IO.File.Exists(Form1.appdata & "\C4TW_music.wav") = False Or System.IO.File.Exists(Form1.appdata & "\C4TW_background.png") = False Or System.IO.File.Exists(Form1.appdata & "\C4TW_P1.png") = False Or System.IO.File.Exists(Form1.appdata & "\C4TW_P2.png") = False Or System.IO.File.Exists(Form1.appdata & "\C4TW_P1_Won.png") = False Or System.IO.File.Exists(Form1.appdata & "\C4TW_P2_Won.png") = False Then
            MsgBox("The resource pack that contains music and graphic is required to launch the game.
You need a network connection to download all the data. Press 'OK' when you're ready.", MsgBoxStyle.Information, "Resource pack missing")
            update()
        Else
            ProgressBar1.Value = 0
            Timer1.Start()
            My.Computer.Audio.Play(Form1.appdata & "\C4TW_music.wav", AudioPlayMode.BackgroundLoop)
        End If
    End Sub
    Private Sub Form2_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If Form1.reboot = True Then
            Timer1.Start()
        End If
        Form1.TimerReboot.Stop()
        Erase Form1.matrix
        ReDim Form1.matrix(7, 6)
        Form1.PB00.BackgroundImage = Nothing
    End Sub

    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Timer1.Stop()
    End Sub
    Private Sub update()
        Label2.Hide()
        Try
            My.Computer.Network.Ping("www.google.com")
        Catch ex As Exception
            MsgBox("The game failed to connect into the Network!, verify your connection status and retry.", MsgBoxStyle.Critical, "Connection error")
            End
        End Try
        Try
            Label1.Text = "downloading music..."
            Select Case (a)
                Case 1
                    downloader.DownloadFileAsync(New Uri("https://github.com/Nannesco/Connect-4-the-win/raw/main/updated_resource_pack/C4TW_music.wav"), Form1.appdata & "\C4TW_music.wav")
                    'ProgressBar1.Value = 50
                Case 2
                    Label1.Text = "downloading background..."
                    downloader.DownloadFileAsync(New Uri("https://github.com/Nannesco/Connect-4-the-win/raw/main/updated_resource_pack/C4TW_background.png"), Form1.appdata & "\C4TW_background.png")
                    'ProgressBar1.Value = 60
                Case 3
                    Label1.Text = "downloading 1P piece image..."
                    downloader.DownloadFileAsync(New Uri("https://github.com/Nannesco/Connect-4-the-win/raw/main/updated_resource_pack/C4TW_P1.png"), Form1.appdata & "\C4TW_P1.png")
                    'ProgressBar1.Value = 70
                Case 4
                    Label1.Text = "downloading 2P piece image..."
                    downloader.DownloadFileAsync(New Uri("https://github.com/Nannesco/Connect-4-the-win/raw/main/updated_resource_pack/C4TW_P2.png"), Form1.appdata & "\C4TW_P2.png")
                    'ProgressBar1.Value = 75
                Case 5
                    Label1.Text = "downloading 1P piece image (Won)..."
                    downloader.DownloadFileAsync(New Uri("https://github.com/Nannesco/Connect-4-the-win/raw/main/updated_resource_pack/C4TW_P1_Won.png"), Form1.appdata & "\C4TW_P1_Won.png")
                    'ProgressBar1.Value = 80
                Case 6
                    Label1.Text = "downloading 2P piece image (Won)..."
                    downloader.DownloadFileAsync(New Uri("https://github.com/Nannesco/Connect-4-the-win/raw/main/updated_resource_pack/C4TW_P2_Won.png"), Form1.appdata & "\C4TW_P2_Won.png")
                   ' ProgressBar1.Value = 85
                Case 7
                    Label1.Text = "downloading board..."
                    downloader.DownloadFileAsync(New Uri("https://github.com/Nannesco/Connect-4-the-win/raw/main/updated_resource_pack/C4TW_board.png"), Form1.appdata & "\C4TW_board.png")
                    'ProgressBar1.Value = 90
                Case 8
                    'Label1.Text = "launching game!"
                    'Threading.Thread.Sleep(2000)
                    'ProgressBar1.Value = 100
                    'Threading.Thread.Sleep(500)
                    Form1.reboot = False
                    My.Computer.Audio.Play(Form1.appdata & "\C4TW_music.wav", AudioPlayMode.BackgroundLoop)
                    ProgressBar1.Value = 0
                    Application.Restart()
            End Select
        Catch ex As Exception
            System.IO.File.Delete(Form1.appdata & "\C4TW_music.wav")
            System.IO.File.Delete(Form1.appdata & "\C4TW_background.png")
            System.IO.File.Delete(Form1.appdata & "\C4TW_P1.png")
            System.IO.File.Delete(Form1.appdata & "\C4TW_P2.png")
            System.IO.File.Delete(Form1.appdata & "\C4TW_P1_Won.png")
            System.IO.File.Delete(Form1.appdata & "\C4TW_P2_Won.png")
            System.IO.File.Delete(Form1.appdata & "\C4TW_board.png")
            MsgBox("The game failed to download the update. Probably the server is down. Retry later or, if this problem persists, visit: " & vbCrLf &
"https://github.com/Nannesco/Connect-4-the-win/tree/main/updated_resource_pack" & vbCrLf & "or try to update manually putting the files into AppData folder.", MsgBoxStyle.Critical, "Download Error")
            End
        End Try

    End Sub

    Private Sub downloader_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles downloader.DownloadFileCompleted
        ProgressBar1.Value = 0
        a = a + 1
        update()
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.U
                Timer1.Stop()
                ProgressBar1.Value = 0
                MsgBox("The resource pack that contains music and graphic will be updated...
You need a network connection to download all the data. Press 'OK' when you're ready.", MsgBoxStyle.Information, "")
                update()
        End Select
    End Sub

    Private Sub downloader_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles downloader.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage()
    End Sub
End Class