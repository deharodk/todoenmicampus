@ModelType libros.Administrador

@Code
    ViewData("Title") = "Crear nuevo"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
    
End Code

<h1>Crear nuevo</h1>

@Using Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmAdministradorCreate"})
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Administrador</legend>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.email, New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBoxFor(Function(model) model.email, New With {.class = "input-xlarge", .id = "txtMail"})
                @Html.ValidationMessageFor(Function(model) model.email)
            </div>
        </div>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.pass, New With {.class = "control-label"})
            <div class="controls">
                @Html.PasswordFor(Function(model) model.pass, New With {.class = "input-xlarge", .id = "txtPass"})
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
                @Html.EditorFor(Function(model) model.estatus, New With {.id = "chkEstatus"})
                @Html.ValidationMessageFor(Function(model) model.estatus)
            </div>
        </div>

        <div class="form-actions">
            <button class="btn btn-primary" id = "btnSubmit">Crear</button>
            <button class="btn" type="reset">Resetear</button>
        </div>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Volver a la lista", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/assets/js/administrador.js")
End Section
