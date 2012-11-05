@ModelType IEnumerable(Of libros.Contacto)

@Code
    ViewData("Title") = "Usuarios"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Usuarios</h1>
<table class = "table table-bordered table-striped" id = "tblUsuarios">
<thead>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.email)
        </th>
        <th>
            Facultad
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.estatus)
        </th>
        <th>
            Acciones
        </th>
    </tr>
</thead>
<tbody>
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
            @Html.DisplayFor(Function(modelItem) currentItem.Facultad.nombreCorto)
        </td>
         <td>
           @If currentItem.estatus = True Then
                   @<center><img src = "../../../../assets/images/activo.png" alt = "Activo"/></center>
           Else
                    @<center><img src = "../../../../assets/images/inactivo.png" alt = "Inactivo"/></center>
           End If
        </td>
        <td>
            @Html.ActionLink("Detalles", "Details", New With {.id = currentItem.idContacto}) |
            @Html.ActionLink("Cambiar password", "Edit", New With {.id = currentItem.idContacto}) |
            @If currentItem.estatus = True Then
                @Html.ActionLink("Deshabilitar", "Delete", New With {.id = currentItem.idContacto})
            Else
                @Html.ActionLink("Habilitar", "Habilitar", New With {.id = currentItem.idContacto})
            End If
        </td>
    </tr>
Next
   </tbody>
</table>

<br />
<br />

@Section Scripts
    @Scripts.Render("~/assets/js/contacto.js")
End Section