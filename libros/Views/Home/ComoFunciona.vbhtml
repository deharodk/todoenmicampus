@Code
    ViewData("Title") = "¿Cómo funciona? - todoenmicampus"
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

<center>
    <iframe class="youtube-player" type="text/html" width="640" height="385" src="http://www.youtube.com/embed/ERT0pVYmwRk" frameborder="0"></iframe>
        
    <br />


    <p>

      <a class="btn" href="/Anuncios/Create">¡Comenzar ahora! <i class = "icon-play-circle"></i></a>

    </p>

</center>
