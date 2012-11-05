@ModelType libros.FormaPago

@Code
    ViewData("Title") = "Eliminar"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Eliminar</h1>

<h3>¿Estás seguro de que deseas eliminar esto?</h3>
<fieldset>
    <legend>Forma de pago</legend>

     <div class="control-group">
			@Html.LabelFor(Function(model) model.nombre, New With {.class = "control-label"})
				<div class="controls">
					 @Html.TextBoxFor(Function(model) model.nombre, New With {.class = "input-xlarge", .readonly = "readonly"})
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

@Using Html.BeginForm()
    @<p>
        <button class="btn btn-warning" type="submit">Eliminar</button>
        @Html.ActionLink("Volver a la lista", "Index")
    </p>
End Using
