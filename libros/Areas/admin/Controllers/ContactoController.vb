Imports System.Data.Entity
Imports System.Security.Cryptography

Namespace libros.Areas.admin
    Public Class ContactoController
        'Inherits System.Web.Mvc.Controller
        Inherits BaseController

        Private db As New libros_db

        '
        ' GET: /admin/Contacto/

        Function Index() As ActionResult
            Dim contactoes = db.Contactoes.Include(Function(c) c.Facultad)
            Return View(contactoes.ToList())
        End Function

        '
        ' GET: /admin/Contacto/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim contacto As Contacto = db.Contactoes.Find(id)
            If IsNothing(contacto) Then
                Return HttpNotFound()
            End If
            Return View(contacto)
        End Function

        '
        ' GET: /admin/Contacto/Create

        Function Create() As ActionResult
            ViewBag.idFacultad = New SelectList(db.Facultad, "idFacultad", "nombre")
            Return View()
        End Function

        '
        ' POST: /admin/Contacto/Create

        <HttpPost()> _
        Function Create(ByVal contacto As Contacto) As ActionResult
            If ModelState.IsValid Then
                db.Contactoes.Add(contacto)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If

            ViewBag.idFacultad = New SelectList(db.Facultad, "idFacultad", "nombre", contacto.idFacultad)
            Return View(contacto)
        End Function

        '
        ' GET: /admin/Contacto/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim contacto As Contacto = db.Contactoes.Find(id)
            If IsNothing(contacto) Then
                Return HttpNotFound()
            End If
            ViewBag.idFacultad = contacto.idFacultad
            Return View(contacto)
        End Function

        '
        ' POST: /admin/Contacto/Edit/5

        <HttpPost()> _
        Function Edit(ByVal contacto As Contacto) As ActionResult
            If ModelState.IsValid Then
                db.Entry(contacto).State = EntityState.Modified
                Dim byteInput As Byte() = Encoding.UTF8.GetBytes(contacto.pass)
                Dim hash As HashAlgorithm = New SHA512Managed()
                contacto.pass = Convert.ToBase64String(hash.ComputeHash(byteInput))
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.idFacultad = New SelectList(db.Facultad, "idFacultad", "nombre", contacto.idFacultad)
            Return View(contacto)
        End Function

        '
        ' GET: /admin/Contacto/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim contacto As Contacto = db.Contactoes.Find(id)
            If IsNothing(contacto) Then
                Return HttpNotFound()
            End If
            Return View(contacto)
        End Function

        '
        ' GET: /admin/Contacto/Habilitar/5

        Function Habilitar(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim contacto As Contacto = db.Contactoes.Find(id)
            If IsNothing(contacto) Then
                Return HttpNotFound()
            End If
            Return View(contacto)
        End Function

        '
        ' POST: /admin/Contacto/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim contacto As Contacto = db.Contactoes.Find(id)
            contacto.estatus = False
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        '
        ' POST: /admin/Contacto/Habilitar/5

        <HttpPost()> _
        <ActionName("Habilitar")> _
        Function HabilitarConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim contacto As Contacto = db.Contactoes.Find(id)
            contacto.estatus = True
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace