@Code
    ViewData("Title") = "Te damos la bienvenida a todo en mi campus"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>¡Bienvenido a todo en mi campus!</h1>



<p>Te damos la bienvenida a todo en mi campus, esperamos que sea de mucha utilidad para ti</p>


<p> Por cierto, te hemos generado un usuario y contraseña en todo en mi campus, por si algún día no puedes
o no quieres accesar mediante facebook. </p>




<p> <b>Usuario:</b> El correo que usas para conectarte en facebook </p>
<p> <b>Password:</b> @ViewBag.pass </p>



<p>Por favor, por seguridad cambia cuanto antes la contraseña que te hemos dado.</p>


<p>Para continuar a todo en mi campus, da click <a href = "@ViewBag.urlTo">aquí</a> </p>

<!--
<center>
    <img alt = "welcome" src = "../../assets/images/welcome_fb.png"  width = "400px" height = "400px" />
</center>
-->