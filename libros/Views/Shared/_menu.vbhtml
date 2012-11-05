@code
    Dim idContacto As Integer = 0
    Dim email As String = ""
    Dim nombre As String = ""
    Dim idFacultad As Integer = 0
    Dim estatus As Boolean = False
    Dim conectado As Boolean = False
    Try
        idContacto = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
        email = CStr(Request.Cookies("campusContactoCookie")("email"))
        nombre = CStr(Request.Cookies("campusContactoCookie")("nombre"))
        idFacultad = CInt(Request.Cookies("campusContactoCookie")("idFacultad"))
        estatus = CBool(Request.Cookies("campusContactoCookie")("estatus"))
        conectado = CBool(Request.Cookies("campusContactoCookie")("conectado"))
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
          <a class="brand" href="/Home/">Todo en mi campus</a>
          <div class="btn-group pull-right">
          @If conectado = True Then
            @<a class="btn dropdown-toggle" data-toggle="dropdown" href="#">
              <i class="icon-user"></i>
              @email
              <span class="caret"></span>
            </a>
              @<ul class="dropdown-menu">
              <li>
                <a href = "/Usuario/Edit/@idContacto"><i class="icon-edit"></i> mi cuenta</a>
              </li>
              <li>
                <a href = "/Anuncios/MisAnuncios/@idContacto"><i class="icon-inbox"></i> mis anuncios</a>
              </li>
              <li class="divider"></li>
              <li><a onclick="logoutUsuario()" href="javascript:void(0);"><i class="icon-off"></i> cerrar sesión</a></li>
            </ul>
          Else
             @<a class="btn dropdown-toggle" data-toggle="dropdown" href="#">
               <i class="icon-off"></i>   Conectarme
              <span class="caret"></span>
            </a>
              @<ul class="dropdown-menu">
              <li>
                  <a href="/Usuario/login">
                  <i class="icon-play-circle"></i> iniciar sesión
                  </a>
              </li>
              <li>
                <a href="/Usuario/Create">
                <i class="icon-plus"></i> registrarme
                </a>
              </li>
            </ul>
          End If   
          </div>
          <div class="nav-collapse"> 
            <ul class="nav">
              <li><a href="/Anuncios/Conocimiento">Conocimiento</a></li>
              <li><a href="/Anuncios/LibrosMaterial">Libros / Material académico</a></li>
              <li><a href = "/Anuncios/Cuartos">Roomies</a></li>
              <li><a href="/Anuncios/Create"><i class="icon-arrow-right"></i>¡Publicar anuncio!</a></li>
              <li><a href = "/Home/QuienesSomos">¿Quienes somos?</a></li>
            </ul>
          </div>
        </div>
      </div>
    </div>
    <br />
    <br />