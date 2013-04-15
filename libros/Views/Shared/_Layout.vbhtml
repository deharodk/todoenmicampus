<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
    <link href="http://fonts.googleapis.com/css?family=Sintony:400,700|Rambla" rel="stylesheet" type="text/css" />
    @Styles.Render("~/assets/css/bootstrap.css")
    @Styles.Render("~/assets/css/main.css")
    @Styles.Render("~/assets/css/dataTables.css")
    @Styles.Render("~/assets/css/utils.css")
    @Styles.Render("~/assets/css/bootstrap-wysihtml5.css")
    @Scripts.Render("http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js")
    @Scripts.Render("~/assets/js/bootbox.js")
    @Scripts.Render("~/assets/js/bootstrap.min.js")
    @Scripts.Render("~/assets/js/bootswatch.js")
    @Scripts.Render("~/assets/js/subnav.js")
    @Scripts.Render("~/assets/js/general.js")
    @Scripts.Render("~/assets/js/less-1.3.0.min.js")
    @Scripts.Render("~/assets/js/jquery.dataTables.js")
    @Scripts.Render("~/assets/js/analytics.js")
    @Scripts.Render("~/assets/js/wysihtml5-0.3.0.js")
    @Scripts.Render("~/assets/js/bootstrap-wysihtml5.js")
    @Scripts.Render("~/assets/js/chosen.jquery.js")
    @Styles.Render("~/assets/css/chosen.css")
</head>
<body>
    @Html.Partial("_menu")
    <div class = "container" id="main-page">
    @RenderBody()
    @RenderSection("scripts", False)
    @Html.Partial("_footer")
    </div>
</body>
</html>