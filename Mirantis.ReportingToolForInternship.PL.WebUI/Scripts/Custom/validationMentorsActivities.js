﻿/// <reference path="validationActivities.js" />
/// <reference path="validationRecord.js" />

function validationActivitiesFromMentorsReport() {
    return validationAllActivities() && validationEachActivityFromMentorsReport();
}

function validationEachActivityFromMentorsReport() {
    $("span[data-valmsg-for='Activity']").removeClass("field-validation-error")
                                         .addClass("field-validation-valid")
                                         .text("");

    var isValid = true;
    $(".input-activity").each(function () {
        isValid = validationActivityFromMentorsReport($(this)) && isValid;
    });

    return isValid;
}

function validationActivityFromMentorsReport(inputActivity) {
    var $activity = $(inputActivity).closest(".activity"),
        counterCorrectEvaluations = 0,
        activitysDescription = $(inputActivity).val();

    $activity.find(".input-evaluation").each(function () {
        var evaluation = $(this).val();
        if (validationRecord(evaluation)) {
            counterCorrectEvaluations++;
        }
    });

    if (!validationRecord(activitysDescription) && counterCorrectEvaluations > 0) {
        $activity.find("span[data-valmsg-for='Activity']")
                 .removeClass("field-validation-valid")
                 .addClass("field-validation-error")
                 .text("Enter value of activity or remove evaluation that belong to it");
        
        return false;
    }

    return true;
}