@ModelType libros.Contacto

@Code
    ViewData("Title") = "Información del usuario"
    Layout = "~/Views/Shared/_Layout.vbhtml"
    
    Dim idContacto As Integer = 0
    Try
        idContacto = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
    Catch ex As NullReferenceException
        
    End Try
End Code



<h2>Información de @Model.nombre</h2>

<fieldset>
    <legend>Contacto</legend>

    <h4><b>Nombre</b></h4>
    <p>@Model.nombre </p>



    <h4><b>E-mail</b></h4>
    <p>@Model.email </p>



    <h4><b>Facultad</b></h4>
    <p>@Model.Facultad.nombre </p>



    <h4><b>Teléfono móvil</b></h4>
    <p>@IIf(Model.numeroMovil = Nothing, "No proporciona", Model.numeroMovil)</p>



    <h4><b>Cuenta de twitter</b></h4>
    <p>@IIf(Model.cuentaTwitter = Nothing, "No proporciona", Model.cuentaTwitter)</p>

  

    <h4><b>Cuenta de facebook</b></h4>
    <p>@IIf(Model.cuentaFB = Nothing, "No proporciona", Model.cuentaFB)</p>

 

</fieldset>
<br />

@If ViewBag.idUserToSee <> idContacto Then
    @<p>¿Este usuario te ha dado algún problema o crees que su conducta ha sido inapropiada en todo en mi campus?
       <br /> 
       Si es así, entonces queremos saberlo. Cuéntamos qué incidente has tenido con este usuario, si lo consideramos grave
       podemos cancelar la cuenta para que no vuelva a molestar ni a ti ni a otros. Tus denuncias son importantes para nosotros.

       <br />
       Para realizar una denuncia escríbenos a <a href = "mailto:denuncia@todoenmicampus.com" target = "_blank">denuncia@todoenmicampus.com</a> 
       .No olvides mencionar el correo electrónico del usuario.
    </p>
End If


