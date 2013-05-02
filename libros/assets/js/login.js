$(document).ready(function () {
    $("#aClose").click(function () {
        $("#lblError").fadeOut(650);
    });
});

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/es_LA/all.js#xfbml=1&appId=339399766162079";
    fjs.parentNode.insertBefore(js, fjs);
} (document, 'script', 'facebook-jssdk'));

window.fbAsyncInit = function () {

    $("#fbLogin").click(function () {

        FB.login(function (response) {
            if (response.authResponse) {
                FB.api('/me?fields=name,email,username', function (response) {
                    $.ajax({
                        type: "POST",
                        dataType: "json",
                        contentType: "application/x-www-form-urlencoded;charset=ISO-8859-1",
                        url: "/usuario/handleFBLogin",
                        data: "correo=" + response.email + "&fbacc=" + response.username + "&nombre=" + response.name,
                        success:
                                    function (data) {
                                        if (data[2] == 'usrblk') {
                                            bootbox.alert('Tu cuenta parece estar suspendida, si crees que esto es un error contacta a un administrador');
                                            return;
                                        }
                                        if (data[0] == true) {
                                            bootbox.alert("Ha ocurrido un problema tratando de conectarte mediante facebook");
                                        }
                                        else {
                                            if (data[1] == true) {
                                                location.href = '/usuario/fbWelcome/?pass=' + encodeURI(data[5]) + '&urlTo=' + encodeURI(data[3]);
                                            }
                                            else {
                                                location.href = '/' + data[3];
                                            }
                                        }
                                    }
                    });
                });
            } else {
                bootbox.alert('Proporciona tus credenciales correctas para acceder mediante facebook');
            }
        }, { scope: 'email' });
    });
}