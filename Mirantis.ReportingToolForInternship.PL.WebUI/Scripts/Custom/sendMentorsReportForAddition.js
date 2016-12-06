/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="constructors.js" />
/// <reference path="actionsAfterFail.js" />
/// <reference path="actionsAfterSuccessfullAdditionReport.js" />
/// <reference path="changeRulesValidation.js" />
/// <reference path="validationActivities.js" />
/// <reference path="validationMentorsActivities.js" />
/// <reference path="validationFuturePlans.js" />
/// <reference path="validationRecord.js" />
/// <reference path="constructReportBeforeSending.js" />
/// <reference path="disableInputs.js" />
/// <reference path="changeStatusLoadingIcon.js" />
/// <reference path="sendReport.js" />

$(document).ready(function () {
    var $submitButton = $("#SubmitButton"),
        $saveAsDraftButton = $("#SaveAsDraftButton"),
        $mentorsIdInput = $("#MentorsId"),
        $internsIdInput = $("#InternsId"),
        $typeInput = $("#TypeOccuring"),
        $dateInput = $("#Date"),
        ajaxSettingsSaveReport = {
            type: "POST",
            url: "/Report/SaveReportAsDraftAfterAddition",
            contentType: 'application/json; charset=utf-8',
            dataType: 'html',
            success: function (result) {
                hideLoadingIcon();
                alertAboutSuccessfullAddition(result);
            },
            error: function (result) {
                alertAboutFailedAddition(result);
            }
        },
        ajaxSettingsSubmitReport = {
            type: "POST",
            url: "/Report/SubmitReportAfterAddition",
            contentType: 'application/json; charset=utf-8',
            dataType: 'html',
            success: function (result) {
                hideLoadingIcon();
                alertAboutSuccessfullAddition(result);
            },
            error: function (result) {
                alertAboutFailedAddition(result);
            }
        }


    $submitButton.click(function () {
        sendReport(isModelValidate, ajaxSettingsSubmitReport);
    });

    $saveAsDraftButton.click(function () {
        sendReport(isModelValidate, ajaxSettingsSaveReport);
    });

    function isModelValidate() {
        var isValidForm = true;
        isValidForm = $mentorsIdInput.valid() && isValidForm;
        isValidForm = $internsIdInput.valid() && isValidForm;
        isValidForm = $typeInput.valid() && isValidForm;
        isValidForm = $dateInput.valid() && isValidForm;
        isValidForm = validationActivitiesFromMentorsReport() && isValidForm;
        isValidForm = validationFuturePlans() && isValidForm;
        return isValidForm;
    }
});