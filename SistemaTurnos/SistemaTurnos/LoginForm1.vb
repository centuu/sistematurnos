Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Public Class LoginForm1
    Public Session1 As Session = XpoHelper.GetNewSession()
    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Dim existe = Session1.ExecuteScalar("SELECT COUNT(*) FROM Usuarios WHERE Usuario = '" & UsernameTextBox.Text & "'")
        If existe <> Nothing Then
            Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT Clave, NroLocal, Cupos, Nombre, TelLocal, Horario FROM Usuarios WHERE Usuario = '" & UsernameTextBox.Text & "'")
            If PasswordTextBox.Text = resultSet.ResultSet(0).Rows(0).Values(0) Then
                NroLocal = resultSet.ResultSet(0).Rows(0).Values(1)
                CupoLocal = resultSet.ResultSet(0).Rows(0).Values(2)
                NombreLocal = resultSet.ResultSet(0).Rows(0).Values(3)
                TelLocal = resultSet.ResultSet(0).Rows(0).Values(4)
                horarioLocal = resultSet.ResultSet(0).Rows(0).Values(5)
            Else
                MsgBox("CLAVE INCORRECTA.", vbOKOnly + vbExclamation, "Error")
                Exit Sub
            End If
        Else
            MsgBox("USUARIO INEXISTENTE.", vbOKOnly + vbExclamation, "Error")
            Exit Sub
        End If
        Me.Hide()
        UsernameTextBox.Text = ""
        PasswordTextBox.Text = ""
        If NroLocal = 123456 Then
            Form2.Show()
        Else
            Form1.Show()
        End If
    End Sub
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub
End Class
