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
            En todo en mi campus, puedes encontrar lo que necesitas, desde alguien que venda algún libro que ocupas, 
            alguien que dé asesorías en alguna materia que te vaya del nabo, alguien que rente o comparta un cuarto para ti, alguien que
            ofezca la chamba que estás esperando o alguien que venda o compre equis cosa.
            Todo esto es entre tu misma comunidad universitaria, cerca de ti.
        </p>
    </div>

    <div class="span4">
        <h2>Ofrece/Comparte</h2>
        <p>
             ¿Tienes libros o equis cosa que ya no uses y desees vender? 
             ¿Andas buscando chamba o prácticas?
             ¿Eres bueno para alguna materia y piensas que puedes compartir tu conocimiento y ganar algo de dinero con eso?
             ¿Rentas o compartes cuarto pero no has encontrado roomie?
             <br />
             ¡En todo en mi campus te podemos ayudar!
        </p>
 
    </div>

    <div class="span4">
        <h2>Crea comunidad</h2>
        <p>
            En todo en mi campus estamos seguros que vas a poder contactar personas que coincidan
            con tus intereses. Te sorprenderemos de aquí
            en adelante porque vamos a conectar cada vez más tu universidad contigo. ¡Gracias por tu apoyo!
        </p>

        <p>
            <a class="btn pull-right" href="/Anuncios/Create">¡Comenzar ahora! <i class = "icon-play-circle"></i></a>
        </p>
    </div>
</div>
