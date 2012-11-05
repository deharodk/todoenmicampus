@code
    Dim idAdministrador As Integer = 0
    Dim userName As String = ""
    Dim nombre As String = ""
    Dim superPermisos As Boolean = False
    Dim estatus As Boolean = False
    Dim conectado As Boolean = False
    Try
        idAdministrador = CInt(Request.Cookies("campusUserCookie")("idAdministrador"))
        userName = Request.Cookies("campusUserCookie")("userName").ToString()
        nombre = Request.Cookies("campusUserCookie")("nombre").ToString()
        superPermisos = CBool(Request.Cookies("campusUserCookie")("superPermisos"))
        estatus = CBool(Request.Cookies("campusUserCookie")("estatus"))
        conectado = CBool(Request.Cookies("campusUserCookie")("conectado"))
    Catch ex As NullReferenceException
        
    End Try
End code    

<div class="navbar navbar-fixed-top">
      <div class="navbar-inner">
        <div class="container-fluid">
          <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </a>
          <a class="brand" href="/admin/administrador/dashboard">Admin área</a>
          <div class="btn-group pull-right">
          @If conectado = True Then
            @<a class="btn dropdown-toggle" data-toggle="dropdown" href="#">
              <i class="icon-user"></i>
              @userName
              <span class="caret"></span>
            </a>
          End if    
            <ul class="dropdown-menu">
              <li><a href="#">mi perfil</a></li>
              <li class="divider"></li>
              <li><a onclick="logout()" href="javascript:void(0);">cerrar sesión</a></li>
            </ul>
          </div>
          <div class="nav-collapse"> 
            @If conectado = True Then
            @<ul class="nav">
              <li><a href="/admin/contacto/index">Usuarios</a></li>
              <li><a href="/admin/anuncio/index">Anuncios</a></li>
              @If superPermisos = True Then
                  @<li><a href="/admin/facultad/index">Facultades</a></li>
                  @<li><a href="/admin/tipoanuncio/index">Tipo anuncios</a></li>
                  @<li><a href = "/admin/formapago/index">Formas de pago</a></li>
                  @<li><a href="/admin/administrador/index">Administradores</a></li>
                End If
            </ul>
                End If
          </div>
        </div>
      </div>
    </div>
    <br />
    <br />