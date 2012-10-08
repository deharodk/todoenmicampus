$(document).ready(function () {
    $("#frmFacultad").submit(function () {
        var nombre = $("#txtNombre");
        var nombreCorto = $("#txtNombreCorto");
        if (nombre.val().trim() == "") {
            bootbox.alert("El campo nombre es obligatorio", function () {
                nombre.focus();
            });
            return false;
        }
        if (nombreCorto.val().trim() == "") {
            bootbox.alert("El campo nombre corto es obligatorio", function () {
                nombreCorto.focus();
            });
            return false;
        }
    });
});