/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="clearInputs.js" />
/// <reference path="disableInputs.js" />

function alertAboutSuccessfullAddition(result) {
    showMessageStatusReport(result);
    assignEventToAdderNewReportButton();
    assignEventToSearchReportsButton();
}

function assignEventToAdderNewReportButton() {
    $("#AddReport").click(function () {
        $("#MessageAboutStatusReport").slideToggle(1000);
        unlockAllFunctions();
        $(".future-plans .btn-remover:not(:last)").click();
        $(".activity .btn-remover:not(:last)").click();
        $(".btn-remover-activity:not(:last)").click();
        clearInputs();

        $(".date").datepicker("setDate", new Date());
    });
}

function assignEventToSearchReportsButton() {
    $("#SearchReports").click(function () {
        window.location.replace("/Report/Search");
    });
}

function showMessageStatusReport(result) {
    $("#MessageAboutStatusReport").html(result)
        .hide()
        .slideToggle(1000);
}