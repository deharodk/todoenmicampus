@ModelType IEnumerable(Of libros.FormaPago)

@Code
    ViewData("Title") = "Formas de pago"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Formas de pago</h1>

<p>
    @Html.ActionLink("Crear nueva", "Create")
</p>
<table class="table table-bordered table-striped">
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
            @Html.ActionLink("Editar", "Edit", New With {.id = currentItem.idFormaPago}) |
            @Html.ActionLink("Detalles", "Details", New With {.id = currentItem.idFormaPago}) |
            @Html.ActionLink("Eliminar", "Delete", New With {.id = currentItem.idFormaPago})
        </td>
    </tr>
Next

</table>
