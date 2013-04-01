@Code
    ViewData("Title") = "¿Quiénes somos?"
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

<h1>¿Quiénes somos?</h1>

<p>
    Todo en mi campus, es un servicio para estudiantes universitarios que tiene por objetivo, el hacer que la información dentro
    de sus respectivos campus sea más accesible para ellos y que así puedan hacer llegar o recibir un mensaje con facilidad.
    <br />
</p>

<p>
    Creado por estudiantes para estudiantes, creémos en que sólo alguien que ha estado en el campus, puede comprender las
    necesidades que el estudiante de hoy en día puede tener para comunicarse dentro del mismo. 
    Siempre estaremos al pendiente de darte un servicio adecuado. No te preocupes, ¡el servicio es y seguirá siendo gratis!
</p>