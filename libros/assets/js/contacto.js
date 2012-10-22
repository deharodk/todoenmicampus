$(document).ready(function () {
    $("#frmContactoPass").submit(function () {
        var pass = $("#txtPass")
        var passConfirm = $("#txtPassConfirm")

        if (pass.val().trim() == "" || pass.val().trim().length < 8) {
            bootbox.alert("El campo contraseña no puede ser vacío o de menos de 8 caracteres", function () {
                pass.focus();
            });
            return false;
        }

        if (pass.val().trim() != passConfirm.val().trim()) {
            bootbox.alert("Las contraseñas deben de conicidir", function () {
                pass.focus();
            });
            return false;
        }
        return true;
    });
});