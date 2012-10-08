@ModelType libros.TipoAnuncio

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>TipoAnuncio</legend>

        @Html.HiddenFor(Function(model) model.idTipoAnuncio)

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.tipoAnuncio)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.tipoAnuncio)
            @Html.ValidationMessageFor(Function(model) model.tipoAnuncio)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.estatus)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.estatus)
            @Html.ValidationMessageFor(Function(model) model.estatus)
        </div>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
