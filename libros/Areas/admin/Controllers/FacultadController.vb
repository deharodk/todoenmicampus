﻿Imports System.Data.Entity

Namespace libros.Areas.admin
    Public Class FacultadController
        'Inherits System.Web.Mvc.Controller
        Inherits BaseController

        Private db As New libros_db

        '
        ' GET: /admin/Facultad/

        Function Index() As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Return View(db.Facultad.ToList())
        End Function

        '
        ' GET: /admin/Facultad/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Dim facultad As Facultad = db.Facultad.Find(id)
            If IsNothing(facultad) Then
                Return HttpNotFound()
            End If
            Return View(facultad)
        End Function

        '
        ' GET: /admin/Facultad/Create

        Function Create() As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Return View()
        End Function

        '
        ' POST: /admin/Facultad/Create

        <HttpPost()> _
        Function Create(ByVal facultad As Facultad) As ActionResult
            If ModelState.IsValid Then
                db.Facultad.Add(facultad)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(facultad)
        End Function

        '
        ' GET: /admin/Facultad/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Dim facultad As Facultad = db.Facultad.Find(id)
            If IsNothing(facultad) Then
                Return HttpNotFound()
            End If
            Return View(facultad)
        End Function

        '
        ' POST: /admin/Facultad/Edit/5

        <HttpPost()> _
        Function Edit(ByVal facultad As Facultad) As ActionResult
            If ModelState.IsValid Then
                db.Entry(facultad).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(facultad)
        End Function

        '
        ' GET: /admin/Facultad/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Dim facultad As Facultad = db.Facultad.Find(id)
            If IsNothing(facultad) Then
                Return HttpNotFound()
            End If
            Return View(facultad)
        End Function

        '
        ' POST: /admin/Facultad/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim facultad As Facultad = db.Facultad.Find(id)
            db.Facultad.Remove(facultad)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Private Function isAdminSuperAdmin() As Boolean
            Dim superPermisos As Integer
            If Not Request.Cookies("campusUserCookie") Is Nothing Then
                superPermisos = CBool(Request.Cookies("campusUserCookie")("superPermisos"))
                If superPermisos = False Then
                    Return False
                End If
            End If
            Return True
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace