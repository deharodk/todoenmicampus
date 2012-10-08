@ModelType libros.Administrador

@Code
    ViewData("Title") = "Detalles"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Detalles</h1>

<fieldset>
    <legend>Administrador</legend>

    <div class="control-group">
        @Html.LabelFor(Function(model) model.email, New With {.class = "control-label"})
        <div class="controls">
            @Html.TextBoxFor(Function(model) model.email, New With {.class = "input-xlarge", .readonly = "readonly"})
        </div>
    </div>

    <div class="control-group">
        @Html.LabelFor(Function(model) model.nombre, New With {.class = "control-label"})
        <div class="controls">
            @Html.TextBoxFor(Function(model) model.nombre, New With {.class = "input-xlarge", .readonly = "readonly"})
        </div>
    </div>

    <div class="control-group">
        @Html.LabelFor(Function(model) model.estatus, New With {.class = "control-label"})
        <div class="controls">
            @Html.DisplayFor(Function(model) model.estatus)
        </div>
    </div>
</fieldset>
<p>

    @Html.ActionLink("Editar", "Edit", New With {.id = Model.idAdministrador}) |
    @Html.ActionLink("Volver a la lista", "Index")
</p>
