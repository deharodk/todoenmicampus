$(document).ready(function () {
    $("#frmFormaPago").submit(function () {
        var nombre = $("#txtNombre");
        if (nombre.val().trim() == "") {
            bootbox.alert("Proporcione un nombre para la forma de pago", function () {
                nombre.focus();
            });
            return false;
        }
        return true;
    });
});