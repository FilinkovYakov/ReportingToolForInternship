/// <reference path="disableInputs.js" />
/// <reference path="changeStatusLoadingIcon.js" />

function beginSearch() {
    lockAllFunctions();
    showLoadingIcon();
    if ($("#OutputReports").text().trim() != "") {
        $("#OutputReports").slideToggle(1000);
    }
}

function completeSearch() {
    unlockAllFunctions();
    hideLoadingIcon();
}