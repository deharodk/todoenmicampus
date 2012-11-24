Imports System
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Infrastructure
Imports System.ComponentModel
Public Class Contacto
    <Key()>
    Public Property idContacto As Integer
    <Required()>
    <DisplayName("Nombre")>
    Public Property nombre As String
    <Required()>
    <DisplayName("E-mail")>
    Public Property email As String
    <DisplayName("Tel. móvil")>
    Public Property numeroMovil As String
    <DisplayName("Twitter")>
    Public Property cuentaTwitter As String
    <DisplayName("FB")>
    Public Property cuentaFB As String


    <ForeignKey("Facultad")>
    <DisplayName("Facultad")>
    Public Property idFacultad As Integer
    Public Overridable Property Facultad As Facultad



    <Required()>
    <PasswordPropertyText(True)>
    <DisplayName("Contraseña")>
    Public Property pass As String
    <Required()>
    <DisplayName("Estatus")>
    Public Property estatus As Boolean

    <DefaultValue(True)>
    Public Property suspendido As Boolean
End Class
