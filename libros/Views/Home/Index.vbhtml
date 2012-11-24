@ModelType IEnumerable(Of libros.Anuncio)

@Code
    ViewData("Title") = "Todo en mi campus"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Últimos anuncios publicados</h1>


<table class = "table table-bordered table-striped dataTable anuncioTable" id = "tblAnuncios">
<thead>
    <tr>
        <th></th>
    </tr>
</thead>
<tbody>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
           
            <div class = "anuncioDiv">
                <h4 class = "anuncioH4">@currentItem.titulo</h4>
                <p class = "anuncioP">
                    <b>Anunciante:</b> <a target = "_blank" href = "/Usuario/Details/@currentItem.idContacto">@currentItem.Contacto.nombre</a>
                    <br />
                    <b>Tipo anuncio:</b>  <a href = "/Anuncios/Categoria/@currentItem.idTipoAnuncio">@currentItem.TipoAnuncio.nombre</a>
                    <br />
                    <b>Costo: </b> <code>$ @Math.Round(currentItem.precioTotal, 2)</code>
                    <br />
                    <b>Fecha de anuncio: </b> @currentItem.fechaCreacion
                    <br />
                    <a class="btn btn-medium" href="/Anuncios/Details/@currentItem.idAnuncio"><i class="icon-zoom-in"></i>  Ver anuncio</a>
                </p>
            </div>
         
        </td>
    </tr>
Next
</tbody>
<br />
<br />
</table>



@Section Scripts
    @Scripts.Render("~/assets/js/home.js")
End Section


<br />
<br />