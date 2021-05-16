<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.XpCollection1 = New DevExpress.Xpo.XPCollection(Me.components)
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colidTurno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNroLocal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.XpCollection3 = New DevExpress.Xpo.XPCollection(Me.components)
        Me.colFecha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHorario = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemLookUpEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.XpCollection2 = New DevExpress.Xpo.XPCollection(Me.components)
        Me.colNroOrden = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldniCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coltelCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colmailCliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCompro = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colObservaciones = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colReprogramo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNroTicket = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SplashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.SistemaTurnos.WaitForm1), True, True)
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XpCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XpCollection3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XpCollection2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.DataSource = Me.XpCollection1
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemLookUpEdit1, Me.RepositoryItemLookUpEdit2})
        Me.GridControl1.Size = New System.Drawing.Size(800, 450)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'XpCollection1
        '
        Me.XpCollection1.ObjectType = GetType(SistemaTurnos.TurnosMontagne.Turnos)
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colidTurno, Me.colNroLocal, Me.colFecha, Me.colHorario, Me.colNroOrden, Me.colCliente, Me.coldniCliente, Me.coltelCliente, Me.colmailCliente, Me.colCompro, Me.colObservaciones, Me.colReprogramo, Me.colNroTicket})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupCount = 1
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Fecha", Me.colFecha, "Turnos por Local: {0}")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colNroLocal, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colidTurno
        '
        Me.colidTurno.FieldName = "idTurno"
        Me.colidTurno.Name = "colidTurno"
        '
        'colNroLocal
        '
        Me.colNroLocal.Caption = "LOCAL"
        Me.colNroLocal.ColumnEdit = Me.RepositoryItemLookUpEdit1
        Me.colNroLocal.FieldName = "NroLocal"
        Me.colNroLocal.Name = "colNroLocal"
        Me.colNroLocal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "NroLocal", "{0}")})
        Me.colNroLocal.Visible = True
        Me.colNroLocal.VisibleIndex = 1
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.DataSource = Me.XpCollection3
        Me.RepositoryItemLookUpEdit1.DisplayMember = "Nombre"
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        Me.RepositoryItemLookUpEdit1.NullText = ""
        Me.RepositoryItemLookUpEdit1.ValueMember = "NroLocal"
        '
        'XpCollection3
        '
        Me.XpCollection3.ObjectType = GetType(SistemaTurnos.TurnosMontagne.Usuarios)
        '
        'colFecha
        '
        Me.colFecha.Caption = "FECHA"
        Me.colFecha.FieldName = "Fecha"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Fecha", "Total de Turnos: {0}")})
        Me.colFecha.Visible = True
        Me.colFecha.VisibleIndex = 0
        Me.colFecha.Width = 88
        '
        'colHorario
        '
        Me.colHorario.Caption = "HORARIO"
        Me.colHorario.ColumnEdit = Me.RepositoryItemLookUpEdit2
        Me.colHorario.FieldName = "Horario"
        Me.colHorario.Name = "colHorario"
        Me.colHorario.Visible = True
        Me.colHorario.VisibleIndex = 1
        Me.colHorario.Width = 81
        '
        'RepositoryItemLookUpEdit2
        '
        Me.RepositoryItemLookUpEdit2.AutoHeight = False
        Me.RepositoryItemLookUpEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit2.DataSource = Me.XpCollection2
        Me.RepositoryItemLookUpEdit2.DisplayMember = "descripcion"
        Me.RepositoryItemLookUpEdit2.Name = "RepositoryItemLookUpEdit2"
        Me.RepositoryItemLookUpEdit2.NullText = ""
        Me.RepositoryItemLookUpEdit2.ValueMember = "idHorario"
        '
        'XpCollection2
        '
        Me.XpCollection2.ObjectType = GetType(SistemaTurnos.TurnosMontagne.Horarios)
        '
        'colNroOrden
        '
        Me.colNroOrden.Caption = "N° ORDEN"
        Me.colNroOrden.FieldName = "NroOrden"
        Me.colNroOrden.Name = "colNroOrden"
        Me.colNroOrden.Visible = True
        Me.colNroOrden.VisibleIndex = 2
        Me.colNroOrden.Width = 72
        '
        'colCliente
        '
        Me.colCliente.Caption = "CLIENTE"
        Me.colCliente.FieldName = "Cliente"
        Me.colCliente.Name = "colCliente"
        Me.colCliente.Visible = True
        Me.colCliente.VisibleIndex = 3
        Me.colCliente.Width = 87
        '
        'coldniCliente
        '
        Me.coldniCliente.Caption = "DNI"
        Me.coldniCliente.FieldName = "dniCliente"
        Me.coldniCliente.Name = "coldniCliente"
        Me.coldniCliente.Visible = True
        Me.coldniCliente.VisibleIndex = 4
        Me.coldniCliente.Width = 59
        '
        'coltelCliente
        '
        Me.coltelCliente.Caption = "TELEFONO"
        Me.coltelCliente.FieldName = "telCliente"
        Me.coltelCliente.Name = "coltelCliente"
        Me.coltelCliente.Visible = True
        Me.coltelCliente.VisibleIndex = 5
        Me.coltelCliente.Width = 59
        '
        'colmailCliente
        '
        Me.colmailCliente.Caption = "MAIL"
        Me.colmailCliente.FieldName = "mailCliente"
        Me.colmailCliente.Name = "colmailCliente"
        Me.colmailCliente.Visible = True
        Me.colmailCliente.VisibleIndex = 6
        Me.colmailCliente.Width = 53
        '
        'colCompro
        '
        Me.colCompro.Caption = "COMPRO"
        Me.colCompro.FieldName = "Compro"
        Me.colCompro.Name = "colCompro"
        Me.colCompro.Visible = True
        Me.colCompro.VisibleIndex = 7
        Me.colCompro.Width = 53
        '
        'colObservaciones
        '
        Me.colObservaciones.Caption = "OBSERVACIONES"
        Me.colObservaciones.FieldName = "Observaciones"
        Me.colObservaciones.Name = "colObservaciones"
        Me.colObservaciones.Visible = True
        Me.colObservaciones.VisibleIndex = 9
        Me.colObservaciones.Width = 88
        '
        'colReprogramo
        '
        Me.colReprogramo.Caption = "REPROGRAMO"
        Me.colReprogramo.FieldName = "Reprogramo"
        Me.colReprogramo.Name = "colReprogramo"
        Me.colReprogramo.Visible = True
        Me.colReprogramo.VisibleIndex = 8
        Me.colReprogramo.Width = 65
        '
        'colNroTicket
        '
        Me.colNroTicket.Caption = "N° TICKET"
        Me.colNroTicket.FieldName = "NroTicket"
        Me.colNroTicket.Name = "colNroTicket"
        Me.colNroTicket.Visible = True
        Me.colNroTicket.VisibleIndex = 10
        Me.colNroTicket.Width = 77
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.SimpleButton1.Location = New System.Drawing.Point(713, 12)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 53)
        Me.SimpleButton1.TabIndex = 1
        Me.SimpleButton1.Text = "IMPRIMIR"
        '
        'SplashScreenManager1
        '
        Me.SplashScreenManager1.ClosingDelay = 500
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.SimpleButton2.Location = New System.Drawing.Point(632, 12)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 53)
        Me.SimpleButton2.TabIndex = 2
        Me.SimpleButton2.Text = "RESUMEN"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.GridControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DETALLES DE TURNOS"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XpCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XpCollection3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XpCollection2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XpCollection1 As DevExpress.Xpo.XPCollection
    Friend WithEvents XpCollection2 As DevExpress.Xpo.XPCollection
    Friend WithEvents XpCollection3 As DevExpress.Xpo.XPCollection
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colidTurno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNroLocal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colFecha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHorario As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents colNroOrden As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldniCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltelCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colmailCliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCompro As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colObservaciones As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colReprogramo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNroTicket As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SplashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
