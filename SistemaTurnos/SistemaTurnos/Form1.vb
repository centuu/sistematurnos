Imports DevExpress.Xpo
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Grid
Public Class Form1
    Dim Session1 As Session = XpoHelper.GetNewSession
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashScreenManager2.ShowWaitForm()
        Me.Text &= " - LOCAL " & NombreLocal
        If ModoTest Then
            Me.Text &= " (CONECTADO A TEST)"
        End If
        XpCollection1.Session = Session1
        XpCollection2.Session = Session1
        LabelControl6.Text = NroLocal
        XpCollection2.CriteriaString = "NroLocal = " & NroLocal
        SplashScreenManager2.CloseWaitForm()
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Dim idHorario As Integer = Session1.ExecuteScalar("SELECT idHorario FROM Horarios WHERE descripcion = '" & ComboBoxEdit1.Text & "'")
            Dim NroOrden As Integer = Session1.ExecuteScalar("SELECT MAX(NroOrden) FROM Turnos WHERE Fecha = '" & DateEdit1.Text & "' AND Horario = " & idHorario)
            If NroOrden > 0 Then
                NroOrden += 1
            Else
                NroOrden = 1
            End If
            If TextEdit1.Text = "" Then
                MsgBox("Debe ingresar Nombre y Apellido del Cliente.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            If TextEdit2.Text = "" Then
                MsgBox("Debe ingresar DNI del Cliente.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            If TextEdit3.Text = "" Then
                MsgBox("Debe ingresar Telefono del Cliente.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            If TextEdit4.Text = "" Then
                MsgBox("Debe ingresar Mail del Cliente.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            If DateEdit1.EditValue = Nothing Then
                MsgBox("Debe ingresar una fecha.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            If ComboBoxEdit1.SelectedIndex = -1 Then
                MsgBox("Debe ingresar un horario.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            Session1.ExecuteNonQuery("INSERT INTO Turnos(NroLocal, Fecha, Horario, NroOrden, Cliente, dniCliente, telCliente, mailCliente) VALUES(" & NroLocal & ", '" & DateEdit1.Text & "', " & idHorario & ", " & NroOrden & ", '" & TextEdit1.Text & "', '" & TextEdit2.Text & "', '" & TextEdit3.Text & "', '" & TextEdit4.Text & "')")
            'DateEdit1.DateTime.DayOfWeek.ToString.ToUpper
            cuerpoMailstring = "<html><body>HOLA " & TextEdit1.Text & " <br /><br />
TE RECORDAMOS LOS DATOS DEL TURNO ASIGNADO PARA NUESTRO EVENTO:
<br /><br /><b>LOCAL:</b> " & NombreLocal & "
<br /><br /><b>DIA:</b> " & DateEdit1.Text & "
<br /><br /><b>HORA:</b> " & ComboBoxEdit1.Text & "
<br /><br /><b>ORDEN:</b> " & NroOrden & "
<br /><br />EN CASO DE QUERER CANCELAR ESTE TURNO PODES COMUNICARTE AL " & TelLocal & " DE " & horarioLocal & "
<br /><br /><br />No responder a este correo.
<br /><br /></body></html>"
            Sendmail("TURNO ASIGNADO", TextEdit4.Text, Application.StartupPath & "\1.jpg")
            MsgBox("El turno fue asignado correctamente!", vbOKOnly + vbInformation, "Hecho")
        Catch ex As Exception
            MsgBox("No se ha podido asignar el turno.", vbOKOnly + vbExclamation, "Atencion")
        End Try
        Limpiar()
    End Sub
    Private Sub Limpiar()
        Session1.DropIdentityMap()
        XpCollection1.Session = Session1
        XpCollection2.Session = Session1
        XpCollection1.Reload()
        XpCollection2.Reload()
        GridView1.RefreshData()
        XpCollection2.CriteriaString = "NroLocal = " & NroLocal
        TextEdit1.Text = ""
        TextEdit2.Text = ""
        TextEdit3.Text = ""
        TextEdit4.Text = ""
        DateEdit1.EditValue = Nothing
        ComboBoxEdit1.SelectedIndex = -1
        ComboBoxEdit1.Properties.Items.Clear()
    End Sub
    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit1.EditValueChanged
        If DateEdit1.EditValue <> Nothing Then
            Try
                ComboBoxEdit1.SelectedIndex = -1
                ComboBoxEdit1.Properties.Items.Clear()
                Dim resultData = Session1.ExecuteQuery("SELECT idHorario, descripcion FROM Horarios")
                For j As Integer = 0 To resultData.ResultSet(0).Rows.Length - 1
                    Dim Cupo As Integer = Session1.ExecuteScalar("SELECT COUNT(*) FROM Turnos WHERE Fecha = '" & DateEdit1.Text & "' AND Horario = " & resultData.ResultSet(0).Rows(j).Values(0) & " AND NroLocal = " & NroLocal)
                    If Cupo < CupoLocal Then
                        ComboBoxEdit1.Properties.Items.Add(resultData.ResultSet(0).Rows(j).Values(1))
                    End If
                Next
            Catch ex As Exception
                MsgBox("Ha ocurrido un error cargando los horarios disponibles.", vbOKOnly + vbExclamation, "Atencion")
            End Try
        End If
    End Sub
    Private Sub GridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridView1.RowCellClick
        TextEdit1.Text = GridView1.GetFocusedRowCellValue(colCliente)
        TextEdit2.Text = GridView1.GetFocusedRowCellValue(coldniCliente)
        TextEdit3.Text = GridView1.GetFocusedRowCellValue(coltelCliente)
        TextEdit4.Text = GridView1.GetFocusedRowCellValue(colmailCliente)
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
    Private Sub GridView1_ShowingPopupEditForm(sender As Object, e As ShowingPopupEditFormEventArgs) Handles GridView1.ShowingPopupEditForm
        e.EditForm.StartPosition = FormStartPosition.CenterParent
    End Sub
    Private Sub GridView1_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles GridView1.EditFormPrepared
        'e.BindableControls(colidTurno).Enabled = False
        e.BindableControls(colFecha).Enabled = False
        e.BindableControls(colHorario).Enabled = False
        e.BindableControls(colNroOrden).Enabled = False
        e.BindableControls(colCliente).Enabled = False
        e.BindableControls(coldniCliente).Enabled = False
        e.BindableControls(coltelCliente).Enabled = False
        e.BindableControls(colmailCliente).Enabled = False
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If MsgBox("Deseas cancelar este turno?", vbYesNo + vbQuestion, "Cancelar Turno") = vbYes Then
            Try
                Session1.ExecuteNonQuery("DELETE FROM Turnos WHERE idTurno = " & GridView1.GetFocusedRowCellValue(colidTurno))
                MsgBox("El turno fue cancelado.", vbOKOnly + vbInformation, "Hecho")
            Catch ex As Exception
                MsgBox("No se ha podido cancelar el turno.", vbOKOnly + vbExclamation, "Atencion")
            End Try
            Limpiar()
        End If
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try
            Dim idHorario As Integer = Session1.ExecuteScalar("SELECT idHorario FROM Horarios WHERE descripcion = '" & ComboBoxEdit1.Text & "'")
            Dim NroOrden As Integer = Session1.ExecuteScalar("SELECT MAX(NroOrden) FROM Turnos WHERE Fecha = '" & DateEdit1.Text & "' AND Horario = " & idHorario)
            If NroOrden > 0 Then
                NroOrden += 1
            Else
                NroOrden = 1
            End If
            If TextEdit1.Text = "" Then
                MsgBox("Debe ingresar Nombre y Apellido del Cliente.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            If TextEdit2.Text = "" Then
                MsgBox("Debe ingresar DNI del Cliente.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            If TextEdit3.Text = "" Then
                MsgBox("Debe ingresar Telefono del Cliente.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            If TextEdit4.Text = "" Then
                MsgBox("Debe ingresar Mail del Cliente.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            If DateEdit1.EditValue = Nothing Then
                MsgBox("Debe ingresar una fecha.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            If ComboBoxEdit1.SelectedIndex = -1 Then
                MsgBox("Debe ingresar un horario.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            Session1.ExecuteNonQuery("UPDATE Turnos SET Fecha = '" & DateEdit1.Text & "', NroOrden = " & NroOrden & ", Horario = " & idHorario & " WHERE idTurno = " & GridView1.GetFocusedRowCellValue(colidTurno))
            'DateEdit1.DateTime.DayOfWeek.ToString.ToUpper
            cuerpoMailstring = "<html><body>HOLA " & TextEdit1.Text & " <br /><br />
TE RECORDAMOS LOS DATOS DEL TURNO ASIGNADO PARA NUESTRO EVENTO:
<br /><br /><b>LOCAL:</b> " & NombreLocal & "
<br /><br /><b>DIA:</b> " & DateEdit1.Text & "
<br /><br /><b>HORA:</b> " & ComboBoxEdit1.Text & "
<br /><br /><b>ORDEN:</b> " & NroOrden & "
<br /><br />EN CASO DE QUERER CANCELAR ESTE TURNO PODES COMUNICARTE AL " & TelLocal & " DE " & horarioLocal & "
<br /><br /><br />No responder a este correo.
<br /><br /></body></html>"
            Sendmail("TURNO REPROGRAMADO", TextEdit4.Text, Application.StartupPath & "\1.jpg")
            MsgBox("El turno fue reprogramado correctamente!", vbOKOnly + vbInformation, "Hecho")
        Catch ex As Exception
            MsgBox("No se ha podido reprogramar el turno.", vbOKOnly + vbExclamation, "Atencion")
        End Try
        Limpiar()
    End Sub
End Class