﻿@ModelType IEnumerable(Of libros.Anuncio)

@Code
    ViewData("Title") = "Todo en mi campus - anuncios de roomies/cuartos"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Anuncios de roomies/cuartos</h1>
<div class = "floatRight">
    <a href="https://twitter.com/todoenmicampus" class="twitter-follow-button" data-show-count="false">Síguenos</a>
    <script>
        !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "//platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");
    </script>

    <iframe src="//www.facebook.com/plugins/like.php?href=@Server.UrlEncode("http://www.facebook.com/pages/Todo-en-mi-campus/517859971597768?ref=hl")&amp;send=false&amp;layout=button_count&amp;width=450&amp;show_faces=false&amp;font=arial&amp;colorscheme=light&amp;action=like&amp;height=21" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:109px; height:19.6px;" allowTransparency="true"></iframe>
</div>



<table class = "table table-bordered table-striped dataTable anuncioTable" id = "tblAnunciosPublicacion">
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
    @Scripts.Render("~/assets/js/anuncio.js")
End Section


<br />
<br />
