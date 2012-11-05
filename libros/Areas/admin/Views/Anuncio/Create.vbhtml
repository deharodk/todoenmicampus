@ModelType libros.Anuncio

@Code
    ViewData("Title") = "Create"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h1>Publicar un anuncio</h1>

@Using Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmAnuncioCrear"})
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Anuncio</legend>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.titulo, New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBoxFor(Function(model) model.titulo, New With {.class = "input-xlarge", .id = "txtTitulo"})
                @Html.ValidationMessageFor(Function(model) model.titulo)
            </div>
        </div>


        <div class="editor-label">
            @Html.LabelFor(Function(model) model.descripcion)
        </div>
        <div class="editor-field">
            <textarea id = "txtComments" name = "descripcion" class = "textarea" style = "width: 890px; height: 400px" >
                    @Html.Raw(Model.descripcion)
            </textarea>
            @Html.ValidationMessageFor(Function(model) model.descripcion)
        </div>


        <br />


        <div class="control-group">
            @Html.LabelFor(Function(model) model.precioTotal, New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBoxFor(Function(model) model.precioTotal, New With {.class = "input-xlarge", .id = "txtPrecioTotal"})
                @Html.ValidationMessageFor(Function(model) model.precioTotal)
            </div>
        </div>

        <div class="editor-label">
            @Html.HiddenFor(Function(model) model.estatus)
        </div>

 
        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.idContacto)
        </div>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.idTipoAnuncio, "Tipo de anuncio", New With {.class = "control-label"})
            <div class="controls">
                @Html.DropDownList("idTipoAnuncio", String.Empty)
                @Html.ValidationMessageFor(Function(model) model.idTipoAnuncio)
            </div>
        </div>

        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.fechaCreacion)
        </div>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.idFormaPago, "Forma de pago", New With {.class = "control-label"})
            <div class="controls">
                @Html.DropDownList("idFormaPago", String.Empty)
                @Html.ValidationMessageFor(Function(model) model.idFormaPago)
            </div>
        </div>

        <div class="form-actions">
            <button class="btn btn-primary" type="submit">Actualizar</button>
        </div>
    </fieldset>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
