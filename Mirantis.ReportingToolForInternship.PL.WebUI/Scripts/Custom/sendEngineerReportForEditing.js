/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="../jquery.validate.min.js" />
/// <reference path="../jquery.validate.unobtrusive.min.js" />

/// <reference path="clearInputs.js" />
/// <reference path="disableInputs.js" />
/// <reference path="constructors.js" />
/// <reference path="actionsAfterFail.js" />
/// <reference path="actionsAfterSuccessfullChangeReport.js" />
/// <reference path="changeRulesValidation.js" />
/// <reference path="validationActivities.js" />
/// <reference path="validationEngineerActivities.js" />
/// <reference path="validationFuturePlans.js" />
/// <reference path="validationRecord.js" />
/// <reference path="constructReportBeforeSending.js" />
/// <reference path="changeStatusLoadingIcon.js" />
/// <reference path="sendReport.js" />

$(document).ready(function () {
    var $submitButton = $("#SubmitButton"),
        $saveAsDraftButton = $("#SaveAsDraftButton"),
        $titleInput = $("#Title"),
        $typeInput = $("#TypeOccuring"),
        $dateInput = $("#Date"),
        ajaxSettingsSaveReport = {
            type: "POST",
            url: "/Report/SaveReportAsDraftAfterEditing",
            contentType: 'application/json; charset=utf-8',
            dataType: 'html',
            success: function (result) {
                hideLoadingIcon();
                alertAboutSuccessfullChange(result);
                assignEventToReworkReportButton();
            },
            error: function (result) {
                alertAboutFail(result);
            }
        },
        ajaxSettingsSubmitReport = {
            type: "POST",
            url: "/Report/SubmitReportAfterEditing",
            contentType: 'application/json; charset=utf-8',
            dataType: 'html',
            success: function (result) {
                hideLoadingIcon();
                alertAboutSuccessfullChange(result);
                assignEventToAdderNewReportButton();
            },
            error: function (result) {
                alertAboutFail(result);
            }
        };

    $submitButton.click(function () {
        sendReport(isModelValidate, ajaxSettingsSubmitReport);
    });

    $saveAsDraftButton.click(function () {
        sendReport(isModelValidate, ajaxSettingsSaveReport);
    });

    function isModelValidate() {
        var isValidForm = true;
        isValidForm = $titleInput.valid() && isValidForm;
        isValidForm = $typeInput.valid() && isValidForm;
        isValidForm = $dateInput.valid() && isValidForm;
		isValidForm = validationActivitiesFromEngineerReport() && isValidForm;
        isValidForm = validationFuturePlans() && isValidForm;
        return isValidForm;
    }

    function assignEventToAdderNewReportButton() {
        $("#AddReport").click(function () {
			window.location.replace("/Report/AddEngineerReport");
        });
    }

    function assignEventToReworkReportButton() {
        $("#ReworkReport").click(function () {
            unlockAllFunctions();
            location.reload();
        });
    }
});