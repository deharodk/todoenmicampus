@ModelType libros.Administrador

@Code
    ViewData("Title") = "Editar"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h2>Editar</h2>

@Using Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmAdministradorEdit"})
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Administrador</legend>

        @Html.HiddenFor(Function(model) model.idAdministrador)

        <div class="control-group">
            @Html.LabelFor(Function(model) model.email, New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBoxFor(Function(model) model.email, New With {.class = "input-xlarge", .id = "txtMail", .readonly = "readonly"})
                @Html.ValidationMessageFor(Function(model) model.email)
            </div>
        </div>

        <div class="control-group">
            <div class = "controls">
                @Html.HiddenFor(Function(model) model.pass, New With {.id = "txtPass"})
                @Html.ValidationMessageFor(Function(model) model.pass)
            </div>
        </div>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.nombre, New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBoxFor(Function(model) model.nombre, New With {.class = "input-xlarge", .id = "txtNombre"})
                @Html.ValidationMessageFor(Function(model) model.nombre)
            </div>
        </div>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.estatus, New With {.class = "control-label"})
            <div class="controls">
                @Html.EditorFor(Function(model) model.estatus)
                @Html.ValidationMessageFor(Function(model) model.estatus)
            </div>
        </div>

        <div class="control-group">
            <div class = "controls">
                @Html.HiddenFor(Function(model) model.superUsuario)
                @Html.ValidationMessageFor(Function(model) model.superUsuario)
            </div>
        </div>
         <div class="form-actions">
            <button class="btn btn-primary" type="submit">Actualizar</button>
        </div>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Volver a la lista", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/assets/js/administrador.js")
End Section
