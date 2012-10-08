@ModelType IEnumerable(Of libros.Facultad)

@Code
    ViewData("Title") = "Facultad"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Facultades</h1>
<p>
    @Html.ActionLink("Crear nueva facultad", "Create")
</p>
<table class="table table-bordered table-striped">
    <thead>
        <th>
           Nombre
        </th>
        <th>
           Nombre corto
        </th>
        <th>
            Estatus
        </th>
        <th>
            Acciones
        </th>
    </thead>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.nombreCorto)
        </td>
        <td>
           @If currentItem.estatus = True Then
                   @<center><img src = "../../../../assets/images/activo.png" alt = "Activo"/></center>
           Else
                    @<center><img src = "../../../../assets/images/inactivo.png" alt = "Inactivo"/></center>
           End If
                          
        </td>
        <td>
            @Html.ActionLink("Editar", "Edit", New With {.id = currentItem.idFacultad}) |
            @Html.ActionLink("Detalles", "Details", New With {.id = currentItem.idFacultad}) |
            @Html.ActionLink("Eliminar", "Delete", New With {.id = currentItem.idFacultad})
        </td>
    </tr>
Next

</table>
