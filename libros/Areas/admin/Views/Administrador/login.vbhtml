@Code
    ViewData("Title") = "Iniciar sesión - todo en mi campus"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Área de administración</h1>

@Using Html.BeginForm("doLogin", "administrador", FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmLogin"})
     @<fieldset>
        <legend>Inicio de sesión</legend>

        <div class="control-group">
            @Html.Label("User name", New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBox("txtUser", Nothing, New With {.class = "input-xlarge", .id = "txtUser", .maxlength = 255})
            </div>
        </div>

        <div class="control-group">
            @Html.Label("Password", New With {.class = "control-label"})
            <div class="controls">
                @Html.Password("txtPass", Nothing, New With {.class = "input-xlarge", .id = "txtPass", .maxlength = 255})
            </div>
        </div>

        <div class="form-actions">
            <button class="btn btn-primary" type = "submit">Entrar</button>
            <button class="btn" type="reset">Resetear</button>
        </div>

        @If ViewBag.logFails = True Then
           @<div class="alert alert-block" id ="lblError">
            <a class="close" id ="aClose">×</a>
            <h4 class="alert-heading">Alerta</h4>
            <p>No se puede verificar que las credenciales proporcionadas sean auténticas. Si olvidó sus claves, por favor solicitelas con su administrador.</p>
            </div>
        End If
        </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/assets/js/login.js")
End Section