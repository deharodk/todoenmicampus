$(document).ready(function () {
    $("#frmTipoAnuncio").submit(function () {
        var nombre = $("#txtNombre");
        if (nombre.val().trim() == "") {
            bootbox.alert("Proporcione un nombre para el tipo de anuncio", function () {
                nombre.focus();
            });
            return false;
        }
        return true;
    });
});