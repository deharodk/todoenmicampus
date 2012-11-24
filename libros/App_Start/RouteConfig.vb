Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Class RouteConfig
    Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute( _
            name:="Default", _
            url:="{controller}/{action}/{id}", _
            defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional} _
        )


        'routes.MapRoute( _
        '         "passRecoverChange",
        '         "{controller}/{action}/{id}/{key}",
        '         New With {.controller = "Usuario", .action = "assRecoverChange", .id = UrlParameter.Optional, .key = UrlParameter.Optional}
        '         )

    End Sub
End Class