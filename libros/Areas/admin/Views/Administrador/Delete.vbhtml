@ModelType libros.Administrador

@Code
    ViewData("Title") = "Eliminar"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Eliminar</h1>
<h3>¿Estás seguro de que deseas borrar este administrador?</h3>

<fieldset>
    <legend>Administrador</legend>

    <div class="control-group">
        @Html.LabelFor(Function(model) model.email, New With {.class = "control-label"})
        <div class="controls">
            @Html.TextBoxFor(Function(model) model.email, New With {.class = "input-xlarge", .readonly = "readonly"})
        </div>
    </div>

    <div class="display-label">
        @Html.LabelFor(Function(model) model.nombre, New With {.class = "control-label"})
    </div>
    <div class="display-field">
        @Html.TextBoxFor(Function(model) model.nombre, New With {.class = "input-xlarge", .readonly = "readonly"})
    </div>

    <div class="display-label">
        @Html.LabelFor(Function(model) model.estatus, New With {.class = "control-label"})
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.estatus)
    </div>
</fieldset>
<br />
@Using Html.BeginForm()
    @<p>
        <input type="submit" class="btn btn-warning" value="Borrar" /> |
        @Html.ActionLink("Volver a la lista", "Index")
    </p>
End Using
