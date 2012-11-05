@ModelType IEnumerable(Of libros.TipoAnuncio)

@Code
    ViewData("Title") = "Tipo de anuncios"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Tipo de anuncios</h1>

<p>
    @Html.ActionLink("Crear nuevo", "Create")
</p>
<table class = "table table-bordered table-striped">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.estatus)
        </th>
        <th>
            Acciones
        </th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.nombre)
        </td>
        <td>
           @If currentItem.estatus = True Then
                   @<center><img src = "../../../../assets/images/activo.png" alt = "Activo"/></center>
           Else
                    @<center><img src = "../../../../assets/images/inactivo.png" alt = "Inactivo"/></center>
           End If
        </td>
        <td>
            @Html.ActionLink("Editar", "Edit", New With {.id = currentItem.idTipoAnuncio}) |
            @Html.ActionLink("Detalles", "Details", New With {.id = currentItem.idTipoAnuncio}) |
            @Html.ActionLink("Eliminar", "Delete", New With {.id = currentItem.idTipoAnuncio})
        </td>
    </tr>
Next

</table>
