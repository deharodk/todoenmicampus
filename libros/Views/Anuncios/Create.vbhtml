@ModelType libros.Anuncio

@Code
    ViewData("Title") = "Publicar nuevo anuncio"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h1>Publicar un anuncio</h1>

@Using Html.BeginForm(Nothing, Nothing, FormMethod.Post, New With {.class = "form-horizontal well", .id = "frmAnuncioCrear"})
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Anuncio</legend>
         <div class="control-group">
            @Html.LabelFor(Function(model) model.idTipoAnuncio, "Tipo de anuncio", New With {.class = "control-label"})
            <div class="controls">
                @Html.DropDownList("idTipoAnuncio", "[Seleccionar]")
                @Html.ValidationMessageFor(Function(model) model.idTipoAnuncio)
            </div>
        </div>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.titulo, New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBoxFor(Function(model) model.titulo, New With {.class = "input-xlarge", .id = "txtTitulo", .placeholder = "Título", .maxlength = 55})
                @Html.ValidationMessageFor(Function(model) model.titulo)
            </div>
        </div>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.idFormaPago, "Forma de pago", New With {.class = "control-label"})
            <div class="controls">
                @Html.DropDownList("idFormaPago", "[Seleccionar]")
                @Html.ValidationMessageFor(Function(model) model.idFormaPago)
            </div>
        </div>

        <div class="control-group">
            @Html.LabelFor(Function(model) model.precioTotal, New With {.class = "control-label"})
            <div class="controls">
                @Html.TextBoxFor(Function(model) model.precioTotal, New With {.class = "input-xlarge", .id = "txtPrecioTotal", .placeholder = "Precio que propones", .maxlength = 10})
                @Html.ValidationMessageFor(Function(model) model.precioTotal)
            </div>
        </div>


        <div class="editor-label">
            @Html.LabelFor(Function(model) model.descripcion)
        </div>
        <div class="editor-field">
            <textarea id = "txtComments" name = "descripcion" class = "textarea" style = "width: 890px; height: 400px" >
                  
            </textarea>
            @Html.ValidationMessageFor(Function(model) model.descripcion)
        </div>


        <br />
       

        <div class="editor-label">
            @Html.HiddenFor(Function(model) model.estatus)
        </div>

        @Html.ValidationMessageFor(Function(model) model.estatus)
        @Html.ValidationMessageFor(Function(model) model.idContacto)
        @Html.ValidationMessageFor(Function(model) model.fechaCreacion)

        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.idContacto)
        </div>

       

        <div class="editor-field">
            @Html.HiddenFor(Function(model) model.fechaCreacion)
        </div>
     


      

        <div class="form-actions">
            <button class="btn btn-primary" type="submit">Crear</button> <button class = "btn" type = "reset">Resetear</button>
        </div>
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/assets/js/anuncio.js")
End Section
