@ModelType libros.FormaPago

@Code
    ViewData("Title") = "Details"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

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
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.idFormaPago}) |
    @Html.ActionLink("Back to List", "Index")
</p>
