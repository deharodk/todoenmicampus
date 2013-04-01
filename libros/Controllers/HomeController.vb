Imports System.Data.Entity
Namespace libros
    Public Class HomeController
        Inherits System.Web.Mvc.Controller

        Private db As New libros_db

        '
        ' GET: /Home

        Function Index() As ActionResult
            Dim anuncios = db.Anuncios.Include(Function(a) a.Contacto).Include(Function(a) a.TipoAnuncio).Include(Function(a) a.FormaPago).Where(Function(a) a.estatus = True).OrderBy(Function(a) a.fechaCreacion).Take(100).OrderByDescending(Function(a) a.idAnuncio)
            Return View(anuncios.ToList())
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
    End Class
End Namespace