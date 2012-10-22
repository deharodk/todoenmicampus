@ModelType libros.Contacto

@Code
    ViewData("Title") = "Edit"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Cambiar password</h1>

@Using Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmContactoPass"})
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Contacto</legend>

        @Html.HiddenFor(Function(model) model.idContacto)

        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.nombre)
            @Html.ValidationMessageFor(Function(model) model.nombre)
        </div>

        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.email)
            @Html.ValidationMessageFor(Function(model) model.email)
        </div>

        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.numeroMovil)
            @Html.ValidationMessageFor(Function(model) model.numeroMovil)
        </div>

        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.cuentaFB)
            @Html.ValidationMessageFor(Function(model) model.cuentaFB)
        </div>

         <div class="editor-field">
            @Html.HiddenFor(Function(model) model.cuentaTwitter)
            @Html.ValidationMessageFor(Function(model) model.cuentaTwitter)
        </div>

        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.idFacultad)
            @Html.ValidationMessageFor(Function(model) model.idFacultad)
        </div>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.pass, New With {.class = "control-label"})
        <div class="controls">
            @Html.PasswordFor(Function(model) model.pass, New With {.class = "input-xlarge", .id = "txtPass"})
            @Html.ValidationMessageFor(Function(model) model.pass)
        </div>
        </div>

        <div class="control-group">
            @Html.Label("Confirmar nueva contraseña", New With {.class = "control-label"})
            <div class="controls">
                @Html.Password("txtPassConfirm", Nothing, New With {.id = "txtPassConfirm", .class = "input-xlarge"})
            </div>
        </div>

        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.estatus)
            @Html.ValidationMessageFor(Function(model) model.estatus)
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
    @Scripts.Render("~/assets/js/contacto.js")
End Section
