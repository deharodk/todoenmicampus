@ModelType IEnumerable(Of libros.Anuncio)

@Code
    ViewData("Title") = "Mis anuncios"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Mis anuncios</h1>

<p>
    @Html.ActionLink("Publicar nuevo anuncio", "Create")
</p>
<table class = "table table-bordered table-striped" id = "tblAnuncios">
<thead>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.titulo)
        </th>
      
        <th>
            @Html.DisplayNameFor(Function(model) model.TipoAnuncio.nombre)
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
            @Html.DisplayFor(Function(modelItem) currentItem.TipoAnuncio.nombre)
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
        @If currentItem.estatus = True Then
            Dim pipe As String = " | "
            @Html.ActionLink("Editar", "Edit", New With {.id = currentItem.idAnuncio})
            @pipe
            @Html.ActionLink("Detalles", "Details", New With {.id = currentItem.idAnuncio})
            @pipe
            @Html.ActionLink("Quitar", "Delete", New With {.id = currentItem.idAnuncio})
        Else
            Dim pipe As String = "|"
            @<a href = "javascript:void(0);">Editar</a>
            @pipe
            @<a href = "javascript:void(0);">Detalles</a>
            @pipe
            @<a href = "javascript:void(0);">Quitar</a>
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