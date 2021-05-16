Imports DevExpress.Xpo
Imports DevExpress.XtraGrid.Views.Base
Public Class Form3
    Dim Session1 As Session = XpoHelper.GetNewSession
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashScreenManager1.ShowWaitForm()
        XpCollection2.Session = Session1
        SplashScreenManager1.CloseWaitForm()
    End Sub
    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles GridView1.CustomUnboundColumnData
        Try
            Dim fila As Integer = e.ListSourceRowIndex
            Dim Local = GridView1.GetListSourceRowCellValue(fila, colNroLocal)
            Dim Result_Local As Integer = Session1.ExecuteScalar("SELECT COUNT(*) FROM Turnos WHERE NroLocal = " & Local)
            Dim Result_Compro As Integer = Session1.ExecuteScalar("SELECT COUNT(*) FROM Turnos WHERE Compro = 'SI' AND NroLocal = " & Local)
            Dim Result_Reprogramo As Integer = Session1.ExecuteScalar("SELECT COUNT(*) FROM Turnos WHERE Reprogramo = 'SI' AND NroLocal = " & Local)
            Dim Result_Ticket As Integer = Session1.ExecuteScalar("SELECT COUNT(*) FROM Turnos WHERE NroTicket <> 0 AND NroTicket IS NOT NULL AND NroLocal = " & Local)
            If Local <> 0 Then
                Select Case e.Column.Name
                    Case "GridColumn1"
                        e.Value = Result_Local
                    Case "GridColumn2"
                        e.Value = Result_Compro
                    Case "GridColumn3"
                        e.Value = Result_Reprogramo
                    Case "GridColumn4"
                        e.Value = Result_Ticket
                End Select
            End If
        Catch
        End Try
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GridControl1.ShowRibbonPrintPreview()
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Form4.Show()
    End Sub
End Class