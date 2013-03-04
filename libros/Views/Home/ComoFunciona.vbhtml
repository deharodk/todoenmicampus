@Code
    ViewData("Title") = "ComoFunciona"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<br />

<div class = "floatRight">
    <a href="https://twitter.com/share" class="twitter-share-button" data-lang="en" data-url = "@HttpContext.Current.Request.Url.AbsoluteUri" data-text = "Te invito a ver lo que hay en mi campus - ">Tweet</a>
    <script type = "text/javascript">
        !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = "https://platform.twitter.com/widgets.js"; fjs.parentNode.insertBefore(js, fjs); } } (document, "script", "twitter-wjs");
    </script>

    <iframe src="//www.facebook.com/plugins/like.php?href=@Server.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri)&amp;send=false&amp;layout=button_count&amp;width=450&amp;show_faces=false&amp;font=arial&amp;colorscheme=light&amp;action=like&amp;height=21" scrolling="no" frameborder="0" style="border:none; overflow:hidden; width:109px; height:19.6px;" allowTransparency="true"></iframe>
</div>

<h1>¿Cómo funciona?</h1>

<div class="row-fluid">
    <div class="span4">
        <h2>Encuentra</h2>
        <p>
            En todoenmicampus.com, puedes encontrar lo que necesitas, desde alguien que venda algún libro que ocupas, 
            alguien que dé asesorías en alguna materia que te vaya del nabo, o alguien que rente o comparta un cuarto para ti.
            Todo esto es entre tú misma comunidad universitaria, cerca de ti.
        </p>
    </div>

    <div class="span4">
        <h2>Ofrece/Comparte</h2>
        <p>
             ¿Tienes libros que ya no uses y desees vender? 
             ¿Eres bueno para alguna materia y piensas que puedes compartir tu conocimiento y ganar algo de dinero con eso?
             ¿Rentas o compartes cuarto pero no has encontrado roomie?
             <br />
             ¡Entonces todoenmicampus.com es lo que buscas!
        </p>
 
    </div>

    <div class="span4">
        <h2>Crea comunidad</h2>
        <p>
            En todoenmicampus.com estamos seguros que vas a poder contactar personas que coincidan
            con tus intereses. Estamos intentando crear la comunidad más grande dentro de tú universidad, ningún
            otro lugar está actualmente intentando hacer lo que nosotros, tú apoyo es muy importante. Te sorprenderemos de aquí
            en adelante, vamos a conectar cada vez más tú universidad contigo. ¡Gracias por tú apoyo!
        </p>

        <p>
            <a class="btn pull-right" href="/Anuncios/Create">¡Comenzar ahora! <i class = "icon-play-circle"></i></a>
        </p>
    </div>
</div>
