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

 <div class="navbar navbar-fixed-top navbar-inverse">
      <div class="navbar-inner">
        <div class = "container menuF">
          <button type="button" data-toggle="collapse" data-target=".nav-collapse" class="btn btn-navbar">
          <span class="icon-bar"></span>
          <span class="icon-bar"></span>
          <span class="icon-bar"></span>
          </button>
          <a href="/Home/" class="brand">TEMC</a>

      <div class="nav-collapse collapse">
            <ul class="pull-left nav">
             <li class="divider-vertical menuItem"></li>

             <li class = "menuItem"><a href="/Anuncios/Conocimiento">Conocimiento</a></li>
             <li class="divider-vertical menuItem"></li>

             <li class = "menuItem"><a href="/Anuncios/LibrosMaterial">Libros/Material</a></li>
             <li class="divider-vertical menuItem"></li>

             <li class = "menuItem"><a href = "/Anuncios/Cuartos">Roomies</a></li>
             <li class="divider-vertical menuItem"></li>

             <li class = "menuItem"><a href="/Anuncios/Trabajo">Trabajo</a></li>
             <li class="divider-vertical menuItem"></li>

             <li class = "menuItem"><a href = "/Anuncios/EquisCosa">Equis cosa</a></li>
             <li class="divider-vertical menuItem"></li>

             <li class = "menuItem"><a href="/Anuncios/Create">¡Publicar anuncio!</a></li>
             <li class="divider-vertical menuItem"></li>
            </ul>
      </div>

            <div class="navbar-search pull-left">
            @Using Html.BeginForm("Busqueda", "Anuncios", Nothing, FormMethod.Post)
            @<div class="input-append">
              <input type="text" class="span2" name = "patern" id = "patern" placeholder = "¿Qué buscas?"/>
              <button class="btn">Buscar</button>
            </div>
           end using
          </div>

          <div class="nav-collapse collapse">
            @If conectado = True Then
            @<ul class="pull-right nav">
              <li class="divider-vertical menuItem"></li>
              <li class="dropdown menuItem">
                  <a href ='javascript:void(0);' class="dropdown-toggle" data-toggle="dropdown">
                     <i class="icon-user icon-white"></i> @email
                    <b class="caret vam"></b>
                  </a>
                  <ul class="dropdown-menu">
                    <li><a href="/Usuario/Edit/@idContacto"><i class="icon-edit"></i> mi cuenta</a></li>
                    <li><a href="/Anuncios/MisAnuncios/@idContacto"><i class="icon-inbox"></i> mis anuncios</a></li>
                    <li class="divider"></li>
                    <li><a onclick="logoutUsuario()" href="javascript:void(0);"><i class="icon-off"></i> cerrar sesión</a></li>
                  </ul>
             </li>
            </ul>
            Else
           @<ul class="pull-right nav">
              <li class="divider-vertical menuItem"></li>
              <li class="dropdown menuItem">
              <a href ='/Usuario/login' class="dropdown-toggle" data-toggle="dropdown">
                <i class="icon-off icon-white"></i> Conectarme
              </a>
              </li>
            </ul>
            End If
            
          </div>

        </div>
      </div>
    </div>