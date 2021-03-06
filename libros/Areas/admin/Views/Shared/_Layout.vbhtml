﻿<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
    @Styles.Render("~/assets/css/bootstrap.css")
    @Styles.Render("~/assets/css/dataTables.css")
    @Styles.Render("~/assets/css/utils.css")
    @Scripts.Render("http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js")
    @Scripts.Render("~/assets/js/bootbox.js")
    @Scripts.Render("~/assets/js/bootstrap.min.js")
    @Scripts.Render("~/assets/js/bootswatch.js")
    @Scripts.Render("~/assets/js/subnav.js")
    @Scripts.Render("~/assets/js/less-1.3.0.min.js")
    @Scripts.Render("~/assets/js/general.js")
    @Scripts.Render("~/assets/js/jquery.dataTables.js")
</head>
<body>
    @Html.Partial("_menu")
    <div class = "container">
    @RenderBody()
    @RenderSection("scripts", False)
    @Html.Partial("_footer")
    </div>
</body>
</html>