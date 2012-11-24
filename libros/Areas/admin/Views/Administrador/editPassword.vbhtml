@ModelType libros.Administrador

@Code
    ViewData("Title") = "Cambiar contraseña"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h2>Cambiar contraseña</h2>

@Using Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmAdministradorPass"})
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Administrador</legend>

        @Html.HiddenFor(Function(model) model.idAdministrador)

        <div class="editor-field">
            @Html.hiddenfor(Function(model) model.email)
            @Html.ValidationMessageFor(Function(model) model.email)
        </div>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.pass, New With {.class = "control-label"})
        <div class="controls">
            @Html.PasswordFor(Function(model) model.pass, New With {.class = "input-xlarge", .id = "txtPass", .maxlength = 255})
            @Html.ValidationMessageFor(Function(model) model.pass)
        </div>
        </div>

        <div class="control-group">
            @Html.Label("Confirmar nueva contraseña", New With {.class = "control-label"})
            <div class="controls">
                @Html.Password("txtPassConfirm", Nothing, New With {.id = "txtPassConfirm", .class = "input-xlarge", .maxlength = 255})
            </div>
        </div>

        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.nombre)
            @Html.ValidationMessageFor(Function(model) model.nombre)
        </div>

        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.estatus)
            @Html.ValidationMessageFor(Function(model) model.estatus)
        </div>
    
        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.superUsuario)
            @Html.ValidationMessageFor(Function(model) model.superUsuario)
        </div>
        <div class="form-actions">
            <input type="submit" class = "btn btn-primary" value="Cambiar contraseña" />
        </div>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Volver a la lista", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/assets/js/administrador.js")
End Section

