$(document).ready(function () {
    $("#btnSubmit").click(function () {
        var nombre = $("#txtNombre");
        var email = $("#txtMail");
        var pass = $("#txtPass");
        var mailRegEx = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        var username = email.val().trim();
        if (!mailRegEx.test(email.val().trim()) || email.val().trim() == "") {
            bootbox.alert("El valor del campo correo ingresado es incorrecto", function () {
                email.focus();
            });
            return false;
        }

        $.ajax({
            type: "GET",
            contentType: "application/x-www-form-urlencoded;charset=ISO-8859-1",
            url: "/admin/administrador/findByUsername",
            data: "username=" + username,
            success:
                function (data) {
                    if (data[0] == true) {
                        bootbox.alert(data[1]);
                        return false;
                    }
                    else {
                        if (pass.val().trim() == "" || pass.val().length < 8) {
                            bootbox.alert("El campo contraseña no puede ir vacío o ser de menos de 8 caracteres", function () {
                                pass.focus();
                            });
                            return false;
                        }
                        if (nombre.val().trim() == "") {
                            bootbox.alert("El campo nombre es obligatorio", function () {
                                nombre.focus();
                            });
                            return false;
                        }
                        $("#frmAdministradorCreate").submit();
                    }
                }
        });
        return false;
    });


    $("#frmAdministradorEdit").submit(function () {
        var nombre = $("#txtNombre");
        var email = $("#txtMail");
        var pass = $("#txtPass");
        var mailRegEx = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;

        if (!mailRegEx.test(email.val().trim()) || email.val().trim() == "") {
            bootbox.alert("El valor del campo correo ingresado es incorrecto", function () {
                email.focus();
            });
            return false;
        }

        if (pass.val().trim() == "" || pass.val().length < 8) {
            bootbox.alert("El campo contraseña no puede ir vacío o ser de menos de 8 caracteres", function () {
                pass.focus();
            });
            return false;
        }

        if (nombre.val().trim() == "") {
            bootbox.alert("El campo nombre es obligatorio", function () {
                nombre.focus();
            });
            return false;
        }
    });

    $("#frmAdministradorPass").submit(function () {
        var pass = $("#txtPass");
        var passConfirm = $("#txtPassConfirm");

        if (pass.val().trim() == "" || pass.val().trim().length < 8) {
            bootbox.alert("El campo contraseña no puede ser vacío o de menos de 8 caracteres", function () {
                pass.focus();
            });
            return false;
        }

        if (pass.val().trim() != passConfirm.val().trim()) {
            bootbox.alert("El campo contraseña debe ser igual al de nueva contraseña", function () {
                pass.focus();
            });
            return false;
        }
    });
});