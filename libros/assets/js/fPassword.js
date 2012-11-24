$(document).ready(function () {
    $("#frmForgotPassword").submit(function () {
        var txtUser = $("#txtUser");
        var mailRegEx = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        if (!mailRegEx.test(txtUser.val().trim()) || txtUser.val().trim() == "") {
            bootbox.alert("Por favor ingresa un correo correcto", function () {
                txtUser.focus();
            });
            return false;
        }
        return true;
    });

    $("#frmPassRecover").submit(function () {
        var txtPass = $("#txtPass");
        var txtPassConfirm = $("#txtPassConfirm");

        if (txtPass.val().trim() == "" || txtPass.val().length < 8) {
            bootbox.alert("Por favor ingresa el campo contraseña con 8 o más caracteres", function () {
                txtPass.focus();
            });
            return false;
        }

        if (txtPassConfirm.val().trim() == "") {
            bootbox.alert("Por favor ingresa el campo confirmar contraseña", function () {
                txtPassConfirm.focus();
            });
            return false;
        }

        if (txtPass.val() != txtPassConfirm.val()) {
            bootbox.alert("Las contraseñas no coinciden", function () {
                txtPass.focus();
            });
            return false;
        }
        return true;
    });

    $("#aClose").click(function () {
        $("#lblError").fadeOut(600);
    });
});