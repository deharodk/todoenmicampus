@Code
    ViewData("Title") = "Has recuperado tu contraseña"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Ya puedes ingresar otra vez ¡Muy bien!</h1>

<p>Has actualizado tu password con éxito, para ingresar a todo en mi campus da click @Html.ActionLink("aquí", "login", "Usuario") . 
Procura esta ves no extraviar tú contraseña, ha sido un placer el haberte ayudado.</p>

<center><img alt = "happy" src = "../../assets/images/smileFace.png"/></center>