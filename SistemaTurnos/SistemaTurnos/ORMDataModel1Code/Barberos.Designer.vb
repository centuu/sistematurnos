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
Namespace BdBarberia

    Partial Public Class Barberos
        Inherits XPLiteObject
        Dim fidBarbero As Long
        <Key()>
        Public Property idBarbero() As Long
            Get
                Return fidBarbero
            End Get
            Set(ByVal value As Long)
                SetPropertyValue(Of Long)(NameOf(idBarbero), fidBarbero, value)
            End Set
        End Property
        Dim fNombre As String
        Public Property Nombre() As String
            Get
                Return fNombre
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)(NameOf(Nombre), fNombre, value)
            End Set
        End Property
    End Class

End Namespace
