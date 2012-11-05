@ModelType IEnumerable(Of libros.Anuncio)

@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.titulo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.descripcion)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.precioTotal)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.estatus)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Contacto.nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TipoAnuncio.nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.fechaCreacion)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FormaPago.nombre)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.titulo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.descripcion)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.precioTotal)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.estatus)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Contacto.nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.TipoAnuncio.nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.fechaCreacion)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.FormaPago.nombre)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.idAnuncio}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.idAnuncio}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.idAnuncio})
        </td>
    </tr>
Next

</table>
