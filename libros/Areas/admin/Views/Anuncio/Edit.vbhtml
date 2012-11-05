@ModelType libros.Anuncio

@Code
    ViewData("Title") = "Edit"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h2>Edit</h2>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Anuncio</legend>

        @Html.HiddenFor(Function(model) model.idAnuncio)

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.titulo)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.titulo)
            @Html.ValidationMessageFor(Function(model) model.titulo)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.descripcion)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.descripcion)
            @Html.ValidationMessageFor(Function(model) model.descripcion)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.precioTotal)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.precioTotal)
            @Html.ValidationMessageFor(Function(model) model.precioTotal)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.estatus)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.estatus)
            @Html.ValidationMessageFor(Function(model) model.estatus)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.idContacto, "Contacto")
        </div>
        <div class="editor-field">
            @Html.DropDownList("idContacto", String.Empty)
            @Html.ValidationMessageFor(Function(model) model.idContacto)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.idTipoAnuncio, "TipoAnuncio")
        </div>
        <div class="editor-field">
            @Html.DropDownList("idTipoAnuncio", String.Empty)
            @Html.ValidationMessageFor(Function(model) model.idTipoAnuncio)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.fechaCreacion)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.fechaCreacion)
            @Html.ValidationMessageFor(Function(model) model.fechaCreacion)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.idFormaPago, "FormaPago")
        </div>
        <div class="editor-field">
            @Html.DropDownList("idFormaPago", String.Empty)
            @Html.ValidationMessageFor(Function(model) model.idFormaPago)
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
