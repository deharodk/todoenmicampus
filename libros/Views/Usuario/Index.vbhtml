@ModelType IEnumerable(Of libros.Contacto)

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
            @Html.DisplayNameFor(Function(model) model.nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.email)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.numeroMovil)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.cuentaTwitter)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.cuentaFB)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Facultad.nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.pass)
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
            @Html.DisplayFor(Function(modelItem) currentItem.nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.email)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.numeroMovil)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.cuentaTwitter)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.cuentaFB)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Facultad.nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.pass)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.estatus)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.idContacto}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.idContacto}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.idContacto})
        </td>
    </tr>
Next

</table>
