@Code
    ViewData("Title") = "dashboard"
    Layout = "~/Areas/admin/Views/Shared/_Layout.vbhtml"
End Code

<h2>dashboard</h2>

@code
    Dim myValue As String
    myValue = Request.Cookies("campusUserCookie")("userName")
End code

@myValue
