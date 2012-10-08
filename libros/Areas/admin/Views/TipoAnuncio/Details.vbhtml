@ModelType libros.TipoAnuncio

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>TipoAnuncio</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.tipoAnuncio)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.tipoAnuncio)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.estatus)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.estatus)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.idTipoAnuncio}) |
    @Html.ActionLink("Back to List", "Index")
</p>
