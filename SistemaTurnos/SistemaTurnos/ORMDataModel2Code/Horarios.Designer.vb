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

    Partial Public Class Horarios
        Inherits XPLiteObject
        Dim fidHorario As Integer
        <Key(True)>
        Public Property idHorario() As Integer
            Get
                Return fidHorario
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)(NameOf(idHorario), fidHorario, value)
            End Set
        End Property
        Dim fdescripcion As String
        <Size(50)>
        Public Property descripcion() As String
            Get
                Return fdescripcion
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)(NameOf(descripcion), fdescripcion, value)
            End Set
        End Property
    End Class

End Namespace