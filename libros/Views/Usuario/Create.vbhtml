﻿@ModelType libros.Contacto

@Code
    ViewData("Title") = "Registrar cuenta en todo en mi campus"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Registrarse</h1>

@Using Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmCrearCuenta"})
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Registrándote, podrás empezar a publicar anuncios</legend>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.email, New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBoxFor(Function(model) model.email, New With {.class = "input-xlarge", .id = "txtEmail", .placeholder = "Nombre de usuario (correo electrónico)", .maxlength = 35})
                @Html.ValidationMessageFor(Function(model) model.email)
            </div>
        </div>


         <div class="control-group">
            @Html.LabelFor(Function(model) model.nombre, New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBoxFor(Function(model) model.nombre, New With {.class = "input-xlarge", .id = "txtNombre", .placeholder = "Tu nombre", .maxlength = 255})
                @Html.ValidationMessageFor(Function(model) model.nombre)
            </div>
        </div>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.numeroMovil, New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBoxFor(Function(model) model.numeroMovil, New With {.class = "input-xlarge", .id = "txtNumeroMovil", .placeholder = "Número móvil (opcional)", .maxlength = 20})
                @Html.ValidationMessageFor(Function(model) model.numeroMovil)
            </div>
        </div>


        <div class="control-group">
            @Html.LabelFor(Function(model) model.cuentaTwitter, New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBoxFor(Function(model) model.cuentaTwitter, New With {.class = "input-xlarge", .id = "txtCuentaTwitter", .placeholder = "Tu cuenta de twitter (opcional)", .maxlength = 255})
                @Html.ValidationMessageFor(Function(model) model.cuentaTwitter)
            </div>
        </div>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.cuentaFB, New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBoxFor(Function(model) model.cuentaFB, New With {.class = "input-xlarge", .id = "txtFB", .placeholder = "Tu cuenta de facebook (opcional)", .maxlength = 255})
                @Html.ValidationMessageFor(Function(model) model.cuentaFB)
            </div>
        </div>

         <div class="control-group">
            @Html.LabelFor(Function(model) model.idFacultad, New With {.class = "control-label", .data_placeholder = "Tu facultad"})
            <div class="controls">
                @Html.DropDownList("idFacultad", "[Seleccionar]")
                @Html.ValidationMessageFor(Function(model) model.idFacultad)
            </div>
        </div>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.pass, New With {.class = "control-label"})
            <div class="controls">
                @Html.PasswordFor(Function(model) model.pass, New With {.class = "input-xlarge", .id = "txtPass", .placeholder = "Tu contraseña (mínimo 8 caracteres)", .maxlength = 255})
                @Html.ValidationMessageFor(Function(model) model.pass)
            </div>
        </div>

        <div class="control-group">
            @Html.Label("", New With {.class = "control-label"})
            <div class="controls">
                @Html.CheckBox("chkAcepto", False, New With {.class = "input-xlarge", .id = "chkAcepto"})
                He leido y acepto los <a href = "javascript:void(0);" id = "aTerminos">términos y condiciones</a>
            </div>
        </div>

        <div class="form-actions">
            <button class="btn btn-primary" id = "btnSubmit">Crear</button>
            <button class="btn" type="reset">Resetear</button>
        </div>
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/assets/js/contacto.js")
End Section
