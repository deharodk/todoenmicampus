Imports System
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Infrastructure
Imports System.ComponentModel
Public Class FormaPago
    <Key()>
    Public Property idFormaPago As Integer
    <Required()>
    <DisplayName("Forma pago")>
    Public Property nombre As String
    <Required()>
    <DisplayName("Estatus")>
    Public Property estatus As Boolean
End Class
