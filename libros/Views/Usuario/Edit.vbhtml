@ModelType libros.Contacto

@Code
    ViewData("Title") = "Actualizar información de mi cuenta"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Mis datos</h1>

@Using Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmEditarCuenta"})
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Información de mi cuenta</legend>

        @If ViewBag.actualizado = True Then
           @<div class="alert alert-info" id ="lblError">
            <a class="close" id ="aClose">×</a>
            <h4 class="alert-heading">¡Éxito!</h4>
            <p>
                Haz actualizado la información de tu cuenta con éxito. :)
            </p>
            </div>
        End If

        @Html.HiddenFor(Function(model) model.idContacto)

        @Html.HiddenFor(Function(model) model.suspendido)

        <div class="control-group">
			@Html.LabelFor(Function(model) model.nombre, New With {.class = "control-label"})
				<div class="controls">
					 @Html.TextBoxFor(Function(model) model.nombre, New With {.class = "input-xlarge", .id = "txtNombre", .maxlength = 255, .placeholder = "Nombre de usuario"})
					<span class="help-inline">  @Html.ValidationMessageFor(Function(model) model.nombre) </span>
				<p class="help-block"></p>
			    </div>
		</div>

        <div class="control-group">
			@Html.LabelFor(Function(model) model.email, New With {.class = "control-label"})
				<div class="controls">
					 @Html.TextBoxFor(Function(model) model.email, New With {.class = "input-xlarge", .id = "txtEmail", .readonly = "readonly", .maxlength = 255})
					<span class="help-inline">  @Html.ValidationMessageFor(Function(model) model.email) </span>
				<p class="help-block"></p>
			    </div>
		</div>


        <div class="control-group">
			@Html.LabelFor(Function(model) model.numeroMovil, New With {.class = "control-label"})
				<div class="controls">
					 @Html.TextBoxFor(Function(model) model.numeroMovil, New With {.class = "input-xlarge", .id = "txtNumeroMovil", .maxlength = 20, .placeholder = "Número móvil (opcional)"})
					<span class="help-inline">  @Html.ValidationMessageFor(Function(model) model.numeroMovil) </span>
				<p class="help-block"></p>
			    </div>
		</div>

        <div class="control-group">
			@Html.LabelFor(Function(model) model.cuentaTwitter, New With {.class = "control-label"})
				<div class="controls">
					 @Html.TextBoxFor(Function(model) model.cuentaTwitter, New With {.class = "input-xlarge", .id = "txtCuentaTwitter", .maxlength = 255, .placeholder = "Tu cuenta de twitter (opcional)"})
					<span class="help-inline">  @Html.ValidationMessageFor(Function(model) model.cuentaTwitter) </span>
				<p class="help-block"></p>
			    </div>
		</div>

        <div class="control-group">
			@Html.LabelFor(Function(model) model.cuentaFB, New With {.class = "control-label"})
				<div class="controls">
					 @Html.TextBoxFor(Function(model) model.cuentaFB, New With {.class = "input-xlarge", .id = "txtFB", .maxlength = 255, .placeholder = "Tu cuenta de facebook (opcional)"})
					<span class="help-inline">  @Html.ValidationMessageFor(Function(model) model.cuentaFB) </span>
				<p class="help-block"></p>
			    </div>
		</div>

       <div class="control-group">
			@Html.LabelFor(Function(model) model.idFacultad, New With {.class = "control-label"})
				<div class="controls">
					 @Html.DropDownList("idFacultad", "[Seleccionar]")
					<span class="help-inline">  @Html.ValidationMessageFor(Function(model) model.idFacultad) </span>
				<p class="help-block"></p>
			    </div>
		</div>

        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.pass)
            @Html.ValidationMessageFor(Function(model) model.pass)
        </div>

        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.estatus)
            @Html.ValidationMessageFor(Function(model) model.estatus)
        </div>

        <div class="form-actions">
          <button class="btn btn-primary" type="submit">Actualizar mis datos</button> | <a href = "/usuario/EditPassword/@Model.idContacto">Cambiar mi contraseña</a> | <a href = "/usuario/Delete/@Model.idContacto">Dar de baja mi cuenta</a>
        </div>
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/assets/js/contacto.js")
End Section
