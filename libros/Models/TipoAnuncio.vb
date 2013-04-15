Imports System
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Infrastructure
Imports System.ComponentModel

Public Class TipoAnuncio
    <Key()>
    Public Property idTipoAnuncio As Integer
    <Required()>
    <DisplayName("Tipo anuncio")>
    Public Property nombre As String
    <Required()>
    <DisplayName("Estatus")>
    Public Property estatus As Boolean
    <DisplayName("Descripción")>
    Public Property descripcion As String
End Class
