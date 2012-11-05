@ModelType IEnumerable(Of libros.Anuncio)

@Code
    ViewData("Title") = "Anuncios"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Anuncios</h1>

<table class = "table table-bordered table-striped" id = "tblAnuncios">
<thead>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.titulo)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.precioTotal)
        </th>
     
        <th>
            Usuario
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TipoAnuncio.nombre)
        </th>
     
        <th>
            @Html.DisplayNameFor(Function(model) model.FormaPago.nombre)
        </th>

        <th>
            @Html.DisplayNameFor(Function(model) model.fechaCreacion)
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
            @Html.DisplayFor(Function(modelItem) currentItem.titulo)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.precioTotal)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Contacto.nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.TipoAnuncio.nombre)
        </td>

        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.FormaPago.nombre)
        </td>

        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.fechaCreacion)
        </td>

        <td>
           @If currentItem.estatus = True Then
                   @<center><img src = "../../../../assets/images/activo.png" alt = "Activo"/></center>
           Else
                    @<center><img src = "../../../../assets/images/inactivo.png" alt = "Inactivo"/></center>
           End If
        </td>
        <td>
            @Html.ActionLink("Detalles", "Details", New With {.id = currentItem.idAnuncio}) |

            @If currentItem.estatus = True Then
                @Html.ActionLink("Dar baja", "Delete", New With {.id = currentItem.idAnuncio}) 
            Else
                @<a href = "javascript:void(0);">Dar baja</a>
            End If
        </td>
    </tr>
            Next
    </tbody>
</table>

<br />
<br />

@Section Scripts
    @Scripts.Render("~/assets/js/anuncio.js")
End Section