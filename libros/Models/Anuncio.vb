Imports System
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Infrastructure
Imports System.ComponentModel
Public Class Anuncio
    <Key()>
    Public Property idAnuncio As Integer
    <Required()>
    <DisplayName("Título")>
    Public Property titulo As String
    <Required()>
    <DisplayName("Descripción")>
    Public Property descripcion As String
    <DisplayName("Precio")>
    Public Property precioTotal As Decimal
    <DisplayName("Estatus")>
    Public Property estatus As Boolean

    <ForeignKey("Contacto")>
    <DisplayName("Anunciante")>
    Public Property idContacto As Integer
    Public Overridable Property Contacto As Contacto

    <ForeignKey("TipoAnuncio")>
    <DisplayName("Tipo de anuncio")>
    Public Property idTipoAnuncio As Integer
    Public Overridable Property TipoAnuncio As TipoAnuncio

    <Required()>
    <DisplayName("Fecha creación")>
    Public Property fechaCreacion As DateTime

    <ForeignKey("FormaPago")>
    <DisplayName("Forma de pago")>
    Public Property idFormaPago As Integer
    Public Overridable Property FormaPago As FormaPago
End Class
