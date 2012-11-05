@Code
    ViewData("Title") = "¡Muy bien!"
    Layout = "~/Views/Shared/_Layout.vbhtml"
    Dim idUsuario As Integer = 0
    Try
        idUsuario = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
    Catch ex As Exception

    End Try
End Code

<h1>¡Muy bien!</h1>

<p>Has hecho una publicación exitosa de un anuncio de todo en mi campus, ahora puedes @Html.ActionLink("ver tus anuncios", "MisAnuncios", "Anuncios", New With {.id = idUsuario}, Nothing)
o @Html.ActionLink("ver anuncios publicados", "Index", "Home")
</p>

<br />

<center><img src = "../../assets/images/welldone.png" alt = "Éxito" /></center>
