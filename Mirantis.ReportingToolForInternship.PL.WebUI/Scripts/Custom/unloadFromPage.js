/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="constructors.js" />
/// <reference path="constructReportBeforeSending.js" />

var isInputChanged = false;

$("a").click(function (event) {
    if (IsHideMessageAboutSuccessOperation() && isInputChanged) {
        event.preventDefault();
        var targetLink = event.target.href;
        $("#MessageAboutUpload").modal("show");
        $("#ConfirmRedirect").click(function () {
            window.location.href = targetLink;
        })
    }
});

$("input").change(function () {
    isInputChanged = true;
});

function IsHideMessageAboutSuccessOperation() {
    var innerHtml = $("#MessageAboutSuccessOperation").html().trim();
    return innerHtml == "";
}