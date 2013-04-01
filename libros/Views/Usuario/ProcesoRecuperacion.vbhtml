@Code
    ViewData("Title") = "Recuperar password - todo en mi campus"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Cambiar password</h1>

@Using Html.BeginForm("passRecoverChange", "usuario", FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmPassRecover"})
     @<fieldset>
        <legend>Introduce aquí el nuevo password que deseas tener</legend>

        <div class="control-group">
            @Html.Label("Password", New With {.class = "control-label"})
            <div class="controls">
                @Html.Password("txtPass", Nothing, New With {.class = "input-xlarge", .id = "txtPass"})
            </div>
        </div>

        @Html.Hidden("id", Request.QueryString("id"))
        @Html.Hidden("key", Server.urlencode(Request.QueryString("key")))

        <div class="control-group">
            @Html.Label("Confirmar password", New With {.class = "control-label"})
            <div class="controls">
                @Html.Password("txtPassConfirm", Nothing, New With {.class = "input-xlarge", .id = "txtPassConfirm"})
            </div>
        </div>

        <div class="form-actions">
            <button class="btn btn-primary" type = "submit">Cambiar mi contraseña</button>
        </div>

        @If ViewBag.logFails = True Then
           @<div class="alert alert-info" id ="lblError">
            <a class="close" id ="aClose">×</a>
            <h4 class="alert-heading">Alerta</h4>
            <p>
                Lo sentimos pero, no podemos localizar tu usuario para proceder con el cambio de contraseña.
            </p>
            </div>
        End If
        </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/assets/js/fPassword.js")
End Section