@ModelType libros.Contacto

@Code
    ViewData("Title") = "Actualizar mi contraseña"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Cambiar contraseña</h1>

@Using Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmCambiarPassword"})
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Información de mi contraseña</legend>

        @If ViewBag.actualizado = True Then
           @<div class="alert alert-info" id ="lblError">
            <a class="close" id ="aClose">×</a>
            <h4 class="alert-heading">¡Éxito!</h4>
            <p>
                Haz actualizado tú contraseña con éxito. :)
            </p>
            </div>
        End If

        @If ViewBag.passNotMatch = True Then
           @<div class="alert alert-info" id ="lblError">
            <a class="close" id ="aClose">×</a>
            <h4 class="alert-heading">Alerta</h4>
            <p>
                Por favor proporciona correctamente tú actual password.
            </p>
            </div>
        End If

        @Html.HiddenFor(Function(model) model.idContacto)

        <div class="editor-field">
					 @Html.HiddenFor(Function(model) model.nombre, New With {.class = "input-xlarge", .id = "txtNombre"})
					 @Html.ValidationMessageFor(Function(model) model.nombre) 
		</div>

        <div class="editor-field">
					 @Html.HiddenFor(Function(model) model.email, New With {.class = "input-xlarge", .id = "txtEmail", .readonly = "readonly"})
					 @Html.ValidationMessageFor(Function(model) model.email) 		
		</div>


        <div class="editor-field">
					 @Html.HiddenFor(Function(model) model.numeroMovil, New With {.class = "input-xlarge", .id = "txtNumeroMovil"})
					 @Html.ValidationMessageFor(Function(model) model.numeroMovil) 
		</div>

        <div class="editor-field">
					 @Html.HiddenFor(Function(model) model.cuentaTwitter, New With {.class = "input-xlarge", .id = "txtCuentaTwitter"})
					 @Html.ValidationMessageFor(Function(model) model.cuentaTwitter)
		</div>

        <div class="editor-field">
					 @Html.HiddenFor(Function(model) model.cuentaFB, New With {.class = "input-xlarge", .id = "txtFB"})
					 @Html.ValidationMessageFor(Function(model) model.cuentaFB)

		</div>

       <div class="editor-field">
					 @Html.HiddenFor(Function(model) model.idFacultad)
					 @Html.ValidationMessageFor(Function(model) model.idFacultad)
		</div>

        <div class="control-group">
            @Html.Label("Actual password", New With {.class = "control-label"})
				<div class="controls">
					  @Html.Password("txtActualPassword", "", New With {.class = "input-xlarge", .id = "txtPass", .maxlength = 255})
			    </div>
		</div>

        <div class="control-group">
            @Html.Label("Nueva Contraseña", New With {.class = "control-label"})
				<div class="controls">
					  @Html.PasswordFor(Function(model) model.pass, New With {.class = "input-xlarge", .id = "txtPassNew", .maxlength = 255})
					<span class="help-inline">  @Html.ValidationMessageFor(Function(model) model.pass) </span>
				<p class="help-block"></p>
			    </div>
		</div>

         <div class="control-group">
            @Html.Label("Confirmar nueva contraseña", New With {.class = "control-label"})
				<div class="controls">
					  @Html.Password("txtPasswordConfirm", "",New With {.class = "input-xlarge", .id = "txtPassNewConfirm", .maxlength = 255})
			    </div>
		</div>

        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.estatus)
            @Html.ValidationMessageFor(Function(model) model.estatus)
        </div>

        <div class="form-actions">
          <button class="btn btn-primary" type="submit">Actualizar mi contraseña</button>
        </div>
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/assets/js/contacto.js")
End Section
