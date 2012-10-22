Imports System
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.Data.Entity.Infrastructure
Imports System.ComponentModel.DataAnnotations

Public Class libros_db
    Inherits DbContext
    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()
        modelBuilder.Conventions.Remove(Of IncludeMetadataConvention)()
    End Sub
    Public Property Facultad As DbSet(Of Facultad)
    Public Property Administrador As DbSet(Of Administrador)
    Public Property FormaPago As DbSet(Of FormaPago)
    Public Property Contactoes As DbSet(Of Contacto)
End Class

