@Code
    ViewData("Title") = "Iniciar sesión - todo en mi campus"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Iniciar sesión</h1>

@Using Html.BeginForm("doLogin", "usuario", FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmLogin"})
     @<fieldset>
        <legend>Inicio de sesión</legend>

        <div class="control-group">
            @Html.Label("Cuenta", New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBox("txtUser", Nothing, New With {.class = "input-xlarge", .id = "txtUser"})
            </div>
        </div>

        <div class="control-group">
            @Html.Label("Contraseña", New With {.class = "control-label"})
            <div class="controls">
                @Html.Password("txtPass", Nothing, New With {.class = "input-xlarge", .id = "txtPass"}) <a href = "/Usuario/ForgotPassword">¿Olvidaste tú contraseña?</a>
            </div>
        </div>

        <div class="form-actions">
            <button class="btn btn-primary" type = "submit">Entrar</button>
            <button class="btn" type="reset">Resetear</button>
      
        </div>

        @If ViewBag.logFails = True Then
           @<div class="alert alert-info" id ="lblError">
            <a class="close" id ="aClose">×</a>
            <h4 class="alert-heading">Alerta</h4>
            <p>Las credenciales con que intentas accesar no son válidas, si no recuerdas tu password por favor haz click <a href = "/Usuario/ForgotPassword" class = "anclaLogin">aquí.</a>
                si no posees una cuenta <a href = "/Usuario/Create/" class = "anclaLogin">registrate aquí</a>
            </p>
            </div>
        End If
        </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/assets/js/login.js")
End Section
