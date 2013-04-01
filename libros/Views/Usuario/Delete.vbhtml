@ModelType libros.Contacto

@Code
    ViewData("Title") = "Dar de baja la cuenta - todo en mi campus"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Dar de baja mi cuenta</h1>

<h3>¿Estás seguro que desdeas dar de baja tu cuenta?</h3>
<fieldset>
    <legend>Si lo haces no podrás seguir publicando anuncios</legend>

    <div class="display-field">
     

        <p class = "anuncioP"><b>Usuario:</b> @Model.email</p>
    </div>

   
</fieldset>
<br />
<br />
@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Si quiero darla de baja"  class = "btn btn-danger"/> |
        @Html.ActionLink("Olvídalo, cambié de opinión", "Edit", New With {.id = Model.idContacto}, New With {.class = "btn btn-success"})
    </p>
End Using
