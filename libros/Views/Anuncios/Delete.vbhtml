@ModelType libros.Anuncio

@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>¿Estás seguro que deseas quitar este anuncio?</h1>

<h1>@Model.titulo</h1>

<p><b>Publicado por:</b> <a href = "/Usuario/Details/@Model.Contacto.idContacto" target = "_blank">@Model.Contacto.nombre</a>

<br />
<b>El día:</b> @Model.fechaCreacion
</p>

@Html.raw(Model.descripcion)
 
<br />

<p><b>Precio:</b> <code>$@CDbl(Model.precioTotal)</code></p>

<p><b>Tipo anuncio:</b> @Model.TipoAnuncio.nombre</p>
  
<p><b>Forma de pago:</b> @Model.FormaPago.nombre</p>




@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Quitar" class = "btn btn-danger"/> |
        @Html.ActionLink("Volver a mis anuncios", "MisAnuncios", New With {.id = Model.idContacto})
    </p>
End Using
