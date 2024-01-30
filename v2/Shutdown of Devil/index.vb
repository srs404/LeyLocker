Imports System.Net
Imports System.IO
Public Class index
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Long) As Integer

    Dim ctrlkey As Boolean
    Dim shiftkey As Boolean
    Dim x As Boolean



    Private Sub index_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False
        If My.Settings.startup = True Then
            LeyLock.Show()
        End If
    End Sub

    Private Sub interval_Tick(sender As Object, e As EventArgs) Handles interval.Tick

        Try
            Dim mReq As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(My.Settings.ftplink + "lock.lance"), System.Net.FtpWebRequest)
            mReq.Credentials = New System.Net.NetworkCredential(My.Settings.user, My.Settings.pass)
            mReq.Method = System.Net.WebRequestMethods.Ftp.GetFileSize
            mReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            mReq.GetResponse()
            My.Settings.startup = True
            My.Settings.Save()
            interval.Stop()
            LeyLock.ShowDialog()
            Me.Close()
        Catch ex As WebException

        End Try
    End Sub

    Private Sub KeyPressTimer_Tick(sender As Object, e As EventArgs) Handles KeyPressTimer.Tick
        ctrlkey = GetAsyncKeyState(Keys.ControlKey)
        shiftkey = GetAsyncKeyState(Keys.ShiftKey)
        x = GetAsyncKeyState(Keys.X)

        If ctrlkey And shiftkey And x = True Then
            My.Settings.startup = True
            My.Settings.Save()
            interval.Stop()
            LeyLock.ShowDialog()
            Me.Close()
        End If
    End Sub
End Class