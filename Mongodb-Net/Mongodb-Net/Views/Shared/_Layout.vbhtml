﻿<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>Mongodb.Net</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    @Html.Partial("Header")

    @RenderBody()

    @Scripts.Render("~/bundles/jquery")
    @RenderSection("scripts", required:=False)
</body>
</html>
