function logout() {
    $.ajax({
        type: "POST",
        contentType: "application/x-www-form-urlencoded;charset=ISO-8859-1",
        url: "/admin/administrador/logOut",
        data: "",
        success:
                function () {
                    location.href = "/admin/administrador/login";
                }
    });
}