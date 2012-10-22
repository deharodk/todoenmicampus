Public Class BaseController
    Inherits System.Web.Mvc.Controller
    Protected Overrides Sub OnActionExecuting(filterContext As System.Web.Mvc.ActionExecutingContext)
        'Try
        '    Dim idAdministrador As Integer = "ljgvjxhd<hgzbfzgfzgfdz"
        'Catch ex As Exception
        '    filterContext.Result = RedirectToAction("login", "Administrador")
        'End Try
        MyBase.OnActionExecuting(filterContext)
    End Sub
End Class
