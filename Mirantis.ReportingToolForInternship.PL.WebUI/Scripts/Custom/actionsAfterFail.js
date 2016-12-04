/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="disableInputs.js" />

function alertAboutFail(result) {
    showMessageStatusReport(result);
}

function assignEventToHideMessageButton() {
    $("#HideMessage").click(function () {
        $(this).parent().parent().parent().slideToggle(1000);
        unlockAllFunctions();
    });
}

function showMessageStatusReport(result) {
    $("#MessageAboutSuccessOperation").html(result)
        .hide()
        .slideToggle(1000);
}