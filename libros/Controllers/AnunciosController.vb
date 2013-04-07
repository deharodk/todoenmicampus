Imports System.Data.Entity

Namespace libros
    Public Class AnunciosController
        Inherits System.Web.Mvc.Controller

        Private db As New libros_db

        '
        ' GET: /Anuncios/

        Function Index() As ActionResult
            Return RedirectToAction("Index", "Home")
        End Function

        ' GET: /Anuncios/

        Function MisAnuncios(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim idUsuario As Integer = 0
            Try
                idUsuario = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
            Catch ex As Exception

            End Try

            If idUsuario <> id Then
                Return RedirectToAction("Index", "Home")
            End If

            Dim anuncios = db.Anuncios.Include(Function(a) a.Contacto).Include(Function(a) a.TipoAnuncio).Include(Function(a) a.FormaPago).Where(Function(a) a.idContacto = idUsuario).OrderByDescending(Function(a) a.idAnuncio)
            Return View(anuncios.ToList())
        End Function

        Function Conocimiento() As ActionResult
            Dim estatus() As Integer = {1, 2}
            Dim anuncios = db.Anuncios.Include(Function(a) a.Contacto).Include(Function(a) a.TipoAnuncio).Include(Function(a) a.FormaPago).Where(Function(a) a.estatus = True And estatus.Contains(a.idTipoAnuncio)).OrderBy(Function(a) a.fechaCreacion)
            ViewBag.headerAnuncios = "Anuncios de conocimiento"
            ViewBag.isHome = False
            Return View("../Home/Index", anuncios.ToList())
        End Function

        Function LibrosMaterial() As ActionResult
            Dim estatus() As Integer = {3, 4}
            Dim anuncios = db.Anuncios.Include(Function(a) a.Contacto).Include(Function(a) a.TipoAnuncio).Include(Function(a) a.FormaPago).Where(Function(a) a.estatus = True And estatus.Contains(a.idTipoAnuncio)).OrderBy(Function(a) a.fechaCreacion)
            ViewBag.headerAnuncios = "Anuncios de libros/material académico"
            ViewBag.isHome = False
            Return View("../Home/Index", anuncios.ToList())
        End Function

        Function Cuartos() As ActionResult
            Dim estatus() As Integer = {5, 6}
            Dim anuncios = db.Anuncios.Include(Function(a) a.Contacto).Include(Function(a) a.TipoAnuncio).Include(Function(a) a.FormaPago).Where(Function(a) a.estatus = True And estatus.Contains(a.idTipoAnuncio)).OrderBy(Function(a) a.fechaCreacion)
            ViewBag.headerAnuncios = "Anuncios de roomies/cuartos"
            ViewBag.isHome = False
            Return View("../Home/Index", anuncios.ToList())
        End Function

        '
        ' GET: /Anuncios/Categoria/5

        Function Categoria(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim anuncios = db.Anuncios.Include(Function(a) a.Contacto).Include(Function(a) a.TipoAnuncio).Include(Function(a) a.FormaPago).Where(Function(a) a.estatus = True And a.idTipoAnuncio = id).OrderBy(Function(a) a.fechaCreacion).Take(100)
            If IsNothing(anuncios) Then
                Return HttpNotFound()
            End If
            Select Case id
                Case 1, 2
                    ViewBag.headerAnuncios = "Anuncios de conocimiento"
                Case 3, 4
                    ViewBag.headerAnuncios = "Anuncios de libros/material académico"
                Case 5, 6
                    ViewBag.headerAnuncios = "Anuncios de roomies/cuartos"
            End Select

            ViewBag.isHome = False
            Return View("../Home/Index", anuncios.ToList())
        End Function

        '
        ' GET: /Anuncios/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim anuncio As Anuncio = (From a In db.Anuncios Where a.idAnuncio = id And a.estatus = True).FirstOrDefault()
            'db.Anuncios.FirstOrDefault(Function(a) a.idAnuncio = id)
            ' Dim anuncio As Anuncio = db.Database.SqlQuery(Of Anuncio)("exec spDetallesAnuncio")
            If IsNothing(anuncio) Then
                Return HttpNotFound()
            End If
            Dim idUsuario As Integer = 0
            Try
                idUsuario = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
            Catch ex As Exception

            End Try
 
            If idUsuario = anuncio.idContacto Then
                ViewBag.isUserSeeing = True
            End If
            Return View(anuncio)
        End Function

        '
        ' GET: /Anuncios/Create

        Function Create() As ActionResult
            Dim idUsuario As Integer = 0
            Try
                idUsuario = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
            Catch ex As Exception
                idUsuario = 0
            End Try

            If IsNothing(idUsuario) Or idUsuario = 0 Then
                TempData("toPublish") = True
                Return RedirectToAction("Login", "Usuario")
            End If

            ViewBag.idContacto = New SelectList(db.Contactoes, "idContacto", "nombre")
            ViewBag.idTipoAnuncio = New SelectList(db.TipoAnuncios.Where(Function(a) a.estatus = True), "idTipoAnuncio", "nombre")
            ViewBag.idFormaPago = New SelectList(db.FormaPago.Where(Function(a) a.estatus = True), "idFormaPago", "nombre")
            Return View()
        End Function

        '
        ' POST: /Anuncios/Create

        <HttpPost()>
        <ValidateInput(False)>
        Function Create(ByVal anuncio As Anuncio) As ActionResult
            Dim idUsuario As Integer = 0
            Try
                idUsuario = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
            Catch ex As Exception

            End Try

            ModelState.Remove("estatus")
            ModelState.Remove("fechaCreacion")
            ModelState.Remove("idContacto")


            anuncio.estatus = True
            anuncio.fechaCreacion = Date.Now()
            anuncio.idContacto = idUsuario
            anuncio.titulo = Char.ToUpper(anuncio.titulo(0)) & anuncio.titulo.ToLower.Substring(1)

            If anuncio.idFormaPago = 0 Then
                anuncio.idFormaPago = 1
            End If

            If ModelState.IsValid Then
                db.Anuncios.Add(anuncio)
                db.SaveChanges()
                Return RedirectToAction("Success")
            End If

            ViewBag.idContacto = New SelectList(db.Contactoes, "idContacto", "nombre", anuncio.idContacto)
            ViewBag.idTipoAnuncio = New SelectList(db.TipoAnuncios.Where(Function(a) a.estatus = True), "idTipoAnuncio", "nombre", anuncio.idTipoAnuncio)
            ViewBag.idFormaPago = New SelectList(db.FormaPago.Where(Function(a) a.estatus = True), "idFormaPago", "nombre", anuncio.idFormaPago)
            Return View(anuncio)
        End Function
        '
        'GET: /Anuncios/Success
        Function Success() As ActionResult
            'Cuando un anuncio es publicado con éxito caes aquí
            Return View()
        End Function

        '
        ' GET: /Anuncios/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim anuncio As Anuncio = db.Anuncios.Find(id)
            Dim idUsuario As Integer = 0
            Try
                idUsuario = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
            Catch ex As Exception

            End Try

            If IsNothing(anuncio) Or anuncio.idContacto <> idUsuario Then
                Return HttpNotFound()
            End If

            ViewBag.idContacto = New SelectList(db.Contactoes, "idContacto", "nombre", anuncio.idContacto)
            ViewBag.idTipoAnuncio = New SelectList(db.TipoAnuncios.Where(Function(a) a.estatus = True), "idTipoAnuncio", "nombre", anuncio.idTipoAnuncio)
            ViewBag.idFormaPago = New SelectList(db.FormaPago.Where(Function(a) a.estatus = True), "idFormaPago", "nombre", anuncio.idFormaPago)
            Return View(anuncio)
        End Function

        '
        ' POST: /Anuncios/Edit/5
        <ValidateInput(False)>
        <HttpPost()> _
        Function Edit(ByVal anuncio As Anuncio) As ActionResult
            Dim idUsuario As Integer = 0
            Try
                idUsuario = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
            Catch ex As Exception

            End Try

            If anuncio.idFormaPago = 0 Then
                anuncio.idFormaPago = 1
            End If

            anuncio.titulo = Char.ToUpper(anuncio.titulo(0)) & anuncio.titulo.ToLower.Substring(1)

            If ModelState.IsValid Then
                db.Entry(anuncio).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("MisAnuncios", New With {.id = idUsuario})
            End If

            ViewBag.idContacto = New SelectList(db.Contactoes, "idContacto", "nombre", anuncio.idContacto)
            ViewBag.idTipoAnuncio = New SelectList(db.TipoAnuncios.Where(Function(a) a.estatus = True), "idTipoAnuncio", "nombre", anuncio.idTipoAnuncio)
            ViewBag.idFormaPago = New SelectList(db.FormaPago.Where(Function(a) a.estatus = True), "idFormaPago", "nombre", anuncio.idFormaPago)
            Return View(anuncio)
        End Function

        '
        ' GET: /Anuncios/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim anuncio As Anuncio = db.Anuncios.Find(id)
            Dim idUsuario As Integer = 0
            Try
                idUsuario = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
            Catch ex As NullReferenceException

            End Try
            If IsNothing(anuncio) Or idUsuario <> anuncio.idContacto Then
                Return HttpNotFound()
            End If
            Return View(anuncio)
        End Function

        '
        ' POST: /Anuncios/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim anuncio As Anuncio = db.Anuncios.Find(id)
            Dim idUsuario As Integer = 0
            Try
                idUsuario = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
            Catch ex As NullReferenceException

            End Try
            anuncio.estatus = False
            db.SaveChanges()
            Return RedirectToAction("MisAnuncios", New With {.id = idUsuario})
        End Function
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace