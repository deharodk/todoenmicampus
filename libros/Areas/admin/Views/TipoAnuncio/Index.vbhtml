@ModelType IEnumerable(Of libros.TipoAnuncio)

@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.tipoAnuncio)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.estatus)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.tipoAnuncio)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.estatus)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.idTipoAnuncio}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.idTipoAnuncio}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.idTipoAnuncio})
        </td>
    </tr>
Next

</table>
