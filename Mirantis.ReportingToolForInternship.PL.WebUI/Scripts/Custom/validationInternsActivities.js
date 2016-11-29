/// <reference path="validationActivities.js" />

function validationActivitiesFromInternsReport() {
    return validationAllActivities() && validationEachActivityFromInternsReport();
}

function validationEachActivityFromInternsReport() {
    $("span[data-valmsg-for='Activity']").removeClass("field-validation-error")
                                         .addClass("field-validation-valid")
                                         .text("");

    var isValid = true;
    $(".input-activity").each(function () {
        isValid = validationActivityFromInternsReport($(this)) && isValid;
    });

    return isValid;
}

function validationActivityFromInternsReport(inputActivity) {
    var $activity = $(inputActivity).closest(".activity"),
        countNotEmptyQuestions = 0,
        valueActivity = $(inputActivity).val();

    $activity.find(".input-question").each(function () {
        var question = $(this).val();
        if (question != "") {
            countNotEmptyQuestions++;
        }
    });

    if (valueActivity == "" && countNotEmptyQuestions > 0) {
        $activity.find("span[data-valmsg-for='Activity']")
                 .removeClass("field-validation-valid")
                 .addClass("field-validation-error")
                 .text("Enter value of activity or remove questions that belong to it");

        return false;
    }

    return true;
}