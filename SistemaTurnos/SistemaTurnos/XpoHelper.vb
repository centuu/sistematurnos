Option Infer On
Imports System.Threading
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Public NotInheritable Class XpoHelper
    Private Shared fDataLayer As IDataLayer
    Public Cnstring As String
    Private Shared ReadOnly lockObject As New Object()
    Private Shared ReadOnly Property DataLayer() As IDataLayer
        Get
            If fDataLayer Is Nothing Then
                SyncLock lockObject
                    If Thread.VolatileRead(fDataLayer) Is Nothing Then
                        Thread.VolatileWrite(fDataLayer, GetDataLayer(NuevoLayer))
                    End If
                End SyncLock
            End If
            Return fDataLayer
        End Get
    End Property
    Public Shared Function GetDataLayer(autoCreationOption As AutoCreateOption) As IDataLayer
        Dim conn
        If ModoTest Then
            conn = MSSqlConnectionProvider.GetConnectionString("localhost", "sa", "lobito1.2016", "TurnosMontagne")
        Else
            conn = MSSqlConnectionProvider.GetConnectionString("localhost", "sa", "lobito1.2016", "TurnosMontagne_Test")
        End If
        Return XpoDefault.GetDataLayer(conn, autoCreationOption)
    End Function
    Public Shared Function GetNewSession() As Session
        Return New Session(DataLayer)
    End Function
    Public Shared Function GetNewUnitOfWork() As UnitOfWork
        Return New UnitOfWork(DataLayer)
    End Function
End Class