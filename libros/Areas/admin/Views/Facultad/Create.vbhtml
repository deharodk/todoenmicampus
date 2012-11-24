@ModelType libros.Facultad

@Code
    ViewData("Title") = "Crear nueva facultad"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Crear nueva</h1>

@Using Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmFacultad"})
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Facultad</legend>

        <div class="control-group">
			@Html.LabelFor(Function(model) model.nombre, New With {.class = "control-label"})
				<div class="controls">
					 @Html.TextBoxFor(Function(model) model.nombre, New With {.class = "input-xlarge", .id = "txtNombre", .maxlength = 355})
					<span class="help-inline">  @Html.ValidationMessageFor(Function(model) model.nombre) </span>
				<p class="help-block"></p>
			    </div>
		</div>

        <div class="control-group">
			@Html.LabelFor(Function(model) model.nombreCorto, New With {.class = "control-label"})
				<div class="controls">
					 @Html.TextBoxFor(Function(model) model.nombreCorto, New With {.class = "input-xlarge", .id = "txtNombreCorto", .maxlength = 15})
					<span class="help-inline"> @Html.ValidationMessageFor(Function(model) model.nombreCorto) </span>
				<p class="help-block"></p>
			    </div>
		</div>

       <div class="control-group">
			@Html.LabelFor(Function(model) model.estatus, New With {.class = "control-label"})
				<div class="controls">
					 @Html.EditorFor(Function(model) model.estatus, New With {.id = "chkEstatus"})
					<span class="help-inline"> @Html.ValidationMessageFor(Function(model) model.estatus) </span>
				<p class="help-block"></p>
			    </div>
		</div>
       
       <div class="form-actions">
            <button class="btn btn-primary" type="submit">Crear</button>
            <button class="btn" type="reset">Resetear</button>
        </div>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Volver a la lista", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/assets/js/facultad.js")
End Section


