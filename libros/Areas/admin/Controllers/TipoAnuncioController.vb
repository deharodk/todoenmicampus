Imports System.Data.Entity

Namespace libros.Areas.admin
    Public Class TipoAnuncioController
        Inherits System.Web.Mvc.Controller

        Private db As New libros_db

        '
        ' GET: /admin/TipoAnuncio/

        Function Index() As ActionResult
            Return View(db.TipoAnuncio.ToList())
        End Function

        '
        ' GET: /admin/TipoAnuncio/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim tipoanuncio As TipoAnuncio = db.TipoAnuncio.Find(id)
            If IsNothing(tipoanuncio) Then
                Return HttpNotFound()
            End If
            Return View(tipoanuncio)
        End Function

        '
        ' GET: /admin/TipoAnuncio/Create

        Function Create() As ActionResult
            Return View()
        End Function

        '
        ' POST: /admin/TipoAnuncio/Create

        <HttpPost()> _
        Function Create(ByVal tipoanuncio As TipoAnuncio) As ActionResult
            If ModelState.IsValid Then
                db.TipoAnuncio.Add(tipoanuncio)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            Return View(tipoanuncio)
        End Function

        '
        ' GET: /admin/TipoAnuncio/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim tipoanuncio As TipoAnuncio = db.TipoAnuncio.Find(id)
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
            Dim tipoanuncio As TipoAnuncio = db.TipoAnuncio.Find(id)
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
            Dim tipoanuncio As TipoAnuncio = db.TipoAnuncio.Find(id)
            db.TipoAnuncio.Remove(tipoanuncio)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace