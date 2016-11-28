/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="clearInputs.js" />
/// <reference path="disableInputs.js" />

function successFunction(result) {
    lockAllFunctions();
    showMessageStatusReport(result);
    assignEventToAdderNewReport();
}

function assignEventToAdderNewReport() {
    $("#AddReport").click(function () {
        $("#MessageAboutStatusReport").slideToggle(1000);
        unlockAllFunctions();
        $(".future-plans .btn-remover:not(:last)").click();
        $(".activity .btn-remover:not(:last)").click();
        $(".btn-remover-activity:not(:last)").click();
        clearInputs();
    });

    $("#SearchReports").click(function () {
        window.location.replace("/Report/Search");
    });
}

function showMessageStatusReport(result) {
    $("#MessageAboutStatusReport").html(result)
        .hide()
        .slideToggle(1000);
}