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
                                        if (data[0] == true) {
                                            bootbox.alert("Ha ocurrido un problema tratando de conectarte mediante facebook");
                                        }
                                        else {
                                            if (data[1] == true) {
                                                location.href = '/usuario/fbWelcome/?user=' + encodeURI(data[4]) + '&urlTo=' + encodeURI(data[3]);
                                            }
                                            else {
                                                location.href = '/' + data[3];
                                            }
                                        }
                                        //console.log(data[1]);
                                    }
                            });

                            //console.log('Good to see you, Nombre: ' + response.name + ' Username: ' + response.username + ' Correo: ' + response.email);

                        });
                    } else {
                        bootbox.alert('Proporciona tus credenciales correctas para acceder mediante facebook');
                        //console.log('User cancelled login or did not fully authorize.');
                    }
                }, { scope: 'email' });

    });

}