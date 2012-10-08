@ModelType libros.Facultad

@Code
    ViewData("Title") = "Detalles de facultad"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Detalles</h1>

<fieldset>
    <legend>Facultad</legend>

    <div class="control-group">
			@Html.LabelFor(Function(model) model.nombre, New With {.class = "control-label"})
				<div class="controls">
					 @Html.TextBoxFor(Function(model) model.nombre, New With {.class = "input-xlarge", .readonly = "readonly"})
					<span class="help-inline"></span>
				<p class="help-block"></p>
			    </div>
	</div>

    <div class="control-group">
			@Html.LabelFor(Function(model) model.nombreCorto, New With {.class = "control-label"})
				<div class="controls">
					 @Html.TextBoxFor(Function(model) model.nombreCorto, New With {.class = "input-xlarge", .readonly = "readonly"})
					<span class="help-inline"></span>
				<p class="help-block"></p>
			    </div>
	</div>

    <div class="control-group">
			@Html.LabelFor(Function(model) model.estatus, New With {.class = "control-label"})
				<div class="controls">
					 @Html.DisplayFor(Function(model) model.estatus)
					<span class="help-inline"></span>
				<p class="help-block"></p>
			    </div>
	</div>
</fieldset>
<p>

    @Html.ActionLink("Editar", "Edit", New With {.id = Model.idFacultad}) |
    @Html.ActionLink("Volver a la lista", "Index")
</p>
