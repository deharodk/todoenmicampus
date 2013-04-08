$(document).ready(function () {
    $('#tblAnuncios').dataTable({
        "sPaginationType": "full_numbers",
         "aaSorting": []
    });

    $('#tblAnunciosPublicacion').dataTable({
        "sPaginationType": "full_numbers"
         , "sDom": '<"top"flp<"clear">>rt<"bottom"ilp<"clear">>'
    });

    $('#txtComments').wysihtml5();

    $("#idFormaPago").change(function () {
        var precioTotal = $("#txtPrecioTotal");
        var formaPago = $("#idFormaPago");
        if (formaPago.val().trim() == 1) { //Forma pago N/A
            precioTotal.attr("disabled", true).val(0);
        }
        else {
            precioTotal.removeAttr("disabled");
            precioTotal.val('');
        }
    });



    $("#idTipoAnuncio").change(function () {
        var tipoAnuncio = $("#idTipoAnuncio");
        var formaPago = $("#idFormaPago");
        var precioTotal = $("#txtPrecioTotal");

        if (
            tipoAnuncio.val().trim() == 1 ||
            tipoAnuncio.val().trim() == 3 ||
            tipoAnuncio.val().trim() == 5 ||
            tipoAnuncio.val().trim() == 7 ||
            tipoAnuncio.val().trim() == 9
            ) {
            formaPago.attr("disabled", true);
            precioTotal.attr("disabled", true).val(0);
            formaPago.val(1).attr('selected', true);
            $("#idFormaPago").val(1);
        }
        else {
            formaPago.val(0)
            formaPago.removeAttr("disabled");
            precioTotal.val('')
            precioTotal.removeAttr("disabled");
        }

    });

    $("#frmAnuncioCrear").submit(function () {
        var titulo = $("#txtTitulo");
        var descripcion = $("#txtComments");
        var precioTotal = $("#txtPrecioTotal");
        var tipoAnuncio = $("#idTipoAnuncio");
        var formaPago = $("#idFormaPago");

        if (tipoAnuncio.val().trim() == "") {
            bootbox.alert("Proporciona el tipo de anuncio que publicarás", function () {
                descripcion.focus();
            });
            return false;
        }

        if (titulo.val().trim() == "") {
            bootbox.alert("Proporciona un título para el anuncio", function () {
                titulo.focus();
            });
            return false;
        }

        if (formaPago.val().trim() == "") {
            bootbox.alert("Proporciona la forma de pago del anuncio que publicarás", function () {
                formaPago.focus();
            });
            return false;
        }

        if (!precioTotal.val().match(/^\d+(?:\.\d+)?$/)) {
            bootbox.alert("Proporciona un valor correcto para el precio del anuncio", function () {
                precioTotal.focus();
            });
            return false;
        }

        if (descripcion.val().trim() == "") {
            bootbox.alert("Proporciona una descripción para el anuncio", function () {
                descripcion.focus();
            });
            return false;
        }

        return true;
    });

});