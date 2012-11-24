Imports System.Data.Entity
Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports System.Web.Script.Serialization

Namespace libros.Areas.admin
    Public Class AdministradorController
        Inherits System.Web.Mvc.Controller
        'Inherits BaseController

        Private db As New libros_db

        '
        ' GET: /admin/Administrador/

        Function Index() As ActionResult
            If isAdminLoggedIn() = False Then Return RedirectToAction("login")
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard")
            Dim admin = db.Database.SqlQuery(Of Administrador)("exec spListAdmin")
            Return View(admin.ToList())
        End Function

        '
        ' GET: /admin/Administrador/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            If isAdminLoggedIn() = False Then Return RedirectToAction("login")
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard")
            Dim administrador As Administrador = db.Administrador.Find(id)
            If IsNothing(administrador) Then
                Return HttpNotFound()
            End If
            Return View(administrador)
        End Function

        '
        ' GET: /admin/Administrador/Create

        Function Create() As ActionResult
            If isAdminLoggedIn() = False Then Return RedirectToAction("login")
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard")
            Return View()
        End Function

        '
        'POST: /admin/Administrator/findByUsername

        <HttpGet()> _
        Function findByUserName() As String
            Dim model As Collection = New Collection
            Dim serializer As New JavaScriptSerializer()
            Try
                Response.ContentType = "application/json"
                Dim username As String = Request.Params("username")

                Dim exist = db.Database.SqlQuery(Of Administrador)("exec spExisteAdmin @correo", New SqlParameter("correo", username))
                If exist.Count() >= 1 Then
                    'model = {"error" = "true", "mensaje" = "Un administrador con ese username ya existe"}
                    model.Add(True, "error")
                    model.Add("Un administrador con ese username ya existe", "mensaje")
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
        ' POST: /admin/Administrador/Create

        <HttpPost()> _
        Function Create(ByVal administrador As Administrador) As ActionResult
            If ModelState.IsValid Then
                Dim byteInput As Byte() = Encoding.UTF8.GetBytes(administrador.pass)
                Dim hash As HashAlgorithm = New SHA512Managed()
                administrador.pass = Convert.ToBase64String(hash.ComputeHash(byteInput))
                administrador.superUsuario = False
                db.Administrador.Add(administrador)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(administrador)
        End Function

        '
        ' GET: /admin/Administrador/Edit/5

        Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
            If isAdminLoggedIn() = False Then Return RedirectToAction("login")
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard")
            Dim administrador As Administrador = db.Administrador.Find(id)
            If IsNothing(administrador) Then
                Return HttpNotFound()
            End If
            Return View(administrador)
        End Function

        '
        ' POST: /admin/Administrador/Edit/5

        <HttpPost()> _
        Function Edit(ByVal administrador As Administrador) As ActionResult
            If ModelState.IsValid Then
                db.Entry(administrador).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(administrador)
        End Function

        '
        ' GET: /admin/Administrador/Delete/5

        Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
            If isAdminLoggedIn() = False Then Return RedirectToAction("login")
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard")
            Dim administrador As Administrador = db.Administrador.Find(id)
            If IsNothing(administrador) Then
                Return HttpNotFound()
            End If
            Return View(administrador)
        End Function

        '
        ' POST: /admin/Administrador/Delete/5

        <HttpPost()> _
        <ActionName("Delete")> _
        Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
            Dim administrador As Administrador = db.Administrador.Find(id)
            db.Administrador.Remove(administrador)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function
        '
        ' GET: /admin/Administrador/editPassword/5

        Function editPassword(Optional ByVal id As Integer = Nothing) As ActionResult
            If isAdminLoggedIn() = False Then Return RedirectToAction("login")
            If Not isAdminSuperAdmin() Then Return RedirectToAction("dashboard")
            Dim administrador As Administrador = db.Administrador.Find(id)
            If IsNothing(administrador) Then
                Return HttpNotFound()
            End If
            Return View(administrador)
        End Function

        '
        ' POST: /admin/Administrador/Edit/5

        <HttpPost()> _
        Function editPassword(ByVal administrador As Administrador) As ActionResult
            If ModelState.IsValid Then
                db.Entry(administrador).State = EntityState.Modified
                Dim byteInput As Byte() = Encoding.UTF8.GetBytes(administrador.pass)
                Dim hash As HashAlgorithm = New SHA512Managed()
                administrador.pass = Convert.ToBase64String(hash.ComputeHash(byteInput))
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(administrador)
        End Function
        Function login() As ActionResult
            Return View()
        End Function
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
            Dim exist = db.Database.SqlQuery(Of Administrador)("exec spLoginAdmin @correo, @pass", New SqlParameter("correo", username), New SqlParameter("pass", pass))
            Dim list As IEnumerable(Of Administrador) = exist.ToList()
            If list.Count() >= 1 Then
                Dim userCookie As New HttpCookie("campusUserCookie")
                userCookie("idAdministrador") = list(0).idAdministrador
                userCookie("userName") = list(0).email.ToString()
                userCookie("nombre") = list(0).nombre.ToString()
                userCookie("superPermisos") = list(0).superUsuario()
                userCookie("estatus") = list(0).estatus
                userCookie("conectado") = True
                userCookie.Expires = DateTime.MaxValue
                HttpContext.Response.Cookies.Add(userCookie)
                Return (RedirectToAction("dashboard"))
            End If
            ViewBag.logFails = True
            Return View("login")
        End Function
        Function dashboard() As ActionResult
            If Not isAdminLoggedIn() Then Return RedirectToAction("login")
            'Anuncios
            Dim totalAnuncios As Integer
            Dim totalAnunciosActivos As Integer
            Dim totalAnunciosInactivos As Integer
            Dim totalAnunciosHoy As Integer
            Dim totalAnunciosMes As Integer

            totalAnuncios = db.Anuncios.Count()
            totalAnunciosActivos = db.Anuncios.Count(Function(a) a.estatus = True)
            totalAnunciosInactivos = db.Anuncios.Count(Function(a) a.estatus = False)
            totalAnunciosHoy = db.Anuncios.Count(Function(a) a.fechaCreacion.Month = Now.Month And a.fechaCreacion.Day = Now.Day And a.fechaCreacion.Year = Now.Year)
            totalAnunciosMes = db.Anuncios.Count(Function(a) a.fechaCreacion.Month = Now.Month)

            'Usuarios
            Dim totalUsuarios As Integer
            Dim totalUsuariosActivos As Integer
            Dim totalUsuariosInactivos As Integer
  
            totalUsuarios = db.Contactoes.Count()
            totalUsuariosActivos = db.Contactoes.Count(Function(a) a.estatus = True)
            totalUsuariosInactivos = db.Contactoes.Count(Function(a) a.estatus = False)

            Dim superPermisos As Boolean = False
            Try
                superPermisos = CBool(Request.Cookies("campusUserCookie")("superPermisos"))
            Catch ex As Exception

            End Try

            'Administradores
            Dim totalAdministradores As Integer
            Dim totalAdministradoresActivos As Integer
            Dim totalAdministradoresInactivos As Integer

            totalAdministradores = db.Administrador.Count()
            totalAdministradoresActivos = db.Administrador.Count(Function(a) a.estatus = True)
            totalAdministradoresInactivos = db.Administrador.Count(Function(a) a.estatus = False)

            'VIEW BAG

            'Anuncios
            ViewBag.totalAnuncios = totalAnuncios
            ViewBag.totalAnunciosActivos = totalAnunciosActivos
            ViewBag.totalAnunciosInactivos = totalAnunciosInactivos
            ViewBag.totalAnunciosHoy = totalAnunciosHoy
            ViewBag.totalAnunciosMes = totalAnunciosMes

            'Usuarios
            ViewBag.totalUsuarios = totalUsuarios
            ViewBag.totalUsuariosActivos = totalUsuariosActivos
            ViewBag.totalUsuariosInactivos = totalUsuariosInactivos

            'Administradores
            ViewBag.totalAdministradores = totalAdministradores
            ViewBag.totalAdministradoresActivos = totalAdministradoresActivos
            ViewBag.totalAdministradoresInactivos = totalAdministradoresInactivos

            ViewBag.superPermisos = superPermisos

            Return View()
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
        Private Function isAdminLoggedIn() As Boolean
            If Request.Cookies("campusUserCookie") Is Nothing Then
                Return False
            End If
            Return True
        End Function
        Private Function isAdminSuperAdmin() As Boolean
            Dim superPermisos As Integer
            If Not Request.Cookies("campusUserCookie") Is Nothing Then
                superPermisos = CBool(Request.Cookies("campusUserCookie")("superPermisos"))
                If superPermisos = False Then
                    Return False
                End If
            End If
            Return True
        End Function
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace