@ModelType libros.Anuncio

@Code
    ViewData("Title") = "Detalles del anuncio"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1 class = "ww">@Model.titulo</h1>

<p><b>Publicado por:</b> <a href = "/Usuario/Details/@Model.Contacto.idContacto" target = "_blank">@Model.Contacto.nombre</a>

<br />
<b>El día:</b> @Model.fechaCreacion
</p>
<hr />

<p class = "ww">
@Html.Raw(Model.descripcion)
</p>

 
<br />
<hr />

<p><b>Precio:</b> <code>$@CDbl(Model.precioTotal)</code></p>

<p><b>Tipo anuncio:</b> @Model.TipoAnuncio.nombre</p>
  
<p><b>Forma de pago:</b> @Model.FormaPago.nombre</p>
   
<p>
    @Html.ActionLink("Dar baja", "Delete", New With {.id = Model.idAnuncio}) |
    @Html.ActionLink("Volver a la lista", "Index")
</p>
