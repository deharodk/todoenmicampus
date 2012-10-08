Imports System
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity.Infrastructure
Imports System.ComponentModel
Public Class Administrador
    <Key()>
    Public Property idAdministrador As Integer
    <Required()>
    <DisplayName("Username")>
    Public Property email As String
    <Required()>
    <PasswordPropertyText(True)>
    <DisplayName("Contraseña")>
    Public Property pass As String
    <Required()>
    <DisplayName("Nombre completo")>
    Public Property nombre As String
    <Required()>
    <DisplayName("Estatus")>
    Public Property estatus As Boolean
    <Required()>
    <DisplayName("Super permisos")>
    Public Property superUsuario As Boolean
End Class
