﻿$(document).ready(function () {
    jQuery.validator.methods["date"] = function (value, element) { return true; } 
});