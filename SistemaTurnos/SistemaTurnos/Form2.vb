Imports DevExpress.Xpo
Public Class Form2
    Dim Session1 As Session = XpoHelper.GetNewSession
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashScreenManager1.ShowWaitForm()
        XpCollection1.Session = Session1
        XpCollection2.Session = Session1
        XpCollection3.Session = Session1
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridControl1.ShowRibbonPrintPreview()
    End Sub
    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Form3.Show()
    End Sub
End Class