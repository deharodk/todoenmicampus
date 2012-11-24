Imports System.Data.Entity

Namespace libros.Areas.admin
    Public Class TipoAnuncioController
        'Inherits System.Web.Mvc.Controller
        Inherits BaseController

        Private db As New libros_db

        '
        ' GET: /admin/TipoAnuncio/

        Function Index() As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Return View(db.TipoAnuncios.ToList())
        End Function

        '
        ' GET: /admin/TipoAnuncio/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Dim tipoanuncio As TipoAnuncio = db.TipoAnuncios.Find(id)
            If IsNothing(tipoanuncio) Then
                Return HttpNotFound()
            End If
            Return View(tipoanuncio)
        End Function

        '
        ' GET: /admin/TipoAnuncio/Create

        Function Create() As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Return View()
        End Function

        '
        ' POST: /admin/TipoAnuncio/Create

        <HttpPost()> _
        Function Create(ByVal tipoanuncio As TipoAnuncio) As ActionResult
            If ModelState.IsValid Then
                db.TipoAnuncios.Add(tipoanuncio)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(tipoanuncio)
        End Function

        '
        ' GET: /admin/TipoAnuncio/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Dim tipoanuncio As TipoAnuncio = db.TipoAnuncios.Find(id)
            If IsNothing(tipoanuncio) Then
                Return HttpNotFound()
            End If
            Return View(tipoanuncio)
        End Function

        '
        ' POST: /admin/TipoAnuncio/Edit/5

        <HttpPost()> _
        Function Edit(ByVal tipoanuncio As TipoAnuncio) As ActionResult
            If ModelState.IsValid Then
                db.Entry(tipoanuncio).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(tipoanuncio)
        End Function

        '
        ' GET: /admin/TipoAnuncio/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard", "Administrador")
            Dim tipoanuncio As TipoAnuncio = db.TipoAnuncios.Find(id)
            If IsNothing(tipoanuncio) Then
                Return HttpNotFound()
            End If
            Return View(tipoanuncio)
        End Function

        '
        ' POST: /admin/TipoAnuncio/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim tipoanuncio As TipoAnuncio = db.TipoAnuncios.Find(id)
            db.TipoAnuncios.Remove(tipoanuncio)
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