/// <reference path="../jquery-1.10.2.min.js" />

function alertAboutSuccessfullChange(result) {
    showMessageStatusReport(result);
    assignEventToSearchReportsButton();
}

function assignEventToSearchReportsButton() {
    $("#SearchReports").click(function () {
        window.location.replace("/Report/Search");
    });
}

function showMessageStatusReport(result) {
    $("#MessageAboutSuccessOperation").html(result)
        .hide()
        .slideToggle(1000);
}