@Code
    ViewData("Title") = "Recuperar password - todo en mi campus"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Recuperar mi cuenta</h1>

@Using Html.BeginForm("QuieroVolverMail", "usuario", FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmRecuperarCuenta"})
     @<fieldset>
        <legend>Ingresa tú nombre de usuario (correo)</legend>

        <div class="control-group">
            @Html.Label("Cuenta", New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBox("txtUser", Nothing, New With {.class = "input-xlarge", .id = "txtUser"})
            </div>
        </div>

        <div class="form-actions">
            <button class="btn btn-primary" type = "submit">¡Quiero recuperar mi cuenta!</button>
        </div>

        @If ViewBag.processFails = True Then
           @<div class="alert alert-info" id ="lblError">
            <a class="close" id ="aClose">×</a>
            <h4 class="alert-heading">Alerta</h4>
            <p>
                Lo sentimos pero, ha ocurrido un error al tratar de enviar el correo para la recuperación de tú cuenta.
            </p>
            </div>
        End If
        </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/assets/quieroVolver.js")
End Section