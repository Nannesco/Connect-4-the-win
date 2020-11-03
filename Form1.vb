Public Class Form1
    Public appdata As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\C4TW"
    Public matrix(7, 6) As Integer
    Dim fullx, fully As Integer
    Dim y(6) As Integer
    Dim player As Integer = 1
    Public reboot, hideshow As Boolean
    Dim indexL, indexL2, indexH2, indexL3, indexH3, indexL4, indexH4, indexL5, indexH5
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.Label2.Hide()
        Form2.Label1.Text = "rebooting game"
        BackgroundImage = New Bitmap(appdata & "\C4TW_background.png")
        board.BackgroundImage = New Bitmap(appdata & "\C4TW_board.png")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If y(0) < 6 Then
            matrix(0, y(0)) = player
            y(0) = y(0) + 1
            point()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If y(1) < 6 Then
            matrix(1, y(1)) = player
            y(1) = y(1) + 1
            point()
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If y(2) < 6 Then
            matrix(2, y(2)) = player
            y(2) = y(2) + 1
            point()
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If y(3) < 6 Then
            matrix(3, y(3)) = player
            y(3) = y(3) + 1
            point()
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If y(4) < 6 Then
            matrix(4, y(4)) = player
            y(4) = y(4) + 1
            point()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If y(5) < 6 Then
            matrix(5, y(5)) = player
            y(5) = y(5) + 1
            point()
        End If
    End Sub

    Private Sub TimerFull_Tick(sender As Object, e As EventArgs) Handles TimerFull.Tick
        If matrix(0, 5) <> 0 And matrix(1, 5) <> 0 And matrix(2, 5) <> 0 And matrix(3, 5) <> 0 And matrix(4, 5) <> 0 And matrix(5, 5) <> 0 And matrix(6, 5) <> 0 Then
            TimerReboot.Start()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If y(6) < 6 Then
            matrix(6, y(6)) = player
            y(6) = y(6) + 1
            point()
        End If
    End Sub

    Private Sub TimerReboot_Tick(sender As Object, e As EventArgs) Handles TimerReboot.Tick
        Form2.Show()
        Me.Dispose()
    End Sub

    Private Sub TimerWAB_Tick(sender As Object, e As EventArgs) Handles TimerWAB.Tick
        Button1.Show()
        Button2.Show()
        Button3.Show()
        Button4.Show()
        Button5.Show()
        Button6.Show()
        Button7.Show()
    End Sub


    Private Sub TimerDX_Tick(sender As Object, e As EventArgs) Handles TimerDX.Tick
        If matrix(indexL4, indexH4) = 1 And matrix(indexL4 + 1, indexH4 + 1) = 1 And matrix(indexL4 + 2, indexH4 + 2) = 1 And matrix(indexL4 + 3, indexH4 + 3) = 1 Then
            'MsgBox("G1WON")
            matrix(indexL4, indexH4) = 3
            matrix(indexL4 + 1, indexH4 + 1) = 3
            matrix(indexL4 + 2, indexH4 + 2) = 3
            matrix(indexL4 + 3, indexH4 + 3) = 3
            player = 0
            point()
        End If

        If matrix(indexL4, indexH4) = 2 And matrix(indexL4 + 1, indexH4 + 1) = 2 And matrix(indexL4 + 2, indexH4 + 2) = 2 And matrix(indexL4 + 3, indexH4 + 3) = 2 Then
            'MsgBox("G2WON")
            matrix(indexL4, indexH4) = 4
            matrix(indexL4 + 1, indexH4 + 1) = 4
            matrix(indexL4 + 2, indexH4 + 2) = 4
            matrix(indexL4 + 3, indexH4 + 3) = 4
            player = 0
            point()
        End If

        If indexL4 < 4 Then
            indexL4 = indexL4 + 1
        Else
            indexL4 = 0
            If indexH4 < 3 Then
                indexH4 = indexH4 + 1
            Else
                indexH4 = 0
            End If
        End If
    End Sub

    Private Sub TimerSX_Tick(sender As Object, e As EventArgs) Handles TimerSX.Tick
        If indexL5 = 0 Then
            indexL5 = 6
        End If
        If matrix(indexL5, indexH5) = 1 And matrix(indexL5 - 1, indexH5 + 1) = 1 And matrix(indexL5 - 2, indexH5 + 2) = 1 And matrix(indexL5 - 3, indexH5 + 3) = 1 Then
            'MsgBox("G1WON")
            matrix(indexL5, indexH5) = 3
            matrix(indexL5 - 1, indexH5 + 1) = 3
            matrix(indexL5 - 2, indexH5 + 2) = 3
            matrix(indexL5 - 3, indexH5 + 3) = 3
            player = 0
            point()
        End If

        If matrix(indexL5, indexH5) = 2 And matrix(indexL5 - 1, indexH5 + 1) = 2 And matrix(indexL5 - 2, indexH5 + 2) = 2 And matrix(indexL5 - 3, indexH5 + 3) = 2 Then
            'MsgBox("G2WON")
            matrix(indexL5, indexH5) = 4
            matrix(indexL5 - 1, indexH5 + 1) = 4
            matrix(indexL5 - 2, indexH5 + 2) = 4
            matrix(indexL5 - 3, indexH5 + 3) = 4
            player = 0
            point()
        End If

        If indexL5 > 3 Then
            indexL5 = indexL5 - 1
        Else
            indexL5 = 6
            If indexH5 < 3 Then
                indexH5 = indexH5 + 1
            Else
                indexH5 = 0
            End If
        End If
    End Sub


    Private Sub TimerVertic_Tick(sender As Object, e As EventArgs) Handles TimerVertic.Tick
        If matrix(indexL3, indexH3) = 1 And matrix(indexL3, indexH3 + 1) = 1 And matrix(indexL3, indexH3 + 2) = 1 And matrix(indexL3, indexH3 + 3) = 1 Then
            'MsgBox("G1WON")
            matrix(indexL3, indexH3) = 3
            matrix(indexL3, indexH3 + 1) = 3
            matrix(indexL3, indexH3 + 2) = 3
            matrix(indexL3, indexH3 + 3) = 3
            player = 0
            point()
        End If

        If matrix(indexL3, indexH3) = 2 And matrix(indexL3, indexH3 + 1) = 2 And matrix(indexL3, indexH3 + 2) = 2 And matrix(indexL3, indexH3 + 3) = 2 Then
            'MsgBox("G2WON")
            matrix(indexL3, indexH3) = 4
            matrix(indexL3, indexH3 + 1) = 4
            matrix(indexL3, indexH3 + 2) = 4
            matrix(indexL3, indexH3 + 3) = 4
            player = 0
            point()
        End If

        If indexH3 < 2 Then
            indexH3 = indexH3 + 1
        Else
            indexH3 = 0
            If indexL3 <= 6 Then
                indexL3 = indexL3 + 1
            Else
                indexL3 = 0
            End If
        End If
    End Sub

    Private Sub TimerOrizz_Tick(sender As Object, e As EventArgs) Handles TimerOrizz.Tick
        If (matrix(indexL2, indexH2) = 1 And matrix(indexL2 + 1, indexH2) = 1 And matrix(indexL2 + 2, indexH2) = 1 And matrix(indexL2 + 3, indexH2) = 1) Then
            'MsgBox("G1WON")
            matrix(indexL2, indexH2) = 3
            matrix(indexL2 + 1, indexH2) = 3
            matrix(indexL2 + 2, indexH2) = 3
            matrix(indexL2 + 3, indexH2) = 3
            player = 0
            point()
        End If

        If (matrix(indexL2, indexH2) = 2 And matrix(indexL2 + 1, indexH2) = 2 And matrix(indexL2 + 2, indexH2) = 2 And matrix(indexL2 + 3, indexH2) = 2) Then
            'MsgBox("G2WON")
            matrix(indexL2, indexH2) = 4
            matrix(indexL2 + 1, indexH2) = 4
            matrix(indexL2 + 2, indexH2) = 4
            matrix(indexL2 + 3, indexH2) = 4
            player = 0
            point()
        End If

        If indexL2 < 4 Then
            indexL2 = indexL2 + 1
        Else
            indexL2 = 0
            If indexH2 <= 5 Then
                indexH2 = indexH2 + 1
            Else
                indexH2 = 0
            End If
        End If
    End Sub
    Public Sub point()
        TimerWAB.Stop()
        indexL = 0
        While indexL <= 6
            If matrix(indexL, 0) = 1 Then
                Select Case indexL
                    Case 0
                        PB00.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 1
                        PB10.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 2
                        PB20.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 3
                        PB30.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 4
                        PB40.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 5
                        PB50.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 6
                        PB60.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                End Select
            ElseIf matrix(indexL, 0) = 2 Then
                Select Case indexL
                    Case 0
                        PB00.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 1
                        PB10.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 2
                        PB20.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 3
                        PB30.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 4
                        PB40.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 5
                        PB50.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 6
                        PB60.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                End Select
            ElseIf matrix(indexL, 0) = 3 Then
                Select Case indexL
                    Case 0
                        PB00.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 1
                        PB10.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 2
                        PB20.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 3
                        PB30.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 4
                        PB40.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 5
                        PB50.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 6
                        PB60.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                End Select
            ElseIf matrix(indexL, 0) = 4 Then
                Select Case indexL
                    Case 0
                        PB00.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 1
                        PB10.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 2
                        PB20.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 3
                        PB30.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 4
                        PB40.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 5
                        PB50.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 6
                        PB60.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                End Select
            End If
            indexL = indexL + 1
        End While


        indexL = 0
        While indexL <= 6
            If matrix(indexL, 1) = 1 Then
                Select Case indexL
                    Case 0
                        PB01.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 1
                        PB11.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 2
                        PB21.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 3
                        PB31.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 4
                        PB41.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 5
                        PB51.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 6
                        PB61.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                End Select
            ElseIf matrix(indexL, 1) = 2 Then
                Select Case indexL
                    Case 0
                        PB01.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 1
                        PB11.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 2
                        PB21.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 3
                        PB31.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 4
                        PB41.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 5
                        PB51.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 6
                        PB61.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                End Select
            ElseIf matrix(indexL, 1) = 3 Then
                Select Case indexL
                    Case 0
                        PB01.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 1
                        PB11.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 2
                        PB21.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 3
                        PB31.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 4
                        PB41.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 5
                        PB51.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 6
                        PB61.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                End Select
            ElseIf matrix(indexL, 1) = 4 Then
                Select Case indexL
                    Case 0
                        PB01.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 1
                        PB11.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 2
                        PB21.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 3
                        PB31.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 4
                        PB41.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 5
                        PB51.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 6
                        PB61.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                End Select
            End If
            indexL = indexL + 1
        End While



        indexL = 0
        While indexL <= 6
            If matrix(indexL, 2) = 1 Then
                Select Case indexL
                    Case 0
                        PB02.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 1
                        PB12.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 2
                        PB22.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 3
                        PB32.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 4
                        PB42.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 5
                        PB52.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 6
                        PB62.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                End Select
            ElseIf matrix(indexL, 2) = 2 Then
                Select Case indexL
                    Case 0
                        PB02.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 1
                        PB12.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 2
                        PB22.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 3
                        PB32.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 4
                        PB42.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 5
                        PB52.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 6
                        PB62.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                End Select
            ElseIf matrix(indexL, 2) = 3 Then
                Select Case indexL
                    Case 0
                        PB02.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 1
                        PB12.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 2
                        PB22.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 3
                        PB32.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 4
                        PB42.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 5
                        PB52.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 6
                        PB62.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                End Select
            ElseIf matrix(indexL, 2) = 4 Then
                Select Case indexL
                    Case 0
                        PB02.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 1
                        PB12.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 2
                        PB22.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 3
                        PB32.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 4
                        PB42.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 5
                        PB52.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 6
                        PB62.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                End Select
            End If

            indexL = indexL + 1
        End While

        indexL = 0
        While indexL <= 6
            If matrix(indexL, 3) = 1 Then
                Select Case indexL
                    Case 0
                        PB03.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 1
                        PB13.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 2
                        PB23.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 3
                        PB33.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 4
                        PB43.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 5
                        PB53.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 6
                        PB63.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                End Select
            ElseIf matrix(indexL, 3) = 2 Then
                Select Case indexL
                    Case 0
                        PB03.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 1
                        PB13.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 2
                        PB23.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 3
                        PB33.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 4
                        PB43.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 5
                        PB53.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 6
                        PB63.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                End Select
            ElseIf matrix(indexL, 3) = 3 Then
                Select Case indexL
                    Case 0
                        PB03.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 1
                        PB13.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 2
                        PB23.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 3
                        PB33.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 4
                        PB43.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 5
                        PB53.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 6
                        PB63.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                End Select
            ElseIf matrix(indexL, 3) = 4 Then
                Select Case indexL
                    Case 0
                        PB03.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 1
                        PB13.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 2
                        PB23.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 3
                        PB33.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 4
                        PB43.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 5
                        PB53.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 6
                        PB63.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                End Select
            End If
            indexL = indexL + 1
        End While




        indexL = 0
        While indexL <= 6
            If matrix(indexL, 4) = 1 Then
                Select Case indexL
                    Case 0
                        PB04.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 1
                        PB14.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 2
                        PB24.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 3
                        PB34.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 4
                        PB44.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 5
                        PB54.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 6
                        PB64.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                End Select
            ElseIf matrix(indexL, 4) = 2 Then
                Select Case indexL
                    Case 0
                        PB04.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 1
                        PB14.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 2
                        PB24.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 3
                        PB34.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 4
                        PB44.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 5
                        PB54.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 6
                        PB64.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                End Select
            ElseIf matrix(indexL, 4) = 3 Then
                Select Case indexL
                    Case 0
                        PB04.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 1
                        PB14.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 2
                        PB24.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 3
                        PB34.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 4
                        PB44.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 5
                        PB54.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 6
                        PB64.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                End Select
            ElseIf matrix(indexL, 4) = 4 Then
                Select Case indexL
                    Case 0
                        PB04.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 1
                        PB14.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 2
                        PB24.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 3
                        PB34.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 4
                        PB44.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 5
                        PB54.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 6
                        PB64.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                End Select
            End If
            indexL = indexL + 1
        End While




        indexL = 0
        While indexL <= 6
            If matrix(indexL, 5) = 1 Then
                Select Case indexL
                    Case 0
                        PB05.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 1
                        PB15.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 2
                        PB25.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 3
                        PB35.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 4
                        PB45.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 5
                        PB55.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                    Case 6
                        PB65.BackgroundImage = New Bitmap(appdata & "\C4TW_P1.png")
                End Select
            ElseIf matrix(indexL, 5) = 2 Then
                Select Case indexL
                    Case 0
                        PB05.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 1
                        PB15.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 2
                        PB25.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 3
                        PB35.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 4
                        PB45.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 5
                        PB55.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                    Case 6
                        PB65.BackgroundImage = New Bitmap(appdata & "\C4TW_P2.png")
                End Select
            ElseIf matrix(indexL, 5) = 3 Then
                Select Case indexL
                    Case 0
                        PB05.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 1
                        PB15.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 2
                        PB25.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 3
                        PB35.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 4
                        PB45.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 5
                        PB55.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                    Case 6
                        PB65.BackgroundImage = New Bitmap(appdata & "\C4TW_P1_Won.png")
                End Select
            ElseIf matrix(indexL, 5) = 4 Then
                Select Case indexL
                    Case 0
                        PB05.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 1
                        PB15.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 2
                        PB25.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 3
                        PB35.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 4
                        PB45.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 5
                        PB55.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                    Case 6
                        PB65.BackgroundImage = New Bitmap(appdata & "\C4TW_P2_Won.png")
                End Select
            End If
            indexL = indexL + 1
        End While

        If player = 1 Then
            player = 2
        ElseIf player = 2 Then
            player = 1
        End If
        If player = 0 Then
            reboot = True
            TimerReboot.Start()
        End If
        If player = 1 Then
            Button1.ForeColor = Color.Blue
            Button2.ForeColor = Color.Blue
            Button3.ForeColor = Color.Blue
            Button4.ForeColor = Color.Blue
            Button5.ForeColor = Color.Blue
            Button6.ForeColor = Color.Blue
            Button7.ForeColor = Color.Blue
        ElseIf player = 2 Then
            Button1.ForeColor = Color.Red
            Button2.ForeColor = Color.Red
            Button3.ForeColor = Color.Red
            Button4.ForeColor = Color.Red
            Button5.ForeColor = Color.Red
            Button6.ForeColor = Color.Red
            Button7.ForeColor = Color.Red
        End If
        Button1.Hide()
        Button2.Hide()
        Button3.Hide()
        Button4.Hide()
        Button5.Hide()
        Button6.Hide()
        Button7.Hide()
        TimerWAB.Start()
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If reboot = False Then
            End
        End If
    End Sub
End Class
