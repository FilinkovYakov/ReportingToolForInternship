/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="disableInputs.js" />
/// <reference path="changeStatusLoadingIcon.js" />
/// <reference path="constructors.js" />

function sendReport(functionOfValidationModel, ajaxSettings) {
    lockAllFunctions();
    $("body").animate({ scrollTop: 0 }, "slow");
    if (functionOfValidationModel()) {
        showLoadingIcon();
        var reportVM = constructReportVM();
        ajaxSettings.data = JSON.stringify(reportVM);
        $.ajax(ajaxSettings);
    } else {
        unlockAllFunctions();
    }
}