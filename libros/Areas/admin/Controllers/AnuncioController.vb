Imports System.Data.Entity

Namespace libros.Areas.admin
    Public Class AnuncioController
        ' Inherits System.Web.Mvc.Controller
        Inherits BaseController

        Private db As New libros_db

        '
        ' GET: /admin/Anuncio/

        Function Index() As ActionResult
            Dim anuncios = db.Anuncios.Include(Function(a) a.Contacto).Include(Function(a) a.TipoAnuncio).Include(Function(a) a.FormaPago).OrderBy(Function(a) a.idAnuncio).OrderByDescending(Function(a) a.idAnuncio)
            Return View(anuncios.ToList())
        End Function

        '
        ' GET: /admin/Anuncio/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim anuncio As Anuncio = db.Anuncios.Find(id)
            If IsNothing(anuncio) Then
                Return HttpNotFound()
            End If
            Return View(anuncio)
        End Function

        '
        ' GET: /admin/Anuncio/Create

        'Function Create() As ActionResult
        '    ViewBag.idContacto = New SelectList(db.Contactoes, "idContacto", "nombre")
        '    ViewBag.idTipoAnuncio = New SelectList(db.TipoAnuncios, "idTipoAnuncio", "nombre")
        '    ViewBag.idFormaPago = New SelectList(db.FormaPago, "idFormaPago", "nombre")
        '    Return View()
        'End Function

        ''
        '' POST: /admin/Anuncio/Create

        '<HttpPost()> _
        'Function Create(ByVal anuncio As Anuncio) As ActionResult
        '    If ModelState.IsValid Then
        '        db.Anuncios.Add(anuncio)
        '        db.SaveChanges()
        '        Return RedirectToAction("Index")
        '    End If

        '    ViewBag.idContacto = New SelectList(db.Contactoes, "idContacto", "nombre", anuncio.idContacto)
        '    ViewBag.idTipoAnuncio = New SelectList(db.TipoAnuncios, "idTipoAnuncio", "nombre", anuncio.idTipoAnuncio)
        '    ViewBag.idFormaPago = New SelectList(db.FormaPago, "idFormaPago", "nombre", anuncio.idFormaPago)
        '    Return View(anuncio)
        'End Function

        '
        ' GET: /admin/Anuncio/Edit/5

        'Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        '    Dim anuncio As Anuncio = db.Anuncios.Find(id)
        '    If IsNothing(anuncio) Then
        '        Return HttpNotFound()
        '    End If
        '    ViewBag.idContacto = New SelectList(db.Contactoes, "idContacto", "nombre", anuncio.idContacto)
        '    ViewBag.idTipoAnuncio = New SelectList(db.TipoAnuncios, "idTipoAnuncio", "nombre", anuncio.idTipoAnuncio)
        '    ViewBag.idFormaPago = New SelectList(db.FormaPago, "idFormaPago", "nombre", anuncio.idFormaPago)
        '    Return View(anuncio)
        'End Function

        ''
        '' POST: /admin/Anuncio/Edit/5

        '<HttpPost()> _
        'Function Edit(ByVal anuncio As Anuncio) As ActionResult
        '    If ModelState.IsValid Then
        '        db.Entry(anuncio).State = EntityState.Modified
        '        db.SaveChanges()
        '        Return RedirectToAction("Index")
        '    End If

        '    ViewBag.idContacto = New SelectList(db.Contactoes, "idContacto", "nombre", anuncio.idContacto)
        '    ViewBag.idTipoAnuncio = New SelectList(db.TipoAnuncios, "idTipoAnuncio", "nombre", anuncio.idTipoAnuncio)
        '    ViewBag.idFormaPago = New SelectList(db.FormaPago, "idFormaPago", "nombre", anuncio.idFormaPago)
        '    Return View(anuncio)
        'End Function

        '
        ' GET: /admin/Anuncio/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim anuncio As Anuncio = db.Anuncios.Find(id)
            If IsNothing(anuncio) Then
                Return HttpNotFound()
            End If
            Return View(anuncio)
        End Function

        '
        ' POST: /admin/Anuncio/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim anuncio As Anuncio = db.Anuncios.Find(id)
            anuncio.estatus = False
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace