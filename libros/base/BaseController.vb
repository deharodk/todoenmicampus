Public Class BaseController
    Inherits System.Web.Mvc.Controller
    Protected Overrides Sub OnActionExecuting(filterContext As System.Web.Mvc.ActionExecutingContext)
        If Request.Cookies("campusUserCookie") Is Nothing Then
            filterContext.Result = RedirectToAction("login", "Administrador")
        End If
        MyBase.OnActionExecuting(filterContext)
    End Sub
End Class
