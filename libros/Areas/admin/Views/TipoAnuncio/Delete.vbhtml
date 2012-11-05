@ModelType libros.TipoAnuncio

@Code
    ViewData("Title") = "Delete"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Eliminar</h1>

<h3>¿Estás seguro de que deseas eliminar este tipo de anuncio?</h3>

<fieldset>
    <legend>Tipo de anuncio</legend>

     <div class="control-group">
        @Html.LabelFor(Function(model) model.nombre, New With {.class = "control-label"})
        <div class="controls">
            @Html.TextBoxFor(Function(model) model.nombre, New With {.class = "input-xlarge", .readonly = "readonly"})
        </div>
    </div>


     <div class="control-group">
        @Html.LabelFor(Function(model) model.estatus, New With {.class = "control-label"})
        <div class="controls">
            @Html.DisplayFor(Function(model) model.estatus, New With {.class = "input-xlarge", .readonly = "readonly"})
        </div>
    </div>

</fieldset>
@Using Html.BeginForm()
    @<p>
        <input type="submit" class="btn btn-warning" value="Borrar" /> |
        @Html.ActionLink("Volver a la lista", "Index")
    </p>
End Using
