@ModelType libros.TipoAnuncio

@Code
    ViewData("Title") = "Details"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Detalles</h1>

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
            @Html.EditorFor(Function(model) model.estatus, New With {.class = "input-xlarge", .readonly = "readonly"})
        </div>
    </div>
</fieldset>
<p>

    @Html.ActionLink("Editar", "Edit", New With {.id = Model.idTipoAnuncio}) |
    @Html.ActionLink("Volver a la lista", "Index")
</p>
