/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="constructors.js" />
/// <reference path="actionsAfterSuccessfullAdditionReport.js" />
/// <reference path="changeRulesValidation.js" />
/// <reference path="validationActivities.js" />
/// <reference path="validationInternsActivities.js" />
/// <reference path="validationFuturePlans.js" />
/// <reference path="validationRecord.js" />
/// <reference path="constructReportBeforeSending.js" />
/// <reference path="disableInputs.js" />

$(document).ready(function () {
    var $submitButton = $("#SubmitButton"),
        $saveAsDraftButton = $("#SaveAsDraftButton"),
        $internNameInput = $("#InternName"),
        $typeInput = $("#TypeOccuring"),
        $dateInput = $("#Date");

    $submitButton.click(function () {
        lockAllFunctions();
        $("body").animate({ scrollTop: 0 }, "slow");
        if (isModelValidate()) {
            var reportVM = constructReportVM();
            $.ajax({
                type: "POST",
                url: "/Report/SubmitReportAfterAddition",
                data: JSON.stringify(reportVM),
                contentType: 'application/json; charset=utf-8',
                dataType: 'html',
                success: function (result) {
                    alertAboutSuccessfullAddition(result);
                }
            });
        } else {
            unlockAllFunctions();
        }
    });

    $saveAsDraftButton.click(function () {
        lockAllFunctions();
        $("body").animate({ scrollTop: 0 }, "slow");
        if (isModelValidate()) {
            var reportVM = constructReportVM();
            $.ajax({
                type: "POST",
                url: "/Report/AddReportAsDraftAfterAddition",
                data: JSON.stringify(reportVM),
                contentType: 'application/json; charset=utf-8',
                dataType: 'html',
                success: function (result) {
                    alertAboutSuccessfullAddition(result);
                }
            })
        } else {
            unlockAllFunctions();
        }
    });

    function isModelValidate() {
        var isValidForm = true;
        isValidForm = $internNameInput.valid() && isValidForm;
        isValidForm = $typeInput.valid() && isValidForm;
        isValidForm = $dateInput.valid() && isValidForm;
        isValidForm = validationActivitiesFromInternsReport() && isValidForm;
        isValidForm = validationFuturePlans() && isValidForm;
        return isValidForm;
    }
});