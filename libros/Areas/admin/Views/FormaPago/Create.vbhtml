@ModelType libros.FormaPago

@Code
    ViewData("Title") = "Create"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h2>Create</h2>

@Using Html.BeginForm()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>FormaPago</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.formaPago)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.formaPago)
            @Html.ValidationMessageFor(Function(model) model.formaPago)
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
