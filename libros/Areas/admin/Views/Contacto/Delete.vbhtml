@ModelType libros.Contacto

@Code
    ViewData("Title") = "Delete"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Deshabilitar</h1>

<h3>¿Estás seguro que deseas deshabilitar este usuario?</h3>
<fieldset>
    <legend>Contacto</legend>

    <div class="control-group">
        @Html.LabelFor(Function(model) model.nombre, New With {.class = "control-label"})
        <div class="controls">
            @Html.TextBoxFor(Function(model) model.nombre, New With {.class = "input-xlarge", .readonly = "readonly"})
        </div>
    </div>

    <div class="control-group">
        @Html.LabelFor(Function(model) model.email, New With {.class = "control-label"})
        <div class="controls">
            @Html.TextBoxFor(Function(model) model.email, New With {.class = "input-xlarge", .readonly = "readonly"})
        </div>
    </div>

    <div class="control-group">
        @Html.LabelFor(Function(model) model.numeroMovil, New With {.class = "control-label"})
        <div class="controls">
            @Html.TextBoxFor(Function(model) model.numeroMovil, New With {.class = "input-xlarge", .readonly = "readonly"})
        </div>
    </div>

    <div class="control-group">
        @Html.LabelFor(Function(model) model.cuentaTwitter, New With {.class = "control-label"})
        <div class="controls">
            @Html.TextBoxFor(Function(model) model.cuentaTwitter, New With {.class = "input-xlarge", .readonly = "readonly"})
        </div>
    </div>

    <div class="control-group">
        @Html.LabelFor(Function(model) model.cuentaFB, New With {.class = "control-label"})
        <div class="controls">
            @Html.TextBoxFor(Function(model) model.cuentaFB, New With {.class = "input-xlarge", .readonly = "readonly"})
        </div>
    </div>


    <div class="control-group">
        @Html.LabelFor(Function(model) model.Facultad.nombreCorto, New With {.class = "control-label"})
        <div class="controls">
            @Html.TextBoxFor(Function(model) model.Facultad.nombreCorto, New With {.class = "input-xlarge", .readonly = "readonly"})
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
        <input type="submit" value="Deshabilitar" class="btn btn-warning"/> |
        @Html.ActionLink("Volver a la lista", "Index")
    </p>
End Using
