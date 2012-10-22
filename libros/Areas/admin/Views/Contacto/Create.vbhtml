@ModelType libros.Contacto

@Code
    ViewData("Title") = "Create"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h2>Create</h2>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Contacto</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.nombre)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.nombre)
            @Html.ValidationMessageFor(Function(model) model.nombre)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.email)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.email)
            @Html.ValidationMessageFor(Function(model) model.email)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.numeroMovil)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.numeroMovil)
            @Html.ValidationMessageFor(Function(model) model.numeroMovil)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.cuentaTwitter)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.cuentaTwitter)
            @Html.ValidationMessageFor(Function(model) model.cuentaTwitter)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.cuentaFB)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.cuentaFB)
            @Html.ValidationMessageFor(Function(model) model.cuentaFB)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.idFacultad, "Facultad")
        </div>
        <div class="editor-field">
            @Html.DropDownList("idFacultad", String.Empty)
            @Html.ValidationMessageFor(Function(model) model.idFacultad)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.pass)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.pass)
            @Html.ValidationMessageFor(Function(model) model.pass)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.estatus)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.estatus)
            @Html.ValidationMessageFor(Function(model) model.estatus)
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
