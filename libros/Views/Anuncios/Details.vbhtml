@ModelType libros.Anuncio

@Code
    ViewData("Title") = Model.titulo & " - todo en mi campus"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1 class = "ww">@Model.titulo</h1>

<div class = "floatRight">
    <a href="https://twitter.com/share" class="twitter-share-button" data-lang="en" data-url = "@HttpContext.Current.Request.Url.AbsoluteUri" data-text = "Te invito a ver lo que hay en mi campus - ">Tweet</a>
    <script type = "text/javascript">
        !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "https://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");
    </script>

    <iframe src="//www.facebook.com/plugins/like.php?href=@Server.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri)&amp;send=false&amp;layout=button_count&amp;width=450&amp;show_faces=false&amp;font=arial&amp;colorscheme=light&amp;action=like&amp;height=21" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:109px; height:19.6px;" allowTransparency="true"></iframe>
</div>

<p><b>Publicado por:</b> <a href = "/Usuario/Details/@Model.Contacto.idContacto" target = "_blank">@Model.Contacto.nombre</a>

<br />
<b>El día:</b> @Model.fechaCreacion
</p>
<hr />
<p class = "ww">@Html.Raw(Model.descripcion)</p>

 
<br />
<hr />

<p><b>Precio:</b> <code>$@CDbl(Model.precioTotal)</code></p>

<p><b>Tipo anuncio:</b> @Model.TipoAnuncio.nombre</p>
  
<p><b>Forma de pago:</b> @Model.FormaPago.nombre</p>

@If ViewBag.isUserSeeing = True Then
    @Html.ActionLink("Volver a mis anuncios", "MisAnuncios", New With {.id = Model.idContacto})
End If

<hr />


<div id="fb-root"></div>
<script type = "text/javascript">    
    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/es_LA/all.js#xfbml=1";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));
</script>

<div class="fb-comments" data-href="@HttpContext.Current.Request.Url.AbsoluteUri" data-width="940" data-num-posts="10"></div>