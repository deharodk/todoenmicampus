@ModelType IEnumerable(Of libros.FormaPago)

@Code
    ViewData("Title") = "Index"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.formaPago)
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
            @Html.DisplayFor(Function(modelItem) currentItem.formaPago)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.estatus)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.idFormaPago}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.idFormaPago}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.idFormaPago})
        </td>
    </tr>
Next

</table>
