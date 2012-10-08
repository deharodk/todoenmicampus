Namespace libros.Areas.admin
    Public Class adminAreaRegistration
        Inherits AreaRegistration

        Public Overrides ReadOnly Property AreaName() As String
            Get
                Return "admin"
            End Get
        End Property

        Public Overrides Sub RegisterArea(ByVal context As System.Web.Mvc.AreaRegistrationContext)
            context.MapRoute( _
                "admin_default", _
               "admin/{controller}/{action}/{id}", _
                New With {.controller = "Administrador", .action = "login", .id = UrlParameter.Optional} _
            )
        End Sub
    End Class
End Namespace

