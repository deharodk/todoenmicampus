Imports System.Data.Entity

Namespace libros.Areas.admin
    Public Class FormaPagoController
        'Inherits System.Web.Mvc.Controller
        Inherits BaseController

        Private db As New libros_db

        '
        ' GET: /admin/FormaPago/

        Function Index() As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Return View(db.FormaPago.ToList())
        End Function

        '
        ' GET: /admin/FormaPago/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Dim formapago As FormaPago = db.FormaPago.Find(id)
            If IsNothing(formapago) Then
                Return HttpNotFound()
            End If
            Return View(formapago)
        End Function

        '
        ' GET: /admin/FormaPago/Create

        Function Create() As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Return View()
        End Function

        '
        ' POST: /admin/FormaPago/Create

        <HttpPost()> _
        Function Create(ByVal formapago As FormaPago) As ActionResult
            If ModelState.IsValid Then
                db.FormaPago.Add(formapago)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(formapago)
        End Function

        '
        ' GET: /admin/FormaPago/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Dim formapago As FormaPago = db.FormaPago.Find(id)
            If IsNothing(formapago) Then
                Return HttpNotFound()
            End If
            Return View(formapago)
        End Function

        '
        ' POST: /admin/FormaPago/Edit/5

        <HttpPost()> _
        Function Edit(ByVal formapago As FormaPago) As ActionResult
            If ModelState.IsValid Then
                db.Entry(formapago).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(formapago)
        End Function

        '
        ' GET: /admin/FormaPago/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Dim formapago As FormaPago = db.FormaPago.Find(id)
            If IsNothing(formapago) Then
                Return HttpNotFound()
            End If
            Return View(formapago)
        End Function

        '
        ' POST: /admin/FormaPago/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim formapago As FormaPago = db.FormaPago.Find(id)
            db.FormaPago.Remove(formapago)
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