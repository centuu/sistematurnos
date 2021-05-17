Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Public Class LoginForm1
    Public Session1 As Session = XpoHelper.GetNewSession()
    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        Dim existe As Integer = Session1.ExecuteScalar("SELECT COUNT(idUsuario) FROM Usuarios WHERE Nombre = '" & UsernameTextBox.Text & "'")
        If existe > 0 Then
            Dim resultSet As SelectedData = Session1.ExecuteQuery("SELECT Clave FROM Usuarios WHERE Nombre = '" & UsernameTextBox.Text & "'")
            If PasswordTextBox.Text <> resultSet.ResultSet(0).Rows(0).Values(0) Then
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
        Form1.Show()
    End Sub
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        CAMBIARCLAVE.Show()
    End Sub
End Class
