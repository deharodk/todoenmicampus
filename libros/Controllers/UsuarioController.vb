Imports System.Data.Entity
Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports System.Web.Script.Serialization
Imports System.Net
Imports System.Net.Mail

Namespace libros
    Public Class UsuarioController
        Inherits System.Web.Mvc.Controller

        Private db As New libros_db

        '
        ' GET: /Usuario/

        Function Index() As ActionResult

            Return View("login")
        End Function

        '
        ' GET: /Usuario/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim contacto As Contacto = db.Contactoes.Find(id)
            Dim idUsuario As Integer = 0
            Try
                idUsuario = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
            Catch ex As Exception
                idUsuario = 0
            End Try

            If IsNothing(contacto) Then
                Return HttpNotFound()
            Else
                If contacto.estatus = False Then
                    Return HttpNotFound()
                End If
                If idUsuario = 0 Then
                    TempData("toViewProfile") = True
                    TempData("userToSee") = id
                    Return RedirectToAction("Login", "Usuario")
                End If
            End If

            Return View(contacto)
        End Function

        '
        'GET /Usuario/ForgotPassword
        Function ForgotPassword() As ActionResult
            Return View()
        End Function

        '
        ' GET: /Usuario/Create

        Function Create() As ActionResult
            ViewBag.idFacultad = New SelectList(db.Facultad.Where(Function(a) a.estatus = True), "idFacultad", "nombreCorto")
            Return View()
        End Function

        '
        ' POST: /Usuario/Create

        <HttpPost()> _
        Function Create(ByVal contacto As Contacto) As ActionResult
            If ModelState.IsValid Then
                Dim byteInput As Byte() = Encoding.UTF8.GetBytes(contacto.pass)
                Dim hash As HashAlgorithm = New SHA512Managed()
                contacto.pass = Convert.ToBase64String(hash.ComputeHash(byteInput))
                contacto.estatus = True
                db.Contactoes.Add(contacto)
                db.SaveChanges()
                Dim userCookie As New HttpCookie("campusContactoCookie")
                userCookie("idContacto") = contacto.idContacto
                userCookie("email") = contacto.email.ToString()
                userCookie("nombre") = contacto.nombre.ToString()
                userCookie("idFacultad") = contacto.idFacultad
                userCookie("estatus") = contacto.estatus
                userCookie("conectado") = True
                userCookie.Expires = DateTime.Now.AddDays(1)
                HttpContext.Response.Cookies.Add(userCookie)
                Return RedirectToAction("Index", "Home")
            End If

            ViewBag.idFacultad = New SelectList(db.Facultad.Where(Function(a) a.estatus = True), "idFacultad", "nombreCorto", contacto.idFacultad)
            Return View(contacto)
        End Function

        '
        ' GET: /Usuario/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim contacto As Contacto = db.Contactoes.Find(id)
            Dim idContacto As Integer = 0
            Try
                idContacto = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
            Catch ex As NullReferenceException

            End Try
            If id <> idContacto Then
                Return RedirectToAction("Index", "Home")
            End If
            If IsNothing(contacto) Then
                Return HttpNotFound()
            End If
            ViewBag.idFacultad = New SelectList(db.Facultad.Where(Function(a) a.estatus = True), "idFacultad", "nombreCorto", contacto.idFacultad)
            Return View(contacto)
        End Function

        '
        ' POST: /Usuario/Edit/5

        <HttpPost()> _
        Function Edit(ByVal contacto As Contacto) As ActionResult

            If ModelState.IsValid Then
                db.Entry(contacto).State = EntityState.Modified
                db.SaveChanges()
                ViewBag.idFacultad = New SelectList(db.Facultad.Where(Function(a) a.estatus = True), "idFacultad", "nombreCorto", contacto.idFacultad)
                ViewBag.actualizado = True
                Return View("Edit", contacto)
            End If

            ViewBag.idFacultad = New SelectList(db.Facultad.Where(Function(a) a.estatus = True), "idFacultad", "nombreCorto", contacto.idFacultad)
            Return View(contacto)
        End Function

        '
        ' GET: /Usuario/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim contacto As Contacto = db.Contactoes.Find(id)
            If IsNothing(contacto) Then
                Return HttpNotFound()
            End If
            Return View(contacto)
        End Function

        '
        ' GET: /Usuario/Delete/5

        Function login() As ActionResult
            Dim idContacto As Integer = 0
            Session("toPublish") = TempData("toPublish")
            Session("toViewProfile") = TempData("toViewProfile")
            Session("userToSee") = TempData("userToSee")

            Try
                idContacto = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
            Catch ex As NullReferenceException

            End Try

            If idContacto <> 0 Then
                Return RedirectToAction("Index", "Home")
            End If

            Return View()
        End Function

        '
        'POST

        <HttpPost()> _
        Function doLogin() As ActionResult
            Dim username As String = Request.Params("txtUser")
            Dim pass As String = Request.Params("txtPass")

            If IsNothing(username) Then
                username = ""
            End If
            If IsNothing(pass) Then
                pass = ""
            End If
            Dim byteInput As Byte() = Encoding.UTF8.GetBytes(pass)
            Dim hash As HashAlgorithm = New SHA512Managed()
            pass = Convert.ToBase64String(hash.ComputeHash(byteInput))
            Dim exist = db.Database.SqlQuery(Of Contacto)("exec spLoginUsuario @correo, @pass", New SqlParameter("correo", username), New SqlParameter("pass", pass))
            Dim list As IEnumerable(Of Contacto) = exist.ToList()
            If list.Count() >= 1 Then
                Dim userCookie As New HttpCookie("campusContactoCookie")
                userCookie("idContacto") = list(0).idContacto
                userCookie("email") = list(0).email.ToString()
                userCookie("nombre") = list(0).nombre.ToString()
                userCookie("idFacultad") = list(0).idFacultad
                userCookie("estatus") = list(0).estatus
                userCookie("conectado") = True
                userCookie.Expires = DateTime.Now.AddDays(1)
                HttpContext.Response.Cookies.Add(userCookie)
                If list.FirstOrDefault().estatus = True Then
                    If Session("toPublish") = True And list.FirstOrDefault().suspendido = False Then
                        Session.Remove("toPublish")
                        Session.Remove("toViewProfile")
                        Session.Remove("userToSee")
                        Return (RedirectToAction("Create", "Anuncios"))
                    ElseIf Session("toViewProfile") = True And list.FirstOrDefault().suspendido = False Then
                        Dim usrToSee = Session("userToSee")
                        Session.Remove("toPublish")
                        Session.Remove("toViewProfile")
                        Session.Remove("userToSee")
                        Return (RedirectToAction("Details", "Usuario", New With {.id = usrToSee}))
                    End If
                    Session.Remove("toPublish")
                    Session.Remove("toViewProfile")
                    Session.Remove("userToSee")
                    Return (RedirectToAction("Index", "Home"))
                ElseIf list.FirstOrDefault().estatus = False And list.FirstOrDefault().suspendido = True Then
                    Dim usuario As New Contacto
                    usuario = db.Contactoes.Find(list.FirstOrDefault().idContacto)
                    usuario.suspendido = False
                    usuario.estatus = True
                    db.SaveChanges()
                    Session.Remove("toPublish")
                    Session.Remove("toViewProfile")
                    Session.Remove("userToSee")
                    Return (RedirectToAction("HasVuelto", "Home"))
                Else
                    ViewBag.logFails = True
                    Session.Remove("toPublish")
                    Session.Remove("toViewProfile")
                    Session.Remove("userToSee")
                    Return View("login")
                End If
            End If
            ViewBag.logFails = True
            Return View("login")
        End Function

        '
        ' POST /Usuario/handleFBLogin
        <HttpPost()> _
        Function handleFBLogin() As String
            Dim model As Collection = New Collection
            Dim serializer As New JavaScriptSerializer()
            Try
                Dim fbUserName As String = CStr(Request.Params("fbacc"))
                Dim correo As String = CStr(Request.Params("correo"))
                Dim nombre As String = CStr(Request.Params("nombre"))

                Dim pass = Replace(Guid.NewGuid().ToString(), "-", "").Substring(0, 15)
                Dim passToShow As String = pass.ToString()

                If IsNothing(fbUserName) Then fbUserName = ""
                If IsNothing(correo) Then correo = ""
                If IsNothing(nombre) Then nombre = ""

                Dim user = db.Contactoes.FirstOrDefault(Function(a) a.email = correo)

                If Not IsNothing(user) Then
                    If user.estatus = True Then
                        Dim userCookie As New HttpCookie("campusContactoCookie")
                        userCookie("idContacto") = user.idContacto
                        userCookie("email") = user.email.ToString()
                        userCookie("nombre") = user.nombre.ToString()
                        userCookie("idFacultad") = user.idFacultad
                        userCookie("estatus") = user.estatus
                        userCookie("conectado") = True
                        userCookie.Expires = DateTime.Now.AddDays(1)
                        HttpContext.Response.Cookies.Add(userCookie)

                        If Session("toPublish") = True And user.suspendido = False Then
                            model.Add(False, "error")
                            model.Add(False, "newacc")
                            model.Add("", "mensaje")
                            model.Add("Anuncios/Create", "redirect")

                        ElseIf Session("toViewProfile") = True And user.suspendido = False Then
                            model.Add(False, "error")
                            model.Add(False, "newacc")
                            model.Add("", "mensaje")
                            model.Add("Usuario/Details/" & CStr(Session("userToSee")), "redirect")

                        Else
                            model.Add(False, "error")
                            model.Add(False, "newacc")
                            model.Add("", "mensaje")
                            model.Add("Home/Index", "redirect")

                        End If

                    ElseIf user.estatus = False And user.suspendido = True Then
                        Dim usuario As New Contacto
                        usuario = db.Contactoes.Find(user.idContacto)
                        usuario.suspendido = False
                        usuario.estatus = True
                        db.SaveChanges()

                        Dim userCookie As New HttpCookie("campusContactoCookie")
                        userCookie("idContacto") = user.idContacto
                        userCookie("email") = user.email.ToString()
                        userCookie("nombre") = user.nombre.ToString()
                        userCookie("idFacultad") = user.idFacultad
                        userCookie("estatus") = user.estatus
                        userCookie("conectado") = True
                        userCookie.Expires = DateTime.Now.AddDays(1)
                        HttpContext.Response.Cookies.Add(userCookie)

                        model.Add(False, "error")
                        model.Add(False, "newacc")
                        model.Add("", "mensaje")
                        model.Add("Home/HasVuelto", "redirect")

                        Session.Remove("toPublish")
                        Session.Remove("toViewProfile")
                        Session.Remove("userToSee")
                    ElseIf user.estatus = False Then
                        'El usuario está inhabiltado
                        model.Add(False, "error")
                        model.Add(False, "newacc")
                        model.Add("usrblk", "mensaje")
                    End If
                Else
                    ' Le creamos una cuenta normal, en base a lo que trajo FB

                    Dim byteInput As Byte() = Encoding.UTF8.GetBytes(pass)
                    Dim hash As HashAlgorithm = New SHA512Managed()
                    pass = Convert.ToBase64String(hash.ComputeHash(byteInput))

                    Dim contacto As New Contacto

                    contacto.cuentaFB = fbUserName
                    contacto.nombre = nombre
                    contacto.email = correo
                    contacto.idFacultad = 7
                    contacto.suspendido = False
                    contacto.pass = Convert.ToBase64String(hash.ComputeHash(byteInput))
                    contacto.estatus = True

                    db.Contactoes.Add(contacto)
                    db.SaveChanges()

                    user = db.Contactoes.FirstOrDefault(Function(a) a.email = correo)

                    Dim userCookie As New HttpCookie("campusContactoCookie")
                    userCookie("idContacto") = contacto.idContacto
                    userCookie("email") = contacto.email.ToString()
                    userCookie("nombre") = contacto.nombre.ToString()
                    userCookie("idFacultad") = contacto.idFacultad
                    userCookie("estatus") = contacto.estatus
                    userCookie("conectado") = True
                    userCookie.Expires = DateTime.Now.AddDays(1)
                    HttpContext.Response.Cookies.Add(userCookie)

                    If Session("toPublish") = True And user.suspendido = False Then
                        model.Add(False, "error")
                        model.Add(True, "newacc")
                        model.Add("", "mensaje")
                        model.Add("Anuncios/Create", "redirect")
                        model.Add(correo, "username")
                        model.Add(passToShow, "pass")
                    ElseIf Session("toViewProfile") = True And user.suspendido = False Then
                        model.Add(False, "error")
                        model.Add(True, "newacc")
                        model.Add("", "mensaje")
                        model.Add("Usuario/Details/" & CStr(Session("userToSee")), "redirect")
                        model.Add(correo, "username")
                        model.Add(passToShow, "pass")
                    Else
                        model.Add(False, "error")
                        model.Add(True, "newacc")
                        model.Add("", "mensaje")
                        model.Add("Home/Index", "redirect")
                        model.Add(correo, "username")
                        model.Add(passToShow, "pass")
                    End If
                End If

            Catch ex As Exception
                model.Add(True, "error")
                model.Add(False, "newacc")
                model.Add(ex.Message.ToString() & "--- " & ex.StackTrace.ToString(), "mensaje")
                model.Add("", "redirect")
            End Try
            Session.Remove("toPublish")
            Session.Remove("toViewProfile")
            Session.Remove("userToSee")
            Return (serializer.Serialize(model))
        End Function

        '
        ' GET
        Function fbWelcome(ByVal user As String) As ActionResult
            Dim password As String = Request.Params("pass")
            Dim urlTo As String = Request.Params("urlTo")

            ViewBag.pass = IIf(IsNothing(password), "", password)
            ViewBag.urlTo = IIf(IsNothing(urlTo), "", "/" & urlTo)

            Return View()
        End Function


        '
        ' POST: /Usuario/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim contacto As Contacto = db.Contactoes.Find(id)
            contacto.estatus = False
            contacto.suspendido = True
            db.SaveChanges()
            Dim aCookie As HttpCookie
            Dim cookieName As String
            Dim cookieTotal As Integer = Request.Cookies.Count - 1
            For i As Integer = 0 To cookieTotal
                cookieName = Request.Cookies(i).Name
                aCookie = New HttpCookie(cookieName)
                aCookie.Expires = DateTime.Now.AddDays(-1)
                Response.Cookies.Add(aCookie)
            Next

            Dim anunciosUsuario = (From a In db.Anuncios
                                    Where a.idContacto = id
                                    Select a).ToList()

            '  anunciosUsuario.ForEach(Function(a) a.estatus = False)

            For Each Anuncio In anunciosUsuario
                Anuncio.estatus = False
            Next

            db.SaveChanges()
            Return RedirectToAction("Borrado", "Home")
        End Function

        <HttpPost()>
        Public Sub logOut()
            Dim aCookie As HttpCookie
            Dim cookieName As String
            Dim cookieTotal As Integer = Request.Cookies.Count - 1
            For i As Integer = 0 To cookieTotal
                cookieName = Request.Cookies(i).Name
                aCookie = New HttpCookie(cookieName)
                aCookie.Expires = DateTime.Now.AddDays(-1)
                Response.Cookies.Add(aCookie)
            Next
        End Sub

        '
        'POST: /usuario/findByUsername

        <HttpGet()> _
        Function findByUserName() As String
            Dim model As Collection = New Collection
            Dim serializer As New JavaScriptSerializer()
            Try
                Response.ContentType = "application/json"
                Dim username As String = Request.Params("username")

                Dim exist = db.Database.SqlQuery(Of Contacto)("exec spExisteUsuario @correo", New SqlParameter("correo", username))
                If exist.Count() >= 1 Then
                    'model = {"error" = "true", "mensaje" = "Un administrador con ese username ya existe"}
                    model.Add(True, "error")
                    model.Add("Un usuario con ese nombre de usuario ya existe, por favor selecciona otro, después inténtalo de nuevo", "mensaje")
                    Return (serializer.Serialize(model))
                End If
            Catch ex As Exception
                'model = {"error" = "true", "mensaje" = ex.Message.ToString()}
                model.Add(True, "error")
                model.Add(ex.Message.ToString(), "mensaje")
                Return (serializer.Serialize(model))
            End Try
            model.Add(False, "error")
            model.Add("", "mensaje")
            Return (serializer.Serialize(model))
        End Function

        '
        ' GET: /Usuario/editPassword/5

        Function EditPassword(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim contacto As Contacto = db.Contactoes.Find(id)
            Dim idContacto As Integer = 0
            Try
                idContacto = CInt(Request.Cookies("campusContactoCookie")("idContacto"))
            Catch ex As NullReferenceException

            End Try
            If id <> idContacto Then
                Return RedirectToAction("Index", "Home")
            End If
            If IsNothing(contacto) Then
                Return HttpNotFound()
            End If
            ViewBag.idFacultad = contacto.idFacultad
            Return View(contacto)
        End Function

        <HttpPost()> _
        Function EditPassword(ByVal contacto As Contacto) As ActionResult
            Dim actualPassword As String = ""
            Dim userName As String = ""
            Try
                userName = CStr(Request.Cookies("campusContactoCookie")("email"))
                actualPassword = CStr(Request.Params("txtActualPassword"))
            Catch ex As NullReferenceException

            End Try
            Dim byteInput As Byte() = Encoding.UTF8.GetBytes(actualPassword)
            Dim hash As HashAlgorithm = New SHA512Managed()
            actualPassword = Convert.ToBase64String(hash.ComputeHash(byteInput))
            Dim exist = db.Database.SqlQuery(Of Contacto)("exec spLoginUsuario @correo, @pass", New SqlParameter("correo", userName), New SqlParameter("pass", actualPassword))
            Dim list As IEnumerable(Of Contacto) = exist.ToList()
            If list.Count() >= 1 Then
                If ModelState.IsValid Then
                    db.Entry(contacto).State = EntityState.Modified
                    Dim byteInput_ As Byte() = Encoding.UTF8.GetBytes(contacto.pass)
                    Dim hash_ As HashAlgorithm = New SHA512Managed()
                    contacto.pass = Convert.ToBase64String(hash_.ComputeHash(byteInput_))
                    db.SaveChanges()
                    ViewBag.idFacultad = contacto.idFacultad
                    ViewBag.actualizado = True
                    Return View("EditPassword")
                End If
            Else
                ViewBag.passNotMatch = True
                Return View("EditPassword")
            End If
            ViewBag.idFacultad = contacto.idFacultad
            Return View(contacto)
        End Function

        <HttpPost()> _
        Function passRecover() As ActionResult
            Dim userName As String
            userName = Request.Params("txtUser")


            Dim usuario = db.Database.SqlQuery(Of Contacto)("exec spEncontrarUsuario @correo", New SqlParameter("correo", userName)).FirstOrDefault()

            If IsNothing(usuario) Then
                ViewBag.userNotExists = True
                Return View("ForgotPassword")
            End If

            Dim idUsuario As Integer = usuario.idContacto
            Dim passwordUser As String = usuario.pass
            Dim mailBody As String = emailRecuperarPassword().Replace("remplazaesto", ConfigurationManager.AppSettings("urlRP").ToString() & idUsuario & "&key=" & passwordUser)
            Dim email As String = ConfigurationManager.AppSettings("mailUsr")
            Dim password As String = ConfigurationManager.AppSettings("mailPwd")
            Dim loginInfo As New NetworkCredential(email, password)
            Dim msg = New MailMessage()
            Dim smtpClient = New SmtpClient(ConfigurationManager.AppSettings("smtpServer").ToString(), CInt(ConfigurationManager.AppSettings("smtpPosrt")))

            msg.From = New MailAddress(email, ConfigurationManager.AppSettings("displayUsr"))
            msg.To.Add(New MailAddress(userName))
            msg.Subject = "Recuperación de contraseña - todo en mi campus"
            msg.Body = mailBody.ToString()
            msg.IsBodyHtml = True

            'smtpClient.EnableSsl = True
            smtpClient.UseDefaultCredentials = False
            smtpClient.Credentials = loginInfo
            smtpClient.Send(msg)

            Return RedirectToAction("EmailRecuperacionEnviado", "Home")
        End Function

        Function emailRecuperarPassword() As String
            Dim myClient As New WebClient()
            Dim myPageHTML As String = Nothing
            Dim requestHTML As Byte()
            Dim currentPageUrl As String = ""
            Dim utf8 As New UTF8Encoding()
            requestHTML = myClient.DownloadData(ConfigurationManager.AppSettings("tmpMailRP").ToString())
            myPageHTML = utf8.GetString(requestHTML)
            Return (myPageHTML)
        End Function

        '
        'GET: /Usuario/ProcesoRecuperacion?id=1&key=v2t4wfHG==

        Function ProcesoRecuperacion() As ActionResult
            Return View()
        End Function

        '
        'GET /Usuario/QuieroVolver

        Function QuieroVolver() As ActionResult
            Return View()
        End Function

        '
        'POST /Usuario/QuieroVolver
        <HttpPost()> _
        Function QuieroVolverMail() As ActionResult
            Dim quiereVolver As String = ""
            quiereVolver = Request.Params("txtUser")

            If IsNothing(quiereVolver) Then
                quiereVolver = ""
            End If

            Dim mailBody As String = "El usuario: " & ""
            Dim email As String = "deharodk@gmail.com"
            Dim password As String = "afi999ladk93"
            Dim loginInfo As New NetworkCredential(email, password)
            Dim msg = New MailMessage()
            Dim smtpClient = New SmtpClient("smtp.gmail.com", 587)

            msg.From = New MailAddress(email)
            msg.To.Add(New MailAddress(email))
            msg.Subject = "Prueba"
            msg.Body = mailBody.ToString()
            msg.IsBodyHtml = True

            smtpClient.EnableSsl = True
            smtpClient.UseDefaultCredentials = False
            smtpClient.Credentials = loginInfo
            smtpClient.Send(msg)

            Return RedirectToAction("CorreoRecuperacionEnviado", "Home")
        End Function

        '
        'POST: /Usuario/passRecoverChange()
        <HttpPost()> _
        Function passRecoverChange() As ActionResult
            Dim id As Integer
            Dim key As String
            Dim newPass As String
            If Not IsNumeric(Request.Params("id")) Then
                ViewBag.logFails = True
                Return View("ProcesoRecuperacion")
            Else
                id = CInt(Request.Params("id"))
            End If

            If Not IsNothing(Request.Params("key")) Then
                key = Server.UrlDecode(Request.Params("key")).Replace(" ", "+")
            Else
                key = ""
            End If

            newPass = Request.Params("txtPass")

            Dim usuario As Contacto = db.Contactoes.Find(id)

            If IsNothing(usuario) Then
                ViewBag.logFails = True
                Return View("ProcesoRecuperacion")
            End If
            If usuario.pass <> key Then
                ViewBag.logFails = True
                Return View("ProcesoRecuperacion")
            End If

            Dim byteInput As Byte() = Encoding.UTF8.GetBytes(newPass)
            Dim hash As HashAlgorithm = New SHA512Managed()
            newPass = Convert.ToBase64String(hash.ComputeHash(byteInput))
            usuario.pass = newPass
            db.SaveChanges()
            ViewBag.logFails = False


            Return RedirectToAction("PasswordRecuperado", "Home")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub

    End Class
End Namespace