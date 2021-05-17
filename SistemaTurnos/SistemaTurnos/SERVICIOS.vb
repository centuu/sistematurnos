﻿Imports DevExpress.Xpo
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Grid
Public Class SERVICIOS
    Dim Session1 As Session = XpoHelper.GetNewSession
    Dim editar As Boolean
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        AgregarRegistro()
    End Sub
    Private Sub GridView1_ShowingPopupEditForm(sender As Object, e As ShowingPopupEditFormEventArgs) Handles GridView1.ShowingPopupEditForm
        e.EditForm.StartPosition = FormStartPosition.CenterParent
        If editar Then
            e.EditForm.Text = "Editar"
        Else
            e.EditForm.Text = "Agregar"
        End If
    End Sub
    Private Sub BarButtonItem2_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        editar = True
        GridView1.ShowEditForm()
    End Sub
    Private Sub BarButtonItem3_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        BorrarRegistro()
    End Sub
    Private Sub GridView1_EditFormPrepared(sender As Object, e As EditFormPreparedEventArgs) Handles GridView1.EditFormPrepared
        Try
            If Not editar Then
                Dim id As Integer = Session1.ExecuteScalar("SELECT MAX(idServicio) FROM Servicios") + 1
                GridView1.SetFocusedRowCellValue(colidServicio, id)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        editar = True
    End Sub
    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            editar = True
        ElseIf e.KeyCode = Keys.Delete Then
            BorrarRegistro()
        ElseIf e.KeyCode = Keys.Insert Then
            AgregarRegistro()
        End If
    End Sub
    Private Sub BorrarRegistro()
        Try
            If GridView1.RowCount < 1 Then Exit Sub
            If MsgBox("¿Desea eliminar el servicio?", vbYesNo + vbQuestion, "Eliminar") = vbYes Then
                Session1.ExecuteNonQuery("DELETE FROM Servicios WHERE idServicio = " & GridView1.GetFocusedRowCellValue(colidServicio))
                XpCollection1.Reload()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub AgregarRegistro()
        editar = False
        GridView1.AddNewRow()
        GridView1.ShowEditForm()
    End Sub
End Class