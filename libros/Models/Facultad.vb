Imports System
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Infrastructure
Imports System.ComponentModel

Public Class Facultad
    <Key()>
    Public Property idFacultad() As Integer
    <Required()>
    <DisplayName("Nombre")>
    Public Property nombre() As String
    <Required()>
    <DisplayName("Nombre corto")>
    Public Property nombreCorto() As String
    <Required()>
    <DisplayName("Estatus")>
    Public Property estatus() As Boolean

End Class
