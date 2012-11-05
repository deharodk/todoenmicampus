$(document).ready(function () {
    $("#frmForgotPassword").submit(function () {
        var txtUser = $("#txtUser");
        var mailRegEx = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        if (! mailRegEx.test(txtUser.val().trim()) || txtUser.val().trim() == "") {
            bootbox.alert("Por favor ingresa un correo correcto", function () {
                txtUser.focus();
            });
            return false;
        }
        return true;
    });
});