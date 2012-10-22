@ModelType libros.Contacto

@Code
    ViewData("Title") = "Details"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Detalles</h1>

<fieldset>
    <legend>Usuario</legend>

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
        Facultad
        <div class="controls">
            @Html.TextBoxFor(Function(model) model.Facultad.nombreCorto, New With {.class = "input-xlarge", .readonly = "readonly"})
        </div>
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.estatus)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.estatus)
    </div>
</fieldset>

<br />
<p>
    @Html.ActionLink("Editar password", "Edit", New With {.id = Model.idContacto}) |
    @Html.ActionLink("Volver a la lista", "Index")
</p>
