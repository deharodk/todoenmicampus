@Code
    ViewData("Title") = "Tablero de indicadores"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Indicadores</h1>

<table class = "dashboardTable">
    <thead>
        <tr>
            <th>Anuncios</th>
            <th>Usuarios</th>
            @If ViewBag.superPermisos = True Then
                @<th>Administradores</th>
            End If
        </tr>
    </thead>
    <tbody>
    <tr>
        <td>
            <p class = "dashboardP">
            <b>Total anuncios:</b> <br /><br />
            
            <span class="badge badge-info">@ViewBag.totalAnuncios</span>
            </p> 

            <p class = "dashboardP">
            <b>Anuncios activos:</b> <br /><br />
           
            <span class="badge badge-success">@ViewBag.totalAnunciosActivos</span>
            </p>

            <p class = "dashboardP">
            <b>Anuncios inactivos:</b> <br /><br />
            
            <span class="badge badge-important">@ViewBag.totalAnunciosInactivos</span>
            </p> 

            <p class = "dashboardP">
            <b>Anuncios hoy:</b> <br /><br />
          
            <span class="badge badge-inverse">@ViewBag.totalAnunciosHoy</span>
            </p> 

            <p class = "dashboardP">
            <b>Anuncios este mes:</b> <br /><br />
            
            <span class="badge badge-inverse">@ViewBag.totalAnunciosMes</span>
            </p> 

        </td>

        <td>
            <p class = "dashboardP">
            <b>Total usuarios:</b> <br /><br />
            
            <span class="badge badge-info">@ViewBag.totalUsuarios</span>
            </p> 

            <p class = "dashboardP">
            <b>Usuarios activos:</b> <br /><br />
           
            <span class="badge badge-success">@ViewBag.totalUsuariosActivos</span>
            </p>

            <p class = "dashboardP">
            <b>Usuarios inactivos:</b> <br /><br />
            
            <span class="badge badge-important">@ViewBag.totalUsuariosInactivos</span>
            </p>

        </td> 

        @If ViewBag.superPermisos = True Then
            @<td>
            <p class = "dashboardP">
            <b>Total administradores:</b> <br /><br />
            
            <span class="badge badge-info">@ViewBag.totalAdministradores</span>
            </p> 

            <p class = "dashboardP">
            <b>Administradores activos:</b> <br /><br />
            
            <span class="badge badge-success">@ViewBag.totalAdministradoresActivos</span>
            </p>

            <p class = "dashboardP">
            <b>Administradores inactivos:</b> <br /><br />
            
            <span class="badge badge-important">@ViewBag.totalAdministradoresInactivos</span>
            </p>
            </td>
        End If
    </tr>
    </tbody>
</table>








