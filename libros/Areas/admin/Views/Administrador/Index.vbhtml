@ModelType IEnumerable(Of libros.Administrador)

@Code
    ViewData("Title") = "Administrador"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Administradores</h1>

<p>
    @Html.ActionLink("Crear nuevo", "Create")
</p>
<table class = "table table-bordered table-striped">
    <thead>
        <th>
           Nombre de usuario
        </th>
        <th>
            Nombre completo
        </th>
        <th>
            Estatus
        </th>
        <th></th>
    </thead>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.email)
        </td>
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
            @Html.ActionLink("Editar", "Edit", New With {.id = currentItem.idAdministrador}) |
            @Html.ActionLink("Cambio password", "editPassword", New With {.id = currentItem.idAdministrador}) |
            @Html.ActionLink("Detalles", "Details", New With {.id = currentItem.idAdministrador}) |
            @Html.ActionLink("Eliminar", "Delete", New With {.id = currentItem.idAdministrador}) |
        </td>
    </tr>
Next

</table>
