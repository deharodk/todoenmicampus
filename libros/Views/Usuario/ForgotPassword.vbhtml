@Code
    ViewData("Title") = "Recuperación de contraseña"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Recuperación de contraseña</h1>

@Using Html.BeginForm("passRecover", "usuario", FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmForgotPassword"})
    @<fieldset>
        <legend>Coloca tu nombre de usuario y se enviarán las instrucciones para recuperar la contraseña</legend>

        <div class="control-group">
            @Html.Label("Nombre de usuario: ", New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBox("txtUser", Nothing, New With {.class = "input-xlarge", .id = "txtUser"}) 
            </div>
        </div>

        <div class="form-actions">
            <input type = "submit" class = "btn btn-primary" value = "Recuperar contraseña"/>
        </div>
      
    </fieldset>
    
    If ViewBag.userNotExists = True Then
        @<div class="alert alert-info" id ="lblError">
            <a class="close" id ="aClose">×</a>
            <h4 class="alert-heading">Alerta</h4>
            <p>
                El usuario que proporcionas no existe o la cuenta le ha sido deshabilitada.
            </p>
          </div>
    End If
   
End Using

@Section Scripts
    @Scripts.Render("~/assets/js/fPassword.js")
End Section