@ModelType IEnumerable(Of libros.TipoAnuncio)

@Code
    ViewData("Title") = "TiposAnuncio"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>¿Dudas sobre los tipos de anuncio? <br /> ¡Aquí te explicamos!</h1>


<table class = "table table-bordered table-striped">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.descripcion)
        </th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.nombre)
        </td>
        <td>
          @Html.DisplayFor(Function(modelItem) currentItem.descripcion)
        </td>
    </tr>
Next

</table>