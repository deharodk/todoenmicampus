Imports System.Data.Entity
Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports System.Web.Script.Serialization

Namespace libros.Areas.admin
    Public Class AdministradorController
        Inherits System.Web.Mvc.Controller

        Private db As New libros_db

        '
        ' GET: /admin/Administrador/

        Function Index() As ActionResult
            Dim admin = db.Database.SqlQuery(Of Administrador)("exec spListAdmin")
            Return View(admin.ToList())
        End Function

        '
        ' GET: /admin/Administrador/Details/5

        Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
            Dim administrador As Administrador = db.Administrador.Find(id)
            If IsNothing(administrador) Then
                Return HttpNotFound()
            End If
            Return View(administrador)
        End Function

        '
        ' GET: /admin/Administrador/Create

        Function Create() As ActionResult
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
                userCookie.Expires = DateTime.Now.AddHours(1.5)
                HttpContext.Response.Cookies.Add(userCookie)
                Return (RedirectToAction("dashboard"))
            End If
            ViewBag.logFails = True
            Return View("login")
        End Function
        Function dashboard() As ActionResult

            Return View()
        End Function
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            db.Dispose()
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace