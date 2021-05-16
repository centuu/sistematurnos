Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.ConnectionParameters
Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DashboardViewer1.DashboardSource = Application.StartupPath & "\resumen.xml"
        Catch
        End Try
    End Sub
    Private Sub DashboardViewer1_ConfigureDataConnection(sender As Object, e As DashboardConfigureDataConnectionEventArgs) Handles DashboardViewer1.ConfigureDataConnection
        Try
            Dim parameters As SqlServerConnectionParametersBase = TryCast(e.ConnectionParameters, SqlServerConnectionParametersBase)
            If parameters IsNot Nothing Then
                parameters.ServerName = "localhost"
                parameters.UserName = "sa"
                parameters.DatabaseName = "TurnosMontagne_Test"
                parameters.Password = "lobito1.2016"
            End If
        Catch
        End Try
    End Sub
End Class