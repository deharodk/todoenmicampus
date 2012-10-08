Imports System
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.Data.Entity.Infrastructure
Imports System.ComponentModel.DataAnnotations

Public Class TipoAnuncio
    <Key()>
    Public Property idTipoAnuncio() As Integer
    <Required()>
    Public Property tipoAnuncio As String
    <Required()>
    Public Property estatus As Boolean
End Class
