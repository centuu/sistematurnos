﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Namespace TurnosMontagne
    Public Class ConnectionHelper
        Shared persistentTypes As Type() = New Type() {
            GetType(Horarios),
            GetType(Turnos),
            GetType(Usuarios)
        }
        Public Shared Function GetPersistentTypes() As Type()
            Dim copy(persistentTypes.Length - 1) As Type
            Array.Copy(persistentTypes, copy, persistentTypes.Length)
            Return copy
        End Function
        Public Const ConnectionString As String = "XpoProvider=MSSqlServer;data source=localhost;user id=sa;password=lobito1.2016;initial catalog=TurnosMontagne_Test;Persist Security Info=true"
        Public Shared Sub Connect(ByVal autoCreationOption As DB.AutoCreateOption, Optional threadSafe As Boolean = False)
            If threadSafe Then
                Dim provider = XpoDefault.GetConnectionProvider(ConnectionString, autoCreationOption)
                Dim dictionary = New DevExpress.Xpo.Metadata.ReflectionDictionary()
                dictionary.GetDataStoreSchema(persistentTypes)
                XpoDefault.DataLayer = New ThreadSafeDataLayer(dictionary, provider)
            Else
                XpoDefault.DataLayer = XpoDefault.GetDataLayer(ConnectionString, autoCreationOption)
            End If
            XpoDefault.Session = Nothing
        End Sub
        Public Shared Function GetConnectionProvider(ByVal autoCreationOption As DB.AutoCreateOption) As DB.IDataStore
            Return XpoDefault.GetConnectionProvider(ConnectionString, autoCreationOption)
        End Function
        Public Shared Function GetConnectionProvider(ByVal autoCreationOption As DB.AutoCreateOption, ByRef objectsToDisposeOnDisconnect() As IDisposable) As DB.IDataStore
            Return XpoDefault.GetConnectionProvider(ConnectionString, autoCreationOption, objectsToDisposeOnDisconnect)
        End Function
        Public Shared Function GetDataLayer(ByVal autoCreationOption As DB.AutoCreateOption) As IDataLayer
            Return XpoDefault.GetDataLayer(ConnectionString, autoCreationOption)
        End Function
    End Class

End Namespace