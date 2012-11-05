$(document).ready(function () {

    $('#tblUsuarios').dataTable({
        "sPaginationType": "full_numbers"
    });

    $("#aClose").click(function () {
        $("#lblError").fadeOut(650);
    });

    $("#txtNumeroMovil").keydown(function (event) {
        // Allow: backspace, delete, tab, escape, and enter
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 || event.keyCode == 13 ||
        // Allow: Ctrl+A
                (event.keyCode == 65 && event.ctrlKey === true) ||
        // Allow: home, end, left, right
                (event.keyCode >= 35 && event.keyCode <= 39)) {
            // let it happen, don't do anything
            return;
        }
        else {
            // Ensure that it is a number and stop the keypress
            if (event.shiftKey || (event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                event.preventDefault();
            }
        }
    });

    $("#frmContactoPass").submit(function () {
        var pass = $("#txtPass");
        var passConfirm = $("#txtPassConfirm");

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

    $("#frmEditarCuenta").submit(function () {
        var nombre = $("#txtNombre");
        var email = $("#txtEmail");
        var numeroMovil = $("#txtNumeroMovil");
        var cuentaTwitter = $("#txtCuentaTwitter");
        var fb = $("#txtFB");
        var idFacultad = $("#idFacultad");
        var mailRegEx = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

        if (nombre.val().trim() == "") {
            bootbox.alert("Debes de proporcionar el campo nombre", function () {
                nombre.focus();
            });
            return false;
        }

        if (!mailRegEx.test(email.val().trim()) || email.val().trim() == "") {
            bootbox.alert("Proporciona un valor correcto para el campo email", function () {
                email.focus();
            });
            return false;
        }

        if (idFacultad.val().trim() == "") {
            bootbox.alert("Debes de proporcionar el campo facultad", function () {
                idFacultad.focus();
            });
            return false;
        }
        return true;
    });


    $("#btnSubmit").click(function () {
        var nombre = $("#txtNombre");
        var username = $("#txtEmail");
        var pass = $("#txtPass");
        var numeroMovil = $("#txtNumeroMovil");
        var cuentaTwitter = $("#txtCuentaTwitter");
        var fb = $("#txtFB");
        var idFacultad = $("#idFacultad");
        var mailRegEx = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;


        if (!mailRegEx.test(username.val().trim()) || username.val().trim() == "") {
            bootbox.alert("El valor del campo correo ingresado es incorrecto", function () {
                username.focus();
            });
            return false;
        }

        $.ajax({
            type: "GET",
            contentType: "application/x-www-form-urlencoded;charset=ISO-8859-1",
            url: "/usuario/findByUsername",
            data: "username=" + username.val().trim(),
            success:
                function (data) {
                    if (data[0] == true) {
                        bootbox.alert(data[1], function () {
                            username.focus();
                        });
                        return false;
                    }
                    else {

                        if (nombre.val().trim() == "") {
                            bootbox.alert("Debes de proporcionar el campo nombre", function () {
                                nombre.focus();
                            });
                            return false;
                        }


                        if (idFacultad.val().trim() == "") {
                            bootbox.alert("Debes de proporcionar el campo facultad", function () {
                                idFacultad.focus();
                            });
                            return false;
                        }

                        if (pass.val().trim() == "" || pass.val().length < 8) {
                            bootbox.alert("El campo contraseña no puede ir vacío o ser de menos de 8 caracteres", function () {
                                pass.focus();
                            });
                            return false;
                        }

                        $("#frmCrearCuenta").submit();
                    }
                }
        });
        return false;
    });


    $("#frmCambiarPassword").submit(function () {
        var actualPassword = $("#txtPass");
        var newPassword = $("#txtPassNew");
        var newPasswordConfirm = $("#txtPassNewConfirm");

        if (actualPassword.val().trim() == "") {
            bootbox.alert("Proporciona tu actual password", function () {
                actualPassword.focus();
            });
            return false;
        }

        if (newPassword.val().trim() == "" || newPassword.val().trim() != newPasswordConfirm.val().trim()) {
            bootbox.alert("Debes de colocar bien la contraseña y la confirmación", function () {
                newPassword.focus();
            });
            return false;
        }

        return true;
    });
});