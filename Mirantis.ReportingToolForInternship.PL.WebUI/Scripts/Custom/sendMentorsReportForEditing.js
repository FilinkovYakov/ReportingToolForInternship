/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="constructors.js" />
/// <reference path="actionsAfterSuccessfullAdditionReport.js" />
/// <reference path="changeRulesValidation.js" />
/// <reference path="validationActivities.js" />
/// <reference path="validationMentorsActivities.js" />
/// <reference path="validationFuturePlans.js" />
/// <reference path="validationRecord.js" />
/// <reference path="constructReportBeforeSending.js" />

$(document).ready(function () {
    var $submitButton = $("#SubmitButton"),
        $saveAsDraftButton = $("#SaveAsDraftButton"),
        $mentorNameInput = $("#MentorName"),
        $internNameInput = $("#InternName"),
        $typeInput = $("#TypeOccuring"),
        $dateInput = $("#Date");

    $saveAsDraftButton.click(function () {
        if (isModelValidate()) {
            var reportVM = constructReportVM();
            $.ajax({
                type: "POST",
                url: "/Report/SaveReportAsDraftAfterEditing",
                data: JSON.stringify(reportVM),
                contentType: 'application/json; charset=utf-8',
                dataType: 'html',
                success: function (result) {
                    alertAboutSuccessfullEditing(result);
                }
            });
        }
    });

    $submitButton.click(function () {
        if (isModelValidate()) {
            var reportVM = constructReportVM();
            $.ajax({
                type: "POST",
                url: "/Report/SubmitReportAfterEditing",
                data: JSON.stringify(reportVM),
                contentType: 'application/json; charset=utf-8',
                dataType: 'html',
                success: function (result) {
                    alertAboutSuccessfullEditing(result);
                }
            })
        }
    });

    function isModelValidate() {
        var isValidForm = true;
        isValidForm = $mentorNameInput.valid() && isValidForm;
        isValidForm = $internNameInput.valid() && isValidForm;
        isValidForm = $typeInput.valid() && isValidForm;
        isValidForm = $dateInput.valid() && isValidForm;
        isValidForm = validationActivitiesFromMentorsReport() && isValidForm;
        isValidForm = validationFuturePlans() && isValidForm;

        return isValidForm;
    }
});