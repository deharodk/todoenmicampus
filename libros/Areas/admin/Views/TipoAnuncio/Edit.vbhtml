@ModelType libros.TipoAnuncio

@Code
    ViewData("Title") = "Editar"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Editar</h1>

@Using Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmTipoAnuncio"})
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Tipo de anuncio</legend>

        @Html.HiddenFor(Function(model) model.idTipoAnuncio)

        <div class="control-group">
            @Html.LabelFor(Function(model) model.nombre, New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBoxFor(Function(model) model.nombre, New With {.class = "input-xlarge", .id = "txtNombre"})
                @Html.ValidationMessageFor(Function(model) model.nombre)
            </div>
        </div>


         <div class="control-group">
            @Html.LabelFor(Function(model) model.estatus, New With {.class = "control-label"})
            <div class="controls">
                @Html.EditorFor(Function(model) model.estatus, New With {.class = "input-xlarge", .id = "txtNombre"})
                @Html.ValidationMessageFor(Function(model) model.estatus)
            </div>
        </div>
        <div class="form-actions">
            <button class="btn btn-primary" type="submit">Actualizar</button>
        </div>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Volver a la lista", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/assets/js/tipoanuncio.js")
End Section
