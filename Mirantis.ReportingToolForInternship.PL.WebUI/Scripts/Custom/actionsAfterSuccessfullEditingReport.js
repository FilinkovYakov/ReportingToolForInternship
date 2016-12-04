/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="clearInputs.js" />
/// <reference path="disableInputs.js" />

function alertAboutSuccessfullEditing(result) {
    showMessageStatusReport(result);
    assignEventToReworkReportButton();
    assignEventToSearchReportsButton();
}

function assignEventToReworkReportButton() {
    $("#ReworkReport").click(function () {
        //$("#MessageAboutSuccessOperation").slideToggle(1000);
        unlockAllFunctions();
        location.reload();
    });
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