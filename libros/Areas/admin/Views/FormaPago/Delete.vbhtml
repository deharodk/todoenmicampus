@ModelType libros.FormaPago

@Code
    ViewData("Title") = "Delete"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>FormaPago</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.formaPago)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.formaPago)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.estatus)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.estatus)
    </div>
</fieldset>
@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
