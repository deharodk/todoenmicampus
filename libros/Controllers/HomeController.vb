Imports System.Data.Entity
Namespace libros
    Public Class HomeController
        Inherits System.Web.Mvc.Controller

        Private db As New libros_db
        Dim anunciosPorPagina As Integer = CInt(ConfigurationManager.AppSettings("registrosPorPagina"))

        '
        ' GET: /Home

        Function Index(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim anuncios = db.Anuncios.Include(Function(a) a.Contacto).Include(Function(a) a.TipoAnuncio).Include(Function(a) a.FormaPago).Where(Function(a) a.estatus = True).Take(anunciosPorPagina).OrderByDescending(Function(a) a.idAnuncio)
            ViewBag.isHome = True
            ViewBag.Action = "/Home/Index/"

            If (Request.IsAjaxRequest()) Then
                Return PartialView("_Anuncios", GetPaginatedProducts(id))
            End If

            Return View(anuncios.ToList())
        End Function

        Private Function GetPaginatedProducts(ByVal page As Integer) As List(Of Anuncio)
            Dim skipRecords As Integer = Page * anunciosPorPagina
            Dim anuncios = db.Anuncios.Include(Function(a) a.Contacto).Include(Function(a) a.TipoAnuncio).Include(Function(a) a.FormaPago).Where(Function(a) a.estatus = True).OrderBy(Function(a) a.fechaCreacion).OrderByDescending(Function(a) a.idAnuncio)
            Return anuncios.Skip(skipRecords).Take(anunciosPorPagina).ToList()
        End Function

        Function QuienesSomos() As ActionResult
            Return View()
        End Function

        Function Contacto() As ActionResult
            Return View()
        End Function

        Function Borrado() As ActionResult
            Return View()
        End Function

        Function PasswordRecuperado() As ActionResult
            Return View()
        End Function

        Function EmailRecuperacionEnviado() As ActionResult
            Return View()
        End Function

        Function CorreoRecuperacionEnviado() As ActionResult
            Return View()
        End Function

        Function HasVuelto() As ActionResult
            Return View()
        End Function

        Function AvisoDePrivacidad() As ActionResult
            Return View()
        End Function

        Function ComoFunciona() As ActionResult
            Return View()
        End Function

        Function TiposAnuncio() As ActionResult
            Dim tipoanuncio = db.TipoAnuncios.ToList()
            Return View(tipoanuncio)
        End Function

    End Class
End Namespace