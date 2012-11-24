@ModelType libros.Contacto

@Code
    ViewData("Title") = "Información del usuario"
    Layout = "~/Views/Shared/_Layout.vbhtml"
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

