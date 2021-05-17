Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class Form1
    Dim Session1 As Session = XpoHelper.GetNewSession
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashScreenManager2.ShowWaitForm()
        XpCollection1.Session = Session1
        XpCollection2.Session = Session1
        XpCollection3.Session = Session1
        XpCollection4.Session = Session1
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
            If LookUpEdit1.EditValue = Nothing Then
                MsgBox("Debe ingresar un barbero.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            If LookUpEdit2.EditValue = Nothing Then
                MsgBox("Debe ingresar un servicio.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            Dim idTurno As Integer = Session1.ExecuteScalar("SELECT MAX(idTurno) FROM Turnos") + 1
            Session1.ExecuteNonQuery("INSERT INTO Turnos(idTurno, Fecha, Horario, NroOrden, Cliente, dniCliente, telCliente, mailCliente) VALUES(" & idTurno & ", '" & DateEdit1.Text & "', " & idHorario & ", " & NroOrden & ", '" & TextEdit1.Text & "', '" & TextEdit2.Text & "', '" & TextEdit3.Text & "', '" & TextEdit4.Text & "')")
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
        XpCollection3.Session = Session1
        XpCollection4.Session = Session1
        XpCollection1.Reload()
        XpCollection2.Reload()
        XpCollection3.Reload()
        XpCollection4.Reload()
        GridView1.RefreshData()
        TextEdit1.Text = ""
        TextEdit2.Text = ""
        TextEdit3.Text = ""
        TextEdit4.Text = ""
        DateEdit1.EditValue = Nothing
        ComboBoxEdit1.SelectedIndex = -1
        ComboBoxEdit1.Properties.Items.Clear()
        LookUpEdit1.EditValue = Nothing
        LookUpEdit2.EditValue = Nothing
    End Sub
    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DateEdit1.EditValueChanged
        If DateEdit1.EditValue <> Nothing Then
            Try
                ComboBoxEdit1.SelectedIndex = -1
                ComboBoxEdit1.Properties.Items.Clear()
                Dim resultData = Session1.ExecuteQuery("SELECT idHorario, descripcion FROM Horarios")
                For j As Integer = 0 To resultData.ResultSet(0).Rows.Length - 1
                    Dim Cupo As Integer = Session1.ExecuteScalar("SELECT COUNT(idTurno) FROM Turnos WHERE Fecha = '" & DateEdit1.Text & "' AND Horario = " & resultData.ResultSet(0).Rows(j).Values(0))
                    If Cupo = 0 Then
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
        e.BindableControls(colFecha).Enabled = False
        e.BindableControls(colHorario).Enabled = False
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
            If LookUpEdit1.EditValue = Nothing Then
                MsgBox("Debe ingresar un barbero.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            If LookUpEdit2.EditValue = Nothing Then
                MsgBox("Debe ingresar un servicio.", vbOKOnly + vbExclamation, "Atencion")
                Exit Sub
            End If
            Session1.ExecuteNonQuery("UPDATE Turnos SET Fecha = '" & DateEdit1.Text & "', NroOrden = " & NroOrden & ", Horario = " & idHorario & " WHERE idTurno = " & GridView1.GetFocusedRowCellValue(colidTurno))
            MsgBox("El turno fue reprogramado correctamente!", vbOKOnly + vbInformation, "Hecho")
        Catch ex As Exception
            MsgBox("No se ha podido reprogramar el turno.", vbOKOnly + vbExclamation, "Atencion")
        End Try
        Limpiar()
    End Sub
    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Limpiar()
    End Sub
    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        GridView1.ShowRibbonPrintPreview()
    End Sub
    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
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
    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles GridView1.CustomUnboundColumnData
        Try
            Dim Resultset_Servicio As SelectedData = Session1.ExecuteQuery("SELECT Precio FROM Servicios WHERE idServicio = " & GridView1.GetListSourceRowCellValue(e.ListSourceRowIndex, colidServicio))
            Select Case e.Column.Name
                Case "GridColumn1"
                    e.Value = Resultset_Servicio.ResultSet(0).Rows(0).Values(0)
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarButtonItem2_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        USUARIOS.Show()
    End Sub
    Private Sub BarButtonItem3_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        BARBEROS.Show()
    End Sub
    Private Sub BarButtonItem4_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        SERVICIOS.Show()
    End Sub
End Class